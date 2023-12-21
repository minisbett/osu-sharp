using Newtonsoft.Json;

namespace OsuSharp.Models.Discussions;

/// <summary>
/// Represents a post in a discussion on a beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapsetdiscussionpost"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-discussion-post-json.ts"/>
/// </summary>
public class DiscussionPost
{
  // TODO: some message & resolved & value bool shenanigans, refer to source

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
  /// TODO: what is this? user id of person that deleted?
  /// </summary>
  [JsonProperty("deleted_by_id")]
  public int? DeletedById { get; private set; }

  /// <summary>
  /// The ID of this post.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// TODO: what is this? The user id of the last person to edit this post?
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

  #endregion

  #region Optional Attributes

  /// <summary>
  /// The discussion this post belongs to. This is an optional attribute and will be null if this post was accessed through a <see cref="Discussion"/>.
  /// </summary>
  [JsonProperty("beatmap_discussion")]
  public Discussion? Discussion { get; private set; }

  #endregion
}
