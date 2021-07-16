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
  /// Represents a slider in a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#sliders">osu! documentation</see>.
  /// </summary>
  public class Slider : HitObject
  {
    /// <summary>
    /// Creates a new <seealso cref="Slider"/> instance with the specified offset, position, newcombo status, amount of combo colours to skip and hitsounds.
    /// </summary>
    /// <param name="offset">Offset of the slider, in milliseconds from the beginning of the beatmap's audio.</param>
    /// <param name="position">The position in osu! pixels of the slider.</param>
    /// <param name="curvetype">The type of curve used to construct the slider.</param>
    /// <param name="curvepoints">The points used to construct this slider.</param>
    /// <param name="length">The visual length in osu! pixels of the slider.</param>
    /// <param name="slides">The amount of times the player has to follow the slider's curve back-and-forth before the slider is complete.</param>
    /// <param name="edgesounds">The hitsounds that play when hitting edges of the slider's curve.</param>
    /// <param name="edgesets">The sample sets used for the <seealso cref="EdgeSounds"/>.</param>
    /// <param name="newcombo">Specifies whether the slider starts a new combo.</param>
    /// <param name="combocolorskips">Specifies how many combo colors to skip, if this slider starts a new combo.</param>
    /// <param name="hitsound">The hitsound applied to the slider.</param>
    /// <param name="normalset">The sampleset used for the hitsound if the <seealso cref="HitSound"/> is <seealso cref="HitSound.Normal"/>.</param>
    /// <param name="additionset">The sampleset used for the hitsound if the <seealso cref="HitSound"/> is <seealso cref="HitSound.Whistle"/>, <seealso cref="HitSound.Finish"/> or <seealso cref="HitSound.Clap"/>.</param>
    /// <param name="sampleindex">The sample index of the sample being played on this slider.</param>
    /// <param name="volume">The volume of this slider's hitsound.</param>
    /// <param name="filename">Custom filename of the addition sound, overrides <seealso cref="HitSound"/>, <seealso cref="NormalSet"/>, <seealso cref="AdditionSet"/> and <seealso cref="SampleIndex"/>. </param>
    public Slider(int offset, Point position, CurveType curvetype, List<Point> curvepoints, float length, int slides = 1, List<HitSound> edgesounds = null, List<(SampleSet, SampleSet)> edgesets = null, bool newcombo = false, int combocolorskips = 0, HitSound hitsound = HitSound.Normal, SampleSet normalset = SampleSet.Normal, SampleSet additionset = SampleSet.Normal, int sampleindex = 0, int volume = 100, string filename = "") : base(HitObjectType.Slider, offset, position, newcombo, combocolorskips, hitsound, normalset, additionset, sampleindex, volume, filename)
    {
      edgesounds = edgesounds ?? new List<HitSound>();
      edgesets = edgesets ?? new List<(SampleSet, SampleSet)>();

      CurveType = curvetype;
      CurvePoints = curvepoints;
      Length = length;
      Slides = slides;
      EdgeSounds = edgesounds;
      EdgeSets = edgesets;
    }

    /// <summary>
    /// The type of curve used to construct the slider.
    /// /// </summary>
    public CurveType CurveType { get; set; }

    /// <summary>
    /// The points used to construct the slider.
    /// </summary>
    public List<Point> CurvePoints { get; set; } = new List<Point>();

    /// <summary>
    /// The visual length in osu! pixels of the slider.
    /// </summary>
    public float Length { get; set; }

    /// <summary>
    /// The amount of times the player has to follow the slider's curve back-and-forth before the slider is complete. It can also be interpreted as the repeat count plus one.
    /// </summary>
    public int Slides { get; set; }

    /// <summary>
    /// The hitsounds that play when hitting edges of the slider's curve. The first sound is the one that plays when the slider is first clicked, and the last sound is the one that plays when the slider's end is hit.
    /// </summary>
    public List<HitSound> EdgeSounds { get; set; } = new List<HitSound>();

    /// <summary>
    /// The sample sets used for the <seealso cref="EdgeSounds"/>.
    /// </summary>
    public List<(SampleSet NormalSet, SampleSet AdditonSet)> EdgeSets { get; set; } = new List<(SampleSet NormalSet, SampleSet AdditonSet)>();
  }
}
