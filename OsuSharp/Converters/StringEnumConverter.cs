using Newtonsoft.Json;
using System.ComponentModel;
using System.Reflection;

namespace OsuSharp.Converters;

/// <summary>
/// A <see cref="JsonConverter"/> to convert strings to an enum and vice versa, using the <see cref="DescriptionAttribute"/> to specify the string value.
/// </summary>
internal class StringEnumConverter : JsonConverter
{
  public override bool CanConvert(Type objectType)
  {
    // Only allow enums to be converted.
    return objectType.Equals(typeof(Enum));
  }

  public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    // If the value is not a string or null, throw an exception.
    if (reader.TokenType != JsonToken.String || reader.Value is null)
      throw new JsonSerializationException($"Unable to convert '{reader.Value}' into a string array.");

    // Go through all the values of the enum, get the description attribute and check if it matches the value read from the reader.
    foreach (FieldInfo field in objectType.GetFields().Where(x => x.Name != "value__"))
    {
      // Try to find the description attribute. If not found, throw an exception.
      DescriptionAttribute? descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
      if (descriptionAttribute is null)
        throw new JsonSerializationException($"Unable to find a description attribute for the field '{field.Name}'.");

      // Get the value of the description attribute and compare it to the value read from the reader. If it matches, return the enum value.
      if (descriptionAttribute.Description.Equals(reader.Value))
        return field.GetValue(null);
    }

    // Throw an exception if no matching enum value was found.
    throw new JsonSerializationException($"Unable to find a matching enum value for the string '{reader.Value}'.");
  }

  public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
  {
    // Get the description attribute. If not found, throw an exception.
    DescriptionAttribute? descriptionAttribute = value?.GetType().GetField(value?.ToString() ?? "")?.GetCustomAttribute<DescriptionAttribute>();
    if (descriptionAttribute is null)
      throw new JsonSerializationException($"Unable to find a description attribute for the enum value '{value}'.");

    // Write the description attribute value to the writer.
    writer.WriteValue(descriptionAttribute.Description);
  }
}