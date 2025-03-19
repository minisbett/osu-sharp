using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Beatmaps;

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
  /// Bool whether this nomination has been reset/withdrawn.
  /// </summary>
  [JsonProperty("reset")]
  public bool IsReset { get; private set; }

  /// <summary>
  /// The rulesets in which this nomination is valid.
  /// </summary>
  [JsonProperty("rulesets")]
  public Ruleset[] Rulesets { get; private set; } = default!;

  /// <summary>
  /// The ID of the user that performed this nomination.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; private set; }
}
