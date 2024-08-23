using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class EntityFolderService
    {
        public void CreateEntityFolders(string entityProjectDir, string projectName)
        {
            // Entity katmanı için gerekli klasörleri oluşturuyoruz
            string[] entityFolders = { "Concrete", "DTOs" };

            foreach (var folder in entityFolders)
            {
                string folderPath = Path.Combine(entityProjectDir, folder);
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}
