using Newtonsoft.Json;
using osu_sharp.Enums;

namespace osu_sharp.Models.Scores;

/// <summary>
/// Represents the osu!mania key variant-specific statistics of a user.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-statistics-json.ts"/>
/// </summary>
public class StatisticsVariant
{
  /// <summary>
  /// The country rank in this variant. This may be null.
  /// </summary>
  [JsonProperty("country_rank")]
  public int CountryRank { get; private set; }

  /// <summary>
  /// The global rank in this variant. This may be null.
  /// </summary>
  [JsonProperty("global_rank")]
  public int GlobalRank { get; private set; }

  /// <summary>
  /// The ruleset this variant is for. Currently, this is always osu!mania.
  /// </summary>
  [JsonProperty("mode")]
  public Ruleset Ruleset { get; private set; }

  /// <summary>
  /// The variant type.
  /// </summary>
  [JsonProperty("variant")]
  public VariantType Variant { get; private set; }
}
