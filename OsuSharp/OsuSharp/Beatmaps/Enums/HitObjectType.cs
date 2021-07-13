using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Enums
{
  /// <summary>
  /// The type of the hitobject. See in the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#hit-objects">osu! documentation</see> for reference.
  /// </summary>
  public enum HitObjectType
  {
    /// <summary>
    /// A hitcircle.
    /// </summary>
    HitCircle = 0,

    /// <summary>
    /// A slider.
    /// </summary>
    Slider = 1,

    /// <summary>
    /// A spinner.
    /// </summary>
    Spinner = 3,

    /// <summary>
    /// An osu!mania hold.
    /// </summary>
    ManiaHold = 7
  }
}
