using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Comments;

/// <summary>
/// Represents metadata about an object that was commented on.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#commentablemeta"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/comment-json.ts"/>
/// </summary>
public class CommentableMeta
{
  /// <summary>
  /// The ID of the commentable object (e.g. beatmapset ID). This will be null if the commentable object was deleted.
  /// </summary>
  public int? Id { get; private set; }

  /// <summary>
  /// The ID of the user that owns the commentable object (eg. beatmapset owner).
  /// This will be null if the commentable object has no owner or has been deleted.
  /// </summary>
  [JsonProperty("owner_id")]
  public int? OwnerId { get; private set; }

  /// <summary>
  /// The type of relation between the commentable object and its' owner. This will be null if the commentable object has no owner or has been deleted.
  /// </summary>
  [JsonProperty("owner_title")]
  public CommentableOwnerTitle? OwnerTitle { get; private set; }

  /// <summary>
  /// The display title for the commentable object (e.g. the title of the beatmapset). If the commentable object was deleted, this will be "Deleted Item".
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; private set; } = default!;

  /// <summary>
  /// The URL to the commentable object. This will be null if the commentable object was deleted.
  /// </summary>
  [JsonProperty("url")]
  public string? Url { get; private set; } = default!;
}
