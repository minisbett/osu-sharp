using Newtonsoft.Json;
using osu_sharp.Enums;

namespace osu_sharp.Models.Users.Events;

/// <summary>
/// Represents the event when a user achieves a certain rank on a beatmap.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class RankEvent : UserEvent
{
  /// <summary>
  /// The rank achieved by the user.
  /// </summary>
  [JsonProperty("rank")]
  public int Rank { get; private set; }

  /// <summary>
  /// The grade achieved by the user.
  /// </summary>
  [JsonProperty("scoreRank")]
  public Grade ScoreRank { get; private set; } = default!;

  /// <summary>
  /// The ruleset this event takes place in.
  /// </summary>
  [JsonProperty("mode")]
  public Ruleset Ruleset { get; private set; } = default!;

  /// <summary>
  /// The beatmap associated with this event.
  /// </summary>
  [JsonProperty("beatmap")]
  public EventBeatmap Beatmap { get; private set; } = default!;

  /// <summary>
  /// The user associated with this event.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; private set; } = default!;
}
