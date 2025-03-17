using Newtonsoft.Json;

namespace osu_sharp.Models.Users;

/// <summary>
/// Represents the user that causes a <see cref="KudosuHistoryEntry"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#kudosuhistory"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/KudosuHistoryTransformer.php"/>
/// </summary>
public class KudosuGiver
{
  /// <summary>
  /// The profile URL of the user that caused the kudosu history entry.
  /// </summary>
  [JsonProperty("url")]
  public string Url { get; private set; } = default!;

  /// <summary>
  /// The name of the user that caused the kudosu history entry.
  /// </summary>
  [JsonProperty("username")]
  public string Name { get; private set; } = default!;
}
