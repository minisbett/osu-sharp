namespace osu_sharp.Enums;

/// <summary>
/// Represents the type of a <see cref="Models.Beatmaps.Discussions.SystemMessage"/> on a discussion post.
/// <br/><br/>
/// API docs: Undocumented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-discussion-post-json.ts"/>
/// </summary>
public enum SystemMessageType
{
  /// <summary>
  /// The system message indicates the resolval/un-resolval of a discussion post.
  /// </summary>
  [JsonAPIName("resolved")]
  Resolved
}
