﻿using Newtonsoft.Json;

namespace OsuSharp.Models.Events;

/// <summary>
/// Represents an event when a beatmapset in graveyard state is updated.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class BeatmapsetReviveEvent : Event
{
  /// <summary>
  /// The beatmapset that was revived.
  /// </summary>
  [JsonProperty("beatmapset")]
  public EventBeatmapset Beatmapset { get; private set; } = default!;

  /// <summary>
  /// The user who is the owner of the beatmapset.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; private set; } = default!;
}