namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the sorting options for posts of forum topics.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-topic-and-posts"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/Forum/Post.php"/>
/// </summary>
public enum PostSort
{
  /// <summary>
  /// Sorts the posts by their creation date in ascending order.
  /// </summary>
  IDAscending,

  /// <summary>
  /// Sorts the posts by their creation date in descending order.
  /// </summary>
  IDDescending
}
