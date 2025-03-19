using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Scores;

/// <summary>
/// Represents a score.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#score"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/score-json.ts"/>
/// </summary>
public class Score
{
  /// <summary>
  /// The accuracy of this score.
  /// </summary>
  [JsonProperty("accuracy")]
  public float Accuracy { get; private set; }

  /// <summary>
  /// The ID of the beatmap this score was set on.
  /// </summary>
  [JsonProperty("beatmap_id")]
  public int BeatmapId { get; private set; }

  /// <summary>
  /// The ID of the best score the player of this score achieved on the beatmap. This will be null if the player has no better score on the beatmap.
  /// </summary>
  [JsonProperty("best_id")]
  public long? BestId { get; private set; }

  /// <summary>
  /// The ID of the osu! client build this score was set on. This may be null.
  /// </summary>
  [JsonProperty("build_id")]
  public int? BuildId { get; private set; }

  /// <summary>
  /// The datetime at which this score was submitted to the osu! servers.
  /// </summary>
  [JsonProperty("ended_at")]
  public DateTimeOffset SubmittedAt { get; private set; }

  /// <summary>
  /// Bool whether this score has an available replay.
  /// </summary>
  [JsonProperty("has_replay")]
  public bool HasReplay { get; private set; }

  /// <summary>
  /// The ID of this score.
  /// </summary>
  [JsonProperty("id")]
  public long Id { get; private set; }

  /// <summary>
  /// Bool whether the score has the maximum combo possible.
  /// </summary>
  [JsonProperty("is_perfect_combo")]
  public bool IsPerfectCombo { get; private set; }

  /// <summary>
  /// Bool whether the score has the maximum combo possible by legacy definition.
  /// </summary>
  [JsonProperty("legacy_perfect")]
  public bool IsPerfectComboLegacy { get; private set; }

  /// <summary>
  /// The legacy, ruleset-specific ID of this score. This will be null if the score is not a legacy score.
  /// </summary>
  [JsonProperty("legacy_score_id")]
  public long? LegacyScoreId { get; private set; }

  /// <summary>
  /// The legacy total score of this score. This will be null if the score is not a legacy score.
  /// </summary>
  [JsonProperty("legacy_total_score")]
  public int? LegacyTotalScore { get; private set; }

  /// <summary>
  /// The maximum combo achieved in this score.
  /// </summary>
  [JsonProperty("max_combo")]
  public int MaxCombo { get; private set; }

  /// <summary>
  /// The maximum possible statistics (hit judgments) this score can have.
  /// </summary>
  [JsonProperty("maximum_statistics")]
  public ScoreStatistics MaximumStatistics { get; private set; } = default!;

  /// <summary>
  /// The mods used for this score.
  /// </summary>
  [JsonProperty("mods")]
  public Mod[] Mods { get; private set; } = default!;

  /// <summary>
  /// Bool whether this score passed the beatmap.
  /// </summary>
  [JsonProperty("passed")]
  public bool IsPassed { get; private set; }

  /// <summary>
  /// The amount of performance points the score is worth. This will be null if the score is not ranked.
  /// </summary>
  [JsonProperty("pp")]
  public float? PP { get; private set; }

  /// <summary>
  /// The grade of this score. (XH, X, SH, S, A, B, C, D)
  /// </summary>
  [JsonProperty("rank")]
  public Grade Grade { get; private set; }

  /// <summary>
  /// The ruleset this score was achieved in.
  /// </summary>
  [JsonProperty("ruleset_id")]
  public Ruleset Ruleset { get; private set; }

  /// <summary>
  /// The datetime at which the player started the score. This may be null.
  /// </summary>
  [JsonProperty("started_at")]
  public DateTimeOffset? StartedAt { get; private set; }

  /// <summary>
  /// The statistics (hit judgments) of this score.
  /// </summary>
  [JsonProperty("statistics")]
  public ScoreStatistics Statistics { get; private set; } = default!;

  /// <summary>
  /// The total score of this score in the ScoreV3 (osu!lazer) format. If this is a legacy score, it is server-side estimated.
  /// </summary>
  [JsonProperty("total_score")]
  public int TotalScore { get; private set; }

  /// <summary>
  /// The <see cref="TotalScore"/> of this score, excluding mod multipliers.
  /// </summary>
  [JsonProperty("total_score_without_mods")]
  public int TotalScoreWithoutMods { get; private set; }

  /// <summary>
  /// The ID of the player of this score.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; private set; }

  /// <summary>
  /// The total score of this score in ScoreV1 (osu!stable) format, server-side estimated from the ScoreV3 total score (<see cref="TotalScore"/>).<br/>
  /// If this is a legacy score, this is the total score estimated in ScoreV3 (osu!lazer), then back in ScoreV1 (osu!stable).
  /// </summary>
  [JsonProperty("classic_total_score")]
  public int ClassicTotalScore { get; private set; }

  /// <summary>
  /// Bool whether this score is preserved and not marked for deletion.
  /// </summary>
  [JsonProperty("preserve")]
  public bool IsPreserved { get; private set; }

  /// <summary>
  /// Bool whether this score was fully processed by the osu! score submission (PP calculation, statistics updating, ...).
  /// </summary>
  [JsonProperty("processed")]
  public bool IsProcessed { get; private set; }

  /// <summary>
  /// Bool whether this score is considered ranked. Scores with unranked mods or rulesets may not be considered ranked, despite being set on a ranked beatmap.
  /// </summary>
  [JsonProperty("ranked")]
  public bool IsRanked { get; private set; }
}