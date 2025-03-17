using Newtonsoft.Json;
using osu_sharp.Models.Users;

namespace osu_sharp.Models.Comments;

/// <summary>
/// Represents a bundle of comments and related data.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#commentbundle"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/comment-json.ts"/>
/// </summary>
public class CommentBundle
{
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
  /// DOCS: what is this? whether the api has more to return?
  /// </summary>
  [JsonProperty("has_more")]
  public bool HasMore { get; private set; }

  /// <summary>
  /// DOCS: what is this?
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
  /// The amount of top-level comments in this bundle.
  /// </summary>
  [JsonProperty("top_level_count")]
  public int TopLevelCount { get; private set; }

  /// <summary>
  /// DOCS: what is this? The total amount of comments on the commentable? including replies?
  /// </summary>
  [JsonProperty("total")]
  public int TotalCount { get; private set; }

  /// <summary>
  /// DOCS: what is this? is it current user related? if so, why is it returned on client credentials auth?
  /// </summary>
  [JsonProperty("user_follow")]
  public bool UserFollow { get; private set; }

  /// <summary>
  /// DOCS: what is this? Seems to be empty
  /// </summary>
  [JsonProperty("user_votes")]
  public int[] UserVotes { get; private set; } = default!;

  /// <summary>
  /// The users involved in this bundle.
  /// </summary>
  [JsonProperty("users")]
  public User[] Users { get; private set; } = default!;
}