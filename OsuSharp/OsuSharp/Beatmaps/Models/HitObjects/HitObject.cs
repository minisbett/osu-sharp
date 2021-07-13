using OsuSharp.Beatmaps.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models
{
  /// <summary>
  /// Represents a hitobject in a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#hit-objects">osu! documentation</see>.
  /// </summary>
  public class HitObject
  {
    /// <summary>
    /// Creates a new <seealso cref="HitObject"/> instance with the specified hitobject type, offset, position, newcombo status, amount of combo colours to skip and hitsounds.
    /// </summary>
    /// <param name="type">The type of the hitobject (Cirlce, Slider, Spinner, osu!mania Hold).</param>
    /// <param name="offset">Offset of the hitobject, in milliseconds from the beginning of the beatmap's audio.</param>
    /// <param name="position">The position in osu! pixels of the object.</param>
    /// <param name="newcombo">Specifies whether the hitobject starts a new combo.</param>
    /// <param name="combocolorskips">Specifies how many combo colors to skip, if this object starts a new combo.</param>
    /// <param name="hitsound">The hitsound applied to the hitobject.</param>
    /// <param name="normalset">The sampleset used for the hitsound if the <seealso cref="HitSound"/> is <seealso cref="HitSound.Normal"/>.</param>
    /// <param name="additionset">The sampleset used for the hitsound if the <seealso cref="HitSound"/> is <seealso cref="HitSound.Whistle"/>, <seealso cref="HitSound.Finish"/> or <seealso cref="HitSound.Clap"/>.</param>
    /// <param name="sampleindex">The sample index of the sample being played on this hitobject.</param>
    /// <param name="volume">The volume of this hitobject's hitsound.</param>
    /// <param name="filename">Custom filename of the addition sound, overrides <seealso cref="HitSound"/>, <seealso cref="NormalSet"/>, <seealso cref="AdditionSet"/> and <seealso cref="SampleIndex"/>. </param>
    public HitObject(HitObjectType type, int offset, Point position, bool newcombo = false, int combocolorskips = 0, HitSound hitsound = HitSound.Normal, SampleSet normalset = SampleSet.Normal, SampleSet additionset = SampleSet.Normal, int sampleindex = 0, int volume = 100, string filename = "")
    {
      Type = type;
      Offset = offset;
      Position = position;
      NewCombo = newcombo;
      ComboColorSkips = combocolorskips;
      HitSound = hitsound;
      NormalSet = normalset;
      AdditionSet = additionset;
      SampleIndex = sampleindex;
      Volume = volume;
      HitSoundFilename = filename;
    }

    /// <summary>
    /// The type of the hitobject (Cirlce, Slider, Spinner, osu!mania Hold).
    /// </summary>
    public HitObjectType Type { get; set; }

    /// <summary>
    /// Offset of the hitobject, in milliseconds from the beginning of the beatmap's audio.
    /// </summary>
    public int Offset { get; set; }

    /// <summary>
    /// The position in osu! pixels of the hitobject.
    /// </summary>
    public Point Position { get; set; }

    /// <summary>
    /// Specifies whether the hitobject starts a new combo.
    /// </summary>
    public bool NewCombo { get; set; }

    /// <summary>
    /// Specifies how many combo colors to skip, if this object starts a new combo.
    /// </summary>
    public int ComboColorSkips { get => m_combocolorskips; set => m_combocolorskips = value > 7 ? 7 : value < 0 ? 0 : value; }
    private int m_combocolorskips;

    /// <summary>
    /// The hitsound applied to the hitobject.
    /// </summary>
    public HitSound HitSound { get; set; }

    /// <summary>
    /// The sampleset used for the hitsound if the <seealso cref="HitSound"/> is <seealso cref="HitSound.Normal"/>.
    /// </summary>
    public SampleSet NormalSet { get; set; }

    /// <summary>
    /// The sampleset used for the hitsound if the <seealso cref="HitSound"/> is <seealso cref="HitSound.Whistle"/>, <seealso cref="HitSound.Finish"/> or <seealso cref="HitSound.Clap"/>.
    /// </summary>
    public SampleSet AdditionSet { get; set; }

    /// <summary>
    /// The sample index of the sample being played on this hitobject.
    /// </summary>
    public int SampleIndex { get; set; }

    /// <summary>
    /// The volume of this hitobject's hitsound.
    /// </summary>
    public int Volume { get; set; }

    /// <summary>
    /// Custom filename of the addition sound, overrides <seealso cref="HitSound"/>, <seealso cref="NormalSet"/>, <seealso cref="AdditionSet"/> and <seealso cref="SampleIndex"/>.
    /// </summary>
    public string HitSoundFilename { get; set; }

    /// <summary>
    /// Returns whether the hitobject is a hitcircle or not.
    /// </summary>
    public bool IsHitCircle => Type == HitObjectType.HitCircle;

    /// <summary>
    /// Returns whether the hitobject is a slider or not.
    /// </summary>

    public bool IsSlider => Type == HitObjectType.Slider;
    
    /// <summary>
    /// Returns whether the hitobject is a spinner or not.
    /// </summary>

    public bool IsSpinner => Type == HitObjectType.Spinner;

    /// <summary>
    /// Returns whether the hitobject is a mania hold or not.
    /// </summary>

    public bool IsManiaHold => Type == HitObjectType.ManiaHold;
  }
}
