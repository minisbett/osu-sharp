using osu.NET.Helpers;

namespace osu.NET.Enums;

/// <summary>
/// Represents the grade a score can have. (XH, SH, X, S, A, B, C, D)
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/rank.ts"/>
/// </summary>
public enum Grade
{
  /// <summary>
  /// 100% accuracy, Hidden and/or Flashlight mod.
  /// </summary>
  [JsonAPIName("xh")]
  [JsonAPIName("ssh")]
  XH,

  /// <summary>
  /// 100% accuracy, any mod.
  /// </summary>
  [JsonAPIName("x")]
  [JsonAPIName("ss")]
  X,

  /// <summary>
  /// S-rank accuracy, Hidden and/or Flashlight mod.
  /// </summary>
  [JsonAPIName("sh")]
  SH,

  /// <summary>
  /// S-rank accuracy, any mod.
  /// </summary>
  [JsonAPIName("s")]
  S,

  /// <summary>
  /// A-rank accuracy, any mod.
  /// </summary>
  [JsonAPIName("a")]
  A,

  /// <summary>
  /// B-rank accuracy, any mod.
  /// </summary>
  [JsonAPIName("b")]
  B,

  /// <summary>
  /// C-rank accuracy, any mod.
  /// </summary>
  [JsonAPIName("c")]
  C,

  /// <summary>
  /// D-rank accuracy, any mod.
  /// </summary>
  [JsonAPIName("d")]
  D
}
