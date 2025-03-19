using Newtonsoft.Json;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents the level and progress of a user.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-statistics-json.ts"/>
/// </summary>
public class Level
{
  /// <summary>
  /// The current level of the user.
  /// </summary>
  [JsonProperty("current")]
  public int Current { get; private set; }

  /// <summary>
  /// The current percentage of the user's progress to the next level.
  /// </summary>
  [JsonProperty("progress")]
  public int Progress { get; private set; }
}