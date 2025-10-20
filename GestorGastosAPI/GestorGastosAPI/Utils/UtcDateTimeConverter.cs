using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GestorGastosAPI.Utils
{
    public class UtcDateTimeConverter : JsonConverter<DateTime>
    {
        // Guardado de datos en el backend (Read: Deserializa (de JSON a C#))
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateString = reader.GetString();

            if (string.IsNullOrEmpty(dateString))
                return DateTime.UtcNow;

            var parsed = DateTime.Parse(dateString, null, System.Globalization.DateTimeStyles.RoundtripKind);

            // Si ya es UTC, la devolvemos tal cual
            if (parsed.Kind == DateTimeKind.Utc)
                return parsed;

            // Si es Unspecified, asumimos que viene del frontend como local y la convertimos a UTC
            if (parsed.Kind == DateTimeKind.Unspecified)
                return DateTime.SpecifyKind(parsed, DateTimeKind.Local).ToUniversalTime();

            // Si es Local, la convertimos a UTC
            return parsed.ToUniversalTime();
        }

        // Envío de datos al Front (Write: Serializa (de C# a JSON))
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // Si el valor es Unspecified, asumimos que ya está en UTC (por cómo se guarda en la base de datos)
            var utcValue = value.Kind == DateTimeKind.Utc
                ? value
                : DateTime.SpecifyKind(value, DateTimeKind.Utc);

            // Escribimos siempre en formato UTC con “Z” para convertir bien en el front.
            writer.WriteStringValue(utcValue.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));

            /*
     
                Éste método en transacciones-widget.component.ts necesita esa "Z"
                para sobrevivir:

                 mostrarFecha(fechaIso: string): string {
                   if (!fechaIso) return '';
                   return new Date(fechaIso).toLocaleString('es-UY', {
                     dateStyle: 'short',
                     timeStyle: 'short',
                     hour12: false,
                   });
                 }

                Si no tuviera la Z, el navegador lo asumiría como hora local,y 
                toLocaleString() devolvería algo desplazado o inconsistente.
                ( = Horas corridas 3 horas menos o 3 hora más de lo necesario).
            */
        }
    }
}