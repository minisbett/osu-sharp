using osu.NET.Enums;
using osu.NET.Helpers;
using osu.NET.Models.Beatmaps;
using osu.NET.Models.Scores;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#beatmaps

  /// <summary>
  /// Looksup the beatmap with the specified MD5 checksum.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.BeatmapNotFound"/></term>
  ///   <description>The beatmap could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="Beatmap.Set"/> (including <see cref="BeatmapSet.Ratings"/>)</item>
  /// <item>Includes <see cref="Beatmap.Failtimes"/></item>
  /// <item>Includes <see cref="Beatmap.MaxCombo"/></item>
  /// </list>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#lookup-beatmap"/>
  /// </summary>
  /// <param name="checksum">The MD5 checksum of the beatmap.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The beatmap with the specified checksum.</returns>
  [CanReturnAPIError(APIErrorType.BeatmapNotFound)]
  public async Task<APIResult<BeatmapExtended>> LookupBeatmapChecksumAsync(string checksum, CancellationToken? cancellationToken = null)
    => (await GetAsync<BeatmapExtended>($"beatmaps/lookup", cancellationToken, new()
    {
      ["checksum"] = checksum
    })).WithErrorFallback(APIErrorType.BeatmapNotFound);

  /// <summary>
  /// Looksup the beatmap with the specified filename.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.BeatmapNotFound"/></term>
  ///   <description>The beatmap could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="Beatmap.Set"/> (including <see cref="BeatmapSet.Ratings"/>)</item>
  /// <item>Includes <see cref="Beatmap.Failtimes"/></item>
  /// <item>Includes <see cref="Beatmap.MaxCombo"/></item>
  /// </list>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#lookup-beatmap"/>
  /// </summary>
  /// <param name="filename">The filename of the beatmap.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The beatmap with the specified filename.</returns>
  [CanReturnAPIError(APIErrorType.BeatmapNotFound)]
  public async Task<APIResult<BeatmapExtended>> LookupBeatmapFilenameAsync(string filename, CancellationToken? cancellationToken = null)
    => (await GetAsync<BeatmapExtended>($"beatmaps/lookup", cancellationToken, new()
    {
      ["filename"] = filename
    })).WithErrorFallback(APIErrorType.BeatmapNotFound);

  /// <summary>
  /// Returns the best score of the specified user on the specified beatmap in the specified ruleset, optionally excluding osu!lazer scores.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.BeatmapNotFound"/></term>
  ///   <description>The beatmap could not be found</description>
  /// </item><br/>
  /// <item>
  ///   <term><see cref="APIErrorType.UserOrScoreNotFound"/></term>
  ///   <description>The user could not be found or has no score on the specified beatmap (cannot be distinguished due to API limitations)</description>
  /// </item>
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>The mods parameter is not implemented yet</item>
  /// </list>
  /// <br/><br/>
  /// API docs:<br/> 
  /// <a href="https://osu.ppy.sh/docs/index.html#get-a-user-beatmap-score"/>
  /// </summary>
  /// <param name="beatmapId">The ID of the beatmap to receive the score of.</param>
  /// <param name="userId">The ID of the user to receive the score of.</param>
  /// <param name="legacyOnly">Bool whether osu!lazer scores should be excluded. Defaults to false.</param>
  /// <param name="ruleset">Optional. The ruleset in which the score was set. Defaults to the users' preferred ruleset.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The best score by the specified user on the specified beatmap.</returns>
  [CanReturnAPIError(APIErrorType.BeatmapNotFound, APIErrorType.UserOrScoreNotFound)]
  public async Task<APIResult<UserBeatmapScore>> GetUserBeatmapScoreAsync(int beatmapId, int userId, bool legacyOnly = false, Ruleset? ruleset = null,
                                                                          CancellationToken? cancellationToken = null)
    => (await GetAsync<UserBeatmapScore>($"beatmaps/{beatmapId}/scores/users/{userId}", cancellationToken, new()
    {
      ["legacy_only"] = legacyOnly,
      ["mode"] = ruleset,
    })).WithErrorFallback(APIErrorType.UserOrScoreNotFound);

  /// <summary>
  /// Returns all scores of the specified user on the specified beatmap in the specified ruleset, optionally excluding osu!lazer scores.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.BeatmapNotFound"/></term>
  ///   <description>The beatmap could not be found</description>
  /// </item><br/>
  /// <item>
  ///   <term><see cref="APIErrorType.UserOrScoreNotFound"/></term>
  ///   <description>The user could not be found or has no scores on the specified beatmap (cannot be distinguished due to API limitations)</description>
  /// </item>
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>The mods parameter is not implemented yet</item>
  /// </list>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-a-user-beatmap-scores"/>
  /// </summary>
  /// <param name="beatmapId">The ID of the beatmap to receive the scores of.</param>
  /// <param name="userId">The ID of the user to receive the scores of.</param>
  /// <param name="legacyOnly">Bool whether osu!lazer scores should be excluded. Defaults to false.</param>
  /// <param name="ruleset">Optional. The ruleset in which the scores were set. Defaults to the users' preferred ruleset.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The scores of the specified user on the specified beatmap.</returns>
  [CanReturnAPIError(APIErrorType.BeatmapNotFound, APIErrorType.UserOrScoreNotFound)]
  public async Task<APIResult<Score[]>> GetUserBeatmapScoresAsync(int beatmapId, int userId, bool legacyOnly = false, Ruleset? ruleset = null,
                                                                  CancellationToken? cancellationToken = null)
    => (await GetAsync<Score[]>($"beatmaps/{beatmapId}/scores/users/{userId}/all", cancellationToken, new()
    {
      ["legacy_only"] = legacyOnly,
      ["ruleset"] = ruleset,
    }, json => json["scores"])).WithErrorFallback(APIErrorType.UserOrScoreNotFound);

  /// <summary>
  /// Returns the top 50 scores on the specified beatmap in the specified ruleset.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.BeatmapNotFound"/></term>
  ///   <description>The beatmap could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>The mods parameter is not implemented yet</item>
  /// <item>The type parameter is not implemented yet</item>
  /// </list>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap-scores-non-legacy"/>
  /// </summary>
  /// <param name="beatmapId">The ID of the beatmap to receive the scores of.</param>
  /// <param name="ruleset">Optional. The ruleset in which the scores were set. Defaults to the users' preferred ruleset.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The top 50 scores on the specified beatmap.</returns>
  [CanReturnAPIError(APIErrorType.BeatmapNotFound)]
  public async Task<APIResult<Score[]>> GetBeatmapScoresAsync(int beatmapId, Ruleset? ruleset = null, CancellationToken? cancellationToken = null)
    => await GetAsync<Score[]>($"beatmaps/{beatmapId}/solo-scores", cancellationToken, new()
    {
      ["mode"] = ruleset
    }, json => json["scores"]);

  /// <summary>
  /// Returns all beatmaps with the specified IDs, up to 50. If a beatmap ID could not be found, it is skipped.
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="Beatmap.Set"/> (including <see cref="BeatmapSet.Ratings"/>)</item>
  /// <item>Includes <see cref="Beatmap.Failtimes"/></item>
  /// <item>Includes <see cref="Beatmap.MaxCombo"/></item>
  /// </list>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmaps"/>
  /// </summary>
  /// <param name="ids">The IDs of the beatmaps.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The beatmaps with the specified IDs.</returns>
  [CanReturnAPIError()]
  public async Task<APIResult<BeatmapExtended[]>> GetBeatmapsAsync(int[] ids, CancellationToken? cancellationToken = null)
  {
    string query = string.Join("&", ids.Select(x => $"ids[]={x}"));
    return await GetAsync<BeatmapExtended[]>($"beatmaps?{query}", cancellationToken, jsonSelector: json => json["beatmaps"]);
  }

  /// <summary>
  /// Returns the beatmap with the specified ID. If the beatmap was not found, null is returned.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.BeatmapNotFound"/></term>
  ///   <description>The beatmap could not be found</description>
  ///  </item>
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="Beatmap.Set"/> (including <see cref="Beatmapset.Ratings"/>)</item>
  /// <item>Includes <see cref="Beatmap.Failtimes"/></item>
  /// <item>Includes <see cref="Beatmap.MaxCombo"/></item>
  /// </list>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap"/>
  /// </summary>
  /// <param name="beatmapId">The beatmap ID.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The beatmap or null, if the beatmap was not found.</returns>
  [CanReturnAPIError(APIErrorType.BeatmapNotFound)]
  public async Task<APIResult<BeatmapExtended>> GetBeatmapAsync(int beatmapId, CancellationToken? cancellationToken = null)
    => await GetAsync<BeatmapExtended>($"beatmaps/{beatmapId}", cancellationToken);

  /// <summary>
  /// Returns the difficulty attributes of the specified beatmap with the specified ruleset and mods.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="APIErrorType.BeatmapNotFound"/></term>
  ///   <description>The beatmap could not be found</description>
  ///  </item>
  /// </summary>
  /// <param name="beatmapId">The beatmap ID.</param>
  /// <param name="ruleset">Optional. The ruleset to consider for the beatmap.</param>
  /// <param name="mods">Optional. The mods to consider for difficulty calculation.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The difficulty attributes of the specified beatmap with the specified ruleset and mods.</returns>
  [CanReturnAPIError(APIErrorType.BeatmapNotFound)]
  public async Task<APIResult<DifficultyAttributes>> GetDifficultyAttributesAsync(int beatmapId, Ruleset ruleset = Ruleset.Osu, string[]? mods = null,
                                                                                  CancellationToken? cancellationToken = null)
  {
    // TODO: add support for specifying the ruleset (requires body content)
    string query = string.Join("&", (mods ?? []).Select(x => $"mods[]={x}"));
    return await GetAsync<DifficultyAttributes>($"beatmaps/{beatmapId}/attributes?{query}", cancellationToken);
  }
}