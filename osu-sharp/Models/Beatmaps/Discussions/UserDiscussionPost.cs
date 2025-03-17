using Newtonsoft.Json;

namespace osu_sharp.Models.Beatmaps.Discussions;

/// <summary>
/// Represents a user-written post in a discussion on a beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapsetdiscussionpost"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-discussion-post-json.ts"/>
/// </summary>
public class UserDiscussionPost : DiscussionPost
{
  /// <summary>
  /// The message content of this post.
  /// </summary>
  [JsonProperty("message")]
  public string Message { get; private set; } = default!;
}