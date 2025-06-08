using lugiaweather_api.Dtos.Leitura;

namespace lugiaweather_api.Validators;

public class LeituraValidator
{
    public static string? ValidarParaCreate(LeituraCreateDto dto)
    {
        if (dto.NivelAguaCm < 0)
            return "O nível da água não pode ser negativo.";

        return null;
    }
}