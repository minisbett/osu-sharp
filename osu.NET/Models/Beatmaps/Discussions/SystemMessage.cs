using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Beatmaps.Discussions;

/// <summary>
/// Represents a system message on a <see cref="SystemDiscussionPost"/>. This contains the type of message and boolean value.
/// <br/><br/>
/// API docs: Undocumented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-discussion-post-json.ts"/>
/// </summary>
public class SystemMessage
{
  /// <summary>
  /// The type of the system message.
  /// </summary>
  [JsonProperty("message_type")]
  public SystemMessageType Type { get; private set; }

  /// <summary>
  /// The boolean value of the system message.
  /// </summary>
  [JsonProperty("value")]
  public bool Value { get; private set; }
}
