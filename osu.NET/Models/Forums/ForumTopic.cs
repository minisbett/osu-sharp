using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Forums;

/// <summary>
/// Represents a forum topic.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#forum-topic"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/Forum/TopicTransformer.php"/>
/// </summary>
public class ForumTopic
{
  /// <summary>
  /// The datetime at which this forum topic was created.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTimeOffset CreatedAt { get; private set; }

  /// <summary>
  /// The datetime at which this forum topic was deleted. This will be null if the topic was not deleted.
  /// </summary>
  [JsonProperty("deleted_at")]
  public DateTimeOffset? DeletedAt { get; private set; }

  /// <summary>
  /// The ID of the first post in this forum topic.
  /// </summary>
  [JsonProperty("first_post_id")]
  public int FirstPostId { get; private set; }

  /// <summary>
  /// The ID of the forum this topic was created in.
  /// </summary>
  [JsonProperty("forum_id")]
  public int ForumId { get; private set; }

  /// <summary>
  /// The ID of this forum topic.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// Bool whether this forum topic is locked, meaning no further posts can be made.
  /// </summary>
  [JsonProperty("is_locked")]
  public bool IsLocked { get; private set; }

  /// <summary>
  /// The ID of the most recent post in this forum topic.
  /// </summary>
  [JsonProperty("last_post_id")]
  public int LastPostId { get; private set; }

  /// <summary>
  /// The poll attached to this forum topic. This will be null if there is no poll.
  /// </summary>
  [JsonProperty("poll")]
  public Poll? Poll { get; private set; }

  /// <summary>
  /// The amount of posts in this forum topic.
  /// </summary>
  [JsonProperty("post_count")]
  public int PostCount { get; private set; }

  /// <summary>
  /// The title of this forum topic.
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; private set; } = default!;

  /// <summary>
  /// The type of this forum topic.
  /// </summary>
  [JsonProperty("type")]
  public ForumTopicType Type { get; private set; }

  /// <summary>
  /// The datetime at which this forum topic was last updated.
  /// </summary>
  [JsonProperty("updated_at")]
  public DateTimeOffset UpdatedAt { get; private set; }

  /// <summary>
  /// The ID of the user that created this forum topic.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; private set; }
}
