using Newtonsoft.Json;
using OsuSharp.Converters;
using OsuSharp.Enums;

namespace OsuSharp.Models.Users;

/// <summary>
/// Represents the history of a user's rank in a specific ruleset.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/rank-history-json.ts"/>
/// </summary>
public class RankHistory
{
  /// <summary>
  /// The ranks from the past.
  /// </summary>
  [JsonProperty("data")]
  public int[] Data { get; private set; } = default!;

  /// <summary>
  /// The ruleset this rank history is for.
  /// </summary>
  [JsonProperty("mode")]
  [JsonConverter(typeof(StringEnumConverter))]
  public Ruleset Ruleset { get; private set; }
}
