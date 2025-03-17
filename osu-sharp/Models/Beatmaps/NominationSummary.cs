using Newtonsoft.Json;
using osu_sharp.Enums;

namespace osu_sharp.Models.Beatmaps;

/// <summary>
/// Represents the nomination progress of a beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapsetextended"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-extended-json.ts"/>
/// </summary>
public class NominationSummary
{
  /// <summary>
  /// The amount of nominations this beatmapset currently has.
  /// </summary>
  [JsonProperty("current")]
  public int Current { get; private set; }

  /// <summary>
  /// The eligible main rulesets of the beatmapset (all rulesets with the highest amount of difficulties).
  /// </summary>
  [JsonProperty("eligible_main_rulesets")]
  public Ruleset[]? Rulesets { get; private set; }

  /// <summary>
  /// The amount of nominations required for the main ruleset and non-main rulesets.<br/>
  /// These values are statically defined in the configuration of the osu! servers and are the same for every beatmapset.
  /// </summary>
  [JsonProperty("required_meta")]
  public RequiredNominationsMeta RequiredNominations { get; private set; } = default!;
}
