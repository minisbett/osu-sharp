using Newtonsoft.Json;

namespace OsuSharp.Converters;

/// <summary>
/// A <see cref="JsonConverter"/> to convert integers representing seconds to a <see cref="TimeSpan"/> and vice versa.
/// </summary>
internal class TimeSpanConverter : JsonConverter
{
  public override bool CanConvert(Type objectType)
  {
    // Only allow integers to be converted.
    return objectType.Equals(typeof(int));
  }

  public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    // If the value is an integer and not null, convert it into a timespan.
    if (reader.TokenType == JsonToken.Integer && reader.Value is not null)
      return TimeSpan.FromSeconds((long)reader.Value);

    // If the value is not valid, throw an exception.
    throw new JsonSerializationException($"Unable to convert '{reader.Value}' into a timespan.");
  }

  public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
  {
    // If the value is a timespan, write it as it's total seconds.
    if (value is TimeSpan span)
      writer.WriteValue(span.Seconds);

    // If the value is not valid, throw an exception.
    else
      throw new JsonSerializationException($"Unexpected type {value?.GetType().Name}.");
  }
}