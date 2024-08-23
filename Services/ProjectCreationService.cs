using EnvDTE;
using EnvDTE80;
using System.IO;
using N_TierSolutionGenerator.Models;

namespace N_TierSolutionGenerator.Services
{
    internal class ProjectCreationService
    {
        private readonly FileCreationService _fileCreationService;
        private readonly BusinessFolderService _businessFolderService;
        private readonly CoreFolderService _coreFolderService;
        private readonly DataAccessFolderService _dataAccessFolderService;
        private readonly EntityFolderService _entityFolderService;

        // Yapıcı metot dört parametre alacak şekilde genişletildi
        public ProjectCreationService(
            BusinessFolderService businessFolderService,
            CoreFolderService coreFolderService,
            DataAccessFolderService dataAccessFolderService,
            EntityFolderService entityFolderService)
        {
            _fileCreationService = new FileCreationService();
            _businessFolderService = businessFolderService;
            _coreFolderService = coreFolderService;
            _dataAccessFolderService = dataAccessFolderService;
            _entityFolderService = entityFolderService;
        }

        public void CreateN_TierProjects(ProjectInfo projectInfo)
        {
            string[] layerNames = { "Entity", "DataAccess", "Business", "Core", "WebAPI", "Web" };

            // Proje adını belirleyin (solution adını kullanarak)
            string solutionName = Path.GetFileNameWithoutExtension(projectInfo.DTE.Solution.FullName);

            foreach (var layer in layerNames)
            {
                string projectDir = Path.Combine(projectInfo.SolutionDir, $"{projectInfo.SolutionName}.{layer}");
                Directory.CreateDirectory(projectDir);

                CreateProject(projectInfo.DTE, projectDir, $"{projectInfo.SolutionName}.{layer}", layer, solutionName);
            }
        }

        private void CreateProject(DTE2 dte, string projectDir, string projectName, string layer, string solutionName)
        {
            string projectFile = Path.Combine(projectDir, $"{projectName}.csproj");
            try
            {
                Directory.CreateDirectory(projectDir);
                if (!File.Exists(projectFile))
                {
                    string projectContent = GenerateProjectFileContent(layer);
                    File.WriteAllText(projectFile, projectContent);

                    // Projeyi solution'a ekle
                    dte.Solution.AddFromFile(projectFile);
                }

                if (layer == "Business")
                {
                    // Business klasörlerini oluştururken proje adını geçiriyoruz
                    _businessFolderService.CreateBusinessFolders(projectDir, solutionName);
                }

                if (layer == "Core")
                {
                    // Core klasörlerini oluşturuyoruz
                    _coreFolderService.CreateCoreFolders(projectDir, solutionName);
                }

                if (layer == "DataAccess")
                {
                    // DataAccess klasörlerini oluşturuyoruz
                    _dataAccessFolderService.CreateDataAccessFolders(projectDir, solutionName);
                }

                if (layer == "Entity")
                {
                    // Entity klasörlerini oluşturuyoruz
                    _entityFolderService.CreateEntityFolders(projectDir, solutionName);
                }

                if (layer == "WebAPI")
                {
                    _fileCreationService.AddWebApiFiles(projectDir);
                }

                if (layer == "Web")
                {
                    _fileCreationService.AddMvcFiles(projectDir);
                }
            }
            catch (Exception ex)
            {
                // Hata mesajını göster
                VS.MessageBox.ShowErrorAsync("Error", ex.Message);
            }
        }

        private string GenerateProjectFileContent(string layer)
        {
            if (layer == "WebAPI" || layer == "Web")
            {
                return $@"
<Project Sdk=""Microsoft.NET.Sdk.Web"">
  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
</Project>";
            }

            return $@"
<Project Sdk=""Microsoft.NET.Sdk"">
  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>
</Project>";
        }
    }
}
