using Newtonsoft.Json;

namespace osu.NET.Models.Scores;

/// <summary>
/// Represents the score statistics (hit judgements) of a score.<br/>
/// Judgements that represent hits (eg. Large Tick Hit, Small Bonus) default to <see langword="null"/> if they are not present in the score.<br/>
/// Judgements that represent misses or negative judgements (eg. Great, Miss, Large Tick Miss) default to 0 if they are not present in the score.
/// </summary>
public class ScoreStatistics
{
  // TODOFUT: not necessarily happy with the way these statistics are handled, especially regarding their default values
  //          this likely needs more thoughts into how this object would be used by people using the library

  /// <summary>
  /// The Perfect judgements of the score. This will be null if the score does not have any Perfect judgements.
  /// </summary>
  [JsonProperty("perfect")]
  public int Perfect { get; private set; } = 0;

  /// <summary>
  /// The Great judgements of the score. This will be 0 if the score does not have any Great judgements.
  /// </summary>
  [JsonProperty("great")]
  public int Great { get; private set; } = 0;

  /// <summary>
  /// The Good judgements of the score. This will be 0 if the score does not have any Good judgements.
  /// </summary>
  [JsonProperty("good")]
  public int Good { get; private set; } = 0;

  /// <summary>
  /// The Ok judgements of the score. This will be 0 if the score does not have any Ok judgements.
  /// </summary>
  [JsonProperty("ok")]
  public int Ok { get; private set; } = 0;

  /// <summary>
  /// The Meh judgements of the score. This will be 0 if the score does not have any Meh judgements.
  /// </summary>
  [JsonProperty("meh")]
  public int Meh { get; private set; } = 0;

  /// <summary>
  /// The Miss judgements of the score. This will be 0 if the score does not have any Miss judgements.
  /// </summary>
  [JsonProperty("miss")]
  public int Miss { get; private set; } = 0;

  /// <summary>
  /// The Large Tick Hit judgements of the score. This will be null if the score does not have any Large Tick Hit judgements.
  /// </summary>
  [JsonProperty("large_tick_hit")]
  public int? LargeTickHit { get; private set; }

  /// <summary>
  /// The Large Tick Miss judgements of the score. This will be 0 if the score does not have any Large Tick Miss judgements.
  /// </summary>
  [JsonProperty("large_tick_miss")]
  public int LargeTickMiss { get; private set; } = 0;

  /// <summary>
  /// The Large Bonus judgements of the score. This will be null if the score does not have any Large Bonus judgements.
  /// </summary>
  [JsonProperty("large_bonus")]
  public int? LargeBonus { get; private set; }

  /// <summary>
  /// The Small Tick Hit judgements of the score. This will be 0 if the score does not have any Small Tick Hit judgements.
  /// </summary>
  [JsonProperty("small_tick_hit")]
  public int SmallTickHit { get; private set; } = 0;

  /// <summary>
  /// The Small Tick Miss judgements of the score. This will be 0 if the score does not have any Small Tick Miss judgements.
  /// </summary>
  [JsonProperty("small_tick_miss")]
  public int SmallTickMiss { get; private set; } = 0;

  /// <summary>
  /// The Small Bonus judgements of the score. This will be null if the score does not have any Small Bonus judgements.
  /// </summary>
  [JsonProperty("small_bonus")]
  public int? SmallBonus { get; private set; }

  /// <summary>
  /// The Ignore Hit judgements of the score. This will be null if the score does not have any Ignore Hit judgements.
  /// </summary>
  [JsonProperty("ignore_hit")]
  public int? IgnoreHit { get; private set; }

  /// <summary>
  /// The Ignore Miss judgements of the score. This will be 0 if the score does not have any Ignore Miss judgements.
  /// </summary>
  [JsonProperty("ignore_miss")]
  public int IgnoreMiss { get; private set; } = 0;

  /// <summary>
  /// The Legacy Combo Increase judgements of the score. This will be null if the score does not have any Legacy Combo Increase judgements.
  /// </summary>
  [JsonProperty("legacy_combo_increase")]
  public int? LegacyComboIncrease { get; private set; }
}
