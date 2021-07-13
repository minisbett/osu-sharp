using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Enums
{
  /// <summary>
  /// Game mode of the beatmap. See in the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#general">osu! documentation</see> for reference.
  /// </summary>
  public enum Mode
  {
    /// <summary>
    /// osu!
    /// </summary>
    Standard = 0,

    /// <summary>
    /// osu!taiko
    /// </summary>
    Taiko = 1,

    /// <summary>
    /// osu!catch
    /// </summary>
    Catch = 2,

    /// <summary>
    /// osu!mania
    /// </summary>
    Mania = 3
  }
}
