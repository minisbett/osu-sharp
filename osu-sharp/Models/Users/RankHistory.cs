using Newtonsoft.Json;
using osu_sharp.Enums;

namespace osu_sharp.Models.Users;

/// <summary>
/// Represents the history of a users' rank in a specific ruleset.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/rank-history-json.ts"/>
/// </summary>
public class RankHistory
{
  /// <summary>
  /// The rank of the past 90 days.
  /// </summary>
  [JsonProperty("data")]
  public int[] Data { get; private set; } = default!;

  /// <summary>
  /// The ruleset this rank history is for.
  /// </summary>
  [JsonProperty("mode")]
  public Ruleset Ruleset { get; private set; }
}
