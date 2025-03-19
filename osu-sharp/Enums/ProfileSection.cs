using osu_sharp.Helpers;

namespace osu_sharp.Enums;

/// <summary>
/// Represents the type of section on a users' profile (eg. beatmaps, me! section, kudosu, ...).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#user-profilepage"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-extended-json.ts"/>
/// </summary>
public enum ProfileSection
{
  /// <summary>
  /// The section listing the users' beatmaps.
  /// </summary>
  [JsonAPIName("beatmaps")]
  Beatmaps,

  /// <summary>
  /// The section listing the users' historical data.
  /// </summary>
  [JsonAPIName("historical")]
  Historical,

  /// <summary>
  /// The section listing the users' kudosu information.
  /// </summary>
  [JsonAPIName("kudosu")]
  Kudosu,

  /// <summary>
  /// The me! section of the users' profile.
  /// </summary>
  [JsonAPIName("me")]
  Me,

  /// <summary>
  /// The section listing the users' medals.
  /// </summary>
  [JsonAPIName("medals")]
  Medals,

  /// <summary>
  /// The section listing the users' recent activity.
  /// </summary>
  [JsonAPIName("recent_activity")]
  RecentActivity,

  /// <summary>
  /// The section listing the users' top scores.
  /// </summary>
  [JsonAPIName("top_ranks")]
  TopRanks,

  /// <summary>
  /// The section listing the users' account standing.
  /// </summary>
  [JsonAPIName("account_standing")]
  AccountStanding
}
