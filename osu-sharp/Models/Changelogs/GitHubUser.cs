using Newtonsoft.Json;

namespace osu_sharp.Models.Changelogs;

/// <summary>
/// Represents the GitHub user responsible for a changelog entry.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#githubuser"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/GithubUserTransformer.php"/>
/// </summary>
public class GitHubUser
{
  /// <summary>
  /// The display name of this GitHub user.
  /// </summary>
  [JsonProperty("display_name")]
  public string DisplayName { get; private set; } = null!;

  /// <summary>
  /// The URL to this GitHub user account. This may be null.
  /// </summary>
  [JsonProperty("github_url")]
  public string? GitHubUrl { get; private set; }

  /// <summary>
  /// The name of this GitHub user. This may be null.
  /// </summary>
  [JsonProperty("github_username")]
  public string? GitHubUsername { get; private set; }

  /// <summary>
  /// The ID of this GitHub user object. This may be null.
  /// </summary>
  [JsonProperty("id")]
  public int? Id { get; private set; }

  /// <summary>
  /// The osu! username of this GitHub user. This may be null.
  /// </summary>
  [JsonProperty("osu_username")]
  public string? Username { get; private set; }

  /// <summary>
  /// The ID of the osu! account of this GitHub user. This may be null.
  /// </summary>
  [JsonProperty("user_id")]
  public int? UserId { get; private set; }

  /// <summary>
  /// The URL to the osu! account of this GitHub user. This may be null.
  /// </summary>
  [JsonProperty("user_url")]
  public string? Url { get; private set; }
}
