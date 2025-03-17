using Newtonsoft.Json;

namespace osu_sharp.Models.Users;

/// <summary>
/// Represents the amount of available and total kudosu of a user.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#user-kudosu"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/UserCompactTransformer.php"/>
/// </summary>
public class Kudosu
{
  /// <summary>
  /// The amount of available kudosu.
  /// </summary>
  [JsonProperty("available")]
  public int Available { get; private set; }

  /// <summary>
  /// The amount of total kudosu.
  /// </summary>
  [JsonProperty("total")]
  public int Total { get; private set; }
}
