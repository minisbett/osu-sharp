using Newtonsoft.Json;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents a tournament banner on a users' profile.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#user-profilebanner"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/profile-banner.ts"/>
/// </summary>
public class ProfileBanner
{
  /// <summary>
  /// The ID of the banner.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The ID of the tournament this banner is for.
  /// </summary>
  [JsonProperty("tournament_id")]
  public int TournamentId { get; private set; }

  /// <summary>
  /// The URL for the image of this banner. This may be null.
  /// </summary>
  [JsonProperty("image")]
  public string? Image { get; private set; }

  /// <summary>
  /// The URL for the high resolution image of this banner. This may be null.
  /// </summary>
  [JsonProperty("image@2x")]
  public string? Image2X { get; private set; }
}