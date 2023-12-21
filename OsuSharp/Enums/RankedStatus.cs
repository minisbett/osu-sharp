using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the rank statuses a beatmap can have.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapset-rank-status"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-json.ts"/>
/// </summary>
public enum RankedStatus
{
  /// <summary>
  /// The beatmap is in the graveyard.
  /// </summary>
  Graveyard = -2,

  /// <summary>
  /// The beatmap is a work in progress.
  /// </summary>
  WIP = -1,

  /// <summary>
  /// The beatmap is pending a rank status evaluation.
  /// </summary>
  [Description("Pending")]
  Pending = 0,

  /// <summary>
  /// The beatmap is ranked.
  /// </summary>
  Ranked = 1,

  /// <summary>
  /// The beatmap is approved.
  /// </summary>
  Approved = 2,

  /// <summary>
  /// The beatmap is qualified.
  /// </summary>
  Qualified = 3,

  /// <summary>
  /// The beatmap is loved.
  /// </summary>
  Loved = 4
}
