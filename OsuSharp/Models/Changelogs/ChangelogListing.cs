using Newtonsoft.Json;

namespace OsuSharp.Models.Changelogs;

/// <summary>
/// Represents osu!'s changelog listing, including the 21 most recent builds (including filters)
/// of the osu! related software and all update streams with their latest build.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-changelog-listing"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/ChangelogController.php"/>
/// </summary>
public class ChangelogListing
{
  /// <summary>
  /// The 21 most recent builds (including filters) builds of the osu! game client.
  /// </summary>
  [JsonProperty("builds")]
  public Build[] Builds { get; private set; } = default!;

  /// <summary>
  /// An array of all update streams of the osu! game client.
  /// </summary>
  [JsonProperty("streams")]
  public UpdateStream[] Streams { get; private set; } = default!;
}
