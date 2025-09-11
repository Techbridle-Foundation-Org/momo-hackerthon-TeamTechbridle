using StokePay.api.Models;
using StokePay.api.Services;
using Microsoft.Extensions.Options;
using StokePay.api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Bind MoMoSettings
builder.Services.Configure<MoMoSettings>(builder.Configuration.GetSection("MoMoSettings"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        _ = policy.WithOrigins("http://localhost:3000")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
    });
});

// Register MoMoService
builder.Services.AddHttpClient<IMoMoService, MoMoService>();
builder.Services.AddScoped<IMoMoService, MoMoService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
