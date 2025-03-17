using Newtonsoft.Json;
using osu_sharp.Enums;

namespace osu_sharp.Models.Users.Events;

/// <summary>
/// Represents the event when a beatmap of a user changes the state to ranked, approved, qualified or loved.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class BeatmapsetApproveEvent : UserEvent
{
  /// <summary>
  /// The approval state of the beatmapset.
  /// </summary>
  [JsonProperty("approval")]
  public BeatmapsetEventApproval Approval { get; private set; } = default!;

  /// <summary>
  /// The beatmapset associated with this event.
  /// </summary>
  [JsonProperty("beatmapset")]
  public EventBeatmapset Beatmapset { get; private set; } = default!;

  /// <summary>
  /// The user who is the owner of this beatmapset.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; private set; } = default!;
}
