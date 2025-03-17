using Newtonsoft.Json;

namespace osu_sharp.Models.Users.Events;

/// <summary>
/// Represents the event when a user supports osu! for the first time.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class UserSupportFirstEvent : UserEvent
{
  /// <summary>
  /// The user who supported osu! for the first time.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; private set; } = default!;
}
