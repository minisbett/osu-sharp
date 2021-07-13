using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Enums
{
  /// <summary>
  /// The curve type of a slider. See in the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#sliders">osu! documentation</see> for reference.
  /// </summary>
  public enum CurveType
  {
    /// <summary>
    /// Bézier curves of arbitrary degree can be made. Multiple bézier curves can be joined into a single slider by repeating their points of intersection.
    /// </summary>
    Bezier,

    /// <summary>
    /// Catmull curves are an interpolating alternative to bézier curves. They are rarely used today due to their lack of visual appeal.
    /// </summary>
    CatmullRom,

    /// <summary>
    /// These curves form a straight path between all of their points.
    /// </summary>
    Linear,

    /// <summary>
    /// Perfect circle curves are limited to three points (including the hit object's position) that define the boundary of a circle. Using more than three points will result in the curve type being switched to bézier.
    /// </summary>
    PerfectCircle
  }
}
