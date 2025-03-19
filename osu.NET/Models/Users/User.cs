using Newtonsoft.Json;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents an osu! user.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#user"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-json.ts"/>
/// </summary>
public class User
{
  // TODO: Implement "statistics_rulesets" attribute

  #region Default Attributes

  /// <summary>
  /// The URL of the avatar of this user.
  /// </summary>
  [JsonProperty("avatar_url")]
  public string AvatarUrl { get; private set; } = default!;

  /// <summary>
  /// The two-letter country code of this user.
  /// </summary>
  [JsonProperty("country_code")]
  public string CountryCode { get; private set; } = default!;

  /// <summary>
  /// The identifier of the default group this user belongs to.
  /// </summary>
  [JsonProperty("default_group")]
  public string? DefaultGroup { get; private set; }

  /// <summary>
  /// The ID of this user.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// Bool whether this user has been active in the osu! in the past X months.
  /// </summary>
  [JsonProperty("is_active")]
  public bool IsActive { get; private set; }

  /// <summary>
  /// Bool whether this user is a bot.
  /// </summary>
  [JsonProperty("is_bot")]
  public bool IsBot { get; private set; }

  /// <summary>
  /// Bool whether this user was deleted.
  /// </summary>
  [JsonProperty("is_deleted")]
  public bool IsDeleted { get; private set; }

  /// <summary>
  /// Bool whether this user is currently online.
  /// </summary>
  [JsonProperty("is_online")]
  public bool IsOnline { get; private set; }

  /// <summary>
  /// Bool whether this user has the osu!supporter status.
  /// </summary>
  [JsonProperty("is_supporter")]
  public bool IsSupporter { get; private set; }

  /// <summary>
  /// The datetime at which this user was last online.
  /// </summary>
  [JsonProperty("last_visit")]
  public DateTimeOffset? LastVisit { get; private set; }

  /// <summary>
  /// Bool whether this user only accepts private messages from friends.
  /// </summary>
  [JsonProperty("pm_friends_only")]
  public bool IsPMFriendsOnly { get; private set; }

  /// <summary>
  /// DOCS: what is this? apparently not the hex colour, there's <see cref="UserExtended.ProfileHue"/> and this seems to always be null
  /// </summary>
  [JsonProperty("profile_colour")]
  public string? ProfileColour { get; private set; }

  /// <summary>
  /// The name of this user.
  /// </summary>
  [JsonProperty("username")]
  public string Username { get; private set; } = default!;

  #endregion

  #region Optional Attributes

  /// <summary>
  /// The account history of this user, containing their restrictions, silences, etc. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("account_history")]
  public AccountHistoryEntry[]? AccountHistory { get; private set; }

  /// <summary>
  /// DOCS: what is this? i thought it might be the "main" one or if its just one
  /// but flary for example got the USA one and this is still null (banners array is not)
  /// </summary>
  [JsonProperty("active_tournament_banner")]
  public ProfileBanner? Banner { get; private set; }

  /// <summary>
  /// The tournament banners of this user. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("active_tournament_banners")]
  public ProfileBanner[]? Banners { get; private set; }

  /// <summary>
  /// The badges of this user. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("badges")]
  public UserBadge[]? Badges { get; private set; }

  /// <summary>
  /// The amount of "most played beatmap" entries this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("beatmap_playcounts_count")]
  public int? MostPlayedCount { get; private set; }

  /// <summary>
  /// The amount of comments this user authored.
  /// </summary>
  [JsonProperty("comments_count")]
  public int? CommentsCount { get; private set; }

  /// <summary>
  /// The country of this user. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("country")]
  public Country? Country { get; private set; }

  /// <summary>
  /// The cover of this user. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("cover")]
  public UserCover? Cover { get; private set; }

  /// <summary>
  /// The daily challenge statistics of this user. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("daily_challenge_user_stats")]
  public DailyChallengeUserStats? DailyChallengeStats { get; private set; }

