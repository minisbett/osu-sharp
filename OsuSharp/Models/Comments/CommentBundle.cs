using Newtonsoft.Json;
using OsuSharp.Models.Users;

namespace OsuSharp.Models.Comments;

/// <summary>
/// Temporary class to allow cursor pagination on comments, as a proper pagination system is not yet implemented.
/// https://osu.ppy.sh/docs/index.html#cursor
/// </summary>
internal class Cursor
{
  [JsonProperty("id")]
  public int Id { get; private set; }

  [JsonProperty("created_at")]
  public DateTime CreatedAt { get; private set; }
}

/// <summary>
/// Represents a bundle of comments and related data.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#commentbundle"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/comment-json.ts"/>
/// </summary>
public class CommentBundle
{
  /// <summary>
  /// Temporary property to allow cursor pagination on comments, as a proper pagination system is not yet implemented.
  /// </summary>
  [JsonProperty("cursor")]
  internal Cursor Cursor { get; private set; } = default!;

  /// <summary>
  /// The metadata for the commentable objects referenced in the comment objects contained in this bundle.
  /// </summary>
  [JsonProperty("commentable_meta")]
  public CommentableMeta[] CommentableMeta { get; private set; } = default!;

  /// <summary>
  /// The primary comments contained in this bundle.
  /// </summary>
  [JsonProperty("comments")]
  public Comment[] Comments { get; private set; } = default!;

  /// <summary>
  /// TODO: what is this? whether the api has more to return?
  /// </summary>
  [JsonProperty("has_more")]
  public bool HasMore { get; private set; }

  /// <summary>
  /// TODO: what is this?
  /// </summary>
  [JsonProperty("has_more_id")]
  public int? HasMoreId { get; private set; }

  /// <summary>
  /// Comments related to the comments in <see cref="Comments"/>, including both replies and parents of them.
  /// </summary>
  [JsonProperty("included_comments")]
  public Comment[] IncludedComments { get; private set; } = default!;

  /// <summary>
  /// The pinned comments in this bundle, which are also contained in <see cref="Comments"/> or <see cref="IncludedComments"/>.
  /// </summary>
  [JsonProperty("pinned_comments")]
  public Comment[] PinnedComments { get; private set; } = default!;

  /// <summary>
  /// The sort order this bundle was fetched with.
  /// </summary>
  [JsonProperty("sort")]
  public string Sort { get; private set; } = default!;

  /// <summary>
  /// TODO: what is this? the amount of top level comments in all of osu?
  /// </summary>
  [JsonProperty("top_level_count")]
  public int TopLevelCount { get; private set; }

  /// <summary>
  /// TODO: what is this? The total amount of comments in all of osu? including replies?
  /// </summary>
  [JsonProperty("total")]
  public int TotalCount { get; private set; }

  /// <summary>
  /// TODO: what is this? is it current user related? if so, why is it returned on client credentials auth?
  /// </summary>
  [JsonProperty("user_follow")]
  public bool UserFollow { get; private set; }

  /// <summary>
  /// TODO: what is this? Seems to be empty when getting a simple instance of this object
  /// </summary>
  [JsonProperty("user_votes")]
  public int[] UserVotes { get; private set; } = default!;

  /// <summary>
  /// The users involved in this bundle.
  /// </summary>
  [JsonProperty("users")]
  public User[] Users { get; private set; } = default!;
}
