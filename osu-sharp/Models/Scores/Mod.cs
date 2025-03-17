using Newtonsoft.Json;

namespace osu_sharp.Models.Scores;

/// <summary>
/// Represents a mod of a score.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/score-mod-json.ts"/>
/// </summary>
public class Mod
{
  /// <summary>
  /// The acronym of this mod.
  /// </summary>
  [JsonProperty("acronym")]
  public string Acronym { get; private set; } = default!;

  /// <summary>
  /// The settings of this mod.
  /// </summary>
  [JsonProperty("settings")]
  public Dictionary<string, object> Settings { get; private set; } = [];
}
