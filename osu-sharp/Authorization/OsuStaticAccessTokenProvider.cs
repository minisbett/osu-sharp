namespace osu_sharp.Authorization;

/// <summary>
/// Provides a statically provided access token.
/// </summary>
/// <param name="accessToken">The access token to be provided to the API client.</param>
public class OsuStaticAccessTokenProvider(string accessToken) : IOsuAccessTokenProvider
{
  /// <inheritdoc/>
  public Task<string> GetAccessTokenAsync(CancellationToken cancellationToken)
  {
    return Task.FromResult(accessToken);
  }
}
