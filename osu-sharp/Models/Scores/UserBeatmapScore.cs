using Newtonsoft.Json;

namespace osu_sharp.Models.Scores;

/// <summary>
/// Represents the score of a user on a beatmap, including the position of the score on the beatmap leaderboards.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapuserscore"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/beatmapsets-show/scoreboard/controller.ts"/>
/// </summary>
public class UserBeatmapScore
{
  /// <summary>
  /// The position of the score on the beatmap leaderboards.
  /// </summary>
  [JsonProperty("position")]
  public int Position { get; private set; }

  /// <summary>
  /// The actual score represented by this <see cref="UserBeatmapScore"/> object.
  /// </summary>
  [JsonProperty("score")]
  public Score Score { get; private set; } = default!;
}