namespace N_TierSolutionGenerator.Services
{
    internal class FileCreationService
    {
        private readonly MvcFileCreationService _mvcService;
        private readonly WebApiFileCreationService _webApiService;
        private readonly SharedFileCreationService _sharedService;

        public FileCreationService()
        {
            _mvcService = new MvcFileCreationService();
            _webApiService = new WebApiFileCreationService();
            _sharedService = new SharedFileCreationService();
        }

        public void AddWebApiFiles(string projectDir)
        {
            _webApiService.AddWebApiFiles(projectDir);
        }

        public void AddMvcFiles(string projectDir)
        {
            _mvcService.AddMvcFiles(projectDir);
        }

        public void AddSharedFiles(string projectDir)
        {
            _sharedService.CreateAppSettingsFile(projectDir);
            _sharedService.CreateLaunchSettingsFile(projectDir);
        }
    }
}
