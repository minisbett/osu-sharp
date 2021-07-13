using OsuSharp.Beatmaps.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models
{
  /// <summary>
  /// Represents a timing point in a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#timing-points">osu! documentation</see>.
  /// </summary>
  public class TimingPoint
  {

    /// <summary>
    /// Creates a new <seealso cref="TimingPoint"/> instance with the specified timing point type and offset.
    /// </summary>
    /// <param name="type">The timing point type.</param>
    /// <param name="offset">The offset from the audio start.</param>
    /// <param name="sampleset">The set of samples that are being played from that timing point on (Normal, Soft, Drum).</param>
    /// <param name="sampleindex">The sample index of the samples being played from that timing point on.</param>
    /// <param name="volume">The new volume at the timing point.</param>
    /// <param name="effects">The effects applied at the timing point.</param>
    public TimingPoint(TimingPointType type, int offset, SampleSet sampleset = SampleSet.Normal, int sampleindex = 0, int volume = 100, TimingPointEffect effects = TimingPointEffect.None)
    {
      Type = type;
      Offset = offset;
      SampleSet = sampleset;
      SampleIndex = sampleindex;
      Volume = volume;
      Effects = effects;
    }

    /// <summary>
    /// The type of the timing point (inherited or uninherited).
    /// </summary>
    public TimingPointType Type { get; set; }

    /// <summary>
    /// Offset of the event, in milliseconds from the beginning of the beatmap's audio.
    /// </summary>
    public int Offset { get; set; }

    /// <summary>
    /// The set of samples that are being played from that timing point on (Normal, Soft, Drum).
    /// </summary>
    public SampleSet SampleSet { get; set; }

    /// <summary>
    /// The sample index of the samples being played from that timing point on.
    /// </summary>
    public int SampleIndex { get; set; }
    
    /// <summary>
    /// The new volume at the timing point.
    /// </summary>
    public int Volume { get; set; }

    /// <summary>
    /// Effects applied at the timing point. See in the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#effects">osu! documentation</see> for reference.
    /// </summary>
    public TimingPointEffect Effects { get; set; }

    /// <summary>
    /// Returns whether the timing point is a slider velocity change or not.
    /// </summary>
    public bool IsSVTimingPoint => Type == TimingPointType.SliderVelocityChange;

    /// <summary>
    /// Returns whether the timing point is a bpm change or not.
    /// </summary>

    public bool IsBPMTimingPoint => Type == TimingPointType.BPMChange;

    /// <summary>
    /// Converts the timing point into a bpm change timing point, or returns null if the conversion failed.
    /// </summary>
    /// <returns>The converted bpm change timing point.</returns>
    public BPMTimingPoint AsBPMTimingPoint() => this is BPMTimingPoint ? this as BPMTimingPoint : null;

    /// <summary>
    /// Converts the timing point into a slider velocity change timing point, or returns null if the conversion failed.
    /// </summary>
    /// <returns>The converted slider velocity change timing point.</returns>
    public SVTimingPoint AsSVTimingPoint() => this is SVTimingPoint ? this as SVTimingPoint : null;
  }
}
