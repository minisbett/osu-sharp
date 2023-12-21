using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the types of relation between two osu! useres.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-relation-json.ts"/>
/// </summary>
public enum UserRelationType
{
  /// <summary>
  /// The user blocked the other user.
  /// </summary>
  [Description("block")]
  Block,

  /// <summary>
  /// The user friended the other user.
  /// </summary>
  [Description("friend")]
  Friend
}
