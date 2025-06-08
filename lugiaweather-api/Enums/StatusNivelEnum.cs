using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace lugiaweather_api.Enums;

[SwaggerSchema("Status atual do nível da água lido pelo dispositivo IoT.")]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StatusNivelEnum
{
    Normal,
    Atencao,
    Alagado,
    Desconhecido
}
