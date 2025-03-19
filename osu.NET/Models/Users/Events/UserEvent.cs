using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Users.Events;

/// <summary>
/// Represents the base class for any user event (the "Recent" section on osu! profiles).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class UserEvent
{
  /// <summary>
  /// The datetime at which this event happened.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTime CreatedAt { get; private set; }

  /// <summary>
  /// The ID of this event.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The type of this event.
  /// </summary>
  [JsonProperty("type")]
  public UserEventType Type { get; private set; }
}
