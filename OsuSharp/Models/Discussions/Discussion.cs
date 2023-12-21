using Newtonsoft.Json;
using OsuSharp.Converters;
using OsuSharp.Enums;
using OsuSharp.Models.Beatmaps;

namespace OsuSharp.Models.Discussions;

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
  /// TODO: what is this
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
  /// TODO: what is this? user id of person that deleted?
  /// </summary>
  [JsonProperty("deleted_by_id")]
  public int? DeletedById { get; private set; }

  /// <summary>
  /// The ID of this discussion.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// TODO: what is this? the author cant get kudosu anymore? who can do this?
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
  [JsonConverter(typeof(StringEnumConverter))]
  public DiscussionType Type { get; private set; }

  /// <summary>
  /// TODO: What is this? Can discussions have parents? Isn't one whole tree of comments one singular discussion?
  /// </summary>
  [JsonProperty("parent_id")]
  public int? ParentId { get; private set; }

  /// <summary>
  /// Bool whether this discussion is marked as resolved.
  /// </summary>
  [JsonProperty("resolved")]
  public bool IsResolved { get; private set; }

  /// <summary>
  /// TODO: what is this?
  /// </summary>
  [JsonProperty("timestamp")]
  public DateTimeOffset? Timestamp { get; private set; }

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
  /// The beatmap this discussion is targetted at. This is an optional property and may be null.
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
