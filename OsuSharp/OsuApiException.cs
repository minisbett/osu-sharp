namespace OsuSharp;

/// <summary>
/// Represents an exception thrown by the <see cref="OsuApiClient"/>.
/// </summary>
public class OsuApiException : Exception
{
  /// <summary>
  /// Creates a new instance of the <see cref="OsuApiException"/> class with the specified message.
  /// </summary>
  /// <param name="message">The message of the exception.</param>
  /// <param name="innerException">The inner exception.</param>
  public OsuApiException(string message, Exception? innerException = null) : base(message, innerException) { }
}
