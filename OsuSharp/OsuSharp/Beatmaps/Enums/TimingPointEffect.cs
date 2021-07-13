using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Enums
{
  /// <summary>
  /// The optional effects of the timing point. See in the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#effects">osu! documentation</see> for reference.
  /// </summary>
  public enum TimingPointEffect
  {
    /// <summary>
    /// The timing point has no effect.
    /// </summary>
    None = 0,

    /// <summary>
    /// The timing point toggles the kiai effect.
    /// </summary>
    Kiai,

    /// <summary>
    /// The timing point toggles the omitted barline effect (osu!taiko and osu!mania).
    /// </summary>
    OmittedBarline
  }
}
