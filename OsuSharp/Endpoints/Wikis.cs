using OsuSharp.Models.Wikis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#wiki

  /// <summary>
  /// Gets the wiki page at the specified path in the specified locale.
  /// Returns null if the wiki page was not found.
  /// <br/><br/>
  /// API notes:
  /// <a href="https://osu.ppy.sh/docs/index.html#get-wiki-page"/>
  /// </summary>
  /// <param name="locale">The locale, as a 2-letter language code.</param>
  /// <param name="path">The path of the wiki page.</param>
  /// <returns>The wiki page or null, if the wiki page was not found.</returns>
  public async Task<WikiPage?> GetWikiPageAsync(string locale, string path)
  {
    // Send the request and return the wiki page object.
    return await GetFromJsonAsync<WikiPage>($"wiki/{locale}/{path}");
  }
}
