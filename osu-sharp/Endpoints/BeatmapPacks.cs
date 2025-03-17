using osu_sharp.Models.Beatmaps;

namespace osu_sharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#beatmap-packs

  // TODOENDPOINT: https://osu.ppy.sh/docs/index.html#get-beatmap-packs (pagination)

  /// <summary>
  /// Returns the beatmap pack with the specified tag.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.BeatmapPackNotFound"/></term>
  ///   <description>The beatmap pack could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API Docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap-pack"/>
  /// </summary>
  /// <param name="tag">The tag of the beatmap pack.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The beatmap pack with the specified tag.</returns>
  public async Task<APIResult<BeatmapPack>> GetBeatmapPackAsync(string tag, CancellationToken? cancellationToken = null)
    => await GetAsync<BeatmapPack>($"beatmaps/packs/{tag}", cancellationToken);
}
