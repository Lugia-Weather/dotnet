using System.Text.Json.Serialization;

namespace lugiaweather_api.Services.Models;

public class OpenCageResponse
{
    [JsonPropertyName("status")]
    public OpenCageStatus? Status { get; set; }

    [JsonPropertyName("results")]
    public List<OpenCageResult>? Results { get; set; }
}

public class OpenCageResult
{
    [JsonPropertyName("geometry")]
    public OpenCageGeometry? Geometry { get; set; }

    [JsonPropertyName("components")]
    public OpenCageComponents? Components { get; set; }
}

public class OpenCageGeometry
{
    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    [JsonPropertyName("lng")]
    public double Lng { get; set; }
}

public class OpenCageComponents
{
    [JsonPropertyName("road")]
    public string? Road { get; set; }

    [JsonPropertyName("suburb")]
    public string? Suburb { get; set; }

    [JsonPropertyName("neighbourhood")]
    public string? Neighbourhood { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("town")]
    public string? Town { get; set; }

    [JsonPropertyName("village")]
    public string? Village { get; set; }

    [JsonPropertyName("state_code")]
    public string? StateCode { get; set; }
}

public class OpenCageStatus
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}