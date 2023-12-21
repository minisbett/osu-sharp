using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the existing, official rulesets.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#ruleset"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Enums/Ruleset.php"/>
/// </summary>
public enum Ruleset
{
  /// <summary>
  /// The standard ruleset.
  /// </summary>
  [Description("osu")]
  Osu,

  /// <summary>
  /// The taiko ruleset.
  /// </summary>
  [Description("taiko")]
  Taiko,

  /// <summary>
  /// The catch the beat ruleset.
  /// </summary>
  [Description("fruits")]
  Catch,

  /// <summary>
  /// The mania ruleset.
  /// </summary>
  [Description("mania")]
  Mania
}
