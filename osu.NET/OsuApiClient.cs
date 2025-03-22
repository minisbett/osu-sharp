using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using osu.NET.Authorization;
using osu.NET.Helpers;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Web;

namespace osu.NET;

/// <summary>
/// An API client for the osu! API v2.
/// </summary>
/// <param name="accessTokenProvider">The provider for access tokens on the osu! API v2.</param>
public partial class OsuApiClient(IOsuAccessTokenProvider accessTokenProvider, OsuApiClientOptions options, ILogger<OsuApiClient> logger)
{
  private static readonly JsonSerializer _jsonSerializer = OsuJsonSerializer.Create();

  private readonly HttpClient _http = new()
  {
    BaseAddress = new("https://osu.ppy.sh/api/v2/"),
    DefaultRequestHeaders =
    {
      { "x-api-version", "20220705" }
    },
    Timeout = options.RequestTimeout
  };

  /// <summary>
  /// Ensures the access token is set on the HTTP client.
  /// </summary>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  private async Task EnsureAccessTokenAsync(CancellationToken cancellationToken)
  {
    string token = await accessTokenProvider.GetAccessTokenAsync(cancellationToken);
    _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
  }

  /// <summary>
  /// Sends a GET request to the specified URL and parses the JSON in the response into the specified type.<br/>
  /// If the request fails, an <see cref="OsuApiException"/> is thrown.
  /// </summary>
  /// <typeparam name="T">The type to parse the JSON response into.</typeparam>
  /// <param name="url">The request URL.</param>
  /// <param name="cancellationToken">The cancellation token for aborting the request.</param>
  /// <param name="parameters">Optional. The query parameters of the URL. Parameters with a null value will be ignored.</param>
  /// <param name="jsonSelector">Optional. A JSON selector for parsing nested objects instead of the root JSON.</param>
  /// <param name="httpMethod">Optional. The HTTP method used for the request. Defaults to GET.</param>
  /// <param name="httpContent">The body content used for the request.</param>
  /// <returns>The parsed API result.</returns>
  private async Task<APIResult<T>> GetAsync<T>(string url, CancellationToken? cancellationToken, (string, object?)[]? parameters = null,
    Func<JObject, JToken?>? jsonSelector = null, HttpMethod? httpMethod = null, HttpContent? httpContent = null) where T : class
  {
    url = BuildRequestUrl(url, parameters ?? []);
    cancellationToken ??= CancellationToken.None;
    httpMethod ??= HttpMethod.Get;

    await EnsureAccessTokenAsync(cancellationToken.Value);

    Stopwatch watch = Stopwatch.StartNew();
    HttpResponseMessage? response = null;
    try
    {
      response = await _http.SendAsync(new(httpMethod, url) { Content = httpContent }, cancellationToken.Value);
    }
    catch (Exception ex)
    {
      if (options.EnableLogging)
        logger.LogError(ex, "Failed to send the API request.");

      throw new OsuApiException("Failed to send the API request.", ex);
    }
    finally
    {
      watch.Stop();
      if (options.EnableLogging)
        logger.LogInformation("URL: {Url}\r\nDuration: {Time:N0}ms\r\nStatus: {Status}", _http.BaseAddress + url,
          watch.ElapsedMilliseconds, response is null ? "Error" : $"{(int)response.StatusCode} ({response.StatusCode})");
    }

    // If the API does not respond with an OK (request successful) or NotFound/UnprocessableEntity (something not found),
    // the request is likely malformed or the osu! API encountered an internal server error. This ensures that any APIResult<T>
    // retrieved by the end user possibly contains an error caused via their own input, and not some API wrapper or osu!-sided issue.
    if (response.StatusCode is not (HttpStatusCode.OK or HttpStatusCode.NotFound or HttpStatusCode.UnprocessableEntity))
      throw new OsuApiException($"API responded with an unexpected status code: {response.StatusCode}.");

    try
    {
      string json = await response.Content.ReadAsStringAsync(cancellationToken.Value);
      JToken token = JToken.Parse(json);
      JObject? obj = token as JObject;

      // Check for an error attribute, indicating the API returned an error.
      // An error attribute may only exist if an object (not an array) was returned.
      var x = obj?["error"];
      if (obj?["error"] is JValue error)
        return APIError.FromMessage(error.Value<string>());
      else if (response.StatusCode is not HttpStatusCode.OK)
        return APIError.FromMessage(null);

      if (obj is not null && jsonSelector is not null)
        token = jsonSelector.Invoke(obj) ?? token;

      return token.ToObject<T?>(_jsonSerializer);
    }
    catch (Exception ex)
    {
      if (options.EnableLogging)
        logger.LogError(ex, "Failed to parse the API response into a {Type} object.", typeof(T));

      throw new OsuApiException($"Failed to parse the API response into a {typeof(T)} object.", ex);
    }
  }

  /// <summary>
  /// Returns the request URL based on the specified base URL and query parameters, excluding those parameters with a null value.
  /// </summary>
  /// <param name="url">The base request URL.</param>
  /// <param name="queryParameters">The query parameters.</param>
  /// <returns>The request URL.</returns>
  private static string BuildRequestUrl(string url, (string Key, object? Value)[] queryParameters)
  {
    url = $"{url.TrimEnd('/')}?";

    foreach ((string Key, object? Value) parameter in queryParameters.Where(x => x.Value is not null))
    {
      string value = parameter.Value switch
      {
        Enum e => e.GetQueryName(),       // Enum     -> APIQueryName attribute
        DateTime dt => dt.ToString("o"),  // DateTime -> ISO 8601
        bool b => b.ToString().ToLower(), // bool     -> lower-case
        _ => parameter.Value!.ToString()!
      };

      url += $"{HttpUtility.UrlEncode(parameter.Key)}={HttpUtility.UrlEncode(value)}&";
    }

    return url.TrimEnd('?').TrimEnd('&');
  }
}