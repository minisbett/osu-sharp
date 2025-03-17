using Newtonsoft.Json;

namespace osu_sharp.Models.Users.Events;

/// <summary>
/// Represents the event when a user obtained an achievement.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class AchievementEvent : UserEvent
{
  /// <summary>
  /// The achievement that was obtained.
  /// </summary>
  [JsonProperty("achievement")]
  public Achievement Achievement { get; private set; } = default!;

  /// <summary>
  /// The user who obtained the achievement.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; private set; } = default!;
}
