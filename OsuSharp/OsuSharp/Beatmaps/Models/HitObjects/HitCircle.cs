using OsuSharp.Beatmaps.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models.HitObjects
{
  /// <summary>
  /// Represents a hitcircle in a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#hit-circles">osu! documentation</see>.
  /// </summary>
  public class HitCircle : HitObject
  {
    /// <summary>
    /// Creates a new <seealso cref="HitCircle"/> instance with the specified offset, position, newcombo status, amount of combo colours to skip and hitsounds.
    /// </summary>
    /// <param name="offset">Offset of the hitcircle, in milliseconds from the beginning of the beatmap's audio.</param>
    /// <param name="position">The position in osu! pixels of the hitcircle.</param>
    /// <param name="newcombo">Specifies whether the hitcircle starts a new combo.</param>
    /// <param name="combocolorskips">Specifies how many combo colors to skip, if this hitcircle starts a new combo.</param>
    /// <param name="hitsound">The hitsound applied to the hitcircle.</param>
    /// <param name="normalset">The sampleset used for the hitsound if the <seealso cref="HitSound"/> is <seealso cref="HitSound.Normal"/>.</param>
    /// <param name="additionset">The sampleset used for the hitsound if the <seealso cref="HitSound"/> is <seealso cref="HitSound.Whistle"/>, <seealso cref="HitSound.Finish"/> or <seealso cref="HitSound.Clap"/>.</param>
    /// <param name="sampleindex">The sample index of the sample being played on this hitcircle.</param>
    /// <param name="volume">The volume of this hitcircle's hitsound.</param>
    /// <param name="filename">Custom filename of the addition sound, overrides <seealso cref="HitSound"/>, <seealso cref="NormalSet"/>, <seealso cref="AdditionSet"/> and <seealso cref="SampleIndex"/>. </param>
    public HitCircle(int offset, Point position, bool newcombo = false, int combocolorskips = 0, HitSound hitsound = HitSound.Normal, SampleSet normalset = SampleSet.Normal, SampleSet additionset = SampleSet.Normal, int sampleindex = 0, int volume = 100, string filename = "") : base(HitObjectType.HitCircle, offset, position, newcombo, combocolorskips, hitsound, normalset, additionset, sampleindex, volume, filename)
    {
      // Hitcircles do not have additional objectParams.
    }
  }
}
