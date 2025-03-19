using Newtonsoft.Json;

namespace osu.NET.Models.Beatmaps;

/// <summary>
/// The description of a beatmapset, including the BBcode and pre-rendered HTML format.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-json.ts"/>
/// </summary>
public class BeatmapSetDescription
{
  /// <summary>
  /// The description of the beatmapset as BBcode. This may be null.
  /// </summary>
  [JsonProperty("bbcode")]
  public string? BBCode { get; private set; }

  /// <summary>
  /// The description of the beatmapset as a pre-rendered HTML string. This may be null.
  /// </summary>
  [JsonProperty("description")]
  public string? Description { get; private set; }
}
