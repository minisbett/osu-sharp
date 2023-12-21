using OsuSharp.Enums;
using OsuSharp.Models.Beatmaps;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#beatmap-packs

  /// <summary>
  /// Returns an asynchronous enumerable for all beatmap packs with the specified type, allowing to lazily
  /// enumerate through all beatmap packs, performing further pagination requests as necessary.<br/>
  /// If a pagination request failed, an <see cref="OsuApiException"/> is thrown.
  /// <br/><br/>
  /// API notes:<br/>
  /// This endpoint does not provide support for targetting a specific page directly per API design.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap-packs"/>
  /// </summary>
  /// <returns>An asynchronous enumerable for lazily enumerating over the beatmap packs.</returns>
  public IAsyncEnumerable<BeatmapPack> GetBeatmapPacksAsync(BeatmapPackType type = BeatmapPackType.Standard)
  {
    // Return the asynchronous enumerable.
    return EnumerateAsync<BeatmapPack>("beatmaps/packs", new Dictionary<string, string?>()
    {
      { "type", type.ToString().ToLower() }
    });
  }

  /// <summary>
  /// Gets the beatmap pack with the specified tag. If the beatmap pack was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap-pack"/>
  /// </summary>
  /// <returns>The beatmap pack with the specified tag or null, if the beatmap pack was not found.</returns>
  public async Task<BeatmapPack?> GetBeatmapPackAsync(string tag)
  {
    // Send the request and return the beatmap pack object.
    return await GetFromJsonAsync<BeatmapPack>($"beatmaps/packs/{tag}");
  }
}