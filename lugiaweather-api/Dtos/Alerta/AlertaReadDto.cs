using System.Text.Json.Serialization;
using lugiaweather_api.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace lugiaweather_api.Dtos.Alerta;

[SwaggerSchema("DTO de resposta com informações do alerta gerado por um dispositivo IoT.")]
public record AlertaReadDto(
    [property: SwaggerSchema("Identificador único do alerta.")]
    [property: JsonPropertyName("id_alerta")]
    long IdAlerta,
    
    [property: SwaggerSchema("Identificador do dispositivo IoT que originou o alerta.")]
    [property: JsonPropertyName("id_dispositivo")]
    long IdDispositivo,
    
    [property: SwaggerSchema("Tipo do alerta (ex: alagamento, falha, etc.).")]
    [property: JsonPropertyName("tipo")]
    TipoAlertaEnum Tipo,
    
    [property: SwaggerSchema("Mensagem descritiva do alerta.")]
    [property: JsonPropertyName("mensagem")]
    string Mensagem,
    
    [property: SwaggerSchema("Data e hora em que o alerta foi criado.")]
    [property: JsonPropertyName("data_criacao")]
    DateTime? DataCriacao
);