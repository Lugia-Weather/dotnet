using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace lugiaweather_api.Dtos;

[SwaggerSchema("DTO usado para criar um novo endereço")]
public record EnderecoCreateDto(
    [property: JsonPropertyName("logradouro")]
    [property: SwaggerSchema(Description = "Nome da rua, avenida ou via pública.")]
    string Logradouro,

    [property: JsonPropertyName("bairro")]
    [property: SwaggerSchema(Description = "Nome do bairro.")]
    string Bairro,

    [property: JsonPropertyName("complemento")]
    [property: SwaggerSchema(Description = "Complemento do endereço, como número, bloco ou referência.")]
    string? Complemento,

    [property: JsonPropertyName("uf")]
    [property: SwaggerSchema(Description = "Unidade Federativa (UF), por exemplo: SP, RJ, etc.")]
    string Uf,

    [property: JsonPropertyName("localidade")]
    [property: SwaggerSchema(Description = "Cidade ou município.")]
    string Localidade,

    [property: JsonPropertyName("latitude")]
    [property: SwaggerSchema(Description = "Coordenada de latitude do endereço (opcional).")]
    decimal? Latitude,

    [property: JsonPropertyName("longitude")]
    [property: SwaggerSchema(Description = "Coordenada de longitude do endereço (opcional).")]
    decimal? Longitude
);