using osu_sharp.Helpers;

namespace osu_sharp.Enums;

/// <summary>
/// The type of a changelog entry, describing the type of change made (Add, Fix, ...).
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/Changelog.php"/>
/// </summary>
public enum ChangelogEntryType
{
  /// <summary>
  /// Indicates an addition.
  /// </summary>
  [JsonAPIName("add")]
  Add,

  /// <summary>
  /// Indicates a change that fixes a bug.
  /// </summary>
  [JsonAPIName("fix")]
  Fix,

  /// <summary>
  /// Indicates a miscellaneous change.
  /// </summary>
  [JsonAPIName("misc")]
  Miscellaneous,
}
