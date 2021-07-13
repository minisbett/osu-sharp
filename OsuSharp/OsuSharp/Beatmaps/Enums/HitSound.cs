using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Enums
{
  /// <summary>
  /// The hitsound used on a hitobject (see in the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#hitsounds">osu! documentation</see> for reference).
  /// /// </summary>
  public enum HitSound
  {
    /// <summary>
    /// The normal hitsound.
    /// </summary>
    Normal = 0,

    /// <summary>
    /// The whistle hitsound.
    /// </summary>
    Whistle = 1,

    /// <summary>
    /// The finish hitsound.
    /// </summary>
    Finish = 2,

    /// <summary>
    /// The clap hitsound.
    /// </summary>
    Clap = 3
  }
}
