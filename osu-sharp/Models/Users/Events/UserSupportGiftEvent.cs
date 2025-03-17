using Newtonsoft.Json;

namespace osu_sharp.Models.Users.Events;

/// <summary>
/// Represents the event when a user is gifted a supporter tag by another user.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class UserSupportGiftEvent : UserEvent
{
  /// <summary>
  /// The user who was gifted the supporter tag.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; private set; } = default!;
}
