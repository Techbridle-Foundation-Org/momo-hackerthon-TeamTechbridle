using StokePay.api.Models;
using StokePay.api.Services;
using Microsoft.Extensions.Options;
using StokePay.api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Bind MoMoSettings
builder.Services.Configure<MoMoSettings>(builder.Configuration.GetSection("MoMoSettings"));

// Register MoMoService
builder.Services.AddHttpClient<IMoMoService, MoMoService>();
builder.Services.AddScoped<IMoMoService, MoMoService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
