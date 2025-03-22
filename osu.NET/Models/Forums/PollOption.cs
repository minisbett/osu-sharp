using Newtonsoft.Json;

namespace osu.NET.Models.Forums;

/// <summary>
/// Represents an option on a <see cref="Poll"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#forum-topic-polloption"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/Forum/PollOption.php"/>
/// </summary>
public class PollOption
{
  /// <summary>
  /// The ID of this poll option.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; internal set; }

  /// <summary>
  /// The text of this poll option.
  /// </summary>
  [JsonProperty("text")]
  public PollText Text { get; private set; } = default!;

  /// <summary>
  /// The amount of votes this poll option has.
  /// This will be null if the poll has not ended yet and <see cref="Poll.HideIncompleteResults"/> is true.
  /// </summary>
  [JsonProperty("vote_count")]
  public int? VoteCount { get; private set; }
}
