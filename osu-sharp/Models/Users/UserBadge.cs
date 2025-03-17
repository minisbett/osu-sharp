using Newtonsoft.Json;

namespace osu_sharp.Models.Users;

/// <summary>
/// Represents a badge on a user's profile.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#user-userbadge"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-badge-json.ts"/>
/// </summary>
public class UserBadge
{
  /// <summary>
  /// The datetime at which this badge was awarded to the user.
  /// </summary>
  [JsonProperty("awarded_at")]
  public DateTimeOffset AwardedAt { get; private set; }

  /// <summary>
  /// The description of this badge. (e.g. "osu! World Cup 2023 Winner (United States)")
  /// </summary>
  [JsonProperty("description")]
  public string Description { get; private set; } = default!;

  /// <summary>
  /// The URL to the high resolution image of this badge.
  /// </summary>
  [JsonProperty("image@2x_url")]
  public string Image2X { get; private set; } = default!;

  /// <summary>
  /// The URL to the image of this badge.
  /// </summary>
  [JsonProperty("image_url")]
  public string Image { get; private set; } = default!;

  /// <summary>
  /// The URL to the tournament (or other kind of topic) this badge is related to.
  /// </summary>
  [JsonProperty("url")]
  public string Url { get; private set; } = default!;
}
