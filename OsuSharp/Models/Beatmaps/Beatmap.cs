using Newtonsoft.Json;
using OsuSharp.Converters;
using OsuSharp.Enums;
using OsuSharp.Models.Users;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents a beatmap.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmap"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmap-json.ts"/>
/// </summary>
public class Beatmap
{
  #region Default Attributes

  /// <summary>
  /// The ID of the beatmapset this beatmap belongs to.
  /// </summary>
  [JsonProperty("beatmapset_id")]
  public int SetId { get; private set; }

  /// <summary>
  /// The difficulty rating of this beatmap.
  /// </summary>
  [JsonProperty("difficulty_rating")]
  public float DifficultyRating { get; private set; }

  /// <summary>
  /// The ID of this beatmap.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The ruleset this beatmap was made for.
  /// </summary>
  [JsonProperty("mode")]
  [JsonConverter(typeof(StringEnumConverter))]
  public Ruleset Ruleset { get; private set; }

  /// <summary>
  /// The ranked status of this beatmap.
  /// </summary>
  [JsonProperty("status")]
  public RankedStatus Status { get; private set; }

  /// <summary>
  /// The total length of this beatmap.
  /// </summary>
  [JsonProperty("total_length")]
  [JsonConverter(typeof(TimeSpanConverter))]
  public TimeSpan TotalLength { get; private set; }

  /// <summary>
  /// The user ID of the creator of this beatmap.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; private set; }

  /// <summary>
  /// The difficulty name of this beatmap.
  /// </summary>
  [JsonProperty("version")]
  public string Version { get; private set; } = default!;

  #endregion

  #region Available Attributes

  /// <summary>
  /// The beatmapset this beatmap belongs to. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("beatmapset")]
  public BeatmapSet? Set { get; internal set; }

  /// <summary>
  /// The MD5 checksum of the .osu file representing this beatmap. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("checksum")]
  public string? Checksum { get; private set; }

  /// <summary>
  /// The amount of times players have exited of failed the beatmap at a certain percentage. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("failtimes")]
  public Failtimes? Failtimes { get; private set; }

  /// <summary>
  /// The maximum achievable combo on this beatmap. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("max_combo")]
  public int? MaxCombo { get; private set; }

  /// <summary>
  /// The creator of this beatmap. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("creator")]
  public User? Creator { get; private set; }

  #endregion
}
