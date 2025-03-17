namespace osu_sharp.Enums;

/// <summary>
/// Represents the playstyle of a user. A user can have multiple playstyles.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: Not documented, refer to API response and <a href="https://osu.ppy.sh/home/account/edit"/>
/// </summary>
public enum Playstyle
{
  /// <summary>
  /// The user plays with a mouse.
  /// </summary>
  [JsonAPIName("mouse")]
  Mouse,

  /// <summary>
  /// The user plays with a keyboard.
  /// </summary>
  [JsonAPIName("keyboard")]
  Keyboard,

  /// <summary>
  /// The user plays with a graphics tablet.
  /// </summary>
  [JsonAPIName("tablet")]
  Tablet,

  /// <summary>
  /// The user plays with a touch screen.
  /// </summary>
  [JsonAPIName("touch")]
  Touch
}
