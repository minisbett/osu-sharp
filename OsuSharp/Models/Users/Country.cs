using Newtonsoft.Json;

namespace OsuSharp.Models.Users;

/// <summary>
/// Represents the country of an osu! user.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/country-json.ts"/>
/// </summary>
public class Country
{
  /// <summary>
  /// The 2-letter code of this country.
  /// </summary>
  [JsonProperty("code")]
  public string Code { get; private set; } = default!;

  /// <summary>
  /// TODO: what is this?
  /// </summary>
  public int? Display { get; private set; }

  /// <summary>
  /// The name of this country.
  /// </summary>
  [JsonProperty("name")]
  public string Name { get; private set; } = default!;
}
