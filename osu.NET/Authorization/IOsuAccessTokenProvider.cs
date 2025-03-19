namespace osu.NET.Authorization;

/// <summary>
/// Represents a provider for an access token for the osu! API v2.
/// </summary>
public interface IOsuAccessTokenProvider
{
  /// <summary>
  /// Provides an access token via the authorization method of this provider.
  /// </summary>
  /// <param name="cancellationToken">The cancellation token for aborting the request.</param>
  /// <returns>The access token.</returns>
  public Task<string> GetAccessTokenAsync(CancellationToken cancellationToken);
}