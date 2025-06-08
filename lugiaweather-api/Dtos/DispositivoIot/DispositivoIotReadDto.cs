using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;
using lugiaweather_api.Enums;

namespace lugiaweather_api.Dtos.DispositivoIot;

[SwaggerSchema("DTO de leitura de um dispositivo IoT")]
public record DispositivoIotReadDto(
    [property: JsonPropertyName("id_dispositivo")]
    [property: SwaggerSchema(Description = "Identificador único do dispositivo.")]
    long IdDispositivo,

    [property: JsonPropertyName("id_modulo")]
    [property: SwaggerSchema(Description = "Identificador do módulo do dispositivo.")]
    string IdModulo,

    [property: JsonPropertyName("mac_endereco")]
    [property: SwaggerSchema(Description = "Endereço MAC do dispositivo.")]
    string MacEndereco,

    [property: JsonPropertyName("projeto")]
    [property: SwaggerSchema(Description = "Nome do projeto associado ao dispositivo.")]
    string Projeto,

    [property: JsonConverter(typeof(JsonStringEnumConverter))]
    [property: SwaggerSchema(Description = "Status atual do dispositivo (ativo, manutencao, inativo).")]
    StatusDispositivoIotEnum Status,

    [property: JsonPropertyName("endereco")]
    [property: SwaggerSchema(Description = "Endereço associado ao dispositivo, se houver.")]
    EnderecoReadDto? Endereco,

    [property: JsonPropertyName("data_criacao")]
    [property: SwaggerSchema(Description = "Data de criação do registro do dispositivo.")]
    DateTime? DataCriacao,

    [property: JsonPropertyName("data_atualizacao")]
    [property: SwaggerSchema(Description = "Data da última atualização do registro do dispositivo.")]
    DateTime? DataAtualizacao
);