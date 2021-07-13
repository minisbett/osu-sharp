using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Beatmaps.Models
{
  /// <summary>
  /// Represents the "[Difficulty]" section of a beatmap according to the <see href="https://osu.ppy.sh/wiki/en/osu!_File_Formats/Osu_(file_format)#difficulty">osu! documentation</see>.
  /// </summary>
  public class DifficultySection
  {
    public DifficultySection() { }

    /// <summary>
    /// HP setting (0–10).
    /// </summary>
    public float HPDrainRate { get => m_hp; set => m_hp = value > 10 ? 10 : value < 0 ? 0 : value; }
    private float m_hp = 5;

    /// <summary>
    /// CS setting (0–10).
    /// </summary>
    public float CircleSize { get => m_cs; set => m_cs = value > 10 ? 10 : value < 0 ? 0 : value; }
    private float m_cs = 5;

    /// <summary>
    /// OD setting (0–10).
    /// </summary>
    public float OverallDifficulty { get => m_od; set => m_od = value > 10 ? 10 : value < 0 ? 0 : value; }
    private float m_od = 5;

    /// <summary>
    /// AR setting (0–10).
    /// </summary>
    public float ApproachRate { get => m_ar; set => m_ar = value > 10 ? 10 : value < 0 ? 0 : value; }
    private float m_ar = 5;


    /// <summary>
    /// The base slider multiplier of the map.
    /// </summary>
    public float SliderMultiplier { get => m_slidermultiplier; set => m_slidermultiplier = value > 3.6f ? 3.6f : value < 0 ? 0 : value; }
    private float m_slidermultiplier = 1.4f;

    /// <summary>
    /// The slider tick rate of the map.
    /// </summary>
    public float SliderTickRate { get => m_slidertickrate; set => m_slidertickrate = value > 8 ? 8 : value < 0.5f ? 0.5f : value; }
    private float m_slidertickrate = 1;
  }
}
