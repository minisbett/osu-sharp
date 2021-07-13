using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models
{
  /// <summary>
  /// Represents the "[Editor]" section of a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#editor">osu! documentation</see>.
  /// </summary>
  public class EditorSection
  {
    public EditorSection() { }

    /// <summary>
    /// Time in milliseconds of bookmarks
    /// </summary>
    public List<int> Bookmarks { get; } = new List<int>();

    /// <summary>
    /// The distance snap multiplier in the editor
    /// </summary>
    public float DistanceSpacing { get; set; } = 1.3f;

    /// <summary>
    /// The beat snap divisor in the editor
    /// </summary>
    public int BeatDivisor { get; set; } = 4;

    /// <summary>
    /// The grid size in the editor
    /// </summary>
    public float GridSize { get; set; } = 4;

    /// <summary>
    /// the scale factor for the hitobject timeline
    /// </summary>
    public float TimelineZoom { get; set; } = 1;
  }
}
