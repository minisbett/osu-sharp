namespace osu.NET.Helpers;

/// <summary>
/// Attaches a string representation in the JSON response of an API request to an enum field.<br/>
/// Multiple names can be assigned this way, but multiple fields may not have the same string representation.
/// </summary>
/// <param name="name">The string representation.</param>
[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
internal sealed class JsonAPINameAttribute(string name) : Attribute
{
  /// <summary>
  /// The string representation.
  /// </summary>
  public string Name { get; } = name;
}
