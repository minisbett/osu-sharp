using Newtonsoft.Json;

namespace OsuSharp.Models.Forums;

/// <summary>
/// Represents a forum topic.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#forum-topic"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/Forum/TopicTransformer.php"/>
/// </summary>
public class ForumTopic
{
  /// <summary>
  /// The datetime at which the forum topic was created.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTimeOffset CreatedAt { get; private set; }

  /// <summary>
  /// The datetime at which the forum topic was deleted. This will be null if the forum topic was not deleted.
  /// </summary>
  [JsonProperty("deleted_at")]
  public DateTimeOffset DeletedAt { get; private set; }

  /// <summary>
  /// The ID of the first post in the forum topic.
  /// </summary>
  [JsonProperty("first_post_id")]
  public int FirstPostId { get; private set; }

  /// <summary>
  /// The ID of the forum in which this topic was created.
  /// </summary>
  [JsonProperty("forum_id")]
  public int ForumId { get; private set; }

  /// <summary>
  /// The ID of the forum topic.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// Bool whether the forum topic is locked.
  /// </summary>
  [JsonProperty("is_locked")]
  public bool IsLocked { get; private set; }

  /// <summary>
  /// The poll attached to the forum topic. This will be null if the forum topic has no poll.
  /// </summary>
  [JsonProperty("poll")]
  public Poll? Poll { get; private set; }

  /// <summary>
  /// The amount of posts in the forum topic.
  /// </summary>
  [JsonProperty("post_count")]
  public int PostCount { get; private set; }

  // NOTE: This property is populated manually, as the posts are separated in the response and not contained in the forum topic object.
  /// <summary>
  /// The forum posts in this forum topic.
  /// </summary>
  public ForumPost[] Posts { get; init; } = default!;

  /// <summary>
  /// The title of the forum topic.
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; private set; } = default!;

  /// <summary>
  /// The datetime at which the forum topic was last updated.
  /// </summary>
  [JsonProperty("updated_at")]
  public DateTimeOffset UpdatedAt { get; private set; }

  /// <summary>
  /// The ID of the user that created the forum topic.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; private set; }
}
