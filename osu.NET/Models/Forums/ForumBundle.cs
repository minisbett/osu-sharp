using Newtonsoft.Json;

namespace osu.NET.Models.Forums;

/// <summary>
/// Represents a bundle containing a forum and its pinned and recent topics.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-forum-and-topics"/> (response)<br/>
/// Source: <a href=""/>
/// </summary>
public class ForumBundle
{
  /// <summary>
  /// The forum.
  /// </summary>
  [JsonProperty("forum")]
  public Forum Forum { get; private set; } = default!;

  /// <summary>
  /// The recent topics in the forum.
  /// </summary>
  [JsonProperty("topics")]
  public ForumTopic[] RecentTopics { get; private set; } = default!;

  /// <summary>
  /// The pinned topics in the forum.
  /// </summary>
  [JsonProperty("pinned_topics")]
  public ForumTopic[] PinnedTopics { get; private set; } = default!;
}
