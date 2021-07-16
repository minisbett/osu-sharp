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

    #region Serialization

    /// <summary>
    /// Serializes the specified <seealso cref="Beatmap" /> object into a string.
    /// </summary>
    /// <param name="beatmap">The beatmap that is being serialized.</param>
    /// <returns>The serialized string, in the format of a .osu file as described in the <seealso cref="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)">osu! documentation</seealso></returns>
    public static string Serialize(Beatmap beatmap)
    {
      // list that contains all lines of the beatmap data
      List<string> lines = new List<string>() { "osu file format v14", "" };

      // all sections of the beatmap data
      string[] sections = new string[] { "General", "Editor", "Metadata", "Difficulty", "Events", "TimingPoints", "Colours", "HitObjects" };

      // enumerate through all sections and serialize them accordingly
      foreach (string section in sections)
      {
        lines.Add($"[{section}]");

        if (section == "General")
          lines.AddRange(SerializeSection(beatmap.General));
        else if (section == "Editor")
          lines.AddRange(SerializeSection(beatmap.Editor));
        else if (section == "Metadata")
          lines.AddRange(SerializeSection(beatmap.Metadata));
        else if (section == "Difficulty")
          lines.AddRange(SerializeSection(beatmap.Difficulty));
        else if (section == "Events")
          foreach (Event e in beatmap.Events)
            try { lines.Add(SerializeEvent(e)); }
            catch { }
        else if (section == "TimingPoints")
          foreach (TimingPoint timingpoint in beatmap.TimingPoints)
            try { lines.Add(SerializeTimingPoint(timingpoint)); }
            catch { }
        else if (section == "Colours")
          foreach (Colour colour in beatmap.Colours)
            try { lines.Add(SerializeColour(colour)); }
            catch { }
        else if (section == "HitObjects")
          foreach (HitObject hitobject in beatmap.HitObjects)
            try { lines.Add(SerializeHitObject(hitobject)); }
            catch { }

        lines.Add("");
      }

      // Join the list of strings and return it
      return string.Join("\n", lines);
    }

    private static List<string> SerializeSection<T>(T section)
    {
      List<string> lines = new List<string>();

      // get all valid properties
      PropertyInfo[] properties = typeof(T).GetProperties();

      // go through all valid properties
      foreach (PropertyInfo property in properties)
      {
        // get key and value
        string key = property.Name;
        object obj = property.GetValue(section);

        // get the type of the property
        Type type = property.PropertyType;

        // obj.ToString() as the default string value, works for string, int, SampleSet and OverlayPosition
        string value = obj.ToString();

        // try to convert the value of the property into a string
        try
        {
          // number conversion
          if (type == typeof(float))
            value = ((float)obj).ToString(new CultureInfo("en-US"));

          // enum conversions
          else if (type == typeof(CountdownType) || type == typeof(Mode))
            value = $"{(int)obj}";

          // bool conversion
          else if (type == typeof(bool))
            value = (bool)obj ? "1" : "0";

          // list conversions
          else if (type == typeof(List<string>))
            value = string.Join(" ", (List<string>)obj);
          else if (type == typeof(List<int>))
            value = string.Join(",", (List<int>)obj);

          lines.Add($"{key}:{value}");

        }
        catch { continue; }
      }

      return lines;
    }

    private static string SerializeEvent(Event e)
    {
      if (e is BackgroundEvent)
      {
        BackgroundEvent be = e as BackgroundEvent;
        return $"Background,{be.Offset},\"{be.Filename}\",{be.PositionOffset.X},{be.PositionOffset.Y}";
      }
      else if (e is VideoEvent)
      {
        VideoEvent ve = e as VideoEvent;
        return $"Video,{ve.Offset},\"{ve.Filename}\",{ve.PositionOffset.X},{ve.PositionOffset.Y}";
      }
      else if (e is BreakEvent)
      {
        BreakEvent be = e as BreakEvent;
        return $"Break,{be.Offset},{be.EndTime}";
      }
      else
        throw new Exception();
    }

    private static string SerializeTimingPoint(TimingPoint tp)
    {
      float beatlength = tp.IsSVTimingPoint ? (tp as SVTimingPoint).Percentage : (tp as BPMTimingPoint).BeatLength;
      int meter = tp.IsBPMTimingPoint ? (tp as BPMTimingPoint).Meter : 0;
      return $"{tp.Offset},{beatlength.ToString(new CultureInfo("en-US"))},{meter},{(int)tp.SampleSet},{tp.SampleIndex},{tp.Volume},{(tp.IsBPMTimingPoint ? 1 : 0)},{(int)tp.Effects}";
    }

    private static string SerializeColour(Colour c)
    {
      return $"{c.Type}{(c.ComboIndex != -1 ? c.ComboIndex : "")}:{c.Color.R},{c.Color.G},{c.Color.B}";
    }

    private static string SerializeHitObject(HitObject ho)
    {
      int type = (int)ho.Type | ((ho.NewCombo ? 1 : 0) >> 2) | (ho.ComboColorSkips >> 4);
      string hitsample = $"{(int)ho.NormalSet}:{(int)ho.AdditionSet}:{ho.SampleIndex}:{ho.Volume}:{ho.HitSoundFilename}";
      string objparams = "";
      if (ho is Slider)
      {
        Slider s = ho as Slider;
        string curvetype = s.CurveType.ToString().Substring(0, 1);
        string curvepoints = string.Join("|", s.CurvePoints.Select(x => $"{x.X}:{x.Y}"));
        string edgesounds = string.Join("|", s.EdgeSounds.Select(x => (int)x));
        string edgesets = string.Join("|", s.EdgeSets.Select(x => $"{(int)x.NormalSet}:{(int)x.AdditonSet}"));
        objparams = $"{curvetype}|{curvepoints},{s.Slides},{s.Length.ToString(new CultureInfo("en-US"))},{edgesounds},{edgesets}";
      }
      else if (ho is Spinner)
      {
        Spinner s = ho as Spinner;
        objparams = $"{s.EndTime}";
      }

      return $"{ho.Position.X},{ho.Position.Y},{ho.Offset},{type},{(int)ho.HitSound},{(objparams == "" ? "" : $"{objparams},")}{hitsample}";
    }

    #endregion

    #region Deserialization

    /// <summary>
    /// Creates a new <seealso cref="Beatmap"/> object and deserializes the beatmap data from the content of a given file.
    /// </summary>
    /// <param name="data">The path to the .osu file.</param>
    /// <returns>The deserialized <seealso cref="Beatmap"/> object.</returns>
    public static Beatmap DeserializeFile(string filePath) => Deserialize(File.ReadAllText(filePath));

    /// <summary>
    /// Creates a new <seealso cref="Beatmap"/> object and deserializes the beatmap data from a byte array.
    /// </summary>
    /// <param name="data">A byte array with the content of the .osu file.</param>
    /// <returns>The deserialized <seealso cref="Beatmap"/> object.</returns>
    public static Beatmap Deserialize(byte[] data) => Deserialize(Encoding.UTF8.GetString(data));

    /// <summary>
    /// Creates a new <seealso cref="Beatmap"/> object and deserializes the beatmap data from a string array.
    /// </summary>
    /// <param name="data">A string array with the lines of the .osu file.</param>
    /// <returns>The deserialized <seealso cref="Beatmap"/> object.</returns>
    public static Beatmap Deserialize(string[] data) => Deserialize(string.Join("\n", data));

    /// <summary>
    /// Creates a new <seealso cref="Beatmap"/> object and deserializes the beatmap data from a string.
    /// </summary>
    /// <param name="data">A string with the content of the .osu file.</param>
    /// <returns>The deserialized <seealso cref="Beatmap"/> object.</returns>
    public static Beatmap Deserialize(string data)
    {
      Beatmap beatmap = new Beatmap();
      // Read the lines from the byte array, split it and sort out empty lines
      List<string> lines = data.Replace("\r", "").Split('\n').Where(x => x != "").ToList();
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
            beatmap.General = DeserializeSection<GeneralSection>(sectionLines);
          else if (section == "Editor")
            beatmap.Editor = DeserializeSection<EditorSection>(sectionLines);
          else if (section == "Metadata")
            beatmap.Metadata = DeserializeSection<MetadataSection>(sectionLines);
          else if (section == "Difficulty")
            beatmap.Difficulty = DeserializeSection<DifficultySection>(sectionLines);
          else if (section == "Events")
            beatmap.Events.AddRange(DeserializeEventsSection(sectionLines));
          else if (section == "TimingPoints")
            beatmap.TimingPoints.AddRange(DeserializeTimingPointsSection(sectionLines));
          else if (section == "Colours")
            beatmap.Colours.AddRange(DeserializeColoursSection(sectionLines));
          else if (section == "HitObjects")
            beatmap.HitObjects.AddRange(DeserializeHitObjectsSection(sectionLines));

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

    private static T DeserializeSection<T>(List<string> lines)
    {
      // create a new instance of the section
      T section = (T)Activator.CreateInstance(typeof(T));
      // go through all valid lines
      foreach (string line in lines.Where(x => x.Contains(":") && x.Split(':').Length >= 2))
      {
        // get key and value
        string key = line.Split(':')[0];
        string value = line.Split(":".ToCharArray(), 2)[1].Trim(' ');

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

    private static List<Event> DeserializeEventsSection(List<string> lines)
    {
      List<Event> events = new List<Event>();

      // go through all valid lines
      foreach (string line in lines.Where(x => x.Contains(",") && x.Split(',').Length == 8))
      {
        // split the line to follow the eventType,startTime,eventParams syntax
        string[] split = line.Split(",".ToCharArray(), 3);

        try
        {
          // parse the value
          string type = split[0];
          int offset = int.Parse(split[1]);
          string eventparams = split[2];

          // interpret the type and create the according event object
          if (type == "Background" || type == "0")
            events.Add(new BackgroundEvent(eventparams.Split(',')[0], int.Parse(eventparams.Split(',')[1]), int.Parse(eventparams.Split(',')[2])));
          else if (type == "Video" || type == "1")
            events.Add(new VideoEvent(eventparams.Split(',')[0], int.Parse(eventparams.Split(',')[1]), int.Parse(eventparams.Split(',')[2]), offset));
          else if (type == "Break" || type == "2")
            events.Add(new BreakEvent(offset, int.Parse(eventparams)));
        }
        catch { continue; }
      }

      return events;
    }

    private static List<TimingPoint> DeserializeTimingPointsSection(List<string> lines)
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
            timingpoints.Add(new BPMTimingPoint(offset, beatLength, meter, (SampleSet)sampleset, sampleindex, volume, (TimingPointEffect)effects));
          else
            timingpoints.Add(new SVTimingPoint(offset, beatLength, (SampleSet)sampleset, sampleindex, volume, (TimingPointEffect)effects));
        }
        catch { continue; }
      }

      return timingpoints;
    }

    private static List<Colour> DeserializeColoursSection(List<string> lines)
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

    private static List<HitObject> DeserializeHitObjectsSection(List<string> lines)
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
          string[] hitsamplesplit = split[6].Split(':');
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
            CurveType curvetype = Enum.GetValues(typeof(CurveType)).Cast<CurveType>().First(x => x.ToString().StartsWith(curvetypestr));
            List<Point> curvepoints = objparams[0].Split('|').Skip(1).Select(x => new Point(int.Parse(x.Split(':')[0]), int.Parse(x.Split(':')[1]))).ToList();
            int slides = int.Parse(objparams[1]);
            float length = float.Parse(objparams[2], new CultureInfo("en-US"));
            List<HitSound> edgesounds = objparams[3].Split('|').Select(x => (HitSound)int.Parse(x)).ToList();
            List<(SampleSet, SampleSet)> edgesets = objparams[4].Split('|').Select(x => ((SampleSet)int.Parse(x.Split(':')[0]), (SampleSet)int.Parse(x.Split(':')[1]))).ToList();
            hitobjects.Add(new Slider(offset, new Point(x, y), curvetype, curvepoints, length, slides, edgesounds, edgesets, newcombo, combocolorskips, (HitSound)hitsound, normalset, additionset, sampleindex, volume, filename));
          }
          else if (objtype == HitObjectType.Spinner)
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

    #endregion

  }
}
