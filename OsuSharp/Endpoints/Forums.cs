using OsuSharp.Enums;
using OsuSharp.Models.Forums;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#forum

  /// <summary>
  /// Returns an asynchronous enumerable for all posts of a forum topic with the specified filters, allowing to lazily
  /// enumerate through all posts, performing further pagination requests as necessary.<br/>
  /// If a pagination request failed, an <see cref="OsuApiException"/> is thrown.
  /// <br/><br/>
  /// API notes:<br/>
  /// This endpoint does not provide support for targetting a specific page directly per API design.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-topic-and-posts"/>
  /// </summary>
  /// <param name="topicId">The ID of the forum topic.</param>
  /// <param name="sort">The sorting option for the posts.</param>
  /// <param name="limit">The maximum amount of posts to be returned. Defaults to 20, supports up to 50.</param>
  /// <param name="start">The ID of the first post to return. Only applies if <paramref name="sort"/> is <see cref="PostSort.IDAscending"/>.</param>
  /// <param name="end">The ID of the last post to return. Only applies if <paramref name="sort"/> is <see cref="PostSort.IDDescending"/>.</param>
  /// <returns>An asynchronous enumerable for lazily enumerating over the posts of tthe forum topic.</returns>
  public IAsyncEnumerable<ForumPostBundle> GetForumTopicAsync(int topicId, PostSort sort = PostSort.IDAscending, int limit = 20, int? start = null,
                                                              int? end = null)
  {
    // Return the asynchronous enumerable.
    return EnumerateAsync<ForumPostBundle>($"forum/topics/{topicId}", new Dictionary<string, string?>()
    {
      { "sort", sort.ToString() },
      { "limit", limit.ToString() },
      { "start", start?.ToString() },
      { "end", end?.ToString() }
    });
  }
}
