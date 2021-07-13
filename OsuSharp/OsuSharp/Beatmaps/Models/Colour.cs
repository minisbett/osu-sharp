using OsuSharp.Beatmaps.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OsuSharp.Beatmaps.Models
{
  /// <summary>
  /// Represents a colour in a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)">osu! documentation</see>.
  /// </summary>
  public class Colour
  {
    /// <summary>
    /// Creates a new <seealso cref="Colour"/> instance with the specified colour type.
    /// </summary>
    /// <param name="type">The colour type</param>
    /// <param name="color">The color</param>
    public Colour(ColourType type, Color color)
    {
      Type = type;
      Color = color;
    }

    /// <summary>
    /// Creates a new <seealso cref="Colour"/> instance with the specified colour type.
    /// </summary>
    /// <param name="type">The colour type</param>
    /// <param name="color">The color</param>
    /// <param name="index">The index of the combo this colour corresponds to</param>
    public Colour(ColourType type, Color color, int index)
    {
      Type = type;
      Color = color;
      ComboIndex = index;
    }

    /// <summary>
    /// The type of Colour (Combo, SliderTrackOverride or SliderBorder)
    /// </summary>
    public ColourType Type { get; set; }

    /// <summary>
    /// Index of the combo which colour this represents.
    /// </summary>
    public int ComboIndex { get; set; } = -1;

    /// <summary>
    /// The RGB Color of this <seealso cref="Colour"/> object.
    /// </summary>
    public Color Color { get; set; }
  }
}
