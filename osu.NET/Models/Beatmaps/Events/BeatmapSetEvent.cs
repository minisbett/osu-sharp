using Newtonsoft.Json;
using osu.NET.Models.Beatmaps.Discussions;

namespace osu.NET.Models.Beatmaps.Events;

/// <summary>
/// The base class for the events of a beatmapset.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-event-json.ts"/>
/// </summary>
public class BeatmapsetEvent
{
  [JsonProperty("beatmapset")]
  public BeatmapSet Set { get; private set; } = default!;

  [JsonProperty("created_at")]
  public DateTimeOffset CreatedAt { get; private set; }

  [JsonProperty("discussion")]
  public Discussion Discussion { get; private set; } = null!;

  [JsonProperty("id")]
  public int Id { get; private set; }

  [JsonProperty("user_id")]
  public int UserId { get; private set; }
}
