﻿using OsuSharp.Models.Users;

namespace OsuSharp;

public partial class OsuApiClient
{
  /// <summary>
  /// Returns the users on the specified page of the kudosu ranking, sorted by kudosu.
  /// <br/><br/>
  /// API notes:<br/>
  /// Includes <see cref="User.Kudosu"/>.<br/>
  /// One page equals to 50 entries.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-kudosu-ranking"/>
  /// </summary>
  /// <param name="page">Optional. The page to return.</param>
  /// <returns>The users on the specified page of the kudosu ranking.</returns>
  public async Task<User[]?> GetKudosuRankingAsync(int? page = null)
  {
    return await GetFromJsonAsync<User[]>($"rankings/kudosu", new Dictionary<string, object?>()
    {
      { "page", page }
    }, x => x["ranking"]);
  }
}
