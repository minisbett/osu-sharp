using Newtonsoft.Json;
using osu_sharp.Enums;

namespace osu_sharp.Models.Users;

/// <summary>
/// Represents an entry in a user's account history, eg. a silence or a restriction.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#user-useraccounthistory"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-account-history-json.ts"/>
/// </summary>
public class AccountHistoryEntry
{
  /// <summary>
  /// The user whichs account history this entry belongs to. This may be null.
  /// </summary>
  [JsonProperty("actor")]
  public User? User { get; private set; }

  /// <summary>
  /// The description about the action of this history entry.
  /// </summary>
  [JsonProperty("description")]
  public string Description { get; private set; } = default!;

  /// <summary>
  /// The ID of this history entry.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The length of the action taken in this history entry.
  /// </summary>
  [JsonProperty("length")]
  public int Length { get; private set; }

  /// <summary>
  /// Bool whether the action taken in this history entry is permanent.
  /// </summary>
  [JsonProperty("permanent")]
  public bool IsPermanent { get; private set; }

  /// <summary>
  /// DOCS: what is this?
  /// </summary>
  [JsonProperty("supporting_url")]
  public string? SupportingUrl { get; private set; }

  /// <summary>
  /// The datetime at which this history entry was created.
  /// </summary>
  [JsonProperty("timestamp")]
  public DateTimeOffset? Timestamp { get; private set; }

  /// <summary>
  /// The type of this history entry.
  /// </summary>
  [JsonProperty("type")]
  public UserAccountHistoryEntryType Type { get; private set; }
}
