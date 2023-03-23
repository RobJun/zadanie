using System.Text.Json;
using System.Text.Json.Serialization;

public class JsonDateOnlyConverter : JsonConverter<DateOnly>
{
    private const string DateFormat = "dd.MM.yyyy";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString()!,DateFormat);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(DateFormat));

    }
}