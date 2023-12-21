using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the types of a forum topic.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#forum-topic"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/Forum/Topic.php"/>
/// </summary>
public enum ForumTopicType
{
  /// <summary>
  /// Indicates a normal forum topic.
  /// </summary>
  [Description("normal")]
  Normal,

  /// <summary>
  /// Indicates a forum topic that is sticked to the top of the forum.
  /// </summary>
  [Description("sticky")]
  Sticky,

  /// <summary>
  /// Indicates that the forum topic is an announcement.
  /// </summary>
  [Description("announcement")]
  Announcement
}
