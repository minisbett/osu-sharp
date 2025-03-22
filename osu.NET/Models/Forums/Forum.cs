using Newtonsoft.Json;

namespace osu.NET.Models.Forums;

/// <summary>
/// Represents a forum on the osu! website.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#forum189"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/Forum/Forum.php"/>
/// </summary>
public class Forum
{
  /// <summary>
  /// The ID of this forum.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The name of this forum.
  /// </summary>
  [JsonProperty("name")]
  public string Name { get; private set; } = default!;

  /// <summary>
  /// The description of this forum.
  /// </summary>
  [JsonProperty("description")]
  public string Description { get; private set; } = default!;

  /// <summary>
  /// The sub-forums of this forum, up to 2 layers deep. This will be null if this instance is on the 2nd layer of the requested forum.
  /// </summary>
  [JsonProperty("subforums")]
  public Forum[]? SubForums { get; private set; }
}
