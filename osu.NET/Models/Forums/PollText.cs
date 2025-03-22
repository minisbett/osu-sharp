using Newtonsoft.Json;

namespace osu.NET.Models.Forums;

/// <summary>
/// Represents the title of a <see cref="Poll>"/> or text of a <see cref="PollOption"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#forum-topic-polloption"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/Forum/PollOption.php"/>
/// </summary>
public class PollText
{
  /// <summary>
  /// The text in BBcode format.
  /// </summary>
  [JsonProperty("bbcode")]
  public string BBCode { get; private set; } = default!;

  /// <summary>
  /// The text as a pre-rendered HTML string.
  /// </summary>
  [JsonProperty("html")]
  public string Html { get; private set; } = default!;
}
