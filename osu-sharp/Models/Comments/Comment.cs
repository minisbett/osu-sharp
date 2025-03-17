using Newtonsoft.Json;
using osu_sharp.Enums;
using osu_sharp.Models.Users;

namespace osu_sharp.Models.Comments;

/// <summary>
/// Represents a comment on a beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#comment"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/comment-json.ts"/>
/// </summary>
public class Comment
{
  /// <summary>
  /// The ID of the object this comment is attached to (e.g. beatmapset ID).
  /// </summary>
  [JsonProperty("commentable_id")]
  public int CommentableId { get; private set; }

  /// <summary>
  /// The type of object this comment is attached to.
  /// </summary>
  [JsonProperty("commentable_type")]
  public CommentableType CommentableType { get; private set; }

  /// <summary>
  /// The datetime at which this comment was created.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTimeOffset CreatedAt { get; private set; }

  /// <summary>
  /// The datetime at which this comment was deleted. This will be null if the comment was not deleted.
  /// </summary>
  [JsonProperty("deleted_at")]
  public DateTimeOffset? DeletedAt { get; private set; }

  /// <summary>
  /// The ID of the user that deleted the comment. This will be null if the comment was not deleted.
  /// </summary>
  [JsonProperty("deleted_by_id")]
  public int? DeletedById { get; private set; }

  /// <summary>
  /// The datetime at which the comment was last edited. This will be null if the comment was not edited.
  /// </summary>
  [JsonProperty("edited_at")]
  public DateTimeOffset? EditedAt { get; private set; }

  /// <summary>
  /// The ID of the user that edited the comment. This will be null if the comment was not edited.
  /// </summary>
  [JsonProperty("edited_by_id")]
  public int? EditedById { get; private set; }

  /// <summary>
  /// The ID of the comment.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The username displayed on this comment, if this is a legacy comment. This will be null for newer comments.
  /// </summary>
  [JsonProperty("legacy_name")]
  public string LegacyName { get; private set; } = default!;

  /// <summary>
  /// The markdown string for the content of this comment.
  /// </summary>
  [JsonProperty("message")]
  public string Message { get; private set; } = default!;

  /// <summary>
  /// The HTML string for the content of this comment.
  /// </summary>
  [JsonProperty("message_html")]
  public string MessageHtml { get; private set; } = default!;

  /// <summary>
  /// The ID of this comments' parent. This will be null if this comment has no parent.
  /// </summary>
  [JsonProperty("parent_id")]
  public int? ParentId { get; private set; }

  /// <summary>
  /// Bool whether this comment is pinned.
  /// </summary>
  [JsonProperty("pinned")]
  public bool IsPinned { get; private set; }

  /// <summary>
  /// The number of replies to this comment.
  /// </summary>
  [JsonProperty("replies_count")]
  public int RepliesCount { get; private set; }

  /// <summary>
  /// The datetime at which this comment was last updated.
  /// </summary>
  [JsonProperty("updated_at")]
  public DateTimeOffset UpdatedAt { get; private set; }

  /// <summary>
  /// The author of this comment. This will be null if this is a legacy comment.
  /// </summary>
  [JsonProperty("user")]
  public User? User { get; private set; }

  /// <summary>
  /// The user ID of the author of this comment. This may be null.
  /// </summary>
  [JsonProperty("user_id")]
  public int? UserId { get; private set; }

  /// <summary>
  /// The number of upvotes on this comment.
  /// </summary>
  [JsonProperty("votes_count")]
  public int VotesCount { get; private set; }
}
