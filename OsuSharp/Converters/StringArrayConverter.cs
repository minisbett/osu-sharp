using Newtonsoft.Json;

namespace OsuSharp.Converters;

/// <summary>
/// A <see cref="JsonConverter"/> to convert strings to elements separated by a space to string arrays and vice versa.
/// </summary>
internal class StringArrayConverter : JsonConverter
{
  public override bool CanConvert(Type objectType)
  {
    // Only allow string arrays to be converted.
    return objectType.Equals(typeof(string[]));
  }

  public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    // If the value is a string and not null, convert it into a string array.
    if (reader.TokenType == JsonToken.String && reader.Value is not null)
      return reader.Value.ToString()!.Split(' ');

    // If the value is not valid, throw an exception.
    throw new JsonSerializationException($"Unable to convert '{reader.Value}' into a string array.");
  }

  public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
  {
    // If the value is a string array, join it to a string.
    if (value is string[] arr)
      writer.WriteValue(string.Join(' ', arr));

    // If the value is not valid, throw an exception.
    else
      throw new JsonSerializationException($"Unexpected type {value?.GetType().Name}.");
  }
}