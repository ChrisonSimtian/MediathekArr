using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace MediathekViewWeb.Converters;

public class DashSanitizerConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        // Replace various types of dashes with a regular hyphen
        return value?
            .Replace('–', '-')
            .Replace('–', '-')  // en dash
            .Replace('—', '-')  // em dash
            .Replace('−', '-')  // minus sign
            .Replace('‒', '-')  // figure dash
            .Replace('―', '-') // horizontal bar
            ?? string.Empty;
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}
