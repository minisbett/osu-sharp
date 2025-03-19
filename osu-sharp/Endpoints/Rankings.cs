using osu_sharp.Helpers;
using osu_sharp.Models.Rankings;
using osu_sharp.Models.Users;

namespace osu_sharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#ranking

  // TODOENDPOINT: https://osu.ppy.sh/docs/index.html#get-ranking (pagination)

  /// <summary>
  /// Returns the users on the specified page of the kudosu ranking, sorted by kudosu. One page contains 50 users.
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="User.Kudosu"/></item>
  /// </list>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-kudosu-ranking"/>
  /// </summary>
  /// <param name="page">Optional. The page to return.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The users on the specified page of the kudosu ranking.</returns>
  [CanReturnAPIError()]
  public async Task<APIResult<User[]>> GetKudosuRankingAsync(int? page = null, CancellationToken? cancellationToken = null)
    => await GetAsync<User[]>($"rankings/kudosu", cancellationToken, new()
    {
      ["page"] = page
    }, x => x["ranking"]);

  /// <summary>
  /// Returns a list of all spotlights.
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-spotlights"/>
  /// </summary>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The list of spotlights.</returns>
  [CanReturnAPIError()]
  public async Task<APIResult<Spotlight[]>> GetSpotlightsAsync(CancellationToken? cancellationToken = null)
    => await GetAsync<Spotlight[]>($"spotlights", cancellationToken, jsonSelector: json => json["ranking"]);
}
