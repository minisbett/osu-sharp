using osu.NET.Helpers;

namespace osu.NET.Enums;

/// <summary>
/// Represents the type of actions that result in a <see cref="Models.Users.KudosuHistoryEntry"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#kudosuhistory"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/KudosuHistoryTransformer.php"/>
/// </summary>
public enum KudosuAction
{
  /// <summary>
  /// DOCS: what does this mean?
  /// </summary>
  [JsonAPIName("give")]
  Give,

  /// <summary>
  /// DOCS: what does this mean?
  /// </summary>
  [JsonAPIName("vote.give")]
  VoteGive,

  /// <summary>
  /// DOCS: what does this mean?
  /// </summary>
  [JsonAPIName("reset")]
  Reset,

  /// <summary>
  /// DOCS: what does this mean?
  /// </summary>
  [JsonAPIName("vote.reset")]
  VoteReset,

  /// <summary>
  /// DOCS: what does this mean?
  /// </summary>
  [JsonAPIName("revoke")]
  Revoke,

  /// <summary>
  /// DOCS: what does this mean?
  /// </summary>
  [JsonAPIName("vote.revoke")]
  VoteRevoke
}
