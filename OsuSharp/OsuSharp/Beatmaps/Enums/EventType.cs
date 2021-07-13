using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Enums
{
  /// <summary>
  /// Type of the <seealso cref="Event"/> object. See in the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#events">osu! documentation</see> for reference.
  /// </summary>
  public enum EventType
  {
    /// <summary>
    /// Changes the background of the map
    /// </summary>
    Background = 0,

    /// <summary>
    /// Plays back a video in the background
    /// </summary>
    Video = 1,

    /// <summary>
    /// A map break
    /// </summary>
    Break = 2
  }
}
