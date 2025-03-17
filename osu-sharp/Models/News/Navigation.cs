using Newtonsoft.Json;

namespace osu_sharp.Models.News;

/// <summary>
/// Represents navigation metadata for a news post, containing the next and previous news post (if any).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#newspost-navigation"><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/news-post-json.ts"/>
/// </summary>
public class Navigation
{
  /// <summary>
  /// The next (newer) news post. This will be null if there is no newer post.
  /// </summary>
  [JsonProperty("newer")]
  public NewsPost? Next { get; private set; }

  /// <summary>
  /// The previous (older) news post. This will be null if there is no older post.
  /// </summary>
  [JsonProperty("older")]
  public NewsPost? Previous { get; private set; }
}
