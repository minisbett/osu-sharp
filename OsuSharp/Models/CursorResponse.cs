namespace OsuSharp.Models;

/// <summary>
/// Represents a response wrapper for API endpoints that include a "cursor_string" field,
/// which is a string that can be used to fetch the next page of results.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#cursorstring"/>
/// </summary>
internal class CursorResponse<T> where T : class
{
  /// <summary>
  /// The array of data included in the response.
  /// </summary>
  public required T[] Data { get; init; }

  /// <summary>
  /// The cursor string for the next page of results. This will be null if there are no more pages.
  /// </summary>
  public required string? Cursor { get; init; }
}
