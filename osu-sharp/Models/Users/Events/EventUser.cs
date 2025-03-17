using Newtonsoft.Json;

namespace osu_sharp.Models.Users.Events;

/// <summary>
/// Represents the user associated with a <see cref="UserEvent"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-user"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class EventUser
{
  /// <summary>
  /// The username of the user.
  /// </summary>
  [JsonProperty("username")]
  public string Username { get; private set; } = default!;

  /// <summary>
  /// The URL of the users' profile.
  /// </summary>
  [JsonProperty("url")]
  public string Url { get; private set; } = default!;

  /// <summary>
  /// The previous username of the user. This will be null if the related event is not a <see cref="UsernameChangeEvent"/>.
  /// </summary>
  [JsonProperty("previousUsername")]
  public string? PreviousUsername { get; private set; }
}
