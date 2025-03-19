using osu.NET.Helpers;

namespace osu.NET.Enums;

/// <summary>
/// An enum containing the existing, official rulesets.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#ruleset"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Enums/Ruleset.php"/>
/// </summary>
public enum Ruleset : int
{
  /// <summary>
  /// The standard ruleset.
  /// </summary>
  [QueryAPIName("osu")]
  [JsonAPIName("osu")]
  Osu = 0,

  /// <summary>
  /// The taiko ruleset.
  /// </summary>
  [QueryAPIName("taiko")]
  [JsonAPIName("taiko")]
  Taiko = 1,

  /// <summary>
  /// The catch the beat ruleset.
  /// </summary>
  [QueryAPIName("fruits")]
  [JsonAPIName("fruits")]
  Catch = 2,

  /// <summary>
  /// The mania ruleset.
  /// </summary>
  [QueryAPIName("mania")]
  [JsonAPIName("mania")]
  Mania = 3
}