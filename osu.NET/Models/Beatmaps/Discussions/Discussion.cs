using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Beatmaps.Discussions;

/// <summary>
/// Represents a discussion on a beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapsetdiscussion"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-discussion-json.ts"/>
/// </summary>
public class Discussion
{
  #region Default Attributes

  /// <summary>
  /// The ID of the beatmap targetted by this discussion. This will be null if the discussion is not targetted at a specific beatmap.
  /// </summary>
  [JsonProperty("beatmap_id")]
  public int? BeatmapId { get; private set; }

  /// <summary>
  /// The ID of the beatmapset this discussion belongs to.
  /// </summary>
  [JsonProperty("beatmapset_id")]
  public int BeatmapSetId { get; private set; }

  /// <summary>
  /// Bool whether the discussion can be resolved.
  /// </summary>
  [JsonProperty("can_be_resolved")]
  public bool CanBeResolved { get; private set; }

  /// <summary>
  /// Bool whether this discussion can grant kudosu to the author.
  /// </summary>
  [JsonProperty("can_grant_kudosu")]
  public bool CanGrantKudosu { get; private set; }

  /// <summary>
  /// The datetime at which this discussion was created.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTimeOffset CreatedAt { get; private set; }

  /// <summary>
  /// The datetime at which this discussion was deleted. This will be null if the discussion has not been deleted.
  /// </summary>
  [JsonProperty("deleted_at")]
  public DateTimeOffset? DeletedAt { get; private set; }

  /// <summary>
  /// The ID of the user that deleted this dicussion. This will be null if the discussion has not been deleted.
  /// </summary>
  [JsonProperty("deleted_by_id")]
  public int? DeletedById { get; private set; }

  /// <summary>
  /// The ID of this discussion.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// Bool whether the author has been denied from receiving kudosu for this discussion.
  /// </summary>
  [JsonProperty("kudosu_denied")]
  public bool IsKudosuDenied { get; private set; }

  /// <summary>
  /// The datetime at which the last post was made in this discussion. This may be null.
  /// </summary>
  [JsonProperty("last_post_at")]
  public DateTimeOffset? LastPostAt { get; private set; }

  /// <summary>
  /// The type of this discussion.
  /// </summary>
  [JsonProperty("message_type")]
  public DiscussionType Type { get; private set; }

  /// <summary>
  /// The ID of the parent review. This will be null if this discussion is not part of a review.<br/>
  /// A review is a bundle of discussions, with all bundled discussions having the same parent ID.
  /// </summary>
  [JsonProperty("parent_id")]
  public int? ParentReviewId { get; private set; }

  /// <summary>
  /// Bool whether this discussion is marked as resolved.
  /// </summary>
  [JsonProperty("resolved")]
  public bool IsResolved { get; private set; }

  /// <summary>
  /// The millisecond timestamp in the beatmap this discussion refers to. This will be null if the discussion is not targetting a timestamp.<br/>
  /// The timestamp automatically considered the first timestamp mentioned in the body of the discussion.
  /// </summary>
  [JsonProperty("timestamp")]
  public int? Timestamp { get; private set; }

  /// <summary>
  /// The datetime at which this discussion was last updated.
  /// </summary>
  [JsonProperty("updated_at")]
  public DateTimeOffset UpdatedAt { get; private set; }

  /// <summary>
  /// The ID of the author of this discussion.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; private set; }

  #endregion

  #region Optional Attributes

  /// <summary>
  /// The beatmap this discussion is targetted at. This is an optional property and will be null if the discussion is not targetted at a specific beatmap.
  /// </summary>
  [JsonProperty("beatmap")]
  public Beatmap? Beatmap { get; private set; }

  /// <summary>
  /// The beatmapset this discussion is targetted at. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("beatmapset")]
  public BeatmapSet? BeatmapSet { get; private set; }

  /// <summary>
  /// The posts made in this discussion. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("posts")]
  public DiscussionPost[]? Posts { get; private set; }

  /// <summary>
  /// The starting post of this discussion. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("starting_post")]
  public DiscussionPost? StartingPost { get; private set; }

  /// <summary>
  /// The votes of this discussion. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("votes")]
  public DiscussionVotes? Votes { get; private set; }

  #endregion
}