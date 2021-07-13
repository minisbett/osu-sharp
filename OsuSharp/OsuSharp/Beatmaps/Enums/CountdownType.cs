using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Enums
{
  /// <summary>
  /// The speed of countdown on beatmap start. See in the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#general">osu! documentation</see> for reference.
  /// </summary>
  public enum CountdownType
  {
    /// <summary>
    /// Use no countdown.
    /// </summary>
    NoCountdown = 0,

    /// <summary>
    /// Normal speed (x1).
    /// </summary>
    Normal = 1,

    /// <summary>
    /// Half speed (x0.5).
    /// </summary>
    Half = 2,

    /// <summary>
    /// Double speed (x2).
    /// </summary>
    Double = 3
  }
}
