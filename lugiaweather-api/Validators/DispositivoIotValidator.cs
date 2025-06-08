using System.Text.RegularExpressions;
using lugiaweather_api.Dtos;

namespace lugiaweather_api.Validators;

public class DispositivoIotValidator
{
    private const int MaxModuloLength = 100;
    private const int MaxProjetoLength = 1000;

    private static readonly Regex _macRegex = 
        new(@"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$", RegexOptions.Compiled);

    public static string? ValidarIdModulo(string idModulo)
    {
        return string.IsNullOrWhiteSpace(idModulo) || idModulo.Length > MaxModuloLength
            ? $"O campo 'id_modulo' é obrigatório e deve ter até {MaxModuloLength} caracteres."
            : null;
    }

    public static string? ValidarMacEndereco(string macEndereco)
    {
        return string.IsNullOrWhiteSpace(macEndereco) || !_macRegex.IsMatch(macEndereco)
            ? "O campo 'mac_endereco' é obrigatório e deve estar no formato MAC válido (ex: AA:BB:CC:DD:EE:FF)."
            : null;
    }

    public static string? ValidarProjeto(string projeto)
    {
        return string.IsNullOrWhiteSpace(projeto) || projeto.Length > MaxProjetoLength
            ? $"O campo 'projeto' é obrigatório e deve ter até {MaxProjetoLength} caracteres."
            : null;
    }

    public static string? ValidarLatitude(decimal latitude) =>
        EnderecoValidator.ValidarLatitude(latitude);

    public static string? ValidarLongitude(decimal longitude) =>
        EnderecoValidator.ValidarLongitude(longitude);

    public static string? ValidarParaCreate(DispositivoIotCreateDto dto)
    {
        return ValidarIdModulo(dto.IdModulo)
               ?? ValidarMacEndereco(dto.MacEndereco)
               ?? ValidarProjeto(dto.Projeto)
               ?? ValidarLatitude(dto.Latitude)
               ?? ValidarLongitude(dto.Longitude);
    }
}