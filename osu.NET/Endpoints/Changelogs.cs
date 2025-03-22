using osu.NET.Enums;
using osu.NET.Helpers;
using osu.NET.Models.Changelogs;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#changelog10

  /// <summary>
  /// Returns the build with specified version in the specified update stream.<br/>
  /// For the version, the <see cref="Build.DisplayVersion"/> needs to be specified (e.g. "20231219.2").
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.BuildNotFound"/></term>
  ///   <description>The build could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="Build.Changelog"/> (including <see cref="ChangelogEntry.GitHubUser"/>)</item>
  /// <item>Includes <see cref="Build.Versions"/></item>
  /// </list>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-changelog-build"/>
  /// </summary>
  /// <param name="stream">The update stream.</param>
  /// <param name="build">The version of the build (e.g. "20231219.2").</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The build with the specified version in the specified update stream.</returns>
  [CanReturnAPIError(APIErrorType.BuildNotFound)]
  public async Task<APIResult<Build>> GetBuildAsync(UpdateStreamName stream, string build, CancellationToken? cancellationToken = null)
    => await GetAsync<Build>($"changelog/{stream.GetQueryName()}/{build}", cancellationToken);

  /// <summary>
  /// Returns the changelog listing of osu!, optionally using the specified filters.
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>The amount of builds returned is always limited to 21 and sorted by most recent, regardless of the filters</item>
  /// <item><see cref="ChangelogListing.Streams"/> includes <see cref="UpdateStream.LatestBuild"/></item>
  /// <item><see cref="ChangelogListing.Streams"/> includes <see cref="UpdateStream.UserCount"/></item>
  /// <item><see cref="ChangelogListing.Builds"/> includes <see cref="Build.Changelog"/> (including <see cref="ChangelogEntry.GitHubUser"/>).</item>
  /// </list>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-changelog-listing"/>
  /// </summary>
  /// <param name="stream">Optional. The name of the update stream to exclusively return builds from.</param>
  /// <param name="fromBuild">Optional. The version of the minimum build to return.</param>
  /// <param name="toBuild">Optional. The version of the maximum build to return.</param>
  /// <param name="maxBuildId">Optional. The ID of the maximum build to return.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The changelog listing.</returns>
  [CanReturnAPIError()]
  public async Task<APIResult<ChangelogListing>> GetChangelogListingAsync(UpdateStreamName? stream = null, string? fromBuild = null,
    string? toBuild = null, int? maxBuildId = null, CancellationToken? cancellationToken = null)
    => await GetAsync<ChangelogListing>("changelog", cancellationToken,
    [
      ("stream", stream),
      ("from", fromBuild),
      ("to", toBuild),
      ("max_id", maxBuildId)
    ]);

  /// <summary>
  /// Looksup the build with the specified ID.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.BuildNotFound"/></term>
  ///   <description>The build could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#lookup-changelog-build"/>
  /// </summary>
  /// <param name="buildId">The ID of the build.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The build with the specified ID.</returns>
  [CanReturnAPIError(APIErrorType.BuildNotFound)]
  public async Task<APIResult<Build>> LookupBuildAsync(int buildId, CancellationToken? cancellationToken = null)
    => await GetAsync<Build>($"changelog/{buildId}", cancellationToken, [("key", "id")]);

  /// <summary>
  /// Looksup the latest build of the specified update stream.
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#lookup-changelog-build"/>
  /// </summary>
  /// <param name="stream">The update stream.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The latest build of the specified update stream.</returns>
  [CanReturnAPIError()]
  public async Task<APIResult<Build>> LookupLatestBuildAsync(UpdateStreamName stream, CancellationToken? cancellationToken = null)
    => await GetAsync<Build>($"changelog/{stream.GetQueryName()}", cancellationToken);
}
