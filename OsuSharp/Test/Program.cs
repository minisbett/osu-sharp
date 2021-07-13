using Newtonsoft.Json;
using OsuSharp.Beatmaps;
using OsuSharp.Beatmaps.Models;
using System;
using System.Diagnostics;

namespace Test
{
  class Program
  {
    static void Main(string[] args)
    {
      Stopwatch watch = new Stopwatch();
      watch.Start();
      Beatmap beatmap = BeatmapParser.FromFile("C:\\Users\\Niklas\\Desktop\\test.osu");
      watch.Stop();
      string json = JsonConvert.SerializeObject(beatmap, Formatting.Indented);
      Console.WriteLine(json);
      //System.IO.File.WriteAllText("C:\\Users\\Niklas\\Desktop\\test.json", json);
      Console.ReadLine();
    }
  }
}
