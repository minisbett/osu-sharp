using System.ComponentModel;

namespace OsuSharp.Enums;


/// <summary>
/// An enum containing the type of beatmap packs that exist.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmappacktype"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/BeatmapPack.php#L36"/>
/// </summary>
public enum BeatmapPackType
{
  /// <summary>
  /// Targets all beatmap packs. ("S")
  /// </summary>
  [Description("standard")]
  Standard,

  /// <summary>
  /// Targets all beatmap packs including featured artists. (F")
  /// </summary>
  [Description("featured")]
  Featured,

  /// <summary>
  /// Targets all beatmap packs from tournaments. ("P")
  /// </summary>
  [Description("tournament")]
  Tournament,

  /// <summary>
  /// Targets all beatmap packs containing loved beatmaps. ("L")
  /// </summary>
  [Description("loved")]
  Loved,

  /// <summary>
  /// Targets all beatmap packs from the spotlights. ("R")
  /// </summary>
  [Description("chart")]
  Chart,

  /// <summary>
  /// Targets all beatmap packs targetting a theme. ("T")
  /// </summary>
  [Description("theme")]
  Theme,

  /// <summary>
  /// Targets all beatmap packs targetting an artist. ("A")
  /// </summary>
  [Description("artist")]
  Artist
}
