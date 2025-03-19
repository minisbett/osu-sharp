using osu_sharp.Helpers;

namespace osu_sharp.Enums;

/// <summary>
/// Represents the type of objects that can be related to a <see cref="Models.Users.KudosuHistoryEntry"/>.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/KudosuHistoryTransformer.php"/>
/// </summary>
public enum KudosuModel
{
  /// <summary>
  /// The kudosu history entry comes from a forum post. This only applies to older beatmap discussions, which were forum posts.
  /// </summary>
  [JsonAPIName("forum_post")]
  ForumPost,

  /// <summary>
  /// The kudosu history entry comes from a beatmap discussion (not a legacy forum post).
  /// </summary>
  [JsonAPIName("beatmap_discussion")]
  BeatmapDiscussion
}
