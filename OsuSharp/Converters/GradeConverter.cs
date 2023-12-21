using Newtonsoft.Json;
using OsuSharp.Enums;

namespace OsuSharp.Converters;

/// <summary>
/// A <see cref="JsonConverter"/> to convert strings to a <see cref="Grade"/> and vice versa.
/// </summary>
internal class GradeConverter : JsonConverter
{
  public override bool CanConvert(Type objectType)
  {
    // Only allow string arrays to be converted.
    return objectType.Equals(typeof(string));
  }

  public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    // If the value is a string and not null, convert it into a string array.
    if (reader.TokenType == JsonToken.String && reader.Value is not null)
      switch (reader.Value.ToString())
      {
        case "XH":
        case "SSH":
          return Grade.XH;
        case "SH":
          return Grade.SH;
        case "X":
        case "SS":
          return Grade.X;
        case "S":
          return Grade.S;
        case "A":
          return Grade.A;
        case "B":
          return Grade.B;
        case "C":
          return Grade.C;
        case "D":
          return Grade.D;
        default:
          throw new JsonSerializationException($"Unable to convert '{reader.Value}' into a grade.");
      }

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