using lugiaweather_api.Data;
using lugiaweather_api.Dtos.Leitura;
using lugiaweather_api.Enums;
using lugiaweather_api.Errors;
using lugiaweather_api.Models;
using lugiaweather_api.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lugiaweather_api.Endpoints;

public static class LeituraEndpoints
{
    public static void MapLeituraEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/leituras")
            .WithTags("Leituras do dispositivo IoT");

        // Criação de uma nova leitura
        group.MapPost("/", async (
                [FromBody] LeituraCreateDto dto,
                AppDbContext db) =>
            {
                // Validação do DTO
                var erroValidacao = LeituraValidator.ValidarParaCreate(dto);
                if (erroValidacao is not null)
                    return Results.BadRequest(new ErroResponse(erroValidacao));

                // Dispara alerta caso esteja alagado
                Alerta? alerta = null;
                if (dto.StatusNivel == StatusNivelEnum.Alagado)
                {
                    alerta = new Alerta
                    {
                        Tipo = TipoAlertaEnum.Alagado,
                        Mensagem = $"Status de nível alterado para {dto.StatusNivel.ToString()}",
                        DataCriacao = DateTime.Now
                    };

                    db.Alertas.Add(alerta);
                    await db.SaveChangesAsync();
                }

                // Cria a leitura e relaciona com o alerta (se houver)
                var leitura = new Leitura
                {
                    IdDispositivo = dto.IdDispositivo,
                    NivelAguaCm = dto.NivelAguaCm,
                    StatusNivel = dto.StatusNivel,
                    IdAlerta = alerta?.IdAlerta
                };

                db.Leituras.Add(leitura);
                await db.SaveChangesAsync();

                var result = new LeituraReadDto(
                    leitura.IdLeitura,
                    leitura.IdDispositivo,
                    leitura.NivelAguaCm,
                    leitura.StatusNivel,
                    leitura.DataCriacao
                );

                return Results.Created($"/leituras/{leitura.IdLeitura}", result);
            })
            .WithName("CriarLeitura")
            .WithSummary("Cadastra uma nova leitura de nível de água")
            .WithDescription(
                "Cria uma nova leitura vinculada a um dispositivo IoT. Se necessário, gera um alerta automaticamente.")
            .Accepts<LeituraCreateDto>("application/json")
            .Produces<LeituraReadDto>(StatusCodes.Status201Created)
            .Produces<ErroResponse>(StatusCodes.Status400BadRequest)
            .Produces<ErroResponse>(StatusCodes.Status500InternalServerError);


        // Listagem das leituras por dispositivo com filtro opcional de data
        group.MapGet("/{id_dispositivo}", async (
                [FromRoute(Name = "id_dispositivo")] long idDispositivo,
                [FromQuery(Name = "data_inicio")] DateTime? dataInicio,
                [FromQuery(Name = "data_fim")] DateTime? dataFim,
                AppDbContext db) =>
            {
                // Verifica se o dispositivo IoT existe
                var dispositivoExiste = await db.DispositivosIot
                    .Where(d => d.IdDispositivo == idDispositivo)
                    .Select(d => d.IdDispositivo)
                    .FirstOrDefaultAsync();

                if (dispositivoExiste == 0)
                    return Results.BadRequest(new ErroResponse("Dispositivo IoT não encontrado."));

                var query = db.Leituras
                    .Where(l => l.IdDispositivo == idDispositivo);

                if (dataInicio.HasValue)
                    query = query.Where(l => l.DataCriacao >= dataInicio.Value);
                if (dataFim.HasValue)
                    query = query.Where(l => l.DataCriacao <= dataFim.Value);

                var leituras = await query
                    .OrderByDescending(l => l.DataCriacao)
                    .Select(l => new LeituraReadDto(
                        l.IdLeitura,
                        l.IdDispositivo,
                        l.NivelAguaCm,
                        l.StatusNivel,
                        l.DataCriacao))
                    .ToListAsync();

                return Results.Ok(leituras);
            })
            .WithName("ListarLeiturasPorDispositivo")
            .WithSummary("Lista leituras de um dispositivo IoT")
            .WithDescription("Retorna todas as leituras de um dispositivo, com suporte a filtro por data.")
            .Produces<List<LeituraReadDto>>()
            .Produces<ErroResponse>(StatusCodes.Status400BadRequest)
            .Produces<ErroResponse>(StatusCodes.Status500InternalServerError);
    }
}