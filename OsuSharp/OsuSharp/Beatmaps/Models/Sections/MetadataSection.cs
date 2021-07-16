using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models
{ 
   /// <summary>
   /// Represents the "[Metadata]" section of a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#metadata">osu! documentation</see>.
   /// </summary>
  public class MetadataSection
  {
    public MetadataSection() { }

    /// <summary>
    ///	The romanised song title
    /// </summary>
    public string Title { get; set; } = "";

    /// <summary>
    /// The song title
    /// </summary>
    public string TitleUnicode { get; set; } = "";

    /// <summary>
    /// The romanised song artist
    /// </summary>
    public string Artist { get; set; } = "";

    /// <summary>
    /// The song artist
    /// </summary>
    public string ArtistUnicode { get; set; } = "";

    /// <summary>
    /// The beatmap creator
    /// </summary>
    public string Creator { get; set; } = "";

    /// <summary>
    /// The difficulty name
    /// </summary>
    public string Version { get; set; } = "";

    /// <summary>
    /// The original media the song was produced for
    /// </summary>
    public string Source { get; set; } = "";

    /// <summary>
    /// The search terms
    /// </summary>
    public List<string> Tags { get; set; } = new List<string>();

    /// <summary>
    /// The beatmap ID
    /// </summary>
    public int BeatmapID { get; set; } = 0;

    /// <summary>
    /// The beatmapset ID.
    /// </summary>
    public int BeatmapSetID { get; set; } = -1;
  }
}
