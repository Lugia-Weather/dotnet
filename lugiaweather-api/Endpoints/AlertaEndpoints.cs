using lugiaweather_api.Data;
using lugiaweather_api.Dtos.Alerta;
using lugiaweather_api.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lugiaweather_api.Endpoints;

public static class AlertaEndpoints
{
    public static void MapAlertaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/alertas")
            .WithTags("Alertas dos dispositivos IoT");

        group.MapGet("/{id_dispositivo}", async (
                [FromRoute(Name = "id_dispositivo")] long idDispositivo,
                [FromQuery(Name = "data_inicio")] DateTime? dataInicio,
                [FromQuery(Name = "data_fim")] DateTime? dataFim,
                AppDbContext db) =>
            {
                // Verificação sem AnyAsync
                var existeDispositivo = await db.DispositivosIot
                    .Where(d => d.IdDispositivo == idDispositivo)
                    .Select(d => (long?)d.IdDispositivo)
                    .FirstOrDefaultAsync();

                if (!existeDispositivo.HasValue)
                    return Results.BadRequest(new ErroResponse("Dispositivo IoT não encontrado."));

                // Consulta leituras com alerta associado
                var query = db.Leituras
                    .Include(l => l.Alerta)
                    .Where(l => l.IdDispositivo == idDispositivo && l.IdAlerta != null);

                if (dataInicio.HasValue)
                    query = query.Where(l => l.Alerta != null && l.Alerta.DataCriacao >= dataInicio.Value);

                if (dataFim.HasValue)
                    query = query.Where(l => l.Alerta != null && l.Alerta.DataCriacao <= dataFim.Value);

                var alertas = await query
                    .OrderByDescending(l => l.Alerta!.DataCriacao)
                    .Select(l => new AlertaReadDto(
                        l.Alerta!.IdAlerta,
                        l.IdDispositivo,
                        l.Alerta.Tipo,
                        l.Alerta.Mensagem,
                        l.Alerta.DataCriacao
                    ))
                    .ToListAsync();

                return Results.Ok(alertas);
            })
            .WithName("ListarAlertasPorDispositivo")
            .WithSummary("Lista alertas de um dispositivo")
            .WithDescription(
                "Retorna todos os alertas relacionados às leituras de um dispositivo, com suporte a filtro por período.")
            .Produces<List<AlertaReadDto>>()
            .Produces<ErroResponse>(StatusCodes.Status400BadRequest)
            .Produces<ErroResponse>(StatusCodes.Status500InternalServerError);
    }
}