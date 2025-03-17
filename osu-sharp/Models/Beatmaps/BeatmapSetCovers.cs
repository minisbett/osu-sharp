using Newtonsoft.Json;

namespace osu_sharp.Models.Beatmaps;

/// <summary>
/// Contains the URLs to the cover texture assets of a beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapset-covers"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-json.ts"/>
/// </summary>
public class BeatmapSetCovers
{
  /// <summary>
  /// The cover asset of the beatmapset.
  /// </summary>
  [JsonProperty("cover")]
  public string Cover { get; private set; } = default!;

  /// <summary>
  /// The cover asset of the beatmapset, in high resolution.
  /// </summary>
  [JsonProperty("cover@2x")]
  public string Cover2X { get; private set; } = default!;

  /// <summary>
  /// The card asset of the beatmapset.
  /// </summary>
  [JsonProperty("card")]
  public string Card { get; private set; } = default!;

  /// <summary>
  /// The card asset of the beatmapset, in high resolution.
  /// </summary>
  [JsonProperty("card@2x")]
  public string Card2X { get; private set; } = default!;

  /// <summary>
  /// The list asset of the beatmapset.
  /// </summary>
  [JsonProperty("list")]
  public string List { get; private set; } = default!;

  /// <summary>
  /// The list asset of the beatmapset, in high resolution.
  /// </summary>
  [JsonProperty("list@2x")]
  public string List2X { get; private set; } = default!;

  /// <summary>
  /// The slimcover asset of the beatmapset.
  /// </summary>
  [JsonProperty("slimcover")]
  public string SlimCover { get; private set; } = default!;

  /// <summary>
  /// The slimcover asset of the beatmapset, in high resolution.
  /// </summary>
  [JsonProperty("slimcover@2x")]
  public string SlimCover2X { get; private set; } = default!;
}
