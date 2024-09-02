using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class WebApiFileCreationService
    {
        public void AddWebApiFiles(string projectDir,string projectName)
        {
            string controllersDir = Path.Combine(projectDir, "Controllers");

            Directory.CreateDirectory(controllersDir);

            string templatesDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Templates", "WebAPI");

            WriteClassFromTemplate(Path.Combine(controllersDir, "AuthController.cs"), Path.Combine(templatesDir, "Controllers", "AuthController.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(projectDir, "Program.cs"), Path.Combine(templatesDir, "Program.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(projectDir, "appsettings.json"), Path.Combine(templatesDir, "appsettings.json.txt"), projectName);
        }

        private void WriteClassFromTemplate(string targetFilePath, string templateFilePath, string projectName)
        {
            if (File.Exists(templateFilePath))
            {
                string content = File.ReadAllText(templateFilePath);

                if (!string.IsNullOrEmpty(projectName))
                {
                    content = content.Replace("{{ProjectName}}", projectName);
                }

                File.WriteAllText(targetFilePath, content);
            }
            else
            {
                throw new FileNotFoundException($"Template file not found: {templateFilePath}");
            }
        }
    }
}
