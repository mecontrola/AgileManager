using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MeControla.AgileManager.Integrations.Jira.Converters
{
    public class DateTimeJiraConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateTime.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteStringValue($"{value:dd/MM/yyyy HH:mm:ss}");
    }
}