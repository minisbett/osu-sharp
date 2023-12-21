using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OsuSharp.Models;

namespace OsuSharp.Converters;

/// <summary>
/// A <see cref="JsonConverter"/> to convert JSON strings into a <see cref="CursorResponse{T}"/> object.
/// </summary>
/// <typeparam name="T">The type of data wrapped in the cursor response.</typeparam>
internal class CursorResponseConverter<T> : JsonConverter<CursorResponse<T>> where T : class
{
  public override CursorResponse<T> ReadJson(JsonReader reader, Type objectType, CursorResponse<T>? existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    // Check if the JSON token is the start of an object.
    if (reader.TokenType == JsonToken.StartObject)
    {
      // Load the entire JSON object into a JObject and get the cursor string property.
      JObject obj = JObject.Load(reader);
      JProperty? cursorString = obj.Property("cursor_string");

      // Create the cursor response from the JSON object and return it.
      return new CursorResponse<T>()
      {
        Cursor = cursorString?.Value.Value<string>(),
        Data = obj.Properties().FirstOrDefault(p => p.Name != "cursor_string")?.Value.ToObject<T[]>(serializer) ?? Array.Empty<T>()
      };
    }

    // Throw an exception if the JSON token type is unexpected.
    throw new JsonReaderException("Unexpected JSON token type.");
  }

  public override void WriteJson(JsonWriter writer, CursorResponse<T>? value, JsonSerializer serializer)
  {
    throw new NotImplementedException();
  }
}
