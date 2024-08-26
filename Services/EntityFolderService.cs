using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class EntityFolderService
    {
        public void CreateEntityFolders(string entityProjectDir, string projectName)
        {
            // Entity katmanındaki ana klasörleri tanımlıyoruz
            string[] mainFolders = { "Concrete", "Dtos" };

            foreach (var folder in mainFolders)
            {
                string folderPath = Path.Combine(entityProjectDir, folder);
                Directory.CreateDirectory(folderPath);
            }

            // Dosyaları oluşturma
            CreateEntityClasses(entityProjectDir, projectName);
        }

        private void CreateEntityClasses(string entityProjectDir, string projectName)
        {
            string templatesDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Templates", "Entity");


            // Dtos klasöründeki dosyalar
            WriteClassFromTemplate(Path.Combine(entityProjectDir, "Dtos", "UserForLoginDto.cs"), Path.Combine(templatesDir, "Dtos", "UserForLoginDto.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(entityProjectDir, "Dtos", "UserForRegisterDto.cs"), Path.Combine(templatesDir, "Dtos", "UserForRegisterDto.txt"), projectName);


            WriteClassFromTemplate(Path.Combine(entityProjectDir, "Concrete", "Test.cs"), Path.Combine(templatesDir, "Concrete", "Test.txt"), projectName);
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
