using OsuSharp.Beatmaps;
using OsuSharp.Beatmaps.Models;
using OsuSharp.BeatmapSets.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.BeatmapSets.Models
{
  public class BeatmapSet
  {
    // Lookup table to get the right filetype for the file extension
    private static readonly List<(FileType Type, string[] Extensions)> ExtensionLookupTable = new List<(FileType Type, string[] Extensions)>()
    {
      (FileType.Beatmap, new string[] { ".osu"}),
      (FileType.Storyboard, new string[] { ".osb" }),
      (FileType.Audio, new string[] { ".mp3", ".ogg", ".wav"}),
      (FileType.Image, new string[] { ".jpg", ".jpeg", ".png", ".bmp" }),
      (FileType.Video, new string[] { ".mp4", ".mov", ".mkv", ".flv" })
    };

    private List<BeatmapSetFile> m_files = new List<BeatmapSetFile>();
    public IReadOnlyList<BeatmapSetFile> Files => m_files.AsReadOnly();

    public void AddFile(byte[] data, string filename, string path = "")
    {
      if (!ExtensionLookupTable.Any(x => x.Extensions.Any(x => filename.EndsWith(x))))
        throw new InvalidOperationException("The specified filename does not provide a valid file extension.");
      else if (m_files.Any(x => x.Filename == filename && x.Path == path))
        throw new InvalidOperationException("A file with the specified filename already exists in the specified path.");

      FileType type = ExtensionLookupTable.First(x => x.Extensions.Any(x => filename.EndsWith(x))).Type;

      BeatmapSetFile setfile = new BeatmapSetFile(filename, path, data, type);
      m_files.Add(setfile);
    }

    public void RemoveFile(string filename, string path = "")
    {
      m_files.RemoveAll(x => x.Filename == filename && x.Path == path);
    }
  }
}
