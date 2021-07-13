using OsuSharp.Beatmaps.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models
{
  /// <summary>
  /// Represents a break event in a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#breaks">osu! documentation</see>.
  /// </summary>
  public class BreakEvent : Event
  {
    /// <summary>
    /// Creates a new <seealso cref="BreakEvent"/> instance with the specified offset and end time.
    /// </summary>
    /// <param name="offset">The offset from the audio start.</param>
    /// <param name="endtime">The end time.</param>
    public BreakEvent(int offset, int endtime) : base(EventType.Break, offset)
    {
      EndTime = endtime;
    }

    /// <summary>
    /// Creates a new <seealso cref="BreakEvent"/> instance with the specified end time.
    /// </summary>
    /// <param name="endtime">The end time.</param>
    public int EndTime { get; set; }
  }
}
