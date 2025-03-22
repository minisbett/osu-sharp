namespace osu.NET;

/// <summary>
/// Represents an error returned by the osu! API.
/// </summary>
public class APIError
{
  private APIError(APIErrorType type, string? message)
  {
    Type = type;
    Message = message;
  }

  /// <summary>
  /// The type of error returned, determined from a lookup table on the error message provided by the osu! API.<br/>
  /// This is useful for error-handling API requests for different erroring scenarios.
  /// </summary>
  public APIErrorType Type { get; internal set; }

  /// <summary>
  /// The error message provided by the osu! API. This can be null.
  /// </summary>
  public string? Message { get; }

  /// <summary>
  /// Returns an <see cref="APIError"/> object based on the specified error message. The <see cref="Type"/> is determined from a lookup table on 
  /// the error message, or will be <see cref="APIErrorType.Unknown"/> if the error message is not associated with an <see cref="APIErrorType"/>.
  /// </summary>
  /// <param name="message">The error message provided by the osu! API.</param>
  /// <returns>The parsed <see cref="APIError"/>.</returns>
  internal static APIError FromMessage(string? message)
  {
    if (message is null)
      return new(APIErrorType.Null, null);
    else if (_errorMessageMappings.TryGetValue(message, out APIErrorType type))
      return new(type, message);

    return new(APIErrorType.Unknown, message);
  }

  public override string ToString()
  {
    return $"({Type}) {Message}";
  }

  /// <summary>
  /// Represents a mapping between error messages returned by the osu! API and their corresponding <see cref="APIErrorType"/>.
  /// </summary>
  private static readonly Dictionary<string, APIErrorType> _errorMessageMappings = new()
  {
    ["Specified beatmap difficulty couldn't be found."] = APIErrorType.BeatmapNotFound,
    ["Specified beatmap couldn't be found."] = APIErrorType.BeatmapSetNotFound,
    ["Specified BeatmapPack couldn't be found."] = APIErrorType.BeatmapPackNotFound,
    ["Specified Build couldn't be found."] = APIErrorType.BuildNotFound,
    ["Specified Comment couldn't be found."] = APIErrorType.CommentNotFound,
    ["Specified Forum\\Forum couldn't be found."] = APIErrorType.ForumNotFound
  };
}