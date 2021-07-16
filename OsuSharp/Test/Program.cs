using OsuSharp.Beatmaps;
using OsuSharp.Beatmaps.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Test
{
  class Program
  {
    static void Main(string[] args)
    {
      Stopwatch stopwatch = new Stopwatch();
      List<long> benchmarks = new List<long>();

      string data1 = File.ReadAllText("C:\\Users\\Niklas\\Desktop\\test.osu");
      Beatmap b = null;
      for (int i = 0; i < 100; i++)
      {
        stopwatch.Restart();
        b = BeatmapParser.Deserialize(data1);
        stopwatch.Stop();
        benchmarks.Add(stopwatch.ElapsedMilliseconds);
      }

      double average = Math.Round(benchmarks.Sum() * 1d / benchmarks.Count, 2);
      Console.WriteLine($"Benchmark average of 100 deserializations: {average.ToString(new CultureInfo("en-US"))}ms");
      Console.WriteLine($"Hit Circles: {b.HitObjects.Count(x => x.IsHitCircle)}");
      Console.WriteLine($"Sliders: {b.HitObjects.Count(x => x.IsSlider)}");
      Console.WriteLine($"Spinners: {b.HitObjects.Count(x => x.IsSpinner)}");
      Console.WriteLine($"SV Timingpoints: {b.TimingPoints.Count(x => x.IsSVTimingPoint)}");
      Console.WriteLine($"BPM Timingpoints: {b.TimingPoints.Count(x => x.IsBPMTimingPoint)}");
      Console.WriteLine($"Colours: {b.Colours.Count}");
      Console.WriteLine($"Background Events: {b.Events.Count(x => x.IsBackground)}");
      Console.WriteLine($"Video Events: {b.Events.Count(x => x.IsVideo)}");
      Console.WriteLine($"Break Events: {b.Events.Count(x => x.IsBreak)}");

      benchmarks.Clear();
      for (int i = 0; i < 100; i++)
      {
        stopwatch.Restart();
        string data2 = BeatmapParser.Serialize(b);
        stopwatch.Stop();
        benchmarks.Add(stopwatch.ElapsedMilliseconds);
      }

      average = Math.Round(benchmarks.Sum() * 1d / benchmarks.Count, 2);
      Console.WriteLine($"Benchmark average of 100 serializations: {average.ToString(new CultureInfo("en-US"))}ms");
      Console.ReadLine();
    }
  }
}
