using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace lugiaweather_api.Enums;

[SwaggerSchema("Tipo do alerta emitido pelo dispositivo IoT.")]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TipoAlertaEnum
{
    Atencao,
    Alagado
}