using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace lugiaweather_api.Dtos;

[SwaggerSchema("DTO usado para exibir informações de um endereço")]
public record EnderecoReadDto(
    [property: JsonPropertyName("id_endereco")]
    [property: SwaggerSchema(Description = "Identificador único do endereço.")]
    long IdEndereco,

    [property: JsonPropertyName("logradouro")]
    [property: SwaggerSchema(Description = "Nome da rua, avenida ou via pública.")]
    string Logradouro,

    [property: JsonPropertyName("bairro")]
    [property: SwaggerSchema(Description = "Nome do bairro.")]
    string Bairro,

    [property: JsonPropertyName("complemento")]
    [property: SwaggerSchema(Description = "Informações adicionais, como número ou bloco.")]
    string? Complemento,

    [property: JsonPropertyName("uf")]
    [property: SwaggerSchema(Description = "Unidade Federativa (UF), por exemplo: SP.")]
    string Uf,

    [property: JsonPropertyName("localidade")]
    [property: SwaggerSchema(Description = "Nome da cidade ou município.")]
    string Localidade,

    [property: JsonPropertyName("latitude")]
    [property: SwaggerSchema(Description = "Latitude geográfica do endereço.")]
    decimal? Latitude,

    [property: JsonPropertyName("longitude")]
    [property: SwaggerSchema(Description = "Longitude geográfica do endereço.")]
    decimal? Longitude,

    [property: JsonPropertyName("data_criacao")]
    [property: SwaggerSchema(Description = "Data de criação do registro no banco.")]
    DateTime? DataCriacao,

    [property: JsonPropertyName("data_atualizacao")]
    [property: SwaggerSchema(Description = "Data da última atualização do registro.")]
    DateTime? DataAtualizacao
);