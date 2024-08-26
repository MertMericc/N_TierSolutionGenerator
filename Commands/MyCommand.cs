using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using System.IO;
using System.Threading.Tasks;
using N_TierSolutionGenerator.Services;
using N_TierSolutionGenerator.Models;

namespace N_TierSolutionGenerator.Commands
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        private readonly ProjectCreationService _projectCreationService;

        public MyCommand()
        {
            var businessFolderService = new BusinessFolderService();
            var coreFolderService = new CoreFolderService();
            var dataAccessFolderService = new DataAccessFolderService();
            var entityFolderService = new EntityFolderService();
            var webApiFileCreationService = new WebApiFileCreationService();
            _projectCreationService = new ProjectCreationService(businessFolderService, coreFolderService, dataAccessFolderService, entityFolderService, webApiFileCreationService);
        }

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

            string solutionDir = Path.GetDirectoryName(solution.FullName);
            string solutionName = Path.GetFileNameWithoutExtension(solution.FullName);

            // Proje bilgilerini model kullanarak geçiyoruz
            var projectInfo = new ProjectInfo
            {
                SolutionDir = solutionDir,
                SolutionName = solutionName,
                DTE = dte
            };

            // Projeleri oluşturuyoruz
            _projectCreationService.CreateN_TierProjects(projectInfo);
        }
    }
}
