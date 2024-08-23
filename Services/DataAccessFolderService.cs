using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierSolutionGenerator.Services
{
    internal class DataAccessFolderService
    {
        public void CreateDataAccessFolders(string dataAccessProjectDir, string projectName)
        {
            // DataAccess katmanı için gerekli klasörleri oluşturuyoruz
            string[] dataAccessFolders = { "Abstract", "Concrete" };

            foreach (var folder in dataAccessFolders)
            {
                string folderPath = Path.Combine(dataAccessProjectDir, folder);
                Directory.CreateDirectory(folderPath);
            }

            string entityFramework = Path.Combine(dataAccessProjectDir, "Concrete", "EntityFramework");
            Directory.CreateDirectory(entityFramework);
        }
    }
}
