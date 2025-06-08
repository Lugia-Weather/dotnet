using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;
using lugiaweather_api.Enums;

namespace lugiaweather_api.Dtos.Leitura;

[SwaggerSchema("DTO usado para criar uma nova leitura de nível de água.")]
public record LeituraCreateDto(
    [property: Required]
    [property: JsonPropertyName("id_dispositivo")]
    [property: SwaggerSchema(Description = "Identificador do dispositivo IoT que realizou a leitura.")]
    long IdDispositivo,

    [property: Required]
    [property: JsonPropertyName("nivel_agua_cm")]
    [property: SwaggerSchema(Description = "Nível da água em centímetros.")]
    decimal NivelAguaCm,

    [property: Required]
    [property: JsonPropertyName("status_nivel")]
    [property: JsonConverter(typeof(JsonStringEnumConverter))]
    [property: SwaggerSchema(Description = "Status do nível da água (normal, atencao, alagado).")]
    StatusNivelEnum StatusNivel
);
