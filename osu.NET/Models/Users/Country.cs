using Newtonsoft.Json;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents the country of an osu! user.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/country-json.ts"/>
/// </summary>
public class Country
{
  /// <summary>
  /// The BCP 47 language tag of this country.
  /// </summary>
  [JsonProperty("code")]
  public string Code { get; private set; } = default!;

  /// <summary>
  /// DOCS: what is this?
  /// </summary>
  [JsonProperty("display")]
  public int? Display { get; private set; }

  /// <summary>
  /// The name of this country.
  /// </summary>
  [JsonProperty("name")]
  public string Name { get; private set; } = default!;
}
