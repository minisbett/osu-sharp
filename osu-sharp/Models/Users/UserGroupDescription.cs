using Newtonsoft.Json;

namespace osu_sharp.Models.Users;

/// <summary>
/// Represents the description of a <seealso cref="UserGroup"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#group-description"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/group-json.ts"/>
/// </summary>
public class GroupDescription
{
  /// <summary>
  /// The description of the group, as a pre-rendered HTML string.
  /// </summary>
  [JsonProperty("html")]
  public string Html { get; private set; } = default!;

  /// <summary>
  /// The description of the group, as a markdown string.
  /// </summary>
  [JsonProperty("markdown")]
  public string Markdown { get; private set; } = default!;
}