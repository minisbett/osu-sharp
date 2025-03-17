using Newtonsoft.Json;
using osu_sharp.Enums;

namespace osu_sharp.Models.Wikis;

/// <summary>
/// Represents a wiki page in a specific locale.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#wikipage"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/WikiPageTransformer.php"/>
/// </summary>
public class WikiPage
{
  /// <summary>
  /// The BCP 47 language codes of all locales this wiki page is available in.
  /// </summary>
  [JsonProperty("available_locales")]
  public string[] AvailableLocales { get; private set; } = default!;

  /// <summary>
  /// The layout type of this wiki page.
  /// </summary>
  [JsonProperty("layout")]
  public WikiPageLayout Layout { get; private set; } = default!;

  /// <summary>
  /// The BCP 47 language code of the locale of this wiki page.
  /// </summary>
  [JsonProperty("locale")]
  public string Locale { get; private set; } = default!;

  /// <summary>
  /// The Markdown content of this wiki page.
  /// </summary>
  public string Markdown { get; private set; } = default!;

  /// <summary>
  /// The path to this wiki page.
  /// </summary>
  [JsonProperty("path")]
  public string Path { get; private set; } = default!;

  /// <summary>
  /// The subtitle of this wiki page. This will be null if this wiki page has no subtitle.
  /// </summary>
  [JsonProperty("subtitle")]
  public string? Subtitle { get; private set; } = default!;

  /// <summary>
  /// The tags associated with this wiki page.
  /// </summary>
  [JsonProperty("tags")]
  public string[] Tags { get; private set; } = default!;

  /// <summary>
  /// The title of this wiki page.
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; private set; } = default!;
}
