using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the different titles an owner of a commentable object can have (e.g. Mapper).
/// </summary>
public enum CommentableOwnerTitle
{
  /// <summary>
  /// Indicates that the owner of the commentable object is it's mapper.
  /// </summary>
  [Description("MAPPER")]
  Mapper
}
