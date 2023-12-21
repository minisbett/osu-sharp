using Newtonsoft.Json;
using OsuSharp.Enums;

namespace OsuSharp.Models.Forums;

/// <summary>
/// Represents a bundle of forum posts with it's associated forum topic, as returned
/// on the <see cref="OsuApiClient.GetForumTopicAsync(int, PostSort, int, int?, int?)"/> endpoint.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-topic-and-posts"/>
/// </summary>
public class ForumPostBundle
{
  /// <summary>
  /// The forum topic the forum posts belong to.
  /// </summary>
  [JsonProperty("topic")]
  public ForumTopic Topic { get; private set; } = default!;

  /// <summary>
  /// The forum posts of the forum topic.
  /// </summary>
  [JsonProperty("posts")]
  public ForumPost[] Posts { get; private set; } = default!;
}
