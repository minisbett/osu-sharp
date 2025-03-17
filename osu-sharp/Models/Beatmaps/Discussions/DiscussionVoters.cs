using Newtonsoft.Json;

namespace osu_sharp.Models.Beatmaps.Discussions;

/// <summary>
/// Represents the voters of a discussion on a beatmapset.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-discussion-json.ts"/>
/// </summary>
public class DiscussionVoters
{
  /// <summary>
  /// The IDs of the users that downvoted the discussion.
  /// </summary>
  [JsonProperty("down")]
  public int[] Down { get; private set; } = default!;

  /// <summary>
  /// The IDs of the users that upvoted the discussion.
  /// </summary>
  [JsonProperty("up")]
  public int[] Up { get; private set; } = default!;
}