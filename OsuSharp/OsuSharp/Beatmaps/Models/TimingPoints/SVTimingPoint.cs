using OsuSharp.Beatmaps.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models
{
  /// <summary>
  /// Represents a slider velocity change timing point in a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#timing-points">osu! documentation</see>.
  /// </summary>
  public class SVTimingPoint : TimingPoint
  {
    /// <summary>
    /// Creates a new <seealso cref="SVTimingPoint"/> instance with the specified offset and slider velocity percentage.
    /// </summary>
    /// <param name="offset">The offset from the audio start.</param>
    /// <param name="percentage">A negative inverse slider velocity multiplier, as a percentage.</param>
    /// <param name="sampleset">The set of samples that are being played from that timing point on (Normal, Soft, Drum).</param>
    /// <param name="sampleindex">The sample index of the samples being played from that timing point on.</param>
    /// <param name="volume">The new volume at the timing point.</param>
    /// <param name="effects">The effects applied at the timing point.</param>
    public SVTimingPoint(int offset, float percentage, SampleSet sampleset = SampleSet.Normal, int sampleindex = 0, int volume = 100, TimingPointEffect effects = TimingPointEffect.None) : base(TimingPointType.SliderVelocityChange, offset, sampleset, sampleindex, volume, effects)
    {
      Percentage = percentage;
    }

    /// <summary>
    /// Creates a new <seealso cref="SVTimingPoint"/> instance with the specified offset and slider velocity percentage or multiplier.
    /// </summary>
    /// <param name="offset">The offset from the audio start.</param>
    /// <param name="percentage">The negative inverse slider velocity multiplier as a percentage OR the slider velocity multiplier, if isMultiplier is set to true.</param>
    /// <param name="isMultiplier">Specifies whether the velocity parameter is a percentage or multiplier.</param>
    /// <param name="sampleset">The set of samples that are being played from that timing point on (Normal, Soft, Drum).</param>
    /// <param name="sampleindex">The sample index of the samples being played from that timing point on.</param>
    /// <param name="volume">The new volume at the timing point.</param>
    /// <param name="effects">The effects applied at the timing point.</param>
    public SVTimingPoint(int offset, float velocity, bool isMultiplier, SampleSet sampleset = SampleSet.Normal, int sampleindex = 0, int volume = 100, TimingPointEffect effects = TimingPointEffect.None) : base(TimingPointType.SliderVelocityChange, offset, sampleset, sampleindex, volume, effects)
    {
      if (isMultiplier)
        Multiplier = velocity;
      else
        Percentage = velocity;
    }

    /// <summary>
    /// A negative inverse slider velocity multiplier, as a percentage. For example, -50 would make all sliders in this timing section twice as fast as SliderMultiplier
    /// </summary>
    public float Percentage { get; set; }

    /// <summary>
    /// The <seealso cref="Percentage"/> converted into a multiplier. For example, -50 would result in 2.
    /// </summary>
    public float Multiplier { get => -100 / Percentage; set => Percentage = -100 / value; }
  }
}
