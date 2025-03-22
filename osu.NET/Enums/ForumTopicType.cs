using osu.NET.Helpers;

namespace osu.NET.Enums;

/// <summary>
/// Represents the type of a forum topic.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#forum-topic"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/Forum/Topic.php"/>
/// </summary>
public enum ForumTopicType
{
  /// <summary>
  /// The forum topic is a normal topic.
  /// </summary>
  [JsonAPIName("normal")]
  Normal,

  /// <summary>
  /// The forum topic is stickied to the top of the forum.
  /// </summary>
  [JsonAPIName("sticky")]
  Sticky,

  /// <summary>
  /// The forum topic is an announcement.
  /// </summary>
  [JsonAPIName("announcement")]
  Announcement,
}
