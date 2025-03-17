namespace osu_sharp.Enums;

/// <summary>
/// Represents the type of a spotlight.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: Not documented, refer to API responses
/// </summary>
public enum SpotlightType
{
  /// <summary>
  /// Represents a monthly (seasonal) spotlight.
  /// </summary>
  [JsonAPIName("monthly")]
  Monthly,

  /// <summary>
  /// Represents a spotlight evolving around a theme.
  /// </summary>
  [JsonAPIName("theme")]
  [JsonAPIName("spotlight")] // It appears that in the beginning, spotlights that evolved around a theme were defined as type "spotlight" instead
  Theme,

  /// <summary>
  /// Represents a special spotlight.
  /// </summary>
  [JsonAPIName("special")]
  Special
}
