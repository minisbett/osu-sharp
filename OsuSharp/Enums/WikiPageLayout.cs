using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsuSharp.Models.Wikis;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the types of layout of a <see cref="WikiPage"/>.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/Wiki/Page.php"/>
/// </summary>
public enum WikiPageLayoutType
{
  /// <summary>
  /// Indicates that the wiki page is a normal page written in Markdown.
  /// </summary>
  [Description("markdown_page")]
  Markdown,

  /// <summary>
  /// Indicates that the wiki page is a main page, having a special layout.
  /// </summary>
  [Description("main_page")]
  Main
}
