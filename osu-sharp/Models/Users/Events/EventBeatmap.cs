using Newtonsoft.Json;

namespace osu_sharp.Models.Users.Events;

/// <summary>
/// Represents the beatmap associated with a <see cref="UserEvent"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-beatmap"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class EventBeatmap
{
  /// <summary>
  /// The title of the beatmap.
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; private set; } = default!;

  /// <summary>
  /// The URL of the beatmap.
  /// </summary>
  [JsonProperty("url")]
  public string Url { get; private set; } = default!;
}
