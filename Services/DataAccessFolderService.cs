using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class DataAccessFolderService
    {
        public void CreateDataAccessFolders(string dataAccessProjectDir, string projectName)
        {
            // DataAccess katmanındaki ana klasörleri tanımlıyoruz
            string[] mainFolders = { "Abstract", "Concrete" };

            foreach (var folder in mainFolders)
            {
                string folderPath = Path.Combine(dataAccessProjectDir, folder);
                Directory.CreateDirectory(folderPath);
            }

            // Concrete içindeki EntityFramework ve Contexts klasörlerini oluşturuyoruz
            string entityFrameworkDir = Path.Combine(dataAccessProjectDir, "Concrete", "EntityFramework");
            Directory.CreateDirectory(entityFrameworkDir);
            Directory.CreateDirectory(Path.Combine(entityFrameworkDir, "Contexts"));

            // Dosyaları oluşturma
            CreateDataAccessClasses(dataAccessProjectDir, projectName);
        }

        private void CreateDataAccessClasses(string dataAccessProjectDir, string projectName)
        {
            string templatesDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Templates", "DataAccess");

            // Abstract klasöründeki IUserDal.cs dosyası
            WriteClassFromTemplate(Path.Combine(dataAccessProjectDir, "Abstract", "IUserDal.cs"), Path.Combine(templatesDir, "Abstract", "IUserDal.txt"), projectName);

            // Concrete içerisindeki EntityFramework klasöründeki dosyalar
            WriteClassFromTemplate(Path.Combine(dataAccessProjectDir, "Concrete", "EntityFramework", "EfUserDal.cs"), Path.Combine(templatesDir, "Concrete", "EntityFramework", "EfUserDal.txt"), projectName);

            // Contexts içerisindeki NorthwindContext.cs dosyası
            WriteClassFromTemplate(Path.Combine(dataAccessProjectDir, "Concrete", "EntityFramework", "Contexts", "NorthwindContext.cs"), Path.Combine(templatesDir, "Concrete", "EntityFramework", "Contexts", "NorthwindContext.txt"), projectName);
        }

        private void WriteClassFromTemplate(string targetFilePath, string templateFilePath, string projectName)
        {
            if (File.Exists(templateFilePath))
            {
                string content = File.ReadAllText(templateFilePath);
                content = content.Replace("{{ProjectName}}", projectName);
                File.WriteAllText(targetFilePath, content);
            }
            else
            {
                throw new FileNotFoundException($"Template file not found: {templateFilePath}");
            }
        }
    }
}
