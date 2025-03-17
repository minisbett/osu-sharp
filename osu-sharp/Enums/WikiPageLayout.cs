namespace osu_sharp.Enums;

/// <summary>
/// An enum containing the types of layout of a <see cref="Models.Wikis.WikiPage"/>.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/Wiki/Page.php"/>
/// </summary>
public enum WikiPageLayout
{
  /// <summary>
  /// Indicates that the wiki page is a normal page written in Markdown.
  /// </summary>
  [JsonAPIName("markdown_page")]
  Markdown,

  /// <summary>
  /// Indicates that the wiki page is a main page, having a special layout.
  /// </summary>
  [JsonAPIName("main_page")]
  Main
}
