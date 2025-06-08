using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace lugiaweather_api.Enums;

[SwaggerSchema("Status atual do dispositivo IoT.")]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StatusDispositivoIotEnum
{
    Ativo,
    Inativo,
    Manutencao
}