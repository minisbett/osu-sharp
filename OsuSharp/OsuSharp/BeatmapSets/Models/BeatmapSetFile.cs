using OsuSharp.BeatmapSets.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.BeatmapSets.Models
{
  public class BeatmapSetFile
  {
    internal BeatmapSetFile(string filename, string path, byte[] data, FileType type)
    {
      Filename = filename;
      Path = path;
      Data = data;
      Type = type;
    }

    public string Filename { get; }

    public string Path { get; }

    public byte[] Data { get; }

    public FileType Type { get; }
  }
}
