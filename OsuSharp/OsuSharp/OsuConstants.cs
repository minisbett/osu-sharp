using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp
{
  public static class OsuConstants
  {
    /// <summary>
    /// The size of the osu! gamefield in osu! pixels. (512x384)
    /// </summary>
    public static Size GamefieldSize => new Size(512, 384);

    /// <summary>
    /// The URL to the official osu! website (https://osu.ppy.sh/)
    /// </summary>
    public static string Website => "https://osu.ppy.sh/";
  }
}
