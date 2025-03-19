using osu.NET.Helpers;
using osu.NET.Models.Comments;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#comments

  // TODOENDPOINT: https://osu.ppy.sh/docs/index.html#get-a-comment (pagination)

  /// <summary>
  /// Returns a comment bundle containing the comment with the specified ID and replies up to 2 levels deep.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.CommentNotFound"/></term>
  ///   <description>The comment could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-a-comment"/>
  /// </summary>
  /// <param name="commentId">The ID of the comment.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The comment bundle containing the comment with the specified ID.</returns>
  [CanReturnAPIError(APIErrorType.CommentNotFound)]
  public async Task<APIResult<CommentBundle>> GetCommentAsync(int commentId, CancellationToken? cancellationToken = null)
    => await GetAsync<CommentBundle>($"comments/{commentId}", cancellationToken);
}