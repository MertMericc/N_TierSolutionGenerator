using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class CoreFolderService
    {
        public void CreateCoreFolders(string coreProjectDir, string projectName)
        {
            // Core katmanındaki ana klasörleri tanımlıyoruz
            string[] mainFolders = { "Aspects", "CrossCuttingConcerns", "DataAccess", "DependencyResolvers", "Entities", "Extensions", "Utilities" };

            foreach (var folder in mainFolders)
            {
                string folderPath = Path.Combine(coreProjectDir, folder);
                Directory.CreateDirectory(folderPath);
            }

            // Alt klasörleri oluşturma
            CreateSubFolders(coreProjectDir);

            // Dosyaları oluşturma
            CreateCoreClasses(coreProjectDir, projectName);
        }

        private void CreateSubFolders(string coreProjectDir)
        {
            // Aspects klasör yapısı
            string aspectsDir = Path.Combine(coreProjectDir, "Aspects", "Autofac");
            string[] aspectsSubFolders = { "Caching", "Exception", "Logging", "Performance", "Transaction", "Validation" };
            foreach (var subFolder in aspectsSubFolders)
            {
                Directory.CreateDirectory(Path.Combine(aspectsDir, subFolder));
            }

            // CrossCuttingConcerns klasör yapısı
            string crossCuttingConcernsDir = Path.Combine(coreProjectDir, "CrossCuttingConcerns");
            Directory.CreateDirectory(Path.Combine(crossCuttingConcernsDir, "Caching", "Microsoft"));
            Directory.CreateDirectory(Path.Combine(crossCuttingConcernsDir, "Logging", "Log4Net", "Loggers"));
            Directory.CreateDirectory(Path.Combine(crossCuttingConcernsDir, "Logging", "Log4Net", "Layouts"));
            Directory.CreateDirectory(Path.Combine(crossCuttingConcernsDir, "Validation"));

            // DataAccess klasör yapısı
            Directory.CreateDirectory(Path.Combine(coreProjectDir, "DataAccess", "EntityFramework"));

            // Entities klasör yapısı
            Directory.CreateDirectory(Path.Combine(coreProjectDir, "Entities", "Concrete"));

            // Utilities klasör yapısı
            string[] utilitiesSubFolders = { "Business", "IoC", "Interceptors", "Security/Encryption", "Security/Hashing", "Security/Jwt" };
            foreach (var subFolder in utilitiesSubFolders)
            {
                Directory.CreateDirectory(Path.Combine(coreProjectDir, "Utilities", subFolder));
            }
        }

        private void CreateCoreClasses(string coreProjectDir, string projectName)
        {
            string templatesDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Templates", "Core");

            // Aspects klasörü için dosyalar oluşturuluyor
            CreateAspectFiles(coreProjectDir, templatesDir, projectName);

            // CrossCuttingConcerns klasörü için dosyalar oluşturuluyor
            CreateCrossCuttingConcernsFiles(coreProjectDir, templatesDir, projectName);

            // DataAccess klasörü için dosyalar oluşturuluyor
            CreateDataAccessFiles(coreProjectDir, templatesDir, projectName);

            // Entities klasörü için dosyalar oluşturuluyor
            CreateEntitiesFiles(coreProjectDir, templatesDir, projectName);

            // Extensions klasörü için dosyalar oluşturuluyor
            CreateExtensionsFiles(coreProjectDir, templatesDir, projectName);

            // Utilities klasörü için dosyalar oluşturuluyor
            CreateUtilitiesFiles(coreProjectDir, templatesDir, projectName);
        }

        private void CreateAspectFiles(string coreProjectDir, string templatesDir, string projectName)
        {
            string aspectsDir = Path.Combine(coreProjectDir, "Aspects", "Autofac");

            // Aspects klasörü (Autofac alt klasöründe)
            WriteClassFromTemplate(Path.Combine(aspectsDir, "Caching", "CacheAspect.cs"), Path.Combine(templatesDir, "Aspects", "Autofac", "Caching", "CacheAspect.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(aspectsDir, "Caching", "CacheRemoveAspect.cs"), Path.Combine(templatesDir, "Aspects", "Autofac", "Caching", "CacheRemoveAspect.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(aspectsDir, "Exception", "ExceptionLogAspect.cs"), Path.Combine(templatesDir, "Aspects", "Autofac", "Exception", "ExceptionLogAspect.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(aspectsDir, "Logging", "LogAspect.cs"), Path.Combine(templatesDir, "Aspects", "Autofac", "Logging", "LogAspect.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(aspectsDir, "Performance", "PerformanceAspect.cs"), Path.Combine(templatesDir, "Aspects", "Autofac", "Performance", "PerformanceAspect.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(aspectsDir, "Transaction", "TransactionScopeAspect.cs"), Path.Combine(templatesDir, "Aspects", "Autofac", "Transaction", "TransactionScopeAspect.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(aspectsDir, "Validation", "ValidationAspect.cs"), Path.Combine(templatesDir, "Aspects", "Autofac", "Validation", "ValidationAspect.txt"), projectName);
        }

        private void CreateCrossCuttingConcernsFiles(string coreProjectDir, string templatesDir, string projectName)
        {
            // Caching klasörü (Microsoft alt klasöründe)
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "CrossCuttingConcerns", "Caching", "Microsoft", "MemoryCacheManager.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Caching", "Microsoft", "MemoryCacheManager.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "CrossCuttingConcerns", "Caching", "ICacheManager.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Caching", "Caching", "ICacheManager.txt"), projectName);

            // Logging klasörü (Log4Net altında)
            string loggingDir = Path.Combine(coreProjectDir, "CrossCuttingConcerns", "Logging");
            string log4NetDir = Path.Combine(loggingDir, "Log4Net");
            string loggersDir = Path.Combine(log4NetDir, "Loggers");
            string layoutsDir = Path.Combine(log4NetDir, "Layouts");

            // Loggers altındaki dosyalar
            WriteClassFromTemplate(Path.Combine(loggersDir, "DatabaseLogger.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "Log4Net", "Loggers", "DatabaseLogger.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(loggersDir, "FileLogger.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "Log4Net", "Loggers", "FileLogger.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(loggersDir, "LoggerServiceBase.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "Log4Net", "Loggers", "LoggerServiceBase.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(loggersDir, "SerializableLogEvent.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "Log4Net", "Loggers", "SerializableLogEvent.txt"), projectName);

            // Layouts altındaki dosya
            WriteClassFromTemplate(Path.Combine(layoutsDir, "JsonLayout.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "Log4Net", "Layouts", "JsonLayout.txt"), projectName);

            // Logging klasörünün geri kalan dosyaları
            WriteClassFromTemplate(Path.Combine(loggingDir, "LogDetail.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "LogDetail.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(loggingDir, "LogDetailWithException.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "LogDetailWithException.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(loggingDir, "LogParameter.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "LogParameter.txt"), projectName);

            // Validation klasörü
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "CrossCuttingConcerns", "Validation", "ValidationTool.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Validation", "ValidationTool.txt"), projectName);
        }

        private void CreateDataAccessFiles(string coreProjectDir, string templatesDir, string projectName)
        {
            // DataAccess klasörü için
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "DataAccess", "EntityFramework", "EfEntityRepositoryBase.cs"), Path.Combine(templatesDir, "DataAccess", "EntityFramework", "EfEntityRepositoryBase.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "DataAccess", "IEntityRepository.cs"), Path.Combine(templatesDir, "DataAccess", "IEntityRepository.txt"), projectName);
        }

        private void CreateEntitiesFiles(string coreProjectDir, string templatesDir, string projectName)
        {
            // Entities klasörü için
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Entities", "Concrete", "User.cs"), Path.Combine(templatesDir, "Entities", "Concrete", "User.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Entities", "Concrete", "OperationClaim.cs"), Path.Combine(templatesDir, "Entities", "Concrete", "OperationClaim.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Entities", "Concrete", "UserOperationClaim.cs"), Path.Combine(templatesDir, "Entities", "Concrete", "UserOperationClaim.txt"), projectName);
        }

        private void CreateExtensionsFiles(string coreProjectDir, string templatesDir, string projectName)
        {
            // Extensions klasörü için
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Extensions", "ClaimExtensions.cs"), Path.Combine(templatesDir, "Extensions", "ClaimExtensions.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Extensions", "ErrorDetails.cs"), Path.Combine(templatesDir, "Extensions", "ErrorDetails.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Extensions", "ServiceCollectionExtensions.cs"), Path.Combine(templatesDir, "Extensions", "ServiceCollectionExtensions.txt"), projectName);
        }

        private void CreateUtilitiesFiles(string coreProjectDir, string templatesDir, string projectName)
        {
            // Utilities klasörü için
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Business", "BusinessRules.cs"), Path.Combine(templatesDir, "Utilities", "Business", "BusinessRules.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "IoC", "ServiceTool.cs"), Path.Combine(templatesDir, "Utilities", "IoC", "ServiceTool.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Interceptors", "MethodInterception.cs"), Path.Combine(templatesDir, "Utilities", "Interceptors", "MethodInterception.txt"), projectName);

            // Security klasörü için
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Security", "Encryption", "SecurityKeyHelper.cs"), Path.Combine(templatesDir, "Utilities", "Security", "Encryption", "SecurityKeyHelper.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Security", "Hashing", "HashingHelper.cs"), Path.Combine(templatesDir, "Utilities", "Security", "Hashing", "HashingHelper.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Security", "Jwt", "AccessToken.cs"), Path.Combine(templatesDir, "Utilities", "Security", "Jwt", "AccessToken.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Security", "Jwt", "TokenOptions.cs"), Path.Combine(templatesDir, "Utilities", "Security", "Jwt", "TokenOptions.txt"), projectName);
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