  /// <summary>
  /// The amount of favourited beatmapsets this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("favourite_beatmapset_count")]
  public int? FavouriteBeatmapSetsCount { get; private set; }

  /// <summary>
  /// DOCS: What is this?
  /// </summary>
  [JsonProperty("follow_user_mapping")]
  public int[]? FollowUserMapping { get; private set; }

  /// <summary>
  /// The amount of followers this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("follower_count")]
  public int? FollowersCount { get; private set; }

  /// <summary>
  /// The amount of graveyarded beatmapsets this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("graveyard_beatmapset_count")]
  public int? GraveyardedBeatmapSetsCount { get; private set; }

  /// <summary>
  /// The groups the user is in. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("groups")]
  public UserGroup[]? Groups { get; private set; }

  /// <summary>
  /// The amount of guest participation on ranked or loved beatmapsets this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("guest_beatmapset_count")]
  public int? GuestBeatmapSetsCount { get; private set; }

  /// <summary>
  /// The amount of kudosu this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("kudosu")]
  public Kudosu? Kudosu { get; private set; }

  /// <summary>
  /// The amount of loved beatmapsets this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("loved_beatmapset_count")]
  public int? LovedBeatmapSetsCount { get; private set; }

  /// <summary>
  /// The amount of mapping followers this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("mapping_follower_count")]
  public int? MappingFollowersCount { get; private set; }

  /// <summary>
  /// The monthly playcount of this user. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("monthly_playcounts")]
  public MonthlyPlaycountEntry[]? MonthlyPlaycount { get; private set; }

  /// <summary>
  /// The amount of beatmapsets this user has nominated. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("nominated_beatmapset_count")]
  public int? NominatedBeatmapSetsCount { get; private set; }

  /// <summary>
  /// The me! section of this users' profile. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("page")]
  public UserPage? Page { get; private set; }

  /// <summary>
  /// The amount of pending beatmapsets this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("pending_beatmapset_count")]
  public int? PendingBeatmapSetsCount { get; private set; }

  /// <summary>
  /// The previous usernames of this user. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("previous_usernames")]
  public string[]? PreviousUsernames { get; private set; }

  /// <summary>
  /// The highest rank this user has achieved. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("rank_highest")]
  public HighestRank? HighestRank { get; private set; }

  /// <summary>
  /// The rank history of this user. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("rank_history")]
  public RankHistory? RankHistory { get; private set; }

  /// <summary>
  /// The amount of ranked beatmapsets this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("ranked_beatmapset_count")]
  public int? RankedBeatmapSetsCount { get; private set; }

  /// <summary>
  /// The monthly replays watched from this user. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("replays_watched_counts")]
  public MonthlyReplaysWatchedEntry[]? ReplaysWatched { get; private set; }

  /// <summary>
  /// The amount of top plays this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("scores_best_count")]
  public int? BestScoresCount { get; private set; }

  /// <summary>
  /// The amount of first place scores this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("scores_first_count")]
  public int? FirstScoresCount { get; private set; }

  /// <summary>
  /// The amount of pinned scores this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("scores_pinned_count")]
  public int? PinnedScoresCount { get; private set; }

  /// <summary>
  /// The amount of recent scores this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("scores_recent_count")]
  public int? RecentScoresCount { get; private set; }

  /// <summary>
  /// The statistics of this user. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("statistics")]
  public UserStatistics? Statistics { get; private set; }

  /// <summary>
  /// The level of osu! supporter this user has. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("support_level")]
  public int? SupportLevel { get; private set; }

  /// <summary>
  /// The team this user is in. This is an optional property and will be null if the user is not in a team.
  /// </summary>
  [JsonProperty("team")]
  public Team? Team { get; private set; }

  /// <summary>
  /// The achievements of this user. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("user_achievements")]
  public Achievement[]? Achievements { get; private set; }

  #endregion
}
