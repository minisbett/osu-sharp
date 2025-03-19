using Newtonsoft.Json;

namespace osu.NET.Models.Beatmaps;

/// <summary>
/// Represents the amount of required nomations in the main ruleset and non-main ruleset of a beatmapset.<br/>
/// These values are statically defined in the configuration of the osu! servers and are the same for every beatmapset.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-extended-json.ts"/>
/// </summary>
public class RequiredNominationsMeta
{
  /// <summary>
  /// The amount of nominations requrired for the main ruleset of a beatmapset.
  /// </summary>
  [JsonProperty("main_ruleset")]
  public int MainRuleset { get; private set; }


  /// <summary>
  /// The amount of nominations requrired for a non-main ruleset of a beatmapset.
  /// </summary>
  [JsonProperty("non_main_ruleset")]
  public int NonMainRuleset { get; private set; }
}
