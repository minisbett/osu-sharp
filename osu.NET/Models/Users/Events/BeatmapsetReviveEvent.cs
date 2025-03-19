using Newtonsoft.Json;

namespace osu.NET.Models.Users.Events;

/// <summary>
/// Represents the event when a user updates a beatmapset in the graveyard.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class BeatmapsetReviveEvent : UserEvent
{
  /// <summary>
  /// The beatmapset that was revived.
  /// </summary>
  [JsonProperty("beatmapset")]
  public EventBeatmapset Beatmapset { get; private set; } = default!;

  /// <summary>
  /// The owner of the beatmapset.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; private set; } = default!;
}
