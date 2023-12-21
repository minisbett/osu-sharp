using Newtonsoft.Json;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents the amount of times players have failed or exited the beatmap at a certain percentage, representing by each element in the 100-element arrays.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmap-failtimes"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmap-json.ts"/>
/// </summary>
public class Failtimes
{
  /// <summary>
  /// The amount of times players have exited the beatmap at a certain percentage. This may be null.
  /// </summary>
  [JsonProperty("exit")]
  public int[]? Exits { get; private set; }

  /// <summary>
  /// The amount of times players have failed the beatmap at a certain percentage. This may be null.
  /// </summary>
  [JsonProperty("fail")]
  public int[]? Fails { get; private set; }
}
