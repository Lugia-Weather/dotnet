using lugiaweather_api.Data;
using lugiaweather_api.Dtos;
using lugiaweather_api.Dtos.DispositivoIot;
using lugiaweather_api.Errors;
using lugiaweather_api.Models;
using lugiaweather_api.Services;
using lugiaweather_api.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lugiaweather_api.Endpoints;

public static class DispositivoIotEndpoints
{
    public static void MapDispositivoIotEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/dispositivos")
            .WithTags("Dispositivos IoT");

        // Criação do dispositivo IoT
        group.MapPost("/", async (
                [FromBody] DispositivoIotCreateDto dto,
                AppDbContext db,
                EnderecoService enderecoService) =>
            {
                // Validação dos dados de entrada
                var erroValidacao = DispositivoIotValidator.ValidarParaCreate(dto);
                if (erroValidacao is not null)
                    return Results.BadRequest(new ErroResponse(erroValidacao));

                // Verifica se o endereço já existe pelas coordenadas
                var enderecoExistente = await db.Enderecos
                    .FirstOrDefaultAsync(e =>
                        e.Latitude == dto.Latitude &&
                        e.Longitude == dto.Longitude);

                Endereco endereco;

                if (enderecoExistente is not null)
                {
                    endereco = enderecoExistente;
                }
                else
                {
                    var enderecoDto =
                        await enderecoService.BuscarEnderecoPorCoordenadasAsync(dto.Latitude, dto.Longitude);

                    if (enderecoDto is null)
                        return Results.BadRequest(
                            new ErroResponse("Não foi possível obter o endereço com as coordenadas informadas."));

                    endereco = new Endereco
                    {
                        Logradouro = enderecoDto.Logradouro,
                        Bairro = enderecoDto.Bairro,
                        Complemento = string.IsNullOrWhiteSpace(enderecoDto.Complemento)
                            ? "N/A"
                            : enderecoDto.Complemento,
                        Uf = enderecoDto.Uf,
                        Localidade = enderecoDto.Localidade,
                        Latitude = enderecoDto.Latitude,
                        Longitude = enderecoDto.Longitude
                    };

                    db.Enderecos.Add(endereco);

                    await db.SaveChangesAsync();
                }

                var dispositivo = new DispositivoIot
                {
                    IdModulo = dto.IdModulo,
                    MacEndereco = dto.MacEndereco,
                    Projeto = dto.Projeto,
                    Status = dto.Status,
                    IdEndereco = endereco.IdEndereco
                };

                db.DispositivosIot.Add(dispositivo);

                await db.SaveChangesAsync();

                var result = new DispositivoIotReadDto(
                    dispositivo.IdDispositivo,
                    dispositivo.IdModulo,
                    dispositivo.MacEndereco,
                    dispositivo.Projeto,
                    dispositivo.Status,
                    new EnderecoReadDto(
                        endereco.IdEndereco,
                        endereco.Logradouro,
                        endereco.Bairro,
                        endereco.Complemento,
                        endereco.Uf,
                        endereco.Localidade,
                        endereco.Latitude,
                        endereco.Longitude,
                        endereco.DataCriacao,
                        endereco.DataAtualizacao
                    ),
                    dispositivo.DataCriacao,
                    dispositivo.DataAtualizacao
                );

                return Results.Created($"/dispositivos/{dispositivo.IdDispositivo}", result);
            })
            .WithName("CriarDispositivoIot")
            .WithSummary("Cadastra um novo dispositivo IoT")
            .WithDescription(
                "Cria um novo dispositivo IoT.")
            .Accepts<DispositivoIotCreateDto>("application/json")
            .Produces<DispositivoIotReadDto>(StatusCodes.Status201Created)
            .Produces<ErroResponse>(StatusCodes.Status400BadRequest)
            .Produces<ErroResponse>(StatusCodes.Status500InternalServerError);

        // Listagem dos dispositivos IoT (paginado)
        group.MapGet("/", async (
                AppDbContext db, [FromQuery] int pagina = 1, [FromQuery] int quantidade = 10) =>
            {
                if (pagina <= 0 || quantidade <= 0)
                {
                    return Results.BadRequest(
                        new ErroResponse("Os parâmetros 'pagina' e 'quantidade' devem ser maiores que zero."));
                }

                var totalItens = await db.DispositivosIot.CountAsync();

                var dispositivos = await db.DispositivosIot
                    .Include(d => d.Endereco)
                    .OrderBy(d => d.IdDispositivo)
                    .Skip((pagina - 1) * quantidade)
                    .Take(quantidade)
                    .ToListAsync();

                var dispositivosDto = dispositivos.Select(d => new DispositivoIotReadDto(
                    d.IdDispositivo,
                    d.IdModulo,
                    d.MacEndereco,
                    d.Projeto,
                    d.Status,
                    d.Endereco == null
                        ? null
                        : new EnderecoReadDto(
                            d.Endereco.IdEndereco,
                            d.Endereco.Logradouro,
                            d.Endereco.Bairro,
                            d.Endereco.Complemento,
                            d.Endereco.Uf,
                            d.Endereco.Localidade,
                            d.Endereco.Latitude,
                            d.Endereco.Longitude,
                            d.Endereco.DataCriacao,
                            d.Endereco.DataAtualizacao
                        ),
                    d.DataCriacao,
                    d.DataAtualizacao
                ));

                var totalPaginas = (int)Math.Ceiling(totalItens / (double)quantidade);

                var resposta = new PaginacaoResponse<DispositivoIotReadDto>(
                    PaginaAtual: pagina,
                    ItensPorPagina: quantidade,
                    TotalItens: totalItens,
                    TotalPaginas: totalPaginas,
                    Dados: dispositivosDto
                );

                return Results.Ok(resposta);
            })
            .WithName("ListarDispositivosIot")
            .WithSummary("Lista paginada de dispositivos IoT")
            .WithDescription("Retorna uma lista paginada dos dispositivos IoT cadastrados.")
            .Produces<PaginacaoResponse<DispositivoIotReadDto>>()
            .Produces<ErroResponse>(StatusCodes.Status400BadRequest)
            .Produces<ErroResponse>(StatusCodes.Status500InternalServerError);

