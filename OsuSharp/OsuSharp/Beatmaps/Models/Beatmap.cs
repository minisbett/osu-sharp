using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models
{
  /// <summary>
  /// Represents a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)">osu! documentation</see>.
  /// </summary>
  public class Beatmap
  {
    internal Beatmap() { }

    /// <summary>
    /// The "[General]" section of the beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#general">osu! documentation</see>.
    /// </summary>
    public GeneralSection General { get; internal set; } = new GeneralSection();

    /// <summary>
    /// The "[Editor]" section of the beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#editor">osu! documentation</see>.
    /// </summary>
    public EditorSection Editor { get; internal set; } = new EditorSection();

    /// <summary>
    /// The "[Metadata]" section of the beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#metadata">osu! documentation</see>.
    /// </summary>
    public MetadataSection Metadata { get; internal set; } = new MetadataSection();

    /// <summary>
    /// The "[Difficulty]" section of the beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#difficulty">osu! documentation</see>.
    /// </summary>
    public DifficultySection Difficulty { get; internal set; } = new DifficultySection();

    /// <summary>
    /// The "[Events]" section of the beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#events">osu! documentation</see>.
    /// </summary>
    public List<Event> Events { get; } = new List<Event>();

    /// <summary>
    /// The "[TimingPoints]" section of the beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#timing-points">osu! documentation</see>.
    /// </summary>
    public List<TimingPoint> TimingPoints { get; } = new List<TimingPoint>();

    /// <summary>
    /// The "[Colours]" section of the beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#colours">osu! documentation</see>.
    /// </summary>
    public List<Colour> Colours { get; } = new List<Colour>();

    /// <summary>
    /// The "[HitObjects]" section of the beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#hit-objects">osu! documentation</see>.
    /// </summary>
    public List<HitObject> HitObjects { get; } = new List<HitObject>();
  }
}
