using Newtonsoft.Json;

namespace osu.NET.Models.Beatmaps;

/// <summary>
/// Represents the owner of a beatmap difficulty.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmap-owner-json.ts"/>
/// </summary>
public class BeatmapOwner
{
  /// <summary>
  /// The ID of the user.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The name of the user.
  /// </summary>
  [JsonProperty("username")]
  public string Username { get; private set; } = default!;
}
