using osu.NET.Helpers;

namespace osu.NET.Enums;

/// <summary>
/// An enum containing the possible types of beatmap packs.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmappacktype"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/BeatmapPack.php"/>
/// </summary>
public enum BeatmapPackType
{
  /// <summary>
  /// Targets all beatmap packs.
  /// </summary>
  [QueryAPIName("standard")]
  Standard,

  /// <summary>
  /// Targets all beatmap packs consisting of featured artist songs.
  /// </summary>
  [QueryAPIName("featured")]
  Featured,

  /// <summary>
  /// Targets all beatmap packs from tournaments.
  /// </summary>
  [QueryAPIName("tournament")]
  Tournament,

  /// <summary>
  /// Targets all beatmap packs consisting of loved beatmaps.
  /// </summary>
  [QueryAPIName("loved")]
  Loved,

  /// <summary>
  /// Targets all beatmap packs from the spotlights.
  /// </summary>
  [QueryAPIName("chart")]
  Chart,

  /// <summary>
  /// Targets all beatmap packs targetting a theme.
  /// </summary>
  [QueryAPIName("theme")]
  Theme,

  /// <summary>
  /// Targets all beatmap packs targetting an artist.
  /// </summary>
  [QueryAPIName("artist")]
  Artist
}