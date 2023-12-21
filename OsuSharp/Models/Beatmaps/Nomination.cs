using Newtonsoft.Json;
using OsuSharp.Converters;
using OsuSharp.Enums;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents a nomination on a beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#nomination"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-nomination-json.ts"/>
/// </summary>
public class Nomination
{
  /// <summary>
  /// The ID of the beatmapset that this nomination is for.
  /// </summary>
  [JsonProperty("beatmapset_id")]
  public int BeatmapSetId { get; private set; }

  /// <summary>
  /// The rulesets in which this nomination is valid.
  /// </summary>
  [JsonProperty("rulesets")]
  [JsonConverter(typeof(StringEnumConverter))]
  public Ruleset[] Rulesets { get; private set; } = default!;

  /// <summary>
  /// TODO: what is this?
  /// </summary>
  [JsonProperty("reset")]
  public bool Reset { get; private set; }

  /// <summary>
  /// The ID of the user that performed this nomination.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; private set; }
}
