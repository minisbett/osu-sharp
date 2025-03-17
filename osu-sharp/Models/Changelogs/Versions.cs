using Newtonsoft.Json;

namespace osu_sharp.Models.Changelogs
{
  /// <summary>
  /// Represents the previous and next version of a <see cref="Build"/>.
  /// <br/><br/>
  /// API docs: <a href="https://osu.ppy.sh/docs/index.html#build-versions"/><br/>
  /// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/BuildTransformer.php"/>
  /// </summary>
  public class Versions
  {
    /// <summary>
    /// The next build version. This will be null if no newer build exists.
    /// </summary>
    [JsonProperty("next")]
    public Build? Next { get; private set; }

    /// <summary>
    /// The previous build version. This will be null if no older build exists.
    /// </summary>
    [JsonProperty("previous")]
    public Build? Previous { get; private set; }
  }
}
