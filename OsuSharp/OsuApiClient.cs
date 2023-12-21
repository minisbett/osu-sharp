using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OsuSharp.Converters;
using OsuSharp.Models;
using System.Net;
using System.Net.Http.Headers;

namespace OsuSharp;

/// <summary>
/// The API client used to interact with the osu! API v2.
/// </summary>
public partial class OsuApiClient
{
  /// <summary>
  /// The authorization body used to authenticate to the osu! API v2.
  /// </summary>
  private readonly Dictionary<string, string> _authorizationBody = new Dictionary<string, string>()
  {
    { "client_id", "" },
    { "client_secret", "" },
    { "grant_type", "client_credentials" },
    { "scope", "public" }
  };

  /// <summary>
  /// The HTTP client used to make requests to the osu! API v2.
  /// </summary>
  private readonly HttpClient _http = new HttpClient()
  {
    BaseAddress = new Uri("https://osu.ppy.sh/api/v2/")
  };

  /// <summary>
  /// The expiration date of the current access token stored in the Authorization header of the <see cref="_http"/> client.
  /// </summary>
  private DateTimeOffset _accessTokenExpirationDate = DateTimeOffset.MinValue;

  /// <summary>
  /// Creates a new instance of the <see cref="OsuApiClient"/> class with the specified client credentials.
  /// </summary>
  /// <param name="clientId">The client ID.</param>
  /// <param name="clientSecret">The client secret.</param>
  public OsuApiClient(int clientId, string clientSecret) : this(clientId.ToString(), clientSecret) { }

  /// <summary>
  /// Creates a new instance of the <see cref="OsuApiClient"/> class with the specified client credentials.
  /// </summary>
  /// <param name="clientId">The client ID.</param>
  /// <param name="clientSecret">The client secret.</param>
  public OsuApiClient(string clientId, string clientSecret)
  {
    _authorizationBody["client_id"] = clientId;
    _authorizationBody["client_secret"] = clientSecret;
  }

