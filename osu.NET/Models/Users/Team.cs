using Newtonsoft.Json;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents the team of an osu! user.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/team-json.ts"/>
/// </summary>
public class Team
{
  /// <summary>
  /// The URL of the flag of this team. This will be null if no flag was set.
  /// </summary>
  [JsonProperty("flag_url")]
  public string? FlagUrl { get; private set; }

  /// <summary>
  /// The ID of this team.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The name of this team.
  /// </summary>
  [JsonProperty("name")]
  public string Name { get; private set; } = default!;

  /// <summary>
  /// The short name/tag of this team.
  /// </summary>
  [JsonProperty("short_name")]
  public string ShortName { get; private set; } = default!;
}
