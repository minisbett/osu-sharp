using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Enums
{
  /// <summary>
  /// The sample set used in the general section (see in the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#general">osu! documentation</see> for reference) and timing points (see in the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#timing-points">osu! documentation</see> for reference).
  /// </summary>
  public enum SampleSet
  {
    /// <summary>
    /// Uses the beatmap's default sampleset.
    /// </summary>
    BeatmapDefault = 0,

    /// <summary>
    /// The normal sampleset.
    /// </summary>
    Normal = 1,

    /// <summary>
    /// The soft sampleset.
    /// </summary>
    Soft = 2,

    /// <summary>
    /// The drum sampleset.
    /// </summary>
    Drum = 3
  }
}
