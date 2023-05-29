using B3.CDB.API.Model;
using B3.CDB.API.Service;
using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICdbCalculatorService, CdbCalculatorService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "CDBCalculator",
            Description = "Backend API for CDB Calculator", 
            Version = "v1",
            Contact = new OpenApiContact()
            {
                Name = "Janduy Mornoe",
                Url = new Uri("https://github.com/janduymonroe"),
            },
            License = new OpenApiLicense()
            {
                Name = "MIT",
                Url = new Uri("http://opensource.org/licenses/MIT"),
            }
        });
});

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                    .AddEnvironmentVariables();

var configuration = builder.Configuration.GetSection("IncomeTaxRange");
builder.Services.Configure<IncomeTaxRange>(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "CDBCalculator v1");
        });
}

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();



[ExcludeFromCodeCoverage]
public partial class Program { }