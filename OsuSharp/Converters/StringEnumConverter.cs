using Newtonsoft.Json;
using System.ComponentModel;
using System.Reflection;

namespace OsuSharp.Converters;

/// <summary>
/// A <see cref="JsonConverter"/> to convert strings to an enum and vice versa, using the <see cref="DescriptionAttribute"/> to specify the string value.
/// </summary>
internal class StringEnumConverter : JsonConverter
{
  public override bool CanConvert(Type objectType) => objectType.IsEnum || (objectType.GetElementType()?.IsEnum ?? false);

  public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    // If the value is null, return null.
    if (reader.TokenType == JsonToken.Null)
      return null;
    // If the value is an array, read each value and convert it to an enum using this converter itself.
    else if (reader.TokenType == JsonToken.StartArray)
    {
      List<object?> list = new();
      while (reader.Read() && reader.TokenType != JsonToken.EndArray)
        list.Add(ReadJson(reader, objectType.GetElementType()!, existingValue, serializer));

      // Create an array of type objectType, add all the values to it and return it.
      Array array = Array.CreateInstance(objectType.GetElementType()!, list.Count);
      for (int i = 0; i < list.Count; i++)
        array.SetValue(list[i], i);

      return array;
    }
    // If the value is otherwise not a string, throw an exception.
    else if (reader.TokenType is not JsonToken.String)
      throw new JsonSerializationException($"Unable to convert '{reader.Value}' ({reader.TokenType}) into an enum.");

    // Find the enum value that has a description attribute with a matching value to the string from the reader.
    return Enum.GetValues(objectType).Cast<object>()
      .Select(x => objectType.GetField(x.ToString()!)!)
      .FirstOrDefault(x => x.GetCustomAttribute<DescriptionAttribute>()!.Description.Equals(reader.Value))?.GetValue(null)
      ?? throw new JsonSerializationException($"Unable to find a matching enum value for the string '{reader.Value}'.");
  }

  public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
  {
    if (value is Array array)
    {
      // Write each value in the array using this converter itself.
      writer.WriteStartArray();
      foreach (var item in array)
        WriteJson(writer, item, serializer);
      writer.WriteEndArray();
    }
    else if (value is Enum e)
    {
      // Get the description attribute of the enum value. If not found, throw an exception.
      DescriptionAttribute? descriptionAttribute = e.GetType().GetField(e.ToString())!.GetCustomAttribute<DescriptionAttribute>()
        ?? throw new JsonSerializationException($"Unable to find a description attribute for the enum value '{e}'.");

      // Write the description attribute value to the writer.
      writer.WriteValue(descriptionAttribute.Description);
    }
    else
      throw new JsonSerializationException($"{value?.GetType()} is not an enum value or array.");
  }
}