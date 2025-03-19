using Newtonsoft.Json;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents an entry in the monthy watched replays from a user.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-replays-watched-count-json.ts"/>
/// </summary>
public class MonthlyReplaysWatchedEntry
{
  /// <summary>
  /// The amount of replays watched this month.
  /// </summary>
  [JsonProperty("count")]
  public int Count { get; private set; }

  /// <summary>
  /// The datetime at which this month started.
  /// </summary>
  [JsonProperty("start_date")]
  public DateTimeOffset StartDate { get; private set; }
}
