using System.Text.Json;
using lugiaweather_api.Dtos;
using lugiaweather_api.Services.Models;
using lugiaweather_api.Validators;

namespace lugiaweather_api.Services;

public class EnderecoService
{
    private readonly HttpClient _http;
    private readonly string? _openCageKey;

    public EnderecoService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _openCageKey = configuration["OpenCageKey"];

        if (string.IsNullOrWhiteSpace(_openCageKey))
            throw new InvalidOperationException("Chave da API OpenCage não encontrada na configuração.");
    }

    public async Task<EnderecoCreateDto?> BuscarEnderecoPorCoordenadasAsync(decimal? latitude, decimal? longitude)
    {
        var erroLat = EnderecoValidator.ValidarLatitude(latitude);
        if (erroLat is not null) throw new ArgumentException(erroLat);

        var erroLng = EnderecoValidator.ValidarLongitude(longitude);
        if (erroLng is not null) throw new ArgumentException(erroLng);

        var query = $"{latitude?.ToString(System.Globalization.CultureInfo.InvariantCulture)}+{longitude?.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
        var url = $"https://api.opencagedata.com/geocode/v1/json?q={query}&key={_openCageKey}&language=pt&countrycode=br";

        var geoResp = await _http.GetAsync(url);
        var geoJson = await geoResp.Content.ReadAsStringAsync();

        var geo = JsonSerializer.Deserialize<OpenCageResponse>(geoJson);

        if (geo?.Status is null)
            throw new Exception("Falha ao processar a resposta do OpenCage.");

        if (geo.Status.Code != 200)
            throw new Exception($"Erro OpenCage: {geo.Status.Message ?? "Erro desconhecido"} (code {geo.Status.Code})");

        var components = geo.Results?.FirstOrDefault()?.Components;
        if (components is null)
            return null;

        return new EnderecoCreateDto
        (
            components.Road ?? "",
            components.Suburb ?? components.Neighbourhood ?? "",
            "",
            components.StateCode ?? "",
            components.City ?? components.Town ?? components.Village ?? "",
            latitude,
            longitude
        );
    }

}
