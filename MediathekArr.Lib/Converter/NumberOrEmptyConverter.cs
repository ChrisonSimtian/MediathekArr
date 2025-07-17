using System.Text.Json.Serialization;
using System.Text.Json;

namespace MediathekArr.Converter;

/// <summary>
/// A JSON converter that handles numeric values or returns an empty value.
/// This converter supports int, long, and other numeric types.
/// </summary>
/// <typeparam name="T"></typeparam>
public class NumberOrEmptyConverter<T> : JsonConverter<T>
    where T : struct, IConvertible
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null || (reader.TokenType == JsonTokenType.String && reader.GetString() == ""))
        {
            return default; // Return default value, which will be 0 for int, long, etc.
        }

        // Convert to the target numeric type (int, long, etc.)
        return Type.GetTypeCode(typeof(T)) switch
        {
            TypeCode.Int32 => (T)(object)reader.GetInt32(),
            TypeCode.Int64 => (T)(object)reader.GetInt64(),
            TypeCode.Double => (T)(object)reader.GetDouble(),
            TypeCode.Single => (T)(object)reader.GetSingle(),
            _ => throw new NotSupportedException($"The converter does not support type {typeof(T)}."),
        };
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(Convert.ToDouble(value));
    }
}