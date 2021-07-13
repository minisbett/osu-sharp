using OsuSharp.Beatmaps.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models.HitObjects
{
  class Spinner : HitObject
  {
    /// <summary>
    /// Creates a new <seealso cref="Spinner"/> instance with the specified offset and hitsounds.
    /// </summary>
    /// <param name="offset">Offset of the spinner, in milliseconds from the beginning of the beatmap's audio.</param>
    /// <param name="endtime">The endtime of the spinner, relative from the beginning of the beatmap's audio.</param>
    /// <param name="hitsound">The hitsound applied to the spinner.</param>
    /// <param name="normalset">The sampleset used for the hitsound if the <seealso cref="HitSound"/> is <seealso cref="HitSound.Normal"/>.</param>
    /// <param name="additionset">The sampleset used for the hitsound if the <seealso cref="HitSound"/> is <seealso cref="HitSound.Whistle"/>, <seealso cref="HitSound.Finish"/> or <seealso cref="HitSound.Clap"/>.</param>
    /// <param name="sampleindex">The sample index of the sample being played on this spinner.</param>
    /// <param name="volume">The volume of this spinner's hitsound.</param>
    /// <param name="filename">Custom filename of the addition sound, overrides <seealso cref="HitSound"/>, <seealso cref="NormalSet"/>, <seealso cref="AdditionSet"/> and <seealso cref="SampleIndex"/>. </param>
    public Spinner(int offset, int endtime, HitSound hitsound = HitSound.Normal, SampleSet normalset = SampleSet.Normal, SampleSet additionset = SampleSet.Normal, int sampleindex = 0, int volume = 100, string filename = "") : base(HitObjectType.Spinner, offset, new Point(0, 0), false, 0, hitsound, normalset, additionset, sampleindex, volume, filename)
    {
      EndTime = endtime;
    }

    /// <summary>
    /// The endtime of the spinner, relative from the beginning of the beatmap's audio
    /// </summary>
    public int EndTime { get; set; }
  }
}
