using Newtonsoft.Json;

namespace OsuSharp.Models.Forums;

/// <summary>
/// Represents a post on a <see cref="ForumTopic"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#forum-post"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/Forum/PostTransformer.php"/>
/// </summary>
public class ForumPost
{
  /// <summary>
  /// The datetime at which the forum post was created.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTimeOffset CreatedAt { get; private set; }

  /// <summary>
  /// The datetime at which the forum post was deleted. This will be null if the forum post was not deleted.
  /// </summary>
  [JsonProperty("deleted_at")]
  public DateTimeOffset? DeletedAt { get; private set; }

  /// <summary>
  /// The datetime at which the forum post was edited. This will be null if the forum post was not edited.
  /// </summary>
  [JsonProperty("edited_at")]
  public DateTimeOffset EditedAt { get; private set; }

  /// <summary>
  /// The ID of the user that edited the forum post. This will be null if the forum post was not edited.
  /// </summary>
  [JsonProperty("edited_by_id")]
  public int? EditedById { get; private set; }

  /// <summary>
  /// The ID of the forum the forum topic that this forum post belongs to was created in.
  /// </summary>
  [JsonProperty("forum_id")]
  public int ForumId { get; private set; }

  /// <summary>
  /// The ID of the forum post.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The ID of the forum topic the forum post belongs to.
  /// </summary>
  [JsonProperty("topic_id")]
  public int TopicId { get; private set; }

  /// <summary>
  /// The ID of the author of the forum post.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; private set; }

  /// <summary>
  /// The body of the forum post. This will be null if the forum post was deleted.
  /// </summary>
  [JsonProperty("body")]
  public Text? Body { get; private set; }
}
