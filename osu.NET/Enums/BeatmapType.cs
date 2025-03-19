using osu.NET.Helpers;

namespace osu.NET.Enums;

/// <summary>
/// Represents the beatmap type of beatmaps listed on a users' profile.
/// This includes ranked, pending, guest difficulties, etc., as well as favourited beatmaps.<br/>
/// The most played beatmaps are not included in this enum as the response type differs,
/// meaning the API client provides an additional method for that specific type.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-user-beatmaps"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/UsersController.php"/>
/// </summary>
public enum BeatmapType
{
  /// <summary>
  /// The beatmap is in the favourited beatmaps section of the user.
  /// </summary>
  [QueryAPIName("favourite")]
  Favourite,

  /// <summary>
  /// The beatmap is in the graveyarded section of the user.
  /// </summary>
  [QueryAPIName("graveyard")]
  Graveyard,

  /// <summary>
  /// The beatmap is in the guest difficulty section of the user.
  /// </summary>
  [QueryAPIName("guest")]
  Guest,

  /// <summary>
  /// The beatmap is in the loved beatmaps section of the user.
  /// </summary>
  [QueryAPIName("loved")]
  Loved,

  /// <summary>
  /// The beatmap is in the nominated beatmap section of the user.
  /// </summary>
  [QueryAPIName("nominated")]
  Nominated,

  /// <summary>
  /// The beatmap is in the pending beatmaps section of the user.
  /// </summary>
  [QueryAPIName("pending")]
  Pending,

  /// <summary>
  /// The beatmap is in the ranked beatmaps section of the user.
  /// </summary>
  [QueryAPIName("ranked")]
  Ranked
}
