using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;
using lugiaweather_api.Enums;

namespace lugiaweather_api.Dtos.Leitura;

[SwaggerSchema("DTO usado para exibir os dados de uma leitura registrada.")]
public record LeituraReadDto(
    [property: JsonPropertyName("id_leitura")]
    [property: SwaggerSchema(Description = "Identificador único da leitura.")]
    long IdLeitura,

    [property: JsonPropertyName("id_dispositivo")]
    [property: SwaggerSchema(Description = "Identificador do dispositivo que realizou a leitura.")]
    long IdDispositivo,

    [property: JsonPropertyName("nivel_agua_cm")]
    [property: SwaggerSchema(Description = "Nível da água medido, em centímetros.")]
    decimal NivelAguaCm,

    [property: JsonPropertyName("status_nivel")]
    [property: SwaggerSchema(Description = "Status do nível da água (normal, atencao, alagado).")]
    StatusNivelEnum StatusNivel,

    [property: JsonPropertyName("data_criacao")]
    [property: SwaggerSchema(Description = "Data e hora em que a leitura foi registrada.")]
    DateTime DataCriacao
);