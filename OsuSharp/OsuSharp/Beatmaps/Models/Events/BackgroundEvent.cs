using OsuSharp.Beatmaps.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models
{
  /// <summary>
  /// Represents a background event in a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#backgrounds">osu! documentation</see>.
  /// </summary>
  public class BackgroundEvent : Event
  {
    /// <summary>
    /// Creates a new <seealso cref="BackgroundEvent"/> instance with the specified filename.
    /// </summary>
    /// <param name="filename">The filename of the background file.</param>
    public BackgroundEvent(string filename) : base(EventType.Background, 0)
    {
      Filename = filename;
    }

    /// <summary>
    /// Creates a new <seealso cref="BackgroundEvent"/> instance with the specified offset and filename.
    /// </summary>
    /// <param name="filename">The filename of the background file.</param>
    /// <param name="xOffset">The X offset of the background from the gamefield center.</param>
    /// <param name="yOffset">The Y offset of the background from the gamefield center.</param>
    public BackgroundEvent(string filename, int xOffset, int yOffset) : base(EventType.Background, 0)
    {
      Filename = filename;
      PositionOffset = new Point(xOffset, yOffset);
    }

    /// <summary>
    /// The offset of the event, in milliseconds from the beginning of the beatmap's audio. For events that do not use a start time, the default is 0.
    /// Cannot be modified on a <seealso cref="BackgroundEvent"/> as the offset is always 0.
    /// </summary>
    public new int Offset { get; } = 0;

    /// <summary>
    /// Location of the background image relative to the beatmap directory. Double quotes are usually included surrounding the filename, but they are not required.
    /// </summary>
    public string Filename { get; set; }

    /// <summary>
    /// Offset in osu! pixels from the center of the screen.
    /// </summary>
    public Point PositionOffset { get; set; } = new Point(0, 0);
  }
}
