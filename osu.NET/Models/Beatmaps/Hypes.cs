using Newtonsoft.Json;

namespace osu.NET.Models.Beatmaps;

/// <summary>
/// Represents the hype progress of a beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapsetextended"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-json.ts"/>
/// </summary>
public class Hypes
{
  /// <summary>
  /// The amount of hypes the beatmapset currently has.
  /// </summary>
  [JsonProperty("current")]
  public int Current { get; private set; }

  /// <summary>
  /// The amount of hypes the beatmapset requires to be eligible for ranking.
  /// </summary>
  [JsonProperty("required")]
  public int Required { get; private set; }
}
