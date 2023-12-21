using OsuSharp.Models.Beatmaps;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#beatmapsets

  /// <summary>
  /// Looks up the beatmapset that contains the beatmap with the specified ID. If the beatmapset was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-apiv2beatmapsetslookup"/>
  /// </summary>
  /// <param name="id">The ID of the beatmap.</param>
  /// <returns>The beatmapset or null, if the beatmapset was not found.</returns>
  public async Task<BeatmapSetExtended?> LookupBeatmapSetAsync(int beatmapId)
  {
    // Send the request and return the beatmapset object.
    return await GetFromJsonAsync<BeatmapSetExtended>($"beatmapsets/lookup?beatmap_id={beatmapId}");
  }

  /// <summary>
  /// Gets the beatmapset with the specified ID. If the beatmapset was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-apiv2beatmapsetsbeatmapset"/>
  /// </summary>
  /// <param name="id">The ID of the beatmapset.</param>
  /// <returns>The beatmapset or null, if the beatmapset was not found.</returns>
  public async Task<BeatmapSetExtended?> GetBeatmapSetAsync(int beatmapSetId)
  {
    // Send the request and return the beatmapset object.
    return await GetFromJsonAsync<BeatmapSetExtended>($"beatmapsets/{beatmapSetId}");
  }
}
