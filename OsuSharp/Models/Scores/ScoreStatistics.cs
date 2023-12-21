using Newtonsoft.Json;

namespace OsuSharp.Models.Scores;

/// <summary>
/// Represents the statistics (hit judgements) of a score.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#score"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/score-json.ts"/>
/// </summary>
public class ScoreStatistics
{
  /// <summary>
  /// The amount of 300s in this score.
  /// </summary>
  [JsonProperty("count_300")]
  public int Count300 { get; private set; }

  /// <summary>
  /// The amount of 100s in this score.
  /// </summary>
  [JsonProperty("count_100")]
  public int Count100 { get; private set; }

  /// <summary>
  /// The amount of 50s in this score.
  /// </summary>
  [JsonProperty("count_50")]
  public int Count50 { get; private set; }

  /// <summary>
  /// The amount of gekis in this score.
  /// </summary>
  [JsonProperty("count_geki")]
  public int CountGeki { get; private set; }

  /// <summary>
  /// The amount of katus in this score.
  /// </summary>
  [JsonProperty("count_katu")]
  public int CountKatu { get; private set; }

  /// <summary>
  /// The amount of misses in this score.
  /// </summary>
  [JsonProperty("count_miss")]
  public int Misses { get; private set; }
}
