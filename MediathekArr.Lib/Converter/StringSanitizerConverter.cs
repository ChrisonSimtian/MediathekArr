using System.Text.Json.Serialization;
using System.Text.Json;

namespace MediathekArr.Converter;

/// <summary>
/// A JSON converter that sanitizes strings by replacing specific characters.
/// This converter replaces the en dash (–) with a hyphen (-) in the string
/// </summary>
public class StringSanitizerConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return value?.Replace('–', '-') ?? string.Empty;
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}