using Newtonsoft.Json;
using osu.NET.Helpers;
using System.Collections;

namespace osu.NET.Converters;

/// <summary>
/// A <see cref="JsonConverter"/> that handles the deserialization into enums based on the <see cref="JsonAPINameAttribute"/>.
/// Additionally, it handles arrays of enums, dictionaries with an enum as the key type and integer conversion.
/// </summary>
internal class EnumConverter : JsonConverter
{
  /// <inheritdoc/>
  public override bool CanWrite => false;

  /// <inheritdoc/>
  public override bool CanConvert(Type objectType)
  {
    // Enum or Enum[]
    if (objectType.IsEnum || (objectType.GetElementType()?.IsEnum ?? false))
      return true;

    // Dictionary<Enum, T>
    if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Dictionary<,>) && objectType.GetGenericArguments()[0].IsEnum)
      return true;

    return false;
  }

  /// <inheritdoc/>
  public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    if (reader.TokenType == JsonToken.Null)
      return null;

    else if (reader.TokenType is JsonToken.Integer)
      return Enum.ToObject(objectType, (long)reader.Value!);

    else if (reader.TokenType is JsonToken.String or JsonToken.PropertyName /* To re-use this conversion for dictionary key-parsing */)
    {
      if (!APIUtils.TryGetJsonNameMapping(objectType, reader.Value!.ToString()!, out Enum? value))
        throw new JsonSerializationException($"Unknown {objectType} '{reader.Value}'.");

      return value;
    }

    else if (reader.TokenType is JsonToken.StartArray && (objectType.GetElementType()?.IsEnum ?? false))
    {
      // Deserialize each value in the array using this converter itself.
      List<object?> list = [];
      while (reader.Read() && reader.TokenType != JsonToken.EndArray)
        list.Add(ReadJson(reader, objectType.GetElementType()!, existingValue, serializer));

      // Dynamically create an array with the enum type and array length and set each value.
      Array array = Array.CreateInstance(objectType.GetElementType()!, list.Count);
      for (int i = 0; i < list.Count; i++)
        array.SetValue(list[i], i);

      return array;
    }

    else if (reader.TokenType is JsonToken.StartObject && objectType.IsGenericType
          && objectType.GetGenericTypeDefinition() == typeof(Dictionary<,>) && objectType.GetGenericArguments()[0].IsEnum)
    {
      Type keyType = objectType.GetGenericArguments()[0];
      Type valueType = objectType.GetGenericArguments()[1];
      IDictionary dictionary = (IDictionary)Activator.CreateInstance(objectType)!;

      while (reader.Read() && reader.TokenType != JsonToken.EndObject)
      {
        object? key = ReadJson(reader, keyType, existingValue, serializer);
        reader.Read(); // Move the reader past the PropertyName token the key is read from
        object? value = serializer.Deserialize(reader, valueType);

        dictionary[key!] = value;
      }

      return dictionary;
    }

    throw new JsonSerializationException($"Unable to convert '{reader.Value}' ({reader.TokenType}) into a {objectType}.");
  }

  /// <inheritdoc/>
  public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
  {
    throw new NotImplementedException();
  }
}
