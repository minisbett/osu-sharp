using Newtonsoft.Json;

namespace osu_sharp.Models.Users.Events;

/// <summary>
/// Represents the beatmapset associated with a <see cref="UserEvent"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-beatmapset"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class EventBeatmapset
{
  /// <summary>
  /// The title of the beatmapset.
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; private set; } = default!;

  /// <summary>
  /// The URL of the beatmapset.
  /// </summary>
  [JsonProperty("url")]
  public string Url { get; private set; } = default!;
}
