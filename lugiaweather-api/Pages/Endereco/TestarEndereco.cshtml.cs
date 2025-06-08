using System.ComponentModel.DataAnnotations;
using lugiaweather_api.Dtos;
using lugiaweather_api.Services;
using lugiaweather_api.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lugiaweather_api.Pages.Endereco;

public class TestarEnderecoModel : PageModel
{
    private readonly EnderecoService _enderecoService;

    public TestarEnderecoModel(EnderecoService enderecoService)
    {
        _enderecoService = enderecoService;
    }

    [BindProperty]
    [Required(ErrorMessage = "Latitude é obrigatória.")]
    public decimal? Latitude { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Longitude é obrigatória.")]
    public decimal? Longitude { get; set; }

    public EnderecoCreateDto? Endereco { get; set; }

    public bool CoordenadasPesquisadas { get; set; }

    public string? MensagemErro { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        CoordenadasPesquisadas = true;

        if (!ModelState.IsValid)
            return Page();

        // Validação coordenadas
        var erroLat = EnderecoValidator.ValidarLatitude(Latitude);
        var erroLng = EnderecoValidator.ValidarLongitude(Longitude);

        if (erroLat is not null)
        {
            ModelState.AddModelError(nameof(Latitude), erroLat);
            return Page();
        }

        if (erroLng is not null)
        {
            ModelState.AddModelError(nameof(Longitude), erroLng);
            return Page();
        }

        try
        {
            Endereco = await _enderecoService.BuscarEnderecoPorCoordenadasAsync(Latitude!.Value, Longitude!.Value);

            if (Endereco is null)
                MensagemErro = "Nenhum endereço encontrado para as coordenadas informadas.";
        }
        catch (Exception ex)
        {
            MensagemErro = ex.Message;
        }

        return Page();
    }
}