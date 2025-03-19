using Newtonsoft.Json;

namespace osu.NET.Models.Beatmaps.Discussions;

/// <summary>
/// Represents a system-created post in a discussion on a beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapsetdiscussionpost"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-discussion-post-json.ts"/>
/// </summary>
public class SystemDiscussionPost : DiscussionPost
{
  /// <summary>
  /// The system message of this post.
  /// </summary>
  [JsonProperty("message")]
  public SystemMessage Message { get; private set; } = default!;
}