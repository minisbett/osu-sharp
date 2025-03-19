using osu_sharp.Enums;
using osu_sharp.Helpers;
using osu_sharp.Models.Beatmaps;
using osu_sharp.Models.Scores;
using osu_sharp.Models.Users;
using osu_sharp.Models.Users.Events;

namespace osu_sharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#users

  /// <summary>
  /// Returns the kudosu history of the user with the specified ID.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-kudosu"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="limit">Optional. The amount of history entries to return.</param>
  /// <param name="offset">Optional. The offset in the history to return at.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The kudosu history entries of the user with the specified ID.</returns>
  [CanReturnAPIError(APIErrorType.UserNotFound)]
  public async Task<APIResult<KudosuHistoryEntry[]>> GetKudosuHistoryAsync(int userId, int? limit = null, int? offset = null,
                                                                           CancellationToken? cancellationToken = null)
    => (await GetAsync<KudosuHistoryEntry[]>($"users/{userId}/kudosu", cancellationToken, new()
    {
      ["limit"] = limit,
      ["offset"] = offset
    })).WithErrorFallback(APIErrorType.UserNotFound);

  /// <summary>
  /// Returns the scores of the specified user with the specified type in the specified ruleset, optionally excluding osu!lazer scores and fails.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-scores"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="type">The type of scores to return.</param>
  /// <param name="legacyOnly">Bool whether osu!lazer scores should be excluded. Defaults to false.</param>
  /// <param name="includeFails">Bool whether fails should be included. Defaults to false.</param>
  /// <param name="ruleset">Optional. The ruleset in which the scores are returned. Defaults to the users' preferred ruleset.</param>
  /// <param name="limit">Optional. The amount of results to return.</param>
  /// <param name="offset">Optional. The offset for the scores to return.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The scores of the specified type by the user with the specified ID.</returns>
  [CanReturnAPIError(APIErrorType.UserNotFound)]
  public async Task<APIResult<Score[]>> GetUserScoresAsync(int userId, UserScoreType type, bool legacyOnly = false, bool includeFails = false,
                                                           Ruleset? ruleset = null, int? limit = null, int? offset = null,
                                                           CancellationToken? cancellationToken = null)
    => (await GetAsync<Score[]>($"users/{userId}/scores/{type.GetQueryName()}", cancellationToken, new()
    {
      ["legacy_only"] = legacyOnly,
      ["include_fails"] = includeFails,
      ["mode"] = ruleset,
      ["limit"] = limit,
      ["offset"] = offset
    })).WithErrorFallback(APIErrorType.UserNotFound);

  /// <summary>
  /// Returns the most played beatmaps of the specified user.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-beatmaps"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="limit">Optional. The amount of beatmaps to limit to.</param>
  /// <param name="offset">Optional. The offset for the beatmaps returned.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The most played beatmaps of the user with the specified ID.</returns>
  [CanReturnAPIError(APIErrorType.UserNotFound)]
  public async Task<APIResult<BeatmapPlaycount[]>> GetUserMostPlayedAsync(int userId, int? limit = null, int? offset = null,
                                                                          CancellationToken? cancellationToken = null)
    => (await GetAsync<BeatmapPlaycount[]>($"users/{userId}/beatmapsets/most_played", cancellationToken, new()
    {
      ["limit"] = limit,
      ["offset"] = offset
    })).WithErrorFallback(APIErrorType.UserNotFound);

  /// <summary>
  /// Returns all beatmaps of the specified user with the specified type.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// The <see cref="BeatmapType"/> enum does not contain the most played beatmaps as the response type differs, and should
  /// thus be called via <see cref="GetUserMostPlayedAsync(int, int?, int?, CancellationToken?)"/>.
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-beatmaps"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="type">The type of beatmaps to return.</param>
  /// <param name="limit"> Optional. The amount of beatmaps to limit to.</param>
  /// <param name="offset">Optional. The offset for the beatmaps returned.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The most played beatmaps of the user with the specified ID.</returns>
  [CanReturnAPIError(APIErrorType.UserNotFound)]
  public async Task<APIResult<BeatmapSetExtended[]>> GetUserBeatmapsAsync(int userId, BeatmapType type, int? limit = null, int? offset = null,
                                                                          CancellationToken? cancellationToken = null)
    => (await GetAsync<BeatmapSetExtended[]>($"users/{userId}/beatmapsets/{type.GetQueryName()}", cancellationToken, new()
    {
      ["limit"] = limit,
      ["offset"] = offset
    })).WithErrorFallback(APIErrorType.UserNotFound);

  /// <summary>
  /// Returns the recent events of the specified user.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-recent-activity"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="limit"> Optional. The amount of events to limit to.</param>
  /// <param name="offset">Optional. The offset for the events returned.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The recent events of the user with the specified ID.</returns>
  [CanReturnAPIError(APIErrorType.UserNotFound)]
  public async Task<APIResult<UserEvent[]>> GetRecentActivityAsync(int userId, int? limit = null, int? offset = null, CancellationToken? cancellationToken = null)
    => (await GetAsync<UserEvent[]>($"users/{userId}/recent_activity", cancellationToken, new()
    {
      ["limit"] = limit,
      ["offset"] = offset
    })).WithErrorFallback(APIErrorType.UserNotFound);

  /// <summary>
  /// Returns the user with the specified ID, optionally in the specified ruleset. If no ruleset is specified, the user is returned in their default ruleset.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="ruleset">Optional. The ruleset in which the user is returned.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The user with the specified ID.</returns>
  [CanReturnAPIError(APIErrorType.UserNotFound)]
  public async Task<APIResult<UserExtended>> GetUserAsync(int userId, Ruleset? ruleset = null, CancellationToken? cancellationToken = null)
    => (await GetAsync<UserExtended>($"users/{userId}/{(ruleset is null ? "" : ruleset.Value.GetQueryName())}", cancellationToken))
             .WithErrorFallback(APIErrorType.UserNotFound);

  /// <summary>
  /// Returns the user with the specified name, optionally in the specified ruleset. If no ruleset is specified, the user is returned in their default ruleset.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user"/>
  /// </summary>
  /// <param name="username">The name of the user.</param>
  /// <param name="ruleset">Optional. The ruleset in which the user is returned.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The user with the specified name.</returns>
  [CanReturnAPIError(APIErrorType.UserNotFound)]
  public async Task<APIResult<UserExtended>> GetUserAsync(string username, Ruleset? ruleset = null, CancellationToken? cancellationToken = null)
    => await GetAsync<UserExtended>($"users/@{username}/{(ruleset is null ? "" : ruleset.Value.GetQueryName())}", cancellationToken);

  /// <summary>
  /// Returns all users with the specified IDs, up to 50, optionally including the <c>statistics_rulesets.variants</c> attribute.
  /// If a user ID could not be found, it is skipped.
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="User.Country"/></item>
  /// <item>Includes <see cref="User.Cover"/></item>
  /// <item>Includes <see cref="User.Groups"/></item>
  /// <item>Includes <see cref="User.RulesetStatistics"/></item>
  /// </list>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-users"/>
  /// </summary>
  /// <param name="ids">The user IDs.</param>
  /// <param name="includeVariantStatistics">Optional. Bool whether the <c>statistics_rulesets.variants</c> attribute is included.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The users with the specified IDs.</returns>
  [CanReturnAPIError()]
  public async Task<APIResult<User[]>> GetUsersAsync(int[] ids, bool includeVariantStatistics = false, CancellationToken? cancellationToken = null)
  {
    // TODO: add support for includeVariantStatistics
    if (includeVariantStatistics)
      throw new NotSupportedException("This library does not support includeVariantStatistics yet.");

    string query = string.Join("&", ids.Select(x => $"ids[]={x}"));
    return await GetAsync<User[]>($"users?{query}", cancellationToken, new()
    {
      ["include_variant_statistics"] = includeVariantStatistics
    }, jsonSelector: json => json["users"]);
  }
}
