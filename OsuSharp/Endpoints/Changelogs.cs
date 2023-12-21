using OsuSharp.Models.Changelogs;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#changelog10

  /// <summary>
  /// Gets the build by its specified version in the specified update stream. If the build was not found, null is returned.<br/>
  /// For the update stream, the <see cref="UpdateStream.Name"/> needs to be specified (e.g. "stable40", "beta", ...).<br/>
  /// For the version, the <see cref="Build.DisplayVersion"/> needs to be specified (e.g. "20231219.2").
  /// <br/><br/>
  /// API notes:<br/>
  /// Includes <see cref="Build.Changelog"/> (including <see cref="ChangelogEntry.GitHubUser"/>) and <see cref="Build.Versions"/>.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-changelog-build"/>
  /// </summary>
  /// <param name="stream">The name of the update stream (e.g. "stable40", "beta", ...).</param>
  /// <param name="build">The version of the build (e.g. "20231219.2").</param>
  /// <returns>The build or null, if no build was found.</returns>
  public async Task<Build?> GetBuildAsync(string stream, string build)
  {
    // Send the request and return the build object.
    return await GetFromJsonAsync<Build>($"changelog/{stream}/{build}");
  }

  /// <summary>
  /// Gets the changelog listing of osu!, optionally using the specified filters.
  /// <br/><br/>
  /// API notes:<br/>
  /// The amount of builds returned is always limited to 21 and sorted by most recent, regardless of the filters.<br/>
  /// <see cref="ChangelogListing.Streams"/> always contains all available streams, including <see cref="UpdateStream.LatestBuild"/> and <see cref="UpdateStream.UserCount"/>.<br/>
  /// <see cref="ChangelogListing.Builds"/> includes <see cref="Build.Changelog"/> (including <see cref="ChangelogEntry.GitHubUser"/>) and <see cref="Build.Versions"/>.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-changelog-listing"/>
  /// </summary>
  /// <param name="stream">Optional. The name of the update stream to exclusively return builds from (e.g. "stable40").</param>
  /// <param name="fromBuild">Optional. The version of the minimum build to return.</param>
  /// <param name="stream">Optional. The version of the maximum build to return.</param>
  /// <param name="maxBuildId">Optional. The ID of the maximum build to return.</param>
  /// <returns>The changelog listing.</returns>
  public async Task<ChangelogListing> GetChangelogListingAsync(string? stream = null, string? fromBuild = null, string? toBuild = null, int? maxBuildId = null)
  {
    // Send the request and return the changelog listing object.
    return (await GetFromJsonAsync<ChangelogListing>($"changelog", new Dictionary<string, string?>()
    {
      { "stream", stream },
      { "from", fromBuild },
      { "to", toBuild },
      { "max_id", maxBuildId?.ToString() }
    }))!;
  }

  /// <summary>
  /// Looks up the build with the specified ID. If the build was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#lookup-changelog-build"/>
  /// </summary>
  /// <param name="buildId">The ID of the build.</param>
  /// <returns>The build or null, if no build was found.</returns>
  public async Task<Build?> LookupBuildIdAsync(int buildId)
  {
    // Send the request and return the build object.
    return await GetFromJsonAsync<Build>($"changelog/{buildId}?key=id");
  }

  /// <summary>
  /// Looks up the latest build of the specified update stream. If the update stream was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#lookup-changelog-build"/>
  /// </summary>
  /// <param name="stream">The name of the update stream (e.g. "stable40", "lazer", ...).</param>
  /// <returns>The build or null, if no update stream was found.</returns>
  public async Task<Build?> LookupLatestBuildAsync(string stream)
  {
    // Send the request and return the build object.
    return await GetFromJsonAsync<Build>($"changelog/{stream}");
  }
}