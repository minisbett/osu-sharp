using Newtonsoft.Json;

namespace osu_sharp.Models.Users.Events;

/// <summary>
/// Represents the event when a user deletes a beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class BeatmapsetDeleteEvent : UserEvent
{
  /// <summary>
  /// The beatmapset that was deleted.
  /// </summary>
  [JsonProperty("beatmapset")]
  public EventBeatmapset Beatmapset { get; private set; } = default!;
}
