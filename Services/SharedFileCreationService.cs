using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class SharedFileCreationService
    {
        public void CreateAppSettingsFile(string projectDir)
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

        public void CreateLaunchSettingsFile(string projectDir)
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
    }
}
