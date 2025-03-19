using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents the kudosu history of a user.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#kudosuhistory"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/KudosuHistoryTransformer.php"/>
/// </summary>
public class KudosuHistoryEntry
{
  /// <summary>
  /// The ID of the Kudosu exchange causing this entry.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The action that resulted in this entry.
  /// </summary>
  [JsonProperty("action")]
  public KudosuAction Action { get; private set; }

  /// <summary>
  /// The amount of kudosu involved in this entry.
  /// </summary>
  [JsonProperty("amount")]
  public int Amount { get; private set; }

  /// <summary>
  /// The type of object that this entry origins from.
  /// </summary>
  [JsonProperty("model")]
  public KudosuModel Model { get; private set; }

  /// <summary>
  /// The datetime at which this entry was created.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTimeOffset CreatedAt { get; private set; }

  /// <summary>
  /// The user that caused this entry. This may be null. (DOCS: why? maybe when revoking etc sure but apparently its null without that?)
  /// </summary>
  [JsonProperty("giver")]
  public KudosuGiver? Giver { get; private set; }

  /// <summary>
  /// The object that this entry origins from.
  /// </summary>
  [JsonProperty("post")]
  public KudosuPost Post { get; private set; } = default!;
}
