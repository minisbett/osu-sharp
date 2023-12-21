using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OsuSharp.Models;

/// <summary>
/// Represents a text that is represented in both an HTML and a markup language format (e.g. BBcode, markdown, ...).
/// <br/><br/>
/// This model is used for the following objects:<br/>
/// <a href="https://osu.ppy.sh/docs/index.html#beatmapset"/> (description field)<br/>
/// <a href="https://osu.ppy.sh/docs/index.html#group-description"/><br/>
/// <a href="https://osu.ppy.sh/docs/index.html#forum-post"/><br/>
/// <a href="https://osu.ppy.sh/docs/index.html#forum-topic-poll"/><br/>
/// <a href="https://osu.ppy.sh/docs/index.html#forum-topic-polloption"/><br/>
/// </summary>
public class Text
{
  /// <summary>
  /// The HTML representation of the text.
  /// </summary>
  [JsonProperty("html")]
  public string Html { get; private set; } = default!;

  /// <summary>
  /// The markup language representation of the text.
  /// </summary>
  public string Markup => BBCode ?? Raw!;

  /// <summary>
  /// The BBCode representation of the text. This will be null if the JSON property is called "raw".
  /// </summary>
  [JsonProperty("bbcode")]
  private string? BBCode { get; set; }

  /// <summary>
  /// The BBCode representation of the text. This will be null if the JSON property is called "bbcode".
  /// </summary>
  [JsonProperty("raw")]
  private string? Raw { get; set; }
}
