using osu_sharp.Helpers;
using osu_sharp.Models.Wikis;

namespace osu_sharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#wiki

  /// <summary>
  /// Returns the wikipage at the specified path in the specified locale.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.WikiPageNotFound"/></term>
  ///   <description>The wiki page could not be found</description>
  /// </item>
  /// <br/><br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-wiki-page"/>
  /// </summary>
  /// <param name="locale">The BCP 47 language tag of the wiki page.</param>
  /// <param name="path">The path of the wiki page.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The wiki page at the specified path in the specified locale.</returns>
  [CanReturnAPIError(APIErrorType.WikiPageNotFound)]
  public async Task<APIResult<WikiPage>> GetWikiPageAsync(string locale, string path, CancellationToken cancellationToken)
    => (await GetAsync<WikiPage>($"wiki/{locale}/{path}", cancellationToken)).WithErrorFallback(APIErrorType.WikiPageNotFound);
}
