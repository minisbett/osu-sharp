using OsuSharp.Enums;
using OsuSharp.Models.Beatmaps;
using OsuSharp.Models.Scores;
using OsuSharp.Models.Users;
using System.Web;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#beatmaps

  /// <summary>
  /// Looks up the beatmap with the specified MD5 checksum. If the beatmap was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#lookup-beatmap"/>
  /// </summary>
  /// <param name="checksum">The MD5 checksum of the beatmap.</param>
  /// <returns>The beatmap or null, if the beatmap was not found.</returns>
  public async Task<Beatmap?> LookupBeatmapChecksumAsync(string checksum) => await LookupBeatmapInternalAsync($"checksum={HttpUtility.UrlEncode(checksum)}");

  /// <summary>
  /// Looks up the beatmap with the specified filename. If the beatmap was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#lookup-beatmap"/>
  /// </summary>
  /// <param name="checksum">The filename of the beatmap.</param>
  /// <returns>The beatmap or null, if the beatmap was not found.</returns>
  public async Task<Beatmap?> LookupBeatmapFilenameAsync(string filename) => await LookupBeatmapInternalAsync($"filename={HttpUtility.UrlEncode(filename)}");

  /// <summary>
  /// Looks up the beatmap with the specified ID. If the beatmap was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#lookup-beatmap"/>
  /// </summary>
  /// <param name="beatmapId">The beatmap ID.</param>
  /// <returns>The beatmap or null, if the beatmap was not found.</returns>
  public async Task<Beatmap?> LookupBeatmapIdAsync(int beatmapId) => await LookupBeatmapInternalAsync($"id={beatmapId}");

  /// <summary>
  /// Looks up the beatmap with the specified query parameters. If the beatmap was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#lookup-beatmap"/>
  /// </summary>
  /// <param name="query">The query parameters.</param>
  /// <returns>The beatmap or null, if the beatmap was not found.</returns>
  private async Task<Beatmap?> LookupBeatmapInternalAsync(string query)
  {
    // Send the request and return the beatmap object.
    return await GetFromJsonAsync<Beatmap>($"beatmaps/lookup?{query}");
  }

  /// <summary>
  /// Gets the best score of the specified user with the specified mods on the specified beatmap in the specified ruleset. If the beatmap, user or score was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// The mods parameter is not implemented yet.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-a-user-beatmap-score"/>
  /// </summary>
  /// <param name="beatmapId">The ID of the beatmap to receive the score of.</param>
  /// <param name="userId">The ID of the user to receive the score of.</param>
  /// <param name="ruleset">Optional. The ruleset in which the score was set.</param>
  /// <param name="mods">Optional. The mods applied to the score.</param>
  /// <returns>The beatmap user score or null, if the beatmap, user or score was not found.</returns>
  public async Task<UserBeatmapScore?> GetUserBeatmapScoreAsync(int beatmapId, int userId, Ruleset? ruleset = null, string? mods = null)
  {
    // Send the request and return the score object.
    return await GetFromJsonAsync<UserBeatmapScore>($"beatmaps/{beatmapId}/scores/users/{userId}", new Dictionary<string, string?>()
    {
      { "mode", ruleset?.ToString() },
      { "mods", mods }
    });
  }

  /// <summary>
  /// Gets all scores of the specified user on the specified beatmap in the specified ruleset. If the beatmap or user was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// The mods parameter is not implemented yet.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-a-user-beatmap-scores"/>
  /// </summary>
  /// <param name="beatmapId">The ID of the beatmap to receive the score of.</param>
  /// <param name="userId">The ID of the user to receive the score of.</param>
  /// <param name="ruleset">Optional. The ruleset in which the score was set.</param>
  /// <returns>The beatmap user score or null, if the beatmap or user was not found.</returns>
  public async Task<Score[]?> GetUserBeatmapScoresAsync(int beatmapId, int userId, Ruleset? ruleset = null)
  {
    // Send the request and return the score objects.
    return await GetFromJsonAsync<Score[]>($"beatmaps/{beatmapId}/scores/users/{userId}/all", new Dictionary<string, string?>()
    {
      { "mode", ruleset?.ToString() }
    }, x => x["scores"]);
  }

  /// <summary>
  /// Gets all scores on the specified beatmap in the specified ruleset. If the beatmap or user was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// Includes <see cref="Score.User"/>, which includes <see cref="User.Country"/> and <see cref="User.Cover"/>.<br/>
  /// The mods parameter is not implemented yet.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-a-user-beatmap-scores"/>
  /// </summary>
  /// <param name="beatmapId">The ID of the beatmap to receive the score of.</param>
  /// <param name="ruleset">Optional. The ruleset in which the score was set.</param>
  /// <returns>The beatmap user score or null, if the beatmap or user was not found.</returns>
  public async Task<Score[]?> GetBeatmapScoresAsync(int beatmapId, Ruleset? ruleset = null, string? mods = null)
  {
    // Send the request and return the score objects.
    return await GetFromJsonAsync<Score[]>($"beatmaps/{beatmapId}/scores", new Dictionary<string, string?>()
    {
      { "mode", ruleset?.ToString() },
      { "mods", mods }
    }, x => x["scores"]);
  }

  /// <summary>
  /// Gets all beatmaps with the specified IDs, up to 50.
  /// <br/><br/>
  /// API notes:<br/>
  /// Includes <see cref="BeatmapExtended.Set"/> (including <see cref="BeatmapSet.Ratings"/>), <see cref="Beatmap.Failtimes"/> and <see cref="Beatmap.MaxCombo"/>.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap"/>
  /// </summary>
  /// <param name="ids">The IDs of the beatmaps.</param>
  /// <returns>The beatmaps.</returns>
  public async Task<BeatmapExtended[]> GetBeatmapsAsync(params int[] ids)
  {
    // Send the request and return the beatmap objects.
    return (await GetFromJsonAsync<BeatmapExtended[]>($"beatmaps?{string.Join("&", ids.Select(x => $"ids[]={x}"))}", jsonSelector: x => x["beatmaps"]))!;
  }

  /// <summary>
  /// Gets the beatmap with the specified ID.
  /// If the beatmap was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap"/>
  /// </summary>
  /// <param name="id">The ID of the beatmap.</param>
  /// <returns>The beatmap or null, if the beatmap was not found.</returns>
  public async Task<BeatmapExtended?> GetBeatmapAsync(int id)
  {
    // Send the request and return the beatmap object.
    return await GetFromJsonAsync<BeatmapExtended>($"beatmaps/{id}");
  }

  /// <summary>
  /// Gets the beatmap with the specified ID.
  /// If the beatmap was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap"/>
  /// </summary>
  /// <param name="id">The ID of the beatmap.</param>
  /// <returns>The difficulty attributes or null, if the beatmap was not found.</returns>
  public async Task<DifficultyAttributes?> GetDifficultyAttributesAsync(int id)
  {
    // Send the request and return the difficulty attributes object.
    return await GetFromJsonAsync<DifficultyAttributes>($"beatmaps/{id}/attributes", jsonSelector: x => x["attributes"], method: HttpMethod.Post);
  }
}