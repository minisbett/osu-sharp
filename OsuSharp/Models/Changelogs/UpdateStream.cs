using Newtonsoft.Json;

namespace OsuSharp.Models.Changelogs;

/// <summary>
/// Represents an update stream of an osu! related software to fetch updates from (Stable, Beta, CuttingEdge, Web...).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#updatestream"/><br/>
/// Sources:<br/>
/// <a href="https://github.com/ppy/osu-web/blob/master/app/Models/UpdateStream.php"/><br/>
/// <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/UpdateStreamTransformer.php"/>
/// </summary>
public class UpdateStream
{
  /// <summary>
  /// The display name for this update stream (e.g. "Beta").
  /// </summary>
  [JsonProperty("display_name")]
  public string DisplayName { get; private set; } = default!;

  /// <summary>
  /// The ID of this update stream.
  /// </summary>
  [JsonProperty("id")]
  public int ID { get; private set; }

  /// <summary>
  /// TODO: what does featured mean?
  /// </summary>
  [JsonProperty("is_featured")]
  public bool IsFeatured { get; private set; }

  /// <summary>
  /// The name for this update stream (e.g. "stable40").
  /// </summary>
  [JsonProperty("name")]
  public string Name { get; private set; } = default!;

  /// <summary>
  /// The latest build for this update stream. This will be null if this <see cref="UpdateStream"/> object is accessed via <see cref="Build.UpdateStream"/>.
  /// </summary>
  [JsonProperty("latest_build")]
  public Build? LatestBuild { get; private set; }

  /// <summary>
  /// The amount of online users currently using this update stream. This will be null if this <see cref="UpdateStream"/> object is accessed via <see cref="Build.UpdateStream"/>.
  /// </summary>
  [JsonProperty("user_count")]
  public int? UserCount { get; private set; }
}
