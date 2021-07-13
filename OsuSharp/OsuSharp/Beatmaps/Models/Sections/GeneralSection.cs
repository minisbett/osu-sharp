using OsuSharp.Beatmaps.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models
{
  /// <summary>
  /// Represents the "[General]" section of a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#general">osu! documentation</see>.
  /// </summary>
  public class GeneralSection
  {
    public GeneralSection() { }

    /// <summary>
    /// Location of the audio file relative to the current folder.
    /// </summary>
    public string AudioFilename { get; set; } = "";

    /// <summary>
    /// Milliseconds of silence before the audio starts playing.
    /// </summary>
    public int AudioLeadIn { get; set; } = 0;

    /// <summary>
    /// Time in milliseconds when the audio preview should start.
    /// </summary>
    public int PreviewTime { get; set; } = -1;

    /// <summary>
    /// Speed of the countdown before the first hitobject.
    /// </summary>
    public CountdownType Countdown { get; set; } = CountdownType.Normal;

    /// <summary>
    /// Sample set that will be used if timing points do not override it (Normal, Soft, Drum).
    /// </summary>
    public SampleSet SampleSet { get; set; } = SampleSet.Normal;

    /// <summary>
    /// Multiplier for the threshold in time where hitobjects placed close together stack (0–1).
    /// </summary>
    public float StackLeniency { get => m_stackLeniency; set => m_stackLeniency = value > 1 ? 1 : value < 0 ? 0 : value; }
    private float m_stackLeniency = 0.7f;

    /// <summary>
    /// Game mode (osu!, osu!taiko, osu!catch, osu!mania).
    /// </summary>
    public Mode Mode { get; set; } = Mode.Standard;

    /// <summary>
    /// Whether or not breaks have a letterboxing effect.
    /// </summary>
    public bool LetterboxInBreaks { get; set; } = false;

    /// <summary>
    /// Whether or not the storyboard can use the user's skin images.
    /// </summary>
    public bool UseSkinSprites { get; set; } = false;

    /// <summary>
    /// Draw order of hitcircle overlays compared to hit numbers (NoChange = use skin setting, Below = draw overlays under numbers, Above = draw overlays on top of numbers).
    /// </summary>
    public OverlayPosition OverlayPosition { get; set; } = OverlayPosition.NoChange;

    /// <summary>
    /// Preferred skin to use during gameplay.
    /// </summary>
    public string SkinPreference { get; set; } = "";

    /// <summary>
    /// Whether or not a warning about flashing colours should be shown at the beginning of the map.
    /// </summary>
    public bool EpilepsyWarning { get; set; } = false;

    /// <summary>
    /// Time in beats that the countdown starts before the first hitobject.
    /// </summary>
    public int CountdownOffset { get; set; } = 0;

    /// <summary>
    /// Whether or not the "N+1" style key layout is used for osu!mania.
    /// </summary>
    public bool SpecialStyle { get; set; } = false;

    /// <summary>
    /// Whether or not the storyboard allows widescreen viewing.
    /// </summary>
    public bool WidescreenStoryboard { get; set; } = false;

    /// <summary>
    /// Whether or not sound samples will change rate when playing with speed-changing mods.
    /// </summary>
    public bool SamplesMatchPlaybackRates { get; set; } = false;
  }
}
