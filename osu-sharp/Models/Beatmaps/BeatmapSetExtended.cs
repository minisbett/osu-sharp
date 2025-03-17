using Newtonsoft.Json;

namespace osu_sharp.Models.Beatmaps;

/// <summary>
/// Represents an extended beatmapset, inheriting from <see cref="Beatmapset"/> and including additional properties.
/// The API differentiates between "normal" beatmapsets and "extended" beatmapsets, as not all information is available on all endpoints.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapsetextended"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-extended-json.ts"/>
/// </summary>
public class BeatmapSetExtended : BeatmapSet
{
  #region Default Attributes

  /// <summary>
  /// The beats per minute (BPM) of this beatmapset.
  /// </summary>
  [JsonProperty("bpm")]
  public float BPM { get; private set; }

  /// <summary>
  /// Bool whether this beatmapset can be hyped.
  /// </summary>
  [JsonProperty("can_be_hyped")]
  public bool CanBeHyped { get; private set; }

  /// <summary>
  /// The datetime at which this beatmapset was deleted. This will be null if the beatmapset has not been deleted.
  /// </summary>
  [JsonProperty("deleted_at")]
  public DateTimeOffset? DeletedAt { get; private set; }

  /// <summary>
  /// Bool whether discussion on this beatmapset is locked.
  /// </summary>
  [JsonProperty("discussion_locked")]
  public bool IsDiscussionLocked { get; private set; }

  /// <summary>
  /// Bool whether scores on this beatmapset are persistent (beatmapset is ranked, qualified, approved or loved).
  /// </summary>
  [JsonProperty("is_scoreable")]
  public bool IsScoreable { get; private set; }

  /// <summary>
  /// The datetime at which this beatmapset was last updated.
  /// </summary>
  [JsonProperty("last_updated")]
  public DateTimeOffset LastUpdated { get; private set; }

  /// <summary>
  /// The URL to the legency thread of this beatmapset. This will be null if the beatmapset has no legacy thread.
  /// </summary>
  [JsonProperty("legacy_thread_url")]
  public string? LegacyThreadUrl { get; private set; }

  /// <summary>
  /// Info about the nomination progress of this beatmapset.
  /// </summary>
  [JsonProperty("nominations_summary")]
  public NominationSummary NominationSummary { get; private set; } = default!;

  /// <summary>
  /// The datetime at which this beatmapset was ranked, qualified, approved or loved. This will be null if the beatmapset has none of these statuses.
  /// </summary>
  [JsonProperty("ranked_date")]
  public DateTimeOffset? RankedDate { get; private set; }

  /// <summary>
  /// Bool whether this beatmapset has a storyboard.
  /// </summary>
  [JsonProperty("storyboard")]
  public bool HasStoryboard { get; private set; }

  /// <summary>
  /// The datetime at which this beatmapset was submitted to the osu! servers. This may be null.
  /// </summary>
  [JsonProperty("submitted_date")]
  public DateTimeOffset? SubmittedDate { get; private set; }

  /// <summary>
  /// The tags of this beatmapset, used for indexing and searching.
  /// </summary>
  [JsonProperty("tags")]
  public string Tags { get; private set; } = null!;

  #endregion

  #region Optional Attributes

  private BeatmapExtended[]? _beatmaps;

  /// <summary>
  /// The beatmaps belonging to this beatmapset. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("beatmaps")]
  public new BeatmapExtended[]? Beatmaps
  {
    get => _beatmaps;
    private set
    {
      _beatmaps = value;
      base.Beatmaps = value;
    }
  }

  #endregion
}