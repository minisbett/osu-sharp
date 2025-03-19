using Newtonsoft.Json;
using osu.NET.Models.Responses;

namespace osu.NET.Authorization;

/// <summary>
/// Provides an access token via client credential authorization.
/// </summary>
/// <param name="clientId">The ID of the API client.</param>
/// <param name="clientSecret">The secret of the API client.</param>
public class OsuClientAccessTokenProvider(string clientId, string clientSecret) : IOsuAccessTokenProvider
{
  private string _accessToken = null!;
  private DateTimeOffset _expirationDate = DateTimeOffset.MinValue;

  /// <inheritdoc/>
  public async Task<string> GetAccessTokenAsync(CancellationToken cancellationToken)
  {
    if (_expirationDate > DateTimeOffset.UtcNow)
      return _accessToken;

    HttpResponseMessage response;
    try
    {
      response = await new HttpClient().PostAsync("https://osu.ppy.sh/oauth/token", new FormUrlEncodedContent(new Dictionary<string, string>
      {
        ["grant_type"] = "client_credentials",
        ["client_id"] = clientId,
        ["client_secret"] = clientSecret,
        ["scope"] = "public"
      }), cancellationToken);
    }
    catch (Exception ex)
    {
      throw new AccessTokenRetrievalException("Failed to send the authorization request.", ex);
    }

    string json = await response.Content.ReadAsStringAsync(cancellationToken);

    OsuAccessTokenResponse accessToken;
    try
    {
      accessToken = JsonConvert.DeserializeObject<OsuAccessTokenResponse>(json) ?? throw new("The response is null.");
    }
    catch (Exception ex)
    {
      throw new AccessTokenRetrievalException("Failed to parse the access token response.", ex);
    }

    // If the response is not successful, there should be an error description indicating what went wrong.
    // Also handle the case where the access token or expiration date is null but the response was successful, which should not happen.
    if (!response.IsSuccessStatusCode)
      throw new AccessTokenRetrievalException($"{response.StatusCode}: {accessToken.ErrorDescription}");
    else if (accessToken.Token is null || accessToken.ExpiresIn is null)
      throw new AccessTokenRetrievalException("The access token or expiration date is null, but no error was reported.");

    _accessToken = accessToken.Token;
    _expirationDate = DateTimeOffset.UtcNow.AddSeconds(accessToken.ExpiresIn.Value);
    return _accessToken;
  }

  /// <summary>
  /// Creates an <see cref="OsuClientAccessTokenProvider"/> instance with client credentials from the specified environment variables.
  /// If the environment variable is null, a <see cref="NullReferenceException"/> is thrown.
  /// </summary>
  /// <param name="clientIdVariableName">The name of the environment variable containing the client ID.</param>
  /// <param name="clientSecretVariableName">The name of the environment variable containing the client secret.</param>
  /// <returns>The <see cref="OsuClientAccessTokenProvider"/> based on the specified environment variables.</returns>
  public static OsuClientAccessTokenProvider FromEnvironmentVariables(string clientIdVariableName, string clientSecretVariableName)
  {
    string clientId = Environment.GetEnvironmentVariable(clientIdVariableName)
      ?? throw new NullReferenceException("The client ID environment variable is null.");
    string clientSecret = Environment.GetEnvironmentVariable(clientSecretVariableName)
      ?? throw new NullReferenceException("The client secret environment variable is null");

    return new OsuClientAccessTokenProvider(clientId, clientSecret);
  }
}
