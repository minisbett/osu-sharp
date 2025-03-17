using Newtonsoft.Json;

namespace osu_sharp.Models.Users;

/// <summary>
/// Represents the daily challenge statistics of a user.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/daily-challenge-user-stats-json.ts"/>
/// </summary>
public class DailyChallengeUserStats
{
  /// <summary>
  /// The highest daily streak of the user.
  /// </summary>
  [JsonProperty("daily_streak_best")]
  public int BestDailyStreak { get; private set; }

  /// <summary>
  /// The current daily streak of the user.
  /// </summary>
  [JsonProperty("daily_streak_current")]
  public int CurrentDailyStreak { get; private set; }

  /// <summary>
  /// The datetime at which these statistics were last updated. This may be null.
  /// </summary>
  [JsonProperty("last_update")]
  public DateTime? LastUpdate { get; private set; }

  /// <summary>
  /// DOCS: what is this?
  /// </summary>
  [JsonProperty("last_weekly_streak")]
  public DateTime? LastWeeklyStreak { get; private set; }

  /// <summary>
  /// The amount of daily challenges the user has played.
  /// </summary>
  [JsonProperty("playcount")]
  public int Playcount { get; private set; }

  /// <summary>
  /// The amount of times the user has placed in the top 10% of a daily challenge.
  /// </summary>
  [JsonProperty("top_10p_placements")]
  public int Top10PercentPlacement { get; private set; }

  /// <summary>
  /// The amount of times the user has placed in the top 50% of a daily challenge.
  /// </summary>
  [JsonProperty("top_50p_placements")]
  public int Top50PercentPlacement { get; private set; }

  /// <summary>
  /// The ID of the user these statistics belong to.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; private set; }

  /// <summary>
  /// The highest weekly streak of the user.
  /// </summary>
  [JsonProperty("weekly_streak_best")]
  public int BestWeeklyStreak { get; private set; }

  /// <summary>
  /// The current weekly streak of the user.
  /// </summary>
  [JsonProperty("weekly_streak_current")]
  public int CurrentWeeklyStreak { get; private set; }
}
