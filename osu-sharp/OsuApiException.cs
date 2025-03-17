namespace osu_sharp;

/// <summary>
/// Represents an exception thrown by the <see cref="OsuApiClient"/>.
/// </summary>
/// <param name="message">The exception message.</param>
/// <param name="innerException">Optional. The inner exception.</param>
public class OsuApiException(string message, Exception? innerException = null) : Exception(message, innerException);
