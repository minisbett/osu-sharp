using osu_sharp.Helpers;

namespace osu_sharp.Enums;

/// <summary>
/// Represents the name of an update stream (stable40, beta40, cuttingedge, lazer, web).
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: Not documented, refer to API response
/// </summary>
public enum UpdateStreamName
{
  /// <summary>
  /// Represents the stable update stream of the osu!stable client.
  /// </summary>
  [QueryAPIName("stable40")]
  [JsonAPIName("stable40")]
  Stable40,

  /// <summary>
  /// Represents the beta update stream of the osu!stable client.
  /// </summary>
  [QueryAPIName("beta40")]
  [JsonAPIName("beta40")]
  Beta40,

  /// <summary>
  /// Represents the cutting edge update stream of the osu!stable client.
  /// </summary>
  [QueryAPIName("cuttingedge")]
  [JsonAPIName("cuttingedge")]
  CuttingEdge,

  /// <summary>
  /// Represents the update stream of the osu!lazer client.
  /// </summary>
  [QueryAPIName("lazer")]
  [JsonAPIName("lazer")]
  Lazer,

  /// <summary>
  /// Represents the update stream of osu!web.
  /// </summary>
  [QueryAPIName("web")]
  [JsonAPIName("web")]
  Web
}
