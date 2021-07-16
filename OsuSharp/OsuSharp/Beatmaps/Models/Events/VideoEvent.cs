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
  /// Represents a video event in a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#videos">osu! documentation</see>.
  /// </summary>
  public class VideoEvent : Event
  {
    /// <summary>
    /// Creates a new <seealso cref="VideoEvent"/> instance with the specified filename and offset.
    /// </summary>
    /// <param name="filename">The filename of the video file.</param>
    /// <param name="offset">The offset from the audio start.</param>
    public VideoEvent(string filename, int offset = 0) : base(EventType.Video, offset)
    {
      Filename = filename;
    }

    /// <summary>
    /// Creates a new <seealso cref="VideoEvent"/> instance with the specified offset and filename.
    /// </summary>
    /// <param name="filename">The filename of the video file.</param>
    /// <param name="xOffset">The X offset of the background from the gamefield center.</param>
    /// <param name="yOffset">The Y offset of the background from the gamefield center.</param>
    /// <param name="offset">The offset from the audio start.</param>
    public VideoEvent(string filename, int xOffset, int yOffset, int offset = 0) : base(EventType.Video, offset)
    {
      Filename = filename;
      PositionOffset = new Point(xOffset, yOffset);
    }

    /// <summary>
    /// Location of the video relative to the beatmap directory. Double quotes are usually included surrounding the filename, but they are not required.
    /// </summary>
    public string Filename { get; set; }

    /// <summary>
    /// Offset in osu! pixels from the center of the screen.
    /// </summary>
    public Point PositionOffset { get; set; } = new Point(0, 0);
  }
}