        // GET dados do dispositivo IoT
        group.MapGet("/{id:long}", async (
                long id,
                AppDbContext db) =>
            {
                var dispositivo = await db.DispositivosIot
                    .Include(d => d.Endereco)
                    .FirstOrDefaultAsync(d => d.IdDispositivo == id);

                if (dispositivo is null)
                    return Results.NotFound(new ErroResponse("Dispositivo não encontrado."));

                var dto = new DispositivoIotReadDto(
                    dispositivo.IdDispositivo,
                    dispositivo.IdModulo,
                    dispositivo.MacEndereco,
                    dispositivo.Projeto,
                    dispositivo.Status,
                    dispositivo.Endereco == null
                        ? null
                        : new EnderecoReadDto(
                            dispositivo.Endereco.IdEndereco,
                            dispositivo.Endereco.Logradouro,
                            dispositivo.Endereco.Bairro,
                            dispositivo.Endereco.Complemento,
                            dispositivo.Endereco.Uf,
                            dispositivo.Endereco.Localidade,
                            dispositivo.Endereco.Latitude,
                            dispositivo.Endereco.Longitude,
                            dispositivo.Endereco.DataCriacao,
                            dispositivo.Endereco.DataAtualizacao
                        ),
                    dispositivo.DataCriacao,
                    dispositivo.DataAtualizacao
                );

                return Results.Ok(dto);
            })
            .WithName("BuscarDispositivoIotPorId")
            .WithSummary("Busca um dispositivo IoT pelo ID")
            .WithDescription("Retorna os dados de um dispositivo IoT específico.")
            .Produces<DispositivoIotReadDto>()
            .Produces<ErroResponse>(StatusCodes.Status404NotFound)
            .Produces<ErroResponse>(StatusCodes.Status500InternalServerError);

        // Atualização dos dados do dispositivo IoT
        group.MapPut("/{id:long}", async (
                long id,
                [FromBody] DispositivoIotCreateDto dto,
                AppDbContext db,
                EnderecoService enderecoService) =>
            {
                var dispositivo = await db.DispositivosIot.FindAsync(id);

                if (dispositivo is null)
                    return Results.NotFound(new ErroResponse("Dispositivo não encontrado."));

                // Validação dos dados de entrada
                var erroValidacao = DispositivoIotValidator.ValidarParaCreate(dto);
                if (erroValidacao is not null)
                    return Results.BadRequest(new ErroResponse(erroValidacao));

                var endereco = await db.Enderecos
                    .FirstOrDefaultAsync(e => e.Latitude == dto.Latitude && e.Longitude == dto.Longitude);

                if (endereco is null)
                {
                    var enderecoDto =
                        await enderecoService.BuscarEnderecoPorCoordenadasAsync(dto.Latitude, dto.Longitude);

                    if (enderecoDto is null)
                        return Results.BadRequest(
                            new ErroResponse("Não foi possível obter o endereço com as coordenadas informadas."));

                    endereco = new Endereco
                    {
                        Logradouro = enderecoDto.Logradouro,
                        Bairro = enderecoDto.Bairro,
                        Complemento = string.IsNullOrWhiteSpace(enderecoDto.Complemento)
                            ? "N/A"
                            : enderecoDto.Complemento,
                        Uf = enderecoDto.Uf,
                        Localidade = enderecoDto.Localidade,
                        Latitude = enderecoDto.Latitude,
                        Longitude = enderecoDto.Longitude
                    };

                    db.Enderecos.Add(endereco);
                    await db.SaveChangesAsync();
                }

                dispositivo.IdModulo = dto.IdModulo;
                dispositivo.MacEndereco = dto.MacEndereco;
                dispositivo.Projeto = dto.Projeto;
                dispositivo.Status = dto.Status;
                dispositivo.IdEndereco = endereco.IdEndereco;
                dispositivo.DataAtualizacao = DateTime.UtcNow;

                await db.SaveChangesAsync();

                return Results.NoContent();
            })
            .WithName("AtualizarDispositivoIot")
            .WithSummary("Atualiza um dispositivo IoT")
            .WithDescription("Atualiza os dados de um dispositivo IoT existente.")
            .Accepts<DispositivoIotCreateDto>("application/json")
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ErroResponse>(StatusCodes.Status400BadRequest)
            .Produces<ErroResponse>(StatusCodes.Status404NotFound)
            .Produces<ErroResponse>(StatusCodes.Status500InternalServerError);

        // Remoção do dispositivo IoT
        group.MapDelete("/{id:long}", async (
                long id,
                AppDbContext db) =>
            {
                var dispositivo = await db.DispositivosIot.FindAsync(id);

                if (dispositivo is null)
                    return Results.NotFound(new ErroResponse("Dispositivo não encontrado."));

                db.DispositivosIot.Remove(dispositivo);
                await db.SaveChangesAsync();

                return Results.NoContent();
            })
            .WithName("RemoverDispositivoIot")
            .WithSummary("Remove um dispositivo IoT")
            .WithDescription("Remove um dispositivo IoT existente pelo ID.")
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ErroResponse>(StatusCodes.Status404NotFound)
            .Produces<ErroResponse>(StatusCodes.Status500InternalServerError);
    }
}