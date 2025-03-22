using osu.NET.Helpers;
using osu.NET.Models.News;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#news

  // TODOENDPOINT: https://osu.ppy.sh/docs/index.html#get-news-listing (requires pagination)

  /// <summary>
  /// Returns the news post with the specified slug.<br/>
  /// The slug is a unique identifier for the news post, which is a part of the URL of the news post (eg. <c>2021-04-27-results-a-labour-of-love</c>).
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.NewsPostNotFound"/></term>
  ///   <description>The news post could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-news-post"/>
  /// </summary>
  /// <param name="slug">The slug of the news post (eg. <c>2021-04-27-results-a-labour-of-love</c>).</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The news post with the specified slug.</returns>
  [CanReturnAPIError(APIErrorType.NewsPostNotFound)]
  public async Task<APIResult<NewsPost>> GetNewsPostAsync(string slug, CancellationToken? cancellationToken = null)
    => (await GetAsync<NewsPost>($"news/{slug}", cancellationToken)).WithErrorFallback(APIErrorType.NewsPostNotFound);

  /// <summary>
  /// Returns the news post with the specified ID.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.NewsPostNotFound"/></term>
  ///   <description>The news post could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-news-post"/>
  /// </summary>
  /// <param name="id">The ID of the news post.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The news post with the specified ID.</returns>
  [CanReturnAPIError(APIErrorType.NewsPostNotFound)]
  public async Task<APIResult<NewsPost>> GetNewsPostAsync(int id, CancellationToken? cancellationToken = null)
    => (await GetAsync<NewsPost>($"news/{id}", cancellationToken, [("key", id)])).WithErrorFallback(APIErrorType.NewsPostNotFound);
}
