using lugiaweather_api.Data;
using lugiaweather_api.Endpoints;
using lugiaweather_api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Services

// Oracle DB
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseOracle(builder.Configuration.GetConnectionString("OracleDb"))
            .LogTo(Console.WriteLine, LogLevel.Information) // Log no terminal
            .EnableSensitiveDataLogging()                   // Mostra valores dos parâmetros
);

// Razor Pages + TagHelpers
builder.Services.AddRazorPages();

// Swagger (com título, descrição, enums como string)
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

app.MapDispositivoIotEndpoints(); // Endpoints de dispositivos
app.MapLeituraEndpoints();        // Endpoints de leituras
app.MapAlertaEndpoints();         // Endpoints de alertas

app.Run();