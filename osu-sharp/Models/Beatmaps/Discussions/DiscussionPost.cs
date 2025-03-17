using Newtonsoft.Json;

namespace osu_sharp.Models.Beatmaps.Discussions;

/// <summary>
/// Represents the base class for a post in a discussion on a beatmapset.<br/>
/// A discussion post can contain either a user message or a system message (<see cref="UserDiscussionPost"/> or <see cref="SystemDiscussionPost"/>).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapsetdiscussionpost"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-discussion-post-json.ts"/>
/// </summary>
public class DiscussionPost
{
  #region Default Attributes

  /// <summary>
  /// The ID of the discussion this post belongs to.
  /// </summary>
  [JsonProperty("beatmapset_discussion_id")]
  public int DiscussionId { get; private set; }

  /// <summary>
  /// The datetime at which this post was created.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTimeOffset CreatedAt { get; private set; }

  /// <summary>
  /// The datetime at which this post was deleted. This will be null if the post has not been deleted.
  /// </summary>
  [JsonProperty("deleted_at")]
  public DateTimeOffset? DeletedAt { get; private set; }

  /// <summary>
  /// The ID of the user that deleted this post. This will be null if the post has not been deleted.
  /// </summary>
  [JsonProperty("deleted_by_id")]
  public int? DeletedById { get; private set; }

  /// <summary>
  /// The ID of this post.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The ID of the user that last edited this post. This will be null if the post has not been edited.
  /// </summary>
  [JsonProperty("last_editor_id")]
  public int? LastEditorId { get; private set; }

  /// <summary>
  /// The datetime at which this post was last updated.
  /// </summary>
  [JsonProperty("updated_at")]
  public DateTimeOffset? UpdatedAt { get; private set; }

  /// <summary>
  /// The ID of the author of this post.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; private set; }

  /// <summary>
  /// Bool whether the message of this post is a system message.
  /// </summary>
  [JsonProperty("system")]
  public bool IsSystemMessage { get; private set; }

  #endregion

  #region Optional Attributes

  /// <summary>
  /// The discussion this post belongs to. This is an optional property and will be null if this post was accessed through a <see cref="Discussions.Discussion"/>.
  /// </summary>
  [JsonProperty("beatmap_discussion")]
  public Discussion? Discussion { get; private set; }

  #endregion
}