using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class CoreFolderService
    {
        public void CreateCoreFolders(string coreProjectDir, string projectName)
        {
            string[] mainFolders = { "Aspects", "CrossCuttingConcerns", "DataAccess", "DependencyResolvers", "Entities", "Extensions", "Utilities","Messages" };

            foreach (var folder in mainFolders)
            {
                string folderPath = Path.Combine(coreProjectDir, folder);
                Directory.CreateDirectory(folderPath);
            }

            CreateSubFolders(coreProjectDir);

            CreateCoreClasses(coreProjectDir, projectName);
        }

        private void CreateSubFolders(string coreProjectDir)
        {
            string aspectsDir = Path.Combine(coreProjectDir, "Aspects", "Autofac");
            string[] aspectsSubFolders = { "Caching", "Exception", "Logging", "Performance", "Transaction", "Validation" };
            foreach (var subFolder in aspectsSubFolders)
            {
                Directory.CreateDirectory(Path.Combine(aspectsDir, subFolder));
            }

            string crossCuttingConcernsDir = Path.Combine(coreProjectDir, "CrossCuttingConcerns");
            Directory.CreateDirectory(Path.Combine(crossCuttingConcernsDir, "Caching", "Microsoft"));
            Directory.CreateDirectory(Path.Combine(crossCuttingConcernsDir, "Logging", "Log4Net", "Loggers"));
            Directory.CreateDirectory(Path.Combine(crossCuttingConcernsDir, "Logging", "Log4Net", "Layouts"));
            Directory.CreateDirectory(Path.Combine(crossCuttingConcernsDir, "Validation"));

            Directory.CreateDirectory(Path.Combine(coreProjectDir, "DataAccess", "EntityFramework"));

            Directory.CreateDirectory(Path.Combine(coreProjectDir, "Entities", "Concrete"));

            string[] utilitiesSubFolders = { "Business", "IoC", "Interceptors", "Security/Encryption", "Security/Hashing", "Security/Jwt" ,"Results","Messages"};
            foreach (var subFolder in utilitiesSubFolders)
            {
                Directory.CreateDirectory(Path.Combine(coreProjectDir, "Utilities", subFolder));
            }
        }

        private void CreateCoreClasses(string coreProjectDir, string projectName)
        {
            string templatesDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Templates", "Core");

            CreateAspectFiles(coreProjectDir, templatesDir, projectName);

            CreateCrossCuttingConcernsFiles(coreProjectDir, templatesDir, projectName);

            CreateDataAccessFiles(coreProjectDir, templatesDir, projectName);

            CreateEntitiesFiles(coreProjectDir, templatesDir, projectName);

            CreateExtensionsFiles(coreProjectDir, templatesDir, projectName);

            CreateUtilitiesFiles(coreProjectDir, templatesDir, projectName);
        }

        private void CreateAspectFiles(string coreProjectDir, string templatesDir, string projectName)
        {
            string aspectsDir = Path.Combine(coreProjectDir, "Aspects", "Autofac");

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
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "CrossCuttingConcerns", "Caching", "Microsoft", "MemoryCacheManager.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Caching", "Microsoft", "MemoryCacheManager.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "CrossCuttingConcerns", "Caching", "ICacheManager.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Caching", "ICacheManager.txt"), projectName);

            string loggingDir = Path.Combine(coreProjectDir, "CrossCuttingConcerns", "Logging");
            string log4NetDir = Path.Combine(loggingDir, "Log4Net");
            string loggersDir = Path.Combine(log4NetDir, "Loggers");
            string layoutsDir = Path.Combine(log4NetDir, "Layouts");

            WriteClassFromTemplate(Path.Combine(loggersDir, "DatabaseLogger.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "Log4Net", "Loggers", "DatabaseLogger.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(loggersDir, "FileLogger.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "Log4Net", "Loggers", "FileLogger.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(log4NetDir, "LoggerServiceBase.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "Log4Net", "LoggerServiceBase.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(log4NetDir, "SerializableLogEvent.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "Log4Net", "SerializableLogEvent.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(layoutsDir, "JsonLayout.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "Log4Net", "Layouts", "JsonLayout.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(loggingDir, "LogDetail.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "LogDetail.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(loggingDir, "LogDetailWithException.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "LogDetailWithException.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(loggingDir, "LogParameter.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Logging", "LogParameter.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(coreProjectDir, "CrossCuttingConcerns", "Validation", "ValidationTool.cs"), Path.Combine(templatesDir, "CrossCuttingConcerns", "Validation", "ValidationTool.txt"), projectName);
        }


        private void CreateDataAccessFiles(string coreProjectDir, string templatesDir, string projectName)
        {
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "DataAccess", "EntityFramework", "EfEntityRepositoryBase.cs"), Path.Combine(templatesDir, "DataAccess", "EntityFramework", "EfEntityRepositoryBase.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "DataAccess", "IEntityRepository.cs"), Path.Combine(templatesDir, "DataAccess", "IEntityRepository.txt"), projectName);
        }

        private void CreateEntitiesFiles(string coreProjectDir, string templatesDir, string projectName)
        {
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Entities", "Concrete", "User.cs"), Path.Combine(templatesDir, "Entities", "Concrete", "User.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Entities", "Concrete", "OperationClaim.cs"), Path.Combine(templatesDir, "Entities", "Concrete", "OperationClaim.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Entities", "Concrete", "UserOperationClaim.cs"), Path.Combine(templatesDir, "Entities", "Concrete", "UserOperationClaim.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Entities", "IDto.cs"), Path.Combine(templatesDir, "Entities", "IDto.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Entities", "IEntity.cs"), Path.Combine(templatesDir, "Entities", "IEntity.txt"), projectName);
        }


        private void CreateExtensionsFiles(string coreProjectDir, string templatesDir, string projectName)
        {
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Extensions", "ClaimExtensions.cs"), Path.Combine(templatesDir, "Extensions", "ClaimExtensions.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Extensions", "ClaimsPrincipalExtensions.cs"), Path.Combine(templatesDir, "Extensions", "ClaimsPrincipalExtensions.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Extensions", "ErrorDetails.cs"), Path.Combine(templatesDir, "Extensions", "ErrorDetails.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Extensions", "ServiceCollectionExtensions.cs"), Path.Combine(templatesDir, "Extensions", "ServiceCollectionExtensions.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Extensions", "ExceptionMiddleware.cs"), Path.Combine(templatesDir, "Extensions", "ExceptionMiddleware.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Extensions", "ExceptionMiddlewareExtensions.cs"), Path.Combine(templatesDir, "Extensions", "ExceptionMiddlewareExtensions.txt"), projectName);
        }

        private void CreateUtilitiesFiles(string coreProjectDir, string templatesDir, string projectName)
        {
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Business", "BusinessRules.cs"), Path.Combine(templatesDir, "Utilities", "Business", "BusinessRules.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "IoC", "ServiceTool.cs"), Path.Combine(templatesDir, "Utilities", "IoC", "ServiceTool.txt"), projectName); ////////
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "IoC", "ICoreModule.cs"), Path.Combine(templatesDir, "Utilities", "IoC", "ICoreModule.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Interceptors", "MethodInterception.cs"), Path.Combine(templatesDir, "Utilities", "Interceptors", "MethodInterception.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Interceptors", "AspectInterceptorSelector.cs"), Path.Combine(templatesDir, "Utilities", "Interceptors", "AspectInterceptorSelector.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Interceptors", "MethodInterceptionBaseAttribute.cs"), Path.Combine(templatesDir, "Utilities", "Interceptors", "MethodInterceptionBaseAttribute.txt"), projectName);

            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Security", "Encryption", "SecurityKeyHelper.cs"), Path.Combine(templatesDir, "Utilities", "Security", "Encryption", "SecurityKeyHelper.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Security", "Encryption", "SigningCredentialsHelper.cs"), Path.Combine(templatesDir, "Utilities", "Security", "Encryption", "SigningCredentialsHelper.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Security", "Hashing", "HashingHelper.cs"), Path.Combine(templatesDir, "Utilities", "Security", "Hashing", "HashingHelper.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Security", "Jwt", "AccessToken.cs"), Path.Combine(templatesDir, "Utilities", "Security", "Jwt", "AccessToken.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Security", "Jwt", "ITokenHelper.cs"), Path.Combine(templatesDir, "Utilities", "Security", "Jwt", "ITokenHelper.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Security", "Jwt", "TokenOptions.cs"), Path.Combine(templatesDir, "Utilities", "Security", "Jwt", "TokenOptions.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Security", "Jwt", "JwtHelper.cs"), Path.Combine(templatesDir, "Utilities", "Security", "Jwt", "JwtHelper.txt"), projectName);



            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Results", "DataResult.cs"), Path.Combine(templatesDir, "Utilities", "Results", "DataResult.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Results", "ErrorDataResult.cs"), Path.Combine(templatesDir, "Utilities", "Results", "ErrorDataResult.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Results", "ErrorResult.cs"), Path.Combine(templatesDir, "Utilities", "Results", "ErrorResult.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Results", "IDataResult.cs"), Path.Combine(templatesDir, "Utilities", "Results", "IDataResult.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Results", "IResult.cs"), Path.Combine(templatesDir, "Utilities", "Results", "IResult.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Results", "Result.cs"), Path.Combine(templatesDir, "Utilities", "Results", "Result.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Results", "SuccessDataResult.cs"), Path.Combine(templatesDir, "Utilities", "Results", "SuccessDataResult.txt"), projectName);
            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Results", "SuccessResult.cs"), Path.Combine(templatesDir, "Utilities", "Results", "SuccessResult.txt"), projectName);


            WriteClassFromTemplate(Path.Combine(coreProjectDir, "Utilities", "Messages", "AspectMessages.cs"), Path.Combine(templatesDir, "Utilities", "Messages", "AspectMessages.txt"), projectName);


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
