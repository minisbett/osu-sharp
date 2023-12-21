using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the types of user account history entries.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#user-useraccounthistory"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-account-history-json.ts"/>
/// </summary>
public enum UserAccountHistoryEntryType
{
  /// <summary>
  /// The user account history entry represents a note.
  /// </summary>
  [Description("note")]
  Note,

  /// <summary>
  /// The user account history entry represents a restriction.
  /// </summary>
  [Description("restriction")]
  Restriction,

  /// <summary>
  /// The user account history entry represents a silence.
  /// </summary>
  [Description("silence")]
  Silence,

  /// <summary>
  /// The user account history entry represents a tournament ban.
  /// </summary>
  [Description("tournament_ban")]
  TournamentBan
}
