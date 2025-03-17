using Newtonsoft.Json;

namespace osu_sharp.Models.Responses;

/// <summary>
/// Represents the response from an access token request via <see cref="Authorization.OsuClientAccessTokenProvider"/>.
/// </summary>
internal class OsuAccessTokenResponse
{
  /// <summary>
  /// The access token. If null, an error likely occured.
  /// </summary>
  [JsonProperty("access_token")]
  public string? Token { get; private set; }

  /// <summary>
  /// The amount of seconds in which the access token will expire. If null, an error likely occured.
  /// </summary>
  [JsonProperty("expires_in")]
  public int? ExpiresIn { get; private set; }

  /// <summary>
  /// The description of the authorization error. If null, no error occurred.
  /// </summary>
  [JsonProperty("error_description")]
  public string? ErrorDescription { get; private set; }
}
