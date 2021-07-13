using OsuSharp.Beatmaps.Enums;
using OsuSharp.Beatmaps.Models;
using OsuSharp.Beatmaps.Models.HitObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps
{
  /// <summary>
  /// Static class that provides methods to parse a beatmap from various input sources.
  /// </summary>
  public static class BeatmapParser
  {
    /// <summary>
    /// Creates a new <seealso cref="Beatmap"/> object and parses the beatmap data from a stream.
    /// </summary>
    /// <param name="data">A stream with the content of the .osu file.</param>
    /// <returns>The parsed beatmap.</returns>
    public static Beatmap FromStream(Stream s)
    {
      byte[] buffer = new byte[s.Length];
      s.Read(buffer, 0, buffer.Length);
      return FromData(buffer);
    }

    /// <summary>
    /// Creates a new <seealso cref="Beatmap"/> object and parses the beatmap data from a file.
    /// </summary>
    /// <param name="data">The path to the .osu file.</param>
    /// <returns>The parsed beatmap.</returns>
    public static Beatmap FromFile(string filePath)
    {
      byte[] data = File.ReadAllBytes(filePath);
      return FromData(data);
    }

    /// <summary>
    /// Creates a new <seealso cref="Beatmap"/> object and parses the beatmap data from a byte array.
    /// </summary>
    /// <param name="data">A byte array with the content of the .osu file.</param>
    /// <returns>The parsed beatmap.</returns>
    public static Beatmap FromData(byte[] data)
    {
      Beatmap beatmap = new Beatmap();
      // Read the lines from the byte array, split it and sort out empty lines
      List<string> lines = Encoding.UTF8.GetString(data).Replace("\r", "").Split('\n').Where(x => x != "").ToList();
      // add a "[]" to also parse the last section
      lines.Add("[]");
      string section = "";
      List<string> sectionLines = new List<string>();

      // go through each line and handle it
      foreach (string line in lines)
      {
        // If the line is formatted like "[...]", parse all lines that occured in the current section
        if (line.StartsWith("[") && line.EndsWith("]"))
        {
          if (section == "General")
            beatmap.General = ParseSection<GeneralSection>(sectionLines);
          else if (section == "Editor")
            beatmap.Editor = ParseSection<EditorSection>(sectionLines);
          else if (section == "Metadata")
            beatmap.Metadata = ParseSection<MetadataSection>(sectionLines);
          else if (section == "Difficulty")
            beatmap.Difficulty = ParseSection<DifficultySection>(sectionLines);
          else if (section == "Events")
            beatmap.Events.AddRange(ParseEventsSection(sectionLines));
          else if (section == "TimingPoints")
            beatmap.TimingPoints.AddRange(ParseTimingPointsSection(sectionLines));
          else if (section == "Colours")
            beatmap.Colours.AddRange(ParseColoursSection(sectionLines));
          else if (section == "HitObjects")
            beatmap.HitObjects.AddRange(ParseHitObjectsSection(sectionLines));

          // get the new section name and reset the list of lines in the current section
          section = line.Substring(1, line.Length - 2);
          sectionLines.Clear();
        }
        // otherwise, if the enumeration already encountered a section, add the line to the current section
        else if (section != "")
          sectionLines.Add(line);
      }

      return beatmap;
    }

    private static T ParseSection<T>(List<string> lines)
    {
      // create a new instance of the section
      T section = (T)Activator.CreateInstance(typeof(T));
      // go through all valid lines
      foreach (string line in lines.Where(x => x.Contains(":") && x.Split(':').Length >= 2))
      {
        // get key and value
        string key = line.Split(':')[0];
        string value = line.Split(":".ToCharArray(), 2)[1];

        // find the property that corresponds to the key
        PropertyInfo property = typeof(T).GetProperties().FirstOrDefault(x => x.Name == key);
        if (property == null)
          continue;

        Type type = property.PropertyType;
        object obj = value;

        // try to convert the value into the type requested by the property
        try
        {
          // Number conversions
          if (type == typeof(int))
            obj = int.Parse(value);
          else if (type == typeof(float))
            obj = float.Parse(value, new CultureInfo("en-US"));

          // enum conversions
          else if (type == typeof(CountdownType) || type == typeof(Mode))
            obj = int.Parse(value);
          else if (type == typeof(SampleSet) || type == typeof(OverlayPosition))
            obj = Enum.Parse(type, value);

          // bool conversion
          else if (type == typeof(bool))
            obj = (new bool[] { false, true })[int.Parse(value)];

          // list conversions
          else if (type == typeof(List<string>))
            obj = value.Split(' ').ToList();
          else if (type == typeof(List<int>))
            obj = value.Split(',').Select(x => int.Parse(x)).ToList();
        }
        catch { continue; }

        // set the property to the resulting type
        property.SetValue(section, obj);
      }

      return section;
    }

    private static List<Event> ParseEventsSection(List<string> lines)
    {
      List<Event> events = new List<Event>();

      // go through all valid lines
      foreach (string line in lines.Where(x => x.Contains(",") && x.Split(',').Length == 8))
      {
        // split the line to follow the eventType,startTime,eventParams syntax
        string[] split = line.Split(",".ToCharArray(), 3);

        try
        {
          // parse the values
          string type = split[0];
          int offset = int.Parse(split[1]);
          string eventparams = split[2];

          // interpret the type and create the according event object
          if (type == "Background" || type == "0")
            events.Add(new BackgroundEvent(offset, eventparams.Split(',')[0], int.Parse(eventparams.Split(',')[1]), int.Parse(eventparams.Split(',')[2])));
          else if (type == "Video" || type == "1")
            events.Add(new VideoEvent(offset, eventparams.Split(',')[0], int.Parse(eventparams.Split(',')[1]), int.Parse(eventparams.Split(',')[2])));
          else if (type == "Break" || type == "2")
            events.Add(new BreakEvent(offset, int.Parse(eventparams)));
        }
        catch { continue; }
      }

      return events;
    }

    private static List<TimingPoint> ParseTimingPointsSection(List<string> lines)
    {
      List<TimingPoint> timingpoints = new List<TimingPoint>();

      // go through all valid lines
      foreach (string line in lines.Where(x => x.Contains(",") && x.Split(',').Length == 8))
      {
        string[] split = line.Split(',');

        try
        {
          // parse the values
          int offset = int.Parse(split[0]);
          float beatLength = float.Parse(split[1], new CultureInfo("en-US"));
          int meter = int.Parse(split[2]);
          int sampleset = int.Parse(split[3]);
          int sampleindex = int.Parse(split[4]);
          int volume = int.Parse(split[5]);
          int uninherited = int.Parse(split[6]);
          int effects = int.Parse(split[7]);

          // interpret the type and create the according event object
          if (uninherited == 1)
            timingpoints.Add(new BPMTimingPoint(offset, beatLength, (SampleSet)sampleset, sampleindex, volume, (TimingPointEffect)effects));
          else
            timingpoints.Add(new SVTimingPoint(offset, beatLength, (SampleSet)sampleset, sampleindex, volume, (TimingPointEffect)effects));
        }
        catch { continue; }
      }

      return timingpoints;
    }

    private static List<Colour> ParseColoursSection(List<string> lines)
    {
      List<Colour> colours = new List<Colour>();

      // go through all valid lines
      foreach (string line in lines.Where(x => x.Contains(":") && x.Split(':').Length == 2))
      {
        string key = line.Split(':')[0];
        string value = line.Split(':')[1];

        try
        {
          // parse the color
          int r = int.Parse(value.Split(',')[0]);
          int g = int.Parse(value.Split(',')[1]);
          int b = int.Parse(value.Split(',')[2]);

          // interpret the type and create the according colour object
          if (key.StartsWith("Combo"))
            colours.Add(new Colour(ColourType.Combo, Color.FromArgb(r, g, b), int.Parse(key.Substring(5))));
          else if (key.StartsWith("SliderTrackOverride"))
            colours.Add(new Colour(ColourType.SliderTrackOverride, Color.FromArgb(r, g, b)));
          else if (key.StartsWith("SliderBorder"))
            colours.Add(new Colour(ColourType.SliderBorder, Color.FromArgb(r, g, b)));
        }
        catch { continue; }
      }

      return colours;
    }

    private static List<HitObject> ParseHitObjectsSection(List<string> lines)
    {
      List<HitObject> hitobjects = new List<HitObject>();

      // go through all valid lines
      foreach (string line in lines.Where(x => x.Contains(",") && x.Split(',').Length >= 6))
      {
        // do this to split to have all object params (that may also contain ",") in a single list item.
        string[] _split = line.Split(',');
        List<string> split = new List<string>();
        split.AddRange(_split.Take(5));
        split.Add(string.Join(",", _split.Skip(5).Take(_split.Length - 6)));
        split.Add(_split.Last());

        try
        {
          // parse the general stuff
          int x = int.Parse(split[0]);
          int y = int.Parse(split[1]);
          int offset = int.Parse(split[2]);
          int type = int.Parse(split[3]);
          bool newcombo = (type & 2) != 0;
          HitObjectType objtype = (type & 7) == 0 ? HitObjectType.ManiaHold : (type & 3) == 0 ? HitObjectType.Spinner : (type & 1) == 0 ? HitObjectType.Slider : HitObjectType.HitCircle;
          int combocolorskips = (type >> 4) & 7;                
          int hitsound = int.Parse(split[4]);
          string[] objparams = split[5].Split(',');

          // parse the hitsample
          string hitsample = objtype == HitObjectType.HitCircle ? objparams[0] : split[6];
          string[] hitsamplesplit = hitsample.Split(':');
          SampleSet normalset = (SampleSet)int.Parse(hitsamplesplit[0]);
          SampleSet additionset = (SampleSet)int.Parse(hitsamplesplit[1]);
          int sampleindex = int.Parse(hitsamplesplit[2]);
          int volume = int.Parse(hitsamplesplit[3]);
          string filename = hitsamplesplit[4];

          // add the hitobject to the list
          if (objtype == HitObjectType.HitCircle)
            hitobjects.Add(new HitCircle(offset, new Point(x, y), newcombo, combocolorskips, (HitSound)hitsound, normalset, additionset, sampleindex, volume, filename));
          else if (objtype == HitObjectType.Slider)
          {
            string curvetypestr = objparams[0].Split('|')[0];
            CurveType curvetype = curvetypestr == "B" ? CurveType.Bezier : curvetypestr == "C" ? CurveType.CatmullRom : curvetypestr == "L" ? CurveType.Linear : CurveType.PerfectCircle;
            List<Point> curvepoints = objparams[0].Split('|').Skip(1).Select(x => new Point(int.Parse(x.Split(':')[0]), int.Parse(x.Split(':')[1]))).ToList();
            int slides = int.Parse(objparams[1]);
            float length = float.Parse(objparams[2], new CultureInfo("en-US"));
            List<HitSound> edgesounds = objparams[3].Split('|').Select(x => (HitSound)int.Parse(x)).ToList();
            List<(SampleSet, SampleSet)> edgesets = objparams[4].Split('|').Select(x => ((SampleSet)int.Parse(x.Split(':')[0]), (SampleSet)int.Parse(x.Split(':')[1]))).ToList();
            hitobjects.Add(new Slider(offset, new Point(x, y), curvetype, curvepoints, length, slides, edgesounds, edgesets, newcombo, combocolorskips, (HitSound)hitsound, normalset, additionset, sampleindex, volume, filename));
          }
          else if(objtype == HitObjectType.Spinner)
          {
            // parse the spinner endtime from the object params
            int endtime = int.Parse(objparams[0]);
            hitobjects.Add(new Spinner(offset, endtime, (HitSound)hitsound, normalset, additionset, sampleindex, volume, filename));
          }
        }
        catch { continue; }
      }

      return hitobjects;
    }
  }
}
