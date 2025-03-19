using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Changelogs;

/// <summary>
/// Represents a changelog entry, containing information about a single change made in a build.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#changelogentry"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/ChangelogEntry.php"/>
/// </summary>
public class ChangelogEntry
{
  /// <summary>
  /// The category of this changelog entry, describing the area of change.
  /// </summary>
  [JsonProperty("category")]
  public string Category { get; private set; } = default!;

  /// <summary>
  /// The datetime at which this entry was created. This may be null.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTimeOffset? CreatedAt { get; private set; }

  /// <summary>
  /// The ID of the pull request inside the related GitHub repository that made the changes. This will be null if the change is not open-source.
  /// </summary>
  [JsonProperty("github_pull_request_id")]
  public int? PullRequestId { get; private set; }

  /// <summary>
  /// The URL to the GitHub pull request that made the changes. This will be null if the change is not open-source.
  /// </summary>
  [JsonProperty("github_url")]
  public string? PullRequestUrl { get; private set; }

  /// <summary>
  /// The ID of this changelog entry.
  /// </summary>
  [JsonProperty("id")]
  public int? Id { get; private set; }

  /// <summary>
  /// Bool whether this entry introduces a major change.
  /// </summary>
  [JsonProperty("major")]
  public bool IsMajor { get; private set; }

  /// <summary>
  /// The name of the GitHub user/organization and repository that contains the changes (e.g. "ppy/osu"). This will be null if the change is not open-source.
  /// </summary>
  [JsonProperty("repository")]
  public string? Repository { get; private set; }

  /// <summary>
  /// The title of the changelog entry. This may be null.
  /// </summary>
  [JsonProperty("title")]
  public string? Title { get; private set; }

  /// <summary>
  /// The type of change made (e.g. added, fixed). This may be null.
  /// </summary>
  [JsonProperty("type")]
  public ChangelogEntryType Type { get; private set; }

  /// <summary>
  /// DOCS: what is this? It seems to always be null
  /// </summary>
  [JsonProperty("url")]
  public string? Url { get; private set; }

  /// <summary>
  /// The GitHub user responsible for the changes. This may be null.
  /// </summary>
  [JsonProperty("github_user")]
  public GitHubUser? GitHubUser { get; private set; }

  /// <summary>
  /// A message explaining the changes in this entry. This may be null.
  /// </summary>
  [JsonProperty("message")]
  public string? Message { get; private set; }

  /// <summary>
  /// A message explaining the changes in this entry, including HTML formatting. This may be null.
  /// </summary>
  [JsonProperty("message_html")]
  public string? MessageHtml { get; private set; }
}
