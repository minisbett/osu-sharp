namespace osu_sharp.Enums;

/// <summary>
/// An enum containing the different titles an owner of a commentable object can have (e.g. Mapper).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#commentablemeta"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/CommentableMetaTransformer.php"/>
/// </summary>
public enum CommentableOwnerTitle
{
  // This intentionally only contains one value, as it is only used as this value or null.

  /// <summary>
  /// Indicates that the owner of the commentable object is its' mapper.
  /// </summary>
  [JsonAPIName("MAPPER")]
  Mapper
}
