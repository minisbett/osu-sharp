using OsuSharp.Beatmaps.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models
{
  /// <summary>
  /// Represents a bpm change timing point in a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#timing-points">osu! documentation</see>.
  /// </summary>
  public class BPMTimingPoint : TimingPoint
  {
    /// <summary>
    /// Creates a new <seealso cref="BPMTimingPoint"/> instance with the specified offset and beat length.
    /// </summary>
    /// <param name="offset">The offset from the audio start.</param>
    /// <param name="beat">The duration of a beat in milliseconds.</param>
    /// <param name="sampleset">The set of samples that are being played from that timing point on (Normal, Soft, Drum).</param>
    /// <param name="sampleindex">The sample index of the samples being played from that timing point on.</param>
    /// <param name="volume">The new volume at the timing point.</param>
    /// <param name="effects">The effects applied at the timing point.</param>
    public BPMTimingPoint(int offset, float beat, SampleSet sampleset = SampleSet.Normal, int sampleindex = 0, int volume = 100, TimingPointEffect effects = TimingPointEffect.None) : base(TimingPointType.BPMChange, offset, sampleset, sampleindex, volume, effects)
    {
      BeatLength = beat;
    }

    /// <summary>
    /// Creates a new <seealso cref="BPMTimingPoint"/> instance with the specified offset and beat length or bpm.
    /// </summary>
    /// <param name="offset">The offset from the audio start.</param>
    /// <param name="beat">The duration of a beat in milliseconds OR the beats per minute, if isBPM is set to true.</param>
    /// <param name="isBPM">Specifies whether the beat parameter is measured in milliseconds per beat or beats per minute.</param>
    /// <param name="sampleset">The set of samples that are being played from that timing point on (Normal, Soft, Drum).</param>
    /// <param name="sampleindex">The sample index of the samples being played from that timing point on.</param>
    /// <param name="volume">The new volume at the timing point.</param>
    /// <param name="effects">The effects applied at the timing point.</param>
    public BPMTimingPoint(int offset, float beat, bool isBPM, SampleSet sampleset = SampleSet.Normal, int sampleindex = 0, int volume = 100, TimingPointEffect effects = TimingPointEffect.None) : base(TimingPointType.BPMChange, offset, sampleset, sampleindex, volume, effects)
    {
      if (isBPM)
        BPM = beat;
      else
        BeatLength = beat;
    }

    /// <summary>
    /// The duration of a beat in milliseconds.
    /// </summary>
    public float BeatLength { get; set; }

    /// <summary>
    /// The beats per minute.
    /// </summary>
    public float BPM { get => 60000 / BeatLength; set => BeatLength = 60000 / BPM; }
  }
}
