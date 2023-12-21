using Newtonsoft.Json;

namespace OsuSharp.Models.Forums;

/// <summary>
/// Represents a poll attached to a <see cref="ForumTopic"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#forum-topic-poll"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/Forum/PollTransformer.php"/>
/// </summary>
public class Poll
{
  /// <summary>
  /// Bool whether changing your vote is allowed.
  /// </summary>
  [JsonProperty("allow_vote_change")]
  public bool IsVoteChangeAllowed { get; private set; }

  /// <summary>
  /// The datetime at which the poll ended. This will be null if the poll has not ended yet.
  /// </summary>
  [JsonProperty("ended_at")]
  public DateTimeOffset? EndedAt { get; private set; }

  /// <summary>
  /// Bool whether the poll results are hidden until the poll ended.
  /// </summary>
  [JsonProperty("hide_incomplete_results")]
  public bool HideIncompleteResults { get; private set; }

  /// <summary>
  /// The datetime at which the last vote was performed. This will be null if no vote has been performed yet.
  /// </summary>
  [JsonProperty("last_vote_at")]
  public DateTimeOffset? LastVoteAt { get; private set; }

  /// <summary>
  /// TODO: what is this? maximum amount of votes that can be done in total?
  /// </summary>
  [JsonProperty("max_votes")]
  public int MaxVotes { get; private set; }

  /// <summary>
  /// The datetime at which the poll was started.
  /// </summary>
  [JsonProperty("started_at")]
  public DateTimeOffset StartedAt { get; private set; }

  /// <summary>
  /// The title of the poll.
  /// </summary>
  [JsonProperty("title")]
  public Text Title { get; private set; } = default!;

  /// <summary>
  /// The total amount of votes.
  /// </summary>
  [JsonProperty("total_vote_count")]
  public int TotalVoteCount { get; private set; }
}
