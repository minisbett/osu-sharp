using Newtonsoft.Json;
using osu_sharp.Models.Beatmaps;

namespace osu_sharp.Models.Users;

/// <summary>
/// Represents an entry in the most played beatmaps of a user.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapplaycount"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmap-playcount-json.ts"/>
/// </summary>
public class BeatmapPlaycount
{
  /// <summary>
  /// The ID of the beatmap.
  /// </summary>
  [JsonProperty("beatmap_id")]
  public int BeatmapId { get; private set; }

  /// <summary>
  /// The beatmap. This will be null if the beatmap has been deleted.
  /// </summary>
  [JsonProperty("beatmap")]
  public Beatmap? Beatmap { get; private set; }

  /// <summary>
  /// The beatmapset. This may be null if the beatmapset has been deleted.
  /// </summary>
  [JsonProperty("beatmapset")]
  public BeatmapSet? BeatmapSet { get; private set; }

  /// <summary>
  /// The amount of times the user played the beatmap.
  /// </summary>
  [JsonProperty("count")]
  public int Count { get; private set; }
}
