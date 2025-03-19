using osu_sharp.Helpers;

namespace osu_sharp.Enums;

/// <summary>
/// Represents the type of a user event (the "Recent" section on osu! profiles).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// <br/><br/>
/// </summary>
public enum UserEventType
{
  /// <summary>
  /// Represents the event when a user obtained an achievement.
  /// </summary>
  [JsonAPIName("achievement")]
  Achievement,

  /// <summary>
  /// Represents the event when a user played a beatmap a certain number of times.
  /// </summary>
  [JsonAPIName("beatmapPlaycount")]
  BeatmapPlaycount,

  /// <summary>
  /// Represents the event when a beatmap of a user changes the state to ranked, approved, qualified or loved.
  /// </summary>
  [JsonAPIName("beatmapsetApprove")]
  BeatmapsetApprove,

  /// <summary>
  /// Represents the event when a user deletes a beatmapset.
  /// </summary>
  [JsonAPIName("beatmapsetDelete")]
  BeatmapsetDelete,

  /// <summary>
  /// Represents the event when a user updates a beatmapset in the graveyard.
  /// </summary>
  [JsonAPIName("beatmapsetRevive")]
  BeatmapsetRevive,

  /// <summary>
  /// Represents the event when a user updates a beatmapset.
  /// </summary>
  [JsonAPIName("beatmapsetUpdate")]
  BeatmapsetUpdate,

  /// <summary>
  /// Represents the event when a user uploads a new beatmapset.
  /// </summary>
  [JsonAPIName("beatmapsetUpload")]
  BeatmapsetUpload,

  /// <summary>
  /// Represents the event when a user achieves a certain rank on a beatmap.
  /// </summary>
  [JsonAPIName("rank")]
  Rank,

  /// <summary>
  /// Represents the event when a user loses first place to another user.
  /// </summary>
  [JsonAPIName("rankLost")]
  RankLost,

  /// <summary>
  /// Represents the event when a user changes their username.
  /// </summary>
  [JsonAPIName("usernameChange")]
  UsernameChange,

  /// <summary>
  /// Represents the event when a user supports osu! for the second time and onwards.
  /// </summary>
  [JsonAPIName("userSupportAgain")]
  UserSupportAgain,

  /// <summary>
  /// Represents the event when a user supports osu! for the first time.
  /// </summary>
  [JsonAPIName("userSupportFirst")]
  UserSupportFirst,

  /// <summary>
  /// Represents the event when a user is gifted a supporter tag by another user.
  /// </summary>
  [JsonAPIName("userSupportGift")]
  UserSupportGift
}
