using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Enums
{
  /// <summary>
  /// The type of the timing point. See in the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#timing-points">osu! documentation</see> for reference.
  /// </summary>
  public enum TimingPointType
  {
    /// <summary>
    /// Also known as an uninherited timing point, changes the current BPM.
    /// </summary>
    BPMChange,

    /// <summary>
    /// Also known as inherited timing point, changes the slider velocity.
    /// </summary>
    SliderVelocityChange
  }
}
