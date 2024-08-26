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
        private readonly WebApiFileCreationService _webApiFileCreationService;

        public ProjectCreationService(
            BusinessFolderService businessFolderService,
            CoreFolderService coreFolderService,
            DataAccessFolderService dataAccessFolderService,
            EntityFolderService entityFolderService,
            WebApiFileCreationService webApiFileCreationService)
        {
            _fileCreationService = new FileCreationService();
            _businessFolderService = businessFolderService;
            _coreFolderService = coreFolderService;
            _dataAccessFolderService = dataAccessFolderService;
            _entityFolderService = entityFolderService;
            _webApiFileCreationService = webApiFileCreationService;
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

            // Projeler arası referansları ekleyin
            AddProjectReferences(projectInfo);
        }
        private void AddProjectReferences(ProjectInfo projectInfo)
        {
            var dte = projectInfo.DTE;
            var solution = dte.Solution;

            // Tüm projeleri alıyoruz
            var businessProject = GetProjectByName(solution, $"{projectInfo.SolutionName}.Business");
            var dataAccessProject = GetProjectByName(solution, $"{projectInfo.SolutionName}.DataAccess");
            var coreProject = GetProjectByName(solution, $"{projectInfo.SolutionName}.Core");
            var entityProject = GetProjectByName(solution, $"{projectInfo.SolutionName}.Entity");
            var webApiProject = GetProjectByName(solution, $"{projectInfo.SolutionName}.WebAPI");

            // Entity katmanının Core katmanını referans alması
            if (entityProject != null && coreProject != null)
            {
                AddReference(entityProject, coreProject);
            }

            // Diğer projeler arası referanslar
            if (webApiProject != null && businessProject != null)
            {
                AddReference(webApiProject, businessProject);
            }

            if (webApiProject != null && coreProject != null)
            {
                AddReference(webApiProject, coreProject);
            }

            if (webApiProject != null && entityProject != null)
            {
                AddReference(webApiProject, entityProject);
            }

            if (businessProject != null && coreProject != null)
            {
                AddReference(businessProject, coreProject);
            }

            if (businessProject != null && dataAccessProject != null)
            {
                AddReference(businessProject, dataAccessProject);
            }

            if (dataAccessProject != null && coreProject != null)
            {
                AddReference(dataAccessProject, coreProject);
            }

            if (businessProject != null && entityProject != null)
            {
                AddReference(businessProject, entityProject);
            }

            if (dataAccessProject != null && entityProject != null)
            {
                AddReference(dataAccessProject, entityProject);
            }

            if (coreProject != null && entityProject != null)
            {
                AddReference(coreProject, entityProject);
            }
        }


        private EnvDTE.Project GetProjectByName(EnvDTE.Solution solution, string projectName)
        {
            foreach (EnvDTE.Project project in solution.Projects)
            {
                if (project.Name.Equals(projectName))
                {
                    return project;
                }
            }
            return null;
        }

        private void AddReference(EnvDTE.Project referencingProject, EnvDTE.Project referencedProject)
        {
            // Projeye referans ekleyin
            var vsProject = referencingProject.Object as VSLangProj.VSProject;
            if (vsProject != null)
            {
                vsProject.References.AddProject(referencedProject);
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
                    _webApiFileCreationService.AddWebApiFiles(projectDir,solutionName);
                }

                if (layer == "Web")
                {
                    _fileCreationService.AddMvcFiles(projectDir);
                }
            }
            catch (Exception ex)
            {
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
