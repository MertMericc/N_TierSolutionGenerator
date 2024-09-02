using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class BusinessFolderService
    {
        public void CreateBusinessFolders(string businessProjectDir, string projectName)
        {
            string[] mainFolders = { "Abstract", "Concrete", "Constants", "DependencyResolvers", "ValidationRules", "BusinessAspects" };

            foreach (var folder in mainFolders)
            {
                string folderPath = Path.Combine(businessProjectDir, folder);
                Directory.CreateDirectory(folderPath);
            }

            string businessAspectsDir = Path.Combine(businessProjectDir, "BusinessAspects", "Autofac");
            Directory.CreateDirectory(businessAspectsDir);

            string dependencyResolversDir = Path.Combine(businessProjectDir, "DependencyResolvers", "Autofac");
            Directory.CreateDirectory(dependencyResolversDir);

            string validationRulesDir = Path.Combine(businessProjectDir, "ValidationRules", "FluentValidation");
            Directory.CreateDirectory(validationRulesDir);

            CreateBusinessClasses(businessProjectDir, projectName);
        }

        private void CreateBusinessClasses(string businessProjectDir, string projectName)
        {
            string templatesDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Templates", "Business");

            WriteClassFromTemplate(Path.Combine(businessProjectDir, "Abstract", "IAuthService.cs"), Path.Combine(templatesDir, "Abstract", "IAuthService.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(businessProjectDir, "Abstract", "IUserService.cs"), Path.Combine(templatesDir, "Abstract", "IUserService.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(businessProjectDir, "Concrete", "AuthManager.cs"), Path.Combine(templatesDir, "Concrete", "AuthManager.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(businessProjectDir, "Concrete", "UserManager.cs"), Path.Combine(templatesDir, "Concrete", "UserManager.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(businessProjectDir, "Constants", "Messages.cs"), Path.Combine(templatesDir, "Constants", "Messages.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(businessProjectDir, "BusinessAspects", "Autofac", "SecuredOperation.cs"), Path.Combine(templatesDir, "BusinessAspects", "SecuredOperation.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(businessProjectDir, "DependencyResolvers", "Autofac", "AutofacBusinessModule.cs"), Path.Combine(templatesDir, "DependencyResolvers", "AutofacBusinessModule.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(businessProjectDir, "ValidationRules", "FluentValidation", "ProductValidator.cs"), Path.Combine(templatesDir, "ValidationRules", "ProductValidator.txt"), projectName);
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
