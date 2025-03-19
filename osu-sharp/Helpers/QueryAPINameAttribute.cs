namespace osu_sharp.Helpers;

/// <summary>
/// Attaches a string representation in a REST-URL or query parameter to an enum field.
/// </summary>
/// <param name="name">The string representation.</param>
[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
internal sealed class QueryAPINameAttribute(string name) : Attribute
{
  /// <summary>
  /// The string representation.
  /// </summary>
  public string Name { get; } = name;
}
