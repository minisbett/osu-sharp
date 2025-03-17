using Newtonsoft.Json;

namespace osu_sharp.Models.Beatmaps;

/// <summary>
/// Represents the availability of a beatmapset, including whether it is available for download and more information about the availability.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapsetextended"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-json.ts"/>
/// </summary>
public class Availability
{
  /// <summary>
  /// Bool whether the beatmapset is available for download.
  /// </summary>
  [JsonProperty("download_disabled")]
  public bool IsDownloadDisabled { get; private set; }

  /// <summary>
  /// More information about the availability of the beatmapset. This will be null if the beatmapset is available for download.
  /// </summary>
  [JsonProperty("more_information")]
  public string? Information { get; private set; }
}
