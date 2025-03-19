namespace osu.NET.Authorization;

/// <summary>
/// Represents an exception thrown when the retrieval of an access token in an <see cref="IOsuAccessTokenProvider"/> fails.
/// </summary>
/// <param name="message">The exception message.</param>
/// <param name="innerException">Optional. The inner exception.</param>
public class AccessTokenRetrievalException(string message, Exception? innerException = null) : Exception(message, innerException);
