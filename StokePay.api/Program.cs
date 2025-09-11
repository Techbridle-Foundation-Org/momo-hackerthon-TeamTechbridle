using StokePay.api.Models;
using StokePay.api.Services;
using StokePay.api.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.Configure<MoMoSettings>(builder.Configuration.GetSection("MoMoSettings"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddHttpClient<IMoMoService, MoMoService>();
builder.Services.AddScoped<IMoMoService, MoMoService>();

var app = builder.Build();

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
