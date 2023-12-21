using Newtonsoft.Json;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents the difficulty attributes of a beatmap.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapdifficultyattributes"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Libraries/BeatmapDifficultyAttributes.php"/>
/// </summary>
public class DifficultyAttributes
{
  /// <summary>
  /// The maximum combo of the beatmap.
  /// </summary>
  [JsonProperty("max_combo")]
  public int MaxCombo { get; private set; }

  /// <summary>
  /// The difficulty rating of the beatmap.
  /// </summary>
  [JsonProperty("difficulty_rating")]
  public float DifficultyRating { get; private set; }

  /// <summary>
  /// The aim difficulty rating of the beatmap. This property may be null as it is exclusive to osu!standard beatmaps.
  /// </summary>
  [JsonProperty("aim_difficulty")]
  public float? AimDifficulty { get; private set; }

  /// <summary>
  /// The approach rate (AR) of the beatmap. This property may be null as it is exclusive to osu!standard, osu!taiko and osu!catch beatmaps.
  /// </summary>
  [JsonProperty("approach_rate")]
  public float? AR { get; private set; }

  /// <summary>
  /// The flashlight difficulty rating of the beatmap. This property may be null as it is exclusive to osu!standard beatmaps.
  /// </summary>
  [JsonProperty("flashlight_difficulty")]
  public float? FlashlightDifficulty { get; private set; }

  /// <summary>
  /// The overall difficulty (OD) of the beatmap. This property may be null as it is exclusive to osu!standard beatmaps.
  /// </summary>
  [JsonProperty("overall_difficulty")]
  public float? OD { get; private set; }

  /// <summary>
  /// The slider factor of the beatmap. This property may be null as it is exclusive to osu!standard beatmaps.
  /// </summary>
  [JsonProperty("slider_factor")]
  public float? SliderFactor { get; private set; }

  /// <summary>
  /// The speed difficulty rating of the beatmap. This property may be null as it is exclusive to osu!standard beatmaps.
  /// </summary>
  [JsonProperty("speed_difficulty")]
  public float? SpeedDifficulty { get; private set; }

  /// <summary>
  /// The stamina difficulty rating of the beatmap. This property may be null as it is exclusive to osu!taiko beatmaps.
  /// </summary>
  [JsonProperty("stamina_difficulty")]
  public float? StaminaDifficulty { get; private set; }

  /// <summary>
  /// The rhythm difficulty rating of the beatmap. This property may be null as it is exclusive to osu!taiko beatmaps.
  /// </summary>
  [JsonProperty("rhythm_difficulty")]
  public float? RhythmDifficulty { get; private set; }

  /// <summary>
  /// The colour difficulty rating of the beatmap. This property may be null as it is exclusive to osu!taiko beatmaps.
  /// </summary>
  [JsonProperty("colour_difficulty")]
  public float? ColourDifficulty { get; private set; }

  /// <summary>
  /// The great hitwindow of the beatmap. This property may be null as it is exclusive to osu!taiko and osu!mania beatmaps.
  /// </summary>
  [JsonProperty("great_hit_window")]
  public float? GreatHitWindow { get; private set; }
}
