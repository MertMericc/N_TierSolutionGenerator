using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class WebApiFileCreationService
    {
        public void AddWebApiFiles(string projectDir)
        {
            CreateProgramFile(projectDir);
            CreateAppSettingsFile(projectDir);
            CreateLaunchSettingsFile(projectDir);
            CreateWeatherForecastFiles(projectDir);
        }

        private void CreateProgramFile(string projectDir)
        {
            string programFilePath = Path.Combine(projectDir, "Program.cs");
            if (!File.Exists(programFilePath))
            {
                string programContent = @"
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint(""/swagger/v1/swagger.json"", ""My API V1"");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
";
                File.WriteAllText(programFilePath, programContent);
            }
        }

        private void CreateAppSettingsFile(string projectDir)
        {
            string appSettingsPath = Path.Combine(projectDir, "appsettings.json");
            if (!File.Exists(appSettingsPath))
            {
                string appSettingsContent = @"{
  ""Logging"": {
    ""LogLevel"": {
      ""Default"": ""Information"",
      ""Microsoft.AspNetCore"": ""Warning""
    }
  },
  ""AllowedHosts"": ""*""
}";
                File.WriteAllText(appSettingsPath, appSettingsContent);
            }
        }

        private void CreateLaunchSettingsFile(string projectDir)
        {
            string launchSettingsPath = Path.Combine(projectDir, "Properties", "launchSettings.json");
            Directory.CreateDirectory(Path.Combine(projectDir, "Properties"));

            if (!File.Exists(launchSettingsPath))
            {
                string launchSettingsContent = @"{
  ""$schema"": ""http://json.schemastore.org/launchsettings.json"",
  ""profiles"": {
    ""http"": {
      ""commandName"": ""Project"",
      ""dotnetRunMessages"": true,
      ""launchBrowser"": true,
      ""launchUrl"": ""swagger"",
      ""applicationUrl"": ""http://localhost:5000"",
      ""environmentVariables"": {
        ""ASPNETCORE_ENVIRONMENT"": ""Development""
      }
    },
    ""https"": {
      ""commandName"": ""Project"",
      ""dotnetRunMessages"": true,
      ""launchBrowser"": true,
      ""launchUrl"": ""swagger"",
      ""applicationUrl"": ""https://localhost:5001"",
      ""environmentVariables"": {
        ""ASPNETCORE_ENVIRONMENT"": ""Development""
      }
    }
  }
}";
                File.WriteAllText(launchSettingsPath, launchSettingsContent);
            }
        }

        private void CreateWeatherForecastFiles(string projectDir)
        {
            // WeatherForecast.cs dosyasını oluştur
            string weatherForecastFilePath = Path.Combine(projectDir, "WeatherForecast.cs");
            if (!File.Exists(weatherForecastFilePath))
            {
                string weatherForecastContent = @"
namespace Solution6.WebAPI
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
    }
}";
                File.WriteAllText(weatherForecastFilePath, weatherForecastContent);
            }

            // WeatherForecastController.cs dosyasını oluştur
            string controllersDir = Path.Combine(projectDir, "Controllers");
            Directory.CreateDirectory(controllersDir);

            string controllerFilePath = Path.Combine(controllersDir, "WeatherForecastController.cs");
            if (!File.Exists(controllerFilePath))
            {
                string controllerContent = @"
using Microsoft.AspNetCore.Mvc;

namespace Solution6.WebAPI.Controllers
{
    [ApiController]
    [Route(""[controller]"")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            ""Freezing"", ""Bracing"", ""Chilly"", ""Cool"", ""Mild"", ""Warm"", ""Balmy"", ""Hot"", ""Sweltering"", ""Scorching""
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}";
                File.WriteAllText(controllerFilePath, controllerContent);
            }
        }
    }
}
