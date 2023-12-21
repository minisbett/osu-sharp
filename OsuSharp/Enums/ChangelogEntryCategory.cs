using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// The category of a changelog entry, describing the area of change.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/database/factories/ChangelogFactory.php"/>
/// </summary>
public enum ChangelogEntryCategory
{
  /// <summary>
  /// Indicates a web-related change.
  /// </summary>
  [Description("Web")]
  Web,

  /// <summary>
  /// Indicates an audio-related change.
  /// </summary>
  [Description("Audio")]
  Audio,

  /// <summary>
  /// Indicates a code-related change.
  /// </summary>
  [Description("Code")]
  Code,

  /// <summary>
  /// Indicates an editor-related change.
  /// </summary>
  [Description("Editor")]
  Editor,

  /// <summary>
  /// Indicates a gameplay-related change.
  /// </summary>
  [Description("Gameplay")]
  Gameplay,

  /// <summary>
  /// Indicates an osu!standard gameplay-related change.
  /// </summary>
  [Description("Gameplay (osu!)")]
  GameplayOsu,

  /// <summary>
  /// Indicates an osu!catch gameplay-related change.
  /// </summary>
  [Description("Gameplay (osu!catch)")]
  GameplayCatch,

  /// <summary>
  /// Indicates an osu!taiko gameplay-related change.
  /// </summary>
  [Description("Gameplay (osu!taiko)")]
  GameplayTaiko,

  /// <summary>
  /// Indicates an osu!mania gameplay-related change.
  /// </summary>
  [Description("Gameplay (osu!mania)")]
  GameplayMania,

  /// <summary>
  /// Indicates a graphics-related change.
  /// </summary>
  [Description("Graphics")]
  Graphics,

  /// <summary>
  /// Indicates a song selection-related change.
  /// </summary>
  [Description("Song Select")]
  SongSelect,

  /// <summary>
  /// Indicates a reliability-related change.
  /// </summary>
  [Description("Reliability")]
  Reliability,

  /// <summary>
  /// Indicates a UI-related change.
  /// </summary>
  [Description("UI")]
  UI,

  /// <summary>
  /// Indicates a code quality-related change.
  /// </summary>
  [Description("Code Quality")]
  CodeQuality,

  /// <summary>
  /// Indicates a testing-related change.
  /// </summary>
  [Description("Testing")]
  Testing,

  /// <summary>
  /// Indicates a online-related change.
  /// </summary>
  [Description("Online")]
  Online,

  /// <summary>
  /// Indicates a results-related change.
  /// </summary>
  [Description("Results")]
  Results,

  /// <summary>
  /// Indicates a framework-related change.
  /// </summary>
  [Description("Framework")]
  Framework,

  /// <summary>
  /// Indicates a mobile-related change.
  /// </summary>
  [Description("Mobile")]
  Mobile,

  /// <summary>
  /// Indicates a skin editor-related change.
  /// </summary>
  [Description("Skin Editor")]
  SkinEditor,

  /// <summary>
  /// Indicates a multiplayer-related change.
  /// </summary>
  [Description("Multiplayer")]
  Multiplayer,

  /// <summary>
  /// Indicates a tournament-related change.
  /// </summary>
  [Description("Tournament")]
  Tournament,

  /// <summary>
  /// Indicates a settings-related change.
  /// </summary>
  [Description("Settings")]
  Settings,

  /// <summary>
  /// Indicates a performance-related change.
  /// </summary>
  [Description("Performance")]
  Performance,

  /// <summary>
  /// Indicates a wiki-related change.
  /// </summary>
  [Description("Wiki")]
  Wiki,

  /// <summary>
  /// Indicates a localisation-related change.
  /// </summary>
  [Description("Localisation")]
  Localisation,

  /// <summary>
  /// Indicates a miscellaneous change.
  /// </summary>
  [Description("Misc")]
  Miscellaneous,

  /// <summary>
  /// Indicates a difficulty calculation-related change.
  /// </summary>
  [Description("Difficulty Calculation")]
  DifficultyCalculation,

  /// <summary>
  /// Indicates an API-related change.
  /// </summary>
  [Description("Api")]
  API,

  /// <summary>
  /// Indicates a cosmetic-related change.
  /// </summary>
  [Description("Cosmetic")]
  Cosmetic,

  /// <summary>
  /// Indicates a chat-related change.
  /// </summary>
  [Description("Chat")]
  Chat,

  /// <summary>
  /// Indicates a skinning-related change.
  /// </summary>
  [Description("Skinning")]
  Skinning,

  /// <summary>
  /// Indicates a main menu-related change.
  /// </summary>
  [Description("Main Menu")]
  MainMenu,

  /// <summary>
  /// Indicates a spectator-related change.
  /// </summary>
  [Description("Spectator")]
  Spectator
}
