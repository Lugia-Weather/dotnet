namespace lugiaweather_api.Validators;

public class EnderecoValidator
{
    public static string? ValidarLatitude(decimal? lat)
    {
        if (lat is null)
            return "Latitude não informada.";

        return lat is >= -90 and <= 90 
            ? null 
            : "Latitude inválida. Valor permitido entre -90 e 90 graus.";
    }

    public static string? ValidarLongitude(decimal? lng)
    {
        if (lng is null)
            return "Longitude não informada.";

        return lng is >= -180 and <= 180 
            ? null 
            : "Longitude inválida. Valor permitido entre -180 e 180 graus.";
    }
}