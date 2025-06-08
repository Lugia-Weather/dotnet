using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace lugiaweather_api.Dtos;

[SwaggerSchema("Resposta paginada usada para listar dados com informações de paginação.")]
public record PaginacaoResponse<T>(
    [property: JsonPropertyName("dados")]
    [property: SwaggerSchema(Description = "Lista de dados retornados na página atual.")]
    IEnumerable<T> Dados,

    [property: JsonPropertyName("pagina_atual")]
    [property: SwaggerSchema(Description = "Número da página atual.")]
    int PaginaAtual,

    [property: JsonPropertyName("itens_por_pagina")]
    [property: SwaggerSchema(Description = "Quantidade de itens por página.")]
    int ItensPorPagina,

    [property: JsonPropertyName("total_itens")]
    [property: SwaggerSchema(Description = "Total de itens encontrados.")]
    int TotalItens,

    [property: JsonPropertyName("total_paginas")]
    [property: SwaggerSchema(Description = "Total de páginas disponíveis.")]
    int TotalPaginas
);