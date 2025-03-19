using Newtonsoft.Json;

namespace osu.NET.Models.Beatmaps;

/// <summary>
/// Represents the difficulty attributes of a beatmap in a ruleset.
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
  [JsonProperty("star_rating")]
  public float DifficultyRating { get; private set; }

  #region osu!

  /// <summary>
  /// osu! ruleset only.
  /// </summary>
  [JsonProperty("aim_difficulty")]
  public double AimDifficulty { get; private set; }

  /// <summary>
  /// osu! ruleset only.
  /// </summary>
  [JsonProperty("aim_difficult_slider_count")]
  public double AimDifficultSliderCount { get; private set; }

  /// <summary>
  /// osu! ruleset only.
  /// </summary>
  [JsonProperty("speed_difficulty")]
  public double SpeedDifficulty { get; private set; }

  /// <summary>
  /// osu! ruleset only.
  /// </summary>
  [JsonProperty("speed_note_count")]
  public double SpeedNoteCount { get; private set; }

  /// <summary>
  /// osu! ruleset only.
  /// </summary>
  [JsonProperty("slider_factor")]
  public double SliderFactor { get; private set; }

  /// <summary>
  /// osu! ruleset only.
  /// </summary>
  [JsonProperty("aim_difficult_strain_count")]
  public double AimDifficultStrainCount { get; private set; }

  /// <summary>
  /// osu! ruleset only.
  /// </summary>
  [JsonProperty("speed_difficult_strain_count")]
  public double SpeedDifficultStrainCount { get; private set; }

  #endregion

  #region osu!taiko

  /// <summary>
  /// osu!taiko ruleset only.
  /// </summary>
  [JsonProperty("mono_stamina_factor")]
  public double MonoStaminaFactor { get; private set; }

  #endregion
}
