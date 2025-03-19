using osu.NET.Helpers;

namespace osu.NET.Enums;

/// <summary>
/// An enum containing the rank statuses a beatmapset can have.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapset-rank-status"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-json.ts"/>
/// </summary>
public enum RankedStatus
{
  /// <summary>
  /// The beatmap is in the graveyard.
  /// </summary>
  [JsonAPIName("graveyard")]
  Graveyard = -2,

  /// <summary>
  /// The beatmap is a work in progress.
  /// </summary>
  [JsonAPIName("wip")]
  WIP = -1,

  /// <summary>
  /// The beatmap is pending a rank status evaluation.
  /// </summary>
  [JsonAPIName("pending")]
  Pending = 0,

  /// <summary>
  /// The beatmap is ranked.
  /// </summary>
  [JsonAPIName("ranked")]
  Ranked = 1,

  /// <summary>
  /// The beatmap is approved.
  /// </summary>
  [JsonAPIName("approved")]
  Approved = 2,

  /// <summary>
  /// The beatmap is qualified.
  /// </summary>
  [JsonAPIName("qualified")]
  Qualified = 3,

  /// <summary>
  /// The beatmap is loved.
  /// </summary>
  [JsonAPIName("loved")]
  Loved = 4
}
