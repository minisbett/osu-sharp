using OsuSharp.BeatmapSets.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.BeatmapSets
{
  public static class BeatmapSetParser
  {
    public static BeatmapSet Deserialize(byte[] data)
    {
      return new BeatmapSet();
    }

    public static BeatmapSet DeserializeFile(string filePath) => Deserialize(File.ReadAllBytes(filePath));
  }
}
