using Newtonsoft.Json;

namespace OsuSharp.Models.Discussions;

/// <summary>
/// Represents the votes of a discussion on a beatmapset.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-discussion-json.ts"/>
/// </summary>
public class DiscussionVotes
{
  /// <summary>
  /// The amount of downvotes this discussion has.
  /// </summary>
  [JsonProperty("down")]
  public int Down { get; private set; }

  /// <summary>
  /// The amount of upvotes this discussion has.
  /// </summary>
  [JsonProperty("up")]
  public int Up { get; private set; }

  /// <summary>
  /// The voters of this discussion.
  /// </summary>
  [JsonProperty("voters")]
  public DiscussionVoters Voters { get; private set; } = default!;
}
