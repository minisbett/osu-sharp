using Newtonsoft.Json;

namespace OsuSharp.Models.Scores;

/// <summary>
/// Represents the match a score was set in.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/score-json.ts"/>
/// </summary>
public class Match
{
  /// <summary>
  /// TODO: what is this? whether the score is a pass? since the score itself already got that property
  /// </summary>
  [JsonProperty("pass")]
  public bool Pass { get; internal set; }

  /// <summary>
  /// The slot of the player that set the score inside the match.
  /// </summary>
  [JsonProperty("slot")]
  public int Slot { get; internal set; }

  /// <summary>
  /// The number of the team the player was in.
  /// </summary>
  [JsonProperty("team")]
  public int Team { get; internal set; }
}
