using OsuSharp.Beatmaps.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models
{
  /// <summary>
  /// Represents an event in a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#events">osu! documentation</see>.
  /// </summary>
  public class Event
  {
    /// <summary>
    /// Creates a new <seealso cref="Event"/> instance with the specified offset.
    /// </summary>
    /// <param name="type">The type of the event.</param>
    /// <param name="offset">The offset from the audio start.</param>
    internal Event(EventType type, int offset)
    {
      Type = type;
      Offset = offset;
    }

    /// <summary>
    /// The type of the event.
    /// </summary>
    public EventType Type { get; }

    /// <summary>
    /// The offset of the event, in milliseconds from the beginning of the beatmap's audio. For events that do not use a start time, the default is 0.
    /// </summary>
    public int Offset { get; set; }

    /// <summary>
    /// Returns whether the event is a background event or not.
    /// </summary>
    public bool IsBackground => Type == EventType.Background;

    /// <summary>
    /// Returns whether the event is a video event or not.
    /// </summary>

    public bool IsVideo => Type == EventType.Video;

    /// <summary>
    /// Returns whether the event is a break event or not.
    /// </summary>

    public bool IsBreak => Type == EventType.Break;

    /// <summary>
    /// Converts the event into a background event, or returns null if the conversion failed.
    /// </summary>
    /// <returns>The converted background event.</returns>
    public BackgroundEvent AsBackgroundEvent() => this is BackgroundEvent ? this as BackgroundEvent : null;


    /// <summary>
    /// Converts the event into a video event, or returns null if the conversion failed.
    /// </summary>
    /// <returns>The converted video event.</returns>
    public VideoEvent AsVideoEvent() => this is VideoEvent ? this as VideoEvent : null;


    /// <summary>
    /// Converts the event into a break event, or returns null if the conversion failed.
    /// </summary>
    /// <returns>The converted break event.</returns>
    public BreakEvent AsBreakEvent() => this is BreakEvent ? this as BreakEvent : null;
  }
}
