using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Enums
{
  /// <summary>
  /// Type of a <seealso cref="Colour"/> object. See in the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#colours">osu! documentation</see> for reference.
  /// </summary>
  public enum ColourType
  {
    /// <summary>
    /// The <seealso cref="Colour"/> object represents a combo color.
    /// </summary>
    Combo,

    /// <summary>
    /// The <seealso cref="Colour"/> object represents a slider track color.
    /// </summary>
    SliderTrackOverride,

    /// <summary>
    /// The <seealso cref="Colour"/> object represents a slider border color.
    /// </summary>
    SliderBorder
  }
}