  /// <summary>
  /// Ensures that the current access token is valid, and if not, requests a new one.
  /// This method may be used to improve the performance of the first request, and is
  /// automatically being called by every method that requires an access token.
  /// </summary>
  public async Task EnsureAccessTokenAsync()
  {
    // If the current access token is valid, return.
    if (_accessTokenExpirationDate > DateTimeOffset.UtcNow)
      return;

    try
    {
      // Request a new access token and parses the JSON in the response into a response object.
      var response = await _http.PostAsync("https://osu.ppy.sh/oauth/token", new FormUrlEncodedContent(_authorizationBody));
      string json = await response.Content.ReadAsStringAsync();
      AccessTokenResponse? apResponse = JsonConvert.DeserializeObject<AccessTokenResponse>(json);

      // Validate the parsed JSON object.
      if (apResponse is null)
        throw new OsuApiException("An error occured while requesting a new access token. (response is null)");
      if (apResponse.AccessToken is null || apResponse.ExpiresIn is null) // Error fields are most likely specified
        throw new OsuApiException($"An error occured while requesting a new access token: {apResponse.ErrorDescription} ({apResponse.ErrorCode}).");

      // Set the access token in the Authorization header of the HTTP client and update the expiration date.
      _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apResponse.AccessToken);
      _accessTokenExpirationDate = DateTimeOffset.UtcNow.AddSeconds(apResponse.ExpiresIn.Value - 30 /* Leniency */);
    }
    catch (Exception ex) { throw new OsuApiException("An error occured while requesting a new access token.", ex); }
  }

  /// <summary>
  /// Sends a GET request to the specified URL and parses the JSON in the response into the specified type.
  /// </summary>
  /// <typeparam name="T">The type to parse the JSON in the response into.</typeparam>
  /// <param name="url">The request URL.</param>
  /// <param name="jsonSelector">Optional. A selector for the base JSON, allowing to parse a sub-property of the JSON object.</param>
  /// <returns></returns>
  private async Task<T?> GetFromJsonAsync<T>(string url, Dictionary<string, string?>? parameters = null, Func<JObject, JToken?>? jsonSelector = null, HttpMethod? method = null)
  {
    // Default to an empty dictionary if no parameters are specified.
    parameters ??= new Dictionary<string, string?>();

    // Ensure a valid access token.
    await EnsureAccessTokenAsync();

    try
    {
      // Send the request and validate the response. If 404 is returned, return null.
      HttpResponseMessage response = await _http.SendAsync(new HttpRequestMessage(method ?? HttpMethod.Get, $"{url}{BuildQueryString(parameters)}"));
      if (response.StatusCode == HttpStatusCode.NotFound)
        return default;

      // If a json selector is specified, parse the JSON in the response into a JObject and select the specified token.
      if (jsonSelector is not null)
      {
        // Parse the JSON, select the token and check whether the token was found. If not, return null.
        JObject obj = JObject.Parse(await response.Content.ReadAsStringAsync());
        JToken? o = jsonSelector(obj);
        if (o is null)
          return default;

        // Otherwise, try to parse the token into the specified type and return it.
        return o.ToObject<T>();
      }

      // Parse the JSON in the response into the specified type and return it.
      return JsonConvert.DeserializeObject<T?>(await response.Content.ReadAsStringAsync());
    }
    catch (Exception ex)
    {
      throw new OsuApiException($"An error occured while sending a GET request to {url} and parsing the response as `{typeof(T).Name}`.", ex);
    }
  }

  /// <summary>
  /// Creates an <see cref="IAsyncEnumerable{T}"/>, used to asynchronously enumerate over the specified endpoint with the specified parameters,
  /// using the cursor pagination system of the osu! API v2, making requests on the endpoint as necessary when enumerating over the return value.<br/>
  /// If a pagination request failed, an <see cref="OsuApiException"/> is thrown.
  /// </summary>
  /// <typeparam name="T">The type of objects returned from the endpoint.</typeparam>
  /// <param name="endpoint">The endpoint URL.</param>
  /// <param name="parameters">The query parameters for the requests.</param>
  /// <returns>An asynchronous enumerable to enumerate over the specified endpoint.</returns>
  public async IAsyncEnumerable<T> EnumerateAsync<T>(string endpoint, Dictionary<string, string?> parameters) where T : class
  {
    // Ensure a valid access token.
    await EnsureAccessTokenAsync();

    // Add the cursor to the query parameters.
    parameters.Add("cursor_string", null);

    do
    {
      // Send the request, parse the response JSON and validate the response.
      HttpResponseMessage response = await _http.GetAsync($"{endpoint}{BuildQueryString(parameters)}");
      CursorResponse<T>? cResponse = JsonConvert.DeserializeObject<CursorResponse<T>>(await response.Content.ReadAsStringAsync(), new CursorResponseConverter<T>());
      if (cResponse is null)
        throw new OsuApiException($"An error occurred while requesting the {typeof(T).Name.ToLower()} items. (cResponse is null)");

      // Yield return the data items.
      foreach (T item in cResponse.Data)
        yield return item;

      // Update the cursor for the next request.
      parameters["cursor_string"] = cResponse.Cursor;
    }
    while (parameters["cursor_string"] != null);
  }

  /// <summary>
  /// Constructs a query parameter string from the specified parameters, where all parameters with a null value are ignored.
  /// </summary>
  /// <param name="parameters">The parameters.</param>
  /// <returns>The query parameter string.</returns>
  private string BuildQueryString(Dictionary<string, string?> parameters)
  {
    // If no parameters are specified, return an empty string.
    if (parameters.Count == 0)
      return "";

    // Otherwise construct the query string, including the "?".
    return "?" + string.Join("&", parameters.Where(x => x.Value is not null).Select(x => $"{x.Key}={x.Value}"));
  }
}