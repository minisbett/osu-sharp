using Newtonsoft.Json;

namespace OsuSharp.Models.Users;

/// <summary>
/// Represents a tournament banner on a user's profile.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#user-profilebanner"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/profile-banner.ts"/>
/// </summary>
public class ProfileBanner
{
  /// <summary>
  /// The Id of the banner.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The Id of the tournament this banner is for.
  /// </summary>
  public int TournamentId { get; private set; }

  /// <summary>
  /// The URL for the image of this banner.
  /// </summary>
  [JsonProperty("image")]
  public string Image { get; private set; } = default!;

  /// <summary>
  /// The URL for the high resolution image of this banner.
  /// </summary>
  [JsonProperty("image@2x")]
  public string Image2X { get; private set; } = default!;
}
