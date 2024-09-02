using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class DataAccessFolderService
    {
        public void CreateDataAccessFolders(string dataAccessProjectDir, string projectName)
        {
            string[] mainFolders = { "Abstract", "Concrete" };

            foreach (var folder in mainFolders)
            {
                string folderPath = Path.Combine(dataAccessProjectDir, folder);
                Directory.CreateDirectory(folderPath);
            }

            string entityFrameworkDir = Path.Combine(dataAccessProjectDir, "Concrete", "EntityFramework");
            Directory.CreateDirectory(entityFrameworkDir);
            Directory.CreateDirectory(Path.Combine(entityFrameworkDir, "Contexts"));

            CreateDataAccessClasses(dataAccessProjectDir, projectName);
        }

        private void CreateDataAccessClasses(string dataAccessProjectDir, string projectName)
        {
            string templatesDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Templates", "DataAccess");

            WriteClassFromTemplate(Path.Combine(dataAccessProjectDir, "Abstract", "IUserDal.cs"), Path.Combine(templatesDir, "Abstract", "IUserDal.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(dataAccessProjectDir, "Concrete", "EntityFramework", "EfUserDal.cs"), Path.Combine(templatesDir, "Concrete", "EntityFramework", "EfUserDal.txt"), projectName);

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
