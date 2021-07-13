using OsuSharp.Beatmaps.Enums;
using System;
using System.Collections.Generic;
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
    public BackgroundEvent(string filename) : base(EventType.Background)
    {
      Filename = filename;
    }

    /// <summary>
    /// Creates a new <seealso cref="BackgroundEvent"/> instance with the specified offset and filename.
    /// </summary>
    /// <param name="offset">The offset from the audio start.</param>
    /// <param name="filename">The filename of the background file.</param>
    public BackgroundEvent(int offset, string filename) : base(EventType.Background, offset)
    {
      Filename = filename;
    }

    /// <summary>
    /// Creates a new <seealso cref="BackgroundEvent"/> instance with the specified offset and filename.
    /// </summary>
    /// <param name="filename">The filename of the background file.</param>
    /// <param name="xOffset">The X offset of the background from the gamefield center.</param>
    /// <param name="yOffset">The Y offset of the background from the gamefield center.</param>
    public BackgroundEvent(string filename, int xOffset, int yOffset) : base(EventType.Background)
    {
      Filename = filename;
      XOffset = xOffset;
      YOffset = yOffset;
    }

    /// <summary>
    /// Creates a new <seealso cref="BackgroundEvent"/> instance with the specified offset and filename.
    /// </summary>
    /// <param name="offset">The offset from the audio start.</param>
    /// <param name="filename">The filename of the background file.</param>
    /// <param name="xOffset">The X offset of the background from the gamefield center.</param>
    /// <param name="yOffset">The Y offset of the background from the gamefield center.</param>
    public BackgroundEvent(int offset, string filename, int xOffset, int yOffset) : base(EventType.Background, offset)
    {
      Filename = filename;
      XOffset = xOffset;
      YOffset = yOffset;
    }

    /// <summary>
    /// Location of the background image relative to the beatmap directory. Double quotes are usually included surrounding the filename, but they are not required.
    /// </summary>
    public string Filename { get; set; }

    /// <summary>
    /// X-Offset in osu! pixels from the center of the screen.
    /// </summary>
    public int XOffset { get; set; } = 0;

    /// <summary>
    /// Y-Offset in osu! pixels from the center of the screen.
    /// </summary>
    public int YOffset { get; set; } = 0;
  }
}
