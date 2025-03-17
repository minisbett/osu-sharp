namespace osu_sharp.Enums;

/// <summary>
/// Represents the type of scores associated with a user. (recent scores, first place scores, etc.)
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-user-scores"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/profile-page/extra-page-props.ts"/>
/// </summary>
public enum UserScoreType
{
  /// <summary>
  /// The recent scores of the user.
  /// </summary>
  [QueryAPIName("recent")]
  Recent,

  /// <summary>
  /// The best scores of the user.
  /// </summary>
  [QueryAPIName("best")]
  Best,

  /// <summary>
  /// The first place scores of the user.
  /// </summary>
  [QueryAPIName("firsts")]
  First
}
