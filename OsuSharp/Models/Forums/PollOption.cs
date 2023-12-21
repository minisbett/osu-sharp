using Newtonsoft.Json;

namespace OsuSharp.Models.Forums;

/// <summary>
/// Represents an option of a <see cref="Poll"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#forum-topic-polloption"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/Forum/PollOptionTransformer.php"/>
/// </summary>
public class PollOption
{
  /// <summary>
  /// The ID of the poll option. Only unique per-topic.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The text of the poll option.
  /// </summary>
  [JsonProperty("text")]
  public Text Text { get; private set; } = default!;

  /// <summary>
  /// The amount of votes on the poll option. This will be null if results are hidden until the poll ends and it has not ended yet.
  /// </summary>
  [JsonProperty("vote_count")]
  public int? VoteCount { get; private set; }
}
