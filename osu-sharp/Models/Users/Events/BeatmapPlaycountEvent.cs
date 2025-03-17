using Newtonsoft.Json;

namespace osu_sharp.Models.Users.Events;

/// <summary>
/// Represents the event when a user played a beatmap a certain number of times.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class BeatmapPlaycountEvent : UserEvent
{
  /// <summary>
  /// The beatmap associated with the event.
  /// </summary>
  [JsonProperty("beatmap")]
  public EventBeatmap Beatmap { get; private set; } = default!;

  /// <summary>
  /// The amount of times the beatmap has been played.
  /// </summary>
  [JsonProperty("count")]
  public int Count { get; private set; }
}
