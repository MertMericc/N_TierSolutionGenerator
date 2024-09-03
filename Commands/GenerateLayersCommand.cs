using EnvDTE;
using EnvDTE80;
using System.IO;
using N_TierSolutionGenerator.Services;

namespace N_TierSolutionGenerator.Commands
{
    [Command(PackageIds.GenerateLayersCommand)]
    internal sealed class GenerateLayersCommand : BaseCommand<GenerateLayersCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            var dte = await VS.GetServiceAsync<DTE, DTE2>();
            var solution = dte.Solution;

            if (solution == null || string.IsNullOrEmpty(solution.FullName))
            {
                await VS.MessageBox.ShowErrorAsync("N-Tier Generator", "Lütfen bir solution oluşturun.");
                return;
            }

            string selectedItemPath = GetSelectedItemPath(dte);
            string entityName = Path.GetFileNameWithoutExtension(selectedItemPath);
            string solutionDir = Path.GetDirectoryName(solution.FullName);
            string solutionName = Path.GetFileNameWithoutExtension(solution.FullName);

            var entityDtoService = new EntityDtoService();
            entityDtoService.AddDtos(entityName, Path.Combine(solutionDir, $"{solutionName}.Entity"));

            var dataAccessService = new DataAccessService();
            dataAccessService.AddAbstractInterface(entityName, Path.Combine(solutionDir, $"{solutionName}.DataAccess"));
            dataAccessService.AddConcreteEntityFramework(entityName, Path.Combine(solutionDir, $"{solutionName}.DataAccess"));
            dataAccessService.AddDbSetToContext(entityName, Path.Combine(solutionDir, $"{solutionName}.DataAccess", "Concrete", "EntityFramework", "Contexts", "NorthwindContext.cs"));

            var businessService = new BusinessService();
            businessService.AddAbstractInterface(entityName, Path.Combine(solutionDir, $"{solutionName}.Business"));
            businessService.AddConcreteManager(entityName, Path.Combine(solutionDir, $"{solutionName}.Business"));

            await VS.MessageBox.ShowAsync("N-Tier Generator", $"Katmanlar {entityName} için güncellendi.");
        }

        private string GetSelectedItemPath(DTE2 dte)
        {
            var selectedItem = dte.SelectedItems.Item(1);
            return selectedItem.ProjectItem.FileNames[1];
        }
    }
}
