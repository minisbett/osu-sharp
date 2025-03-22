using System.Reflection;
using System.Web;

namespace osu.NET.Helpers;

/// <summary>
/// Provides extension and utility methods for the API wrapper.
/// </summary>
internal static class APIUtils
{
  /// <summary>
  /// Returns the query string representation of the enum value.
  /// </summary>
  /// <typeparam name="T">The enum type.</typeparam>
  /// <param name="value">The enum value.</param>
  /// <returns>The query API name.</returns>
  public static string GetQueryName<T>(this T value) where T : Enum
  {
    FieldInfo field = value.GetType().GetField(value.ToString())!;
    QueryAPINameAttribute? name = field.GetCustomAttribute<QueryAPINameAttribute>();

    return name?.Name ?? throw new Exception($"The enum field '{value}' does not have a query name declared.");
  }

  /// <summary>
  /// Returns the enum value of the specified enum type with the specified JSON name.
  /// </summary>
  /// <param name="enumType">The enum type.</param>
  /// <param name="name">The JSON name of the enum value.</param>
  /// <param name="enumValue">The enum value.</param>
  /// <returns>Bool whether getting the enum value was successful.</returns>
  public static bool TryGetJsonNameMapping(Type enumType, string name, out Enum? enumValue)
  {
    foreach (Enum value in Enum.GetValues(enumType))
    {
      FieldInfo field = value.GetType().GetField(value.ToString())!;
      JsonAPINameAttribute[] names = field.GetCustomAttributes<JsonAPINameAttribute>().ToArray();

      if (names.Any(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
      {
        enumValue = value;
        return true;
      }
    }

    enumValue = null;
    return false;
  }
}