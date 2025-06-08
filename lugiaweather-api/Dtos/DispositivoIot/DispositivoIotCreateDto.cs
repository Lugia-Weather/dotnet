using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;
using lugiaweather_api.Enums;

[SwaggerSchema("DTO usado para criar um novo dispositivo IoT")]
public record class DispositivoIotCreateDto
{
    [Required]
    [JsonPropertyName("id_modulo")]
    [SwaggerSchema(Description = "Identificador único do módulo IoT.", Nullable = false)]
    public string IdModulo { get; init; } = string.Empty;

    [Required]
    [JsonPropertyName("mac_endereco")]
    [SwaggerSchema(Description = "Endereço MAC do dispositivo.", Nullable = false)]
    public string MacEndereco { get; init; } = string.Empty;

    [Required]
    [JsonPropertyName("projeto")]
    [SwaggerSchema(Description = "Nome do projeto.", Nullable = false)]
    public string Projeto { get; init; } = string.Empty;

    [Required]
    [JsonPropertyName("status")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [SwaggerSchema(Description = "Status do dispositivo (ex: ativo, manutencao).", Nullable = false)]
    public StatusDispositivoIotEnum Status { get; init; }

    [Required]
    [JsonPropertyName("latitude")]
    [SwaggerSchema(Description = "Latitude do dispositivo.", Nullable = false)]
    public decimal Latitude { get; init; }

    [Required]
    [JsonPropertyName("longitude")]
    [SwaggerSchema(Description = "Longitude do dispositivo.", Nullable = false)]
    public decimal Longitude { get; init; }
}