using OsuSharp.Enums;
using OsuSharp.Models.Comments;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#comments

  /// <summary>
  /// Gets a comment bundle containing the comment with the specified ID and replies up to 2 levels deep. If the comment was not found, null is returned.
  /// <br/><br/>
  /// </summary>
  /// <param name="commentId">The ID of the comment.</param>
  /// <returns>The comment bundle or null, if the comment was not found.</returns>
  public async Task<CommentBundle?> GetCommentAsync(int commentId)
  {
    return await GetFromJsonAsync<CommentBundle>($"comments/{commentId}");
  }

  /// <summary>
  /// Returns an asynchronous enumerable for all comments with the specified filters, allowing to lazily
  /// enumerate through all comments, performing further pagination requests as necessary,
  /// with each comment bundle containing multiple comments.<br/>
  /// If a pagination request failed, an <see cref="OsuApiException"/> is thrown.
  /// <br/><br/>
  /// API notes:<br/>
  /// This endpoint does not provide support for targetting a specific page directly per API design.<br/>
  /// Includes <see cref="CommentBundle.PinnedComments"/> if <paramref name="type"/> and <paramref name="commentableId"/> are specified.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-comments"/>
  /// </summary>
  /// <param name="after">The minmum ID for the comments, returning only comments after this ID.</param>
  /// <param name="type">The type of commentable to return comments of.</param>
  /// <param name="commentableId">The ID of the commentable to return the comments of.</param>
  /// <param name="parentId">The ID of the parent comment, returning it's replies.</param>
  /// <param name="sort">The sorting for the returned comments.</param>
  /// <returns>An asynchronous enumerable for lazily enumerating over the comment bundles.</returns>
  public async IAsyncEnumerable<CommentBundle> GetCommentsAsync(int? after = null, CommentableType? type = null, int? commentableId = null, int? parentId = null,
                                                                CommentSortType? sort = null)
  {
    // Always remember the cursor for the next request.
    Cursor? cursor = null;

    // Keep requesting until there are no more pages, and yield return the comment bundles to asynchronously enumerate over them.
    do
    {
      // Send the request.
      CommentBundle? bundle = await GetFromJsonAsync<CommentBundle>($"comments", new Dictionary<string, string?>()
      {
        { "cursor[id]", cursor?.Id.ToString() },
        { "cursor[created_at]", cursor?.CreatedAt.ToString("o") },
        { "after", after?.ToString() },
        { "commentable_type", type?.ToString() },
        { "commentable_id", commentableId?.ToString() },
        { "parent_id", parentId?.ToString() },
        { "sort", sort?.ToString() }
      });

      // Validate the response and throw an exception if the bundle is null.
      if (bundle is null)
        throw new OsuApiException("An error occured while requesting the comment bundle. (bundle is null)");

      // Yield return the bundle and update the cursor for the next request.
      yield return bundle;
      cursor = bundle.Cursor;
    }
    while (cursor != null);
  }
}
