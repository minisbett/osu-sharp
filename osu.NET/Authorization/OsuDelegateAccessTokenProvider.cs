namespace osu.NET.Authorization;

/// <summary>
/// Provides an access token via a specified delegate.
/// </summary>
/// <param name="accessTokenDelegate">The delegate for providing an access token.</param>
public class OsuDelegateAccessTokenProvider(Func<CancellationToken, Task<string>> accessTokenDelegate) : IOsuAccessTokenProvider
{
  /// <inheritdoc/>
  public Task<string> GetAccessTokenAsync(CancellationToken cancellationToken) => accessTokenDelegate(cancellationToken);
}
