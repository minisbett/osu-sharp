using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Enums
{
  /// <summary>
  /// The overlay position/draw order of the circle overlay and their' numbers. See <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#general">osu! documentation</see> for reference.
  /// </summary>
  public enum OverlayPosition
  {
    /// <summary>
    /// Use the skin setting.
    /// </summary>
    NoChange,

    /// <summary>
    /// Draw overlays under numbers.
    /// </summary>
    Below,

    /// <summary>
    /// Draw overlays on top of numbers.
    /// </summary>
    Above
  }
}
