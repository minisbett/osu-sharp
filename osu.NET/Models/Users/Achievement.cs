using Newtonsoft.Json;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents an achievement of a user.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-achievement-json.ts"/>
/// </summary>
public class Achievement
{
  /// <summary>
  /// The datetime at which this achievement was achieved.
  /// </summary>
  [JsonProperty("achieved_at")]
  public DateTimeOffset AchievedAt { get; private set; }

  /// <summary>
  /// The ID of this achievement.
  /// </summary>
  [JsonProperty("achievement_id")]
  public int Id { get; private set; }
}
