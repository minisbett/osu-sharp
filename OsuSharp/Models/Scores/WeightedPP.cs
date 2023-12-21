using Newtonsoft.Json;

namespace OsuSharp.Models.Scores;

/// <summary>
/// Represents the weighted performance points of a score, including it's weight percentage.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/score-json.ts"/>
/// </summary>
public class WeightedPP
{
  /// <summary>
  /// The weight percentage of the performance points. 
  /// </summary>
  [JsonProperty("percentage")]
  public float Weight { get; private set; }

  /// <summary>
  /// The weighted performance points of the score.
  /// </summary>
  [JsonProperty("pp")]
  public float PP { get; private set; }
}
