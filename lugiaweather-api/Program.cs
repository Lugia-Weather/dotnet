using lugiaweather_api.Data;
using lugiaweather_api.Endpoints;
using lugiaweather_api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Oracle DB
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseOracle(builder.Configuration.GetConnectionString("OracleDb"))
);

// Razor Pages + TagHelpers
builder.Services.AddRazorPages();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "LugiaWeather API",
        Version = "v1",
        Description = "API para gerenciamento de dispositivos IoT, leituras e alertas de alagamento.",
    });
    options.EnableAnnotations();
});


// Cliente HTTP
builder.Services.AddHttpClient();

// Serviços
builder.Services.AddScoped<EnderecoService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages(); // Razor Pages

app.MapGet("/", () => Results.Ok(new
    {
        mensagem = "Bem-vindo à API LugiaWeather!",
        versao = "v1",
        documentacao = "/swagger"
    }))
    .WithName("BoasVindas")
    .WithTags("Util")
    .WithSummary("Endpoint inicial da API")
    .WithDescription("Retorna uma mensagem de boas-vindas e o link da documentação Swagger.");

app.MapDispositivoIotEndpoints(); // Endpoints de dispositivos
app.MapLeituraEndpoints();        // Endpoints de leituras
app.MapAlertaEndpoints();         // Endpoints de alertas

app.Run();