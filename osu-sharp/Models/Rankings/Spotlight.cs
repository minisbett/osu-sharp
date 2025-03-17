using Newtonsoft.Json;
using osu_sharp.Enums;

namespace osu_sharp.Models.Rankings;

/// <summary>
/// Represents an osu! spotlight.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#spotlight"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/Spotlight.php"/>
/// </summary>
public class Spotlight
{
  /// <summary>
  /// The ID of the spotlight.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// Bool whether the spotlight is specific to a ruleset.
  /// </summary>
  [JsonProperty("mode_specific")]
  public bool IsModeSpecific { get; private set; }

  /// <summary>
  /// The amount of participants in the spotlight. This will be null if not requesting a single spotlight.
  /// </summary>
  [JsonProperty("participant_amount")]
  public int? ParticipantAmount { get; private set; }

  /// <summary>
  /// The name of the spotlight.
  /// </summary>
  [JsonProperty("name")]
  public string Name { get; private set; } = default!;

  /// <summary>
  /// The datetime at which the spotlight starts.
  /// </summary>
  [JsonProperty("start_date")]
  public DateTimeOffset StartDate { get; private set; }

  /// <summary>
  /// The type of the spotlight.
  /// </summary>
  [JsonProperty("type")]
  public SpotlightType Type { get; private set; } = default!;
}
