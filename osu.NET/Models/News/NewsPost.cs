using Newtonsoft.Json;

namespace osu.NET.Models.News;

/// <summary>
/// Represents a news post on the osu! website.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#newspost"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/news-post-json.ts"/>
/// </summary>
public class NewsPost
{
  /// <summary>
  /// The author(s) of this news post.
  /// </summary>
  [JsonProperty("author")]
  public string Author { get; private set; } = default!;

  /// <summary>
  /// The URL to edit this news post on GitHub.
  /// </summary>
  [JsonProperty("edit_url")]
  public string EditUrl { get; private set; } = default!;

  /// <summary>
  /// The URL to the first image in this post (thumbnail). This will be null if the post has no images.
  /// </summary>
  [JsonProperty("first_image")]
  public string? FirstImage { get; private set; }

  /// <summary>
  /// The ID of this news post.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The datetime at which this news post was published.
  /// </summary>
  [JsonProperty("published_at")]
  public DateTime PublishedAt { get; private set; }

  /// <summary>
  /// The slug of this news post. (eg. <c>2021-04-27-results-a-labour-of-love</c>)
  /// </summary>
  [JsonProperty("slug")]
  public string Slug { get; private set; } = default!;

  /// <summary>
  /// The title of this news post.
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; private set; } = default!;

  /// <summary>
  /// The datetime at which this post was last updated.
  /// </summary>
  [JsonProperty("updated_at")]
  public DateTime UpdatedAt { get; private set; }

  /// <summary>
  /// The HTML content of this news post. This will be null if this news post object was requested alongside multiple others.
  /// </summary>
  [JsonProperty("content")]
  public string? Content { get; private set; }

  /// <summary>
  /// The navigation metadata for this news post, which contains the chronologically previous and next news post.
  /// This will be null if this news post was accessed from a <see cref="News.Navigation"/> object.
  /// </summary>
  [JsonProperty("navigation")]
  public Navigation? Navigation { get; private set; }

  /// <summary>
  /// The preview of this news post, which is the first paragraph of content with HTML markup stripped.
  /// This will be null if this news post object was not requested alongside multiple others.
  /// </summary>
  [JsonProperty("preview")]
  public string? Preview { get; private set; }
}
