using Microsoft.Extensions.Logging;

namespace osu.NET;

/// <summary>
/// Represents options for an <see cref="OsuApiClient"/>.
/// </summary>
public class OsuApiClientOptions
{
  /// <summary>
  /// Bool whether logging via an <see cref="ILogger{OsuApiClient}"/> is enabled. Defaults to false.<br/>
  /// The following actions are logged:
  /// <list type="bullet">
  /// <item>The API requests and their response and duration (<see cref="LogLevel.Debug"/>)</item>
  /// <item>Exceptions thrown by the API client (<see cref="LogLevel.Error"/>)</item>
  /// </list>
  /// </summary>
  public bool EnableLogging { get; set; } = false;

  /// <summary>
  /// The timeout for API requests. Defaults to the default of <see cref="HttpClient.Timeout"/>, which is 100 seconds.
  /// </summary>
  public TimeSpan RequestTimeout { get; set; } = TimeSpan.FromSeconds(100);
}
