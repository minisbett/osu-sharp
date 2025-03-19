using Newtonsoft.Json;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents the me! section of a users' profile page.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#user"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-json.ts"/>
/// </summary>
public class UserPage
{
  /// <summary>
  /// The me! section of a users' profile page as a pre-rendered HTML string.
  /// </summary>
  [JsonProperty("html")]
  public string Html { get; private set; } = default!;

  /// <summary>
  /// The me! section of a users' profile page as a raw string.
  /// </summary>
  [JsonProperty("raw")]
  public string Raw { get; private set; } = default!;
}
