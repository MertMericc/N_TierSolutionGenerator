using System;
using Microsoft.VisualStudio.Shell;
using NuGet.VisualStudio;
using EnvDTE;

namespace N_TierSolutionGenerator.Services
{
    internal class NuGetPackageInstallerService
    {
        private readonly IVsPackageInstaller _packageInstaller;

        public NuGetPackageInstallerService(IVsPackageInstaller packageInstaller)
        {
            _packageInstaller = packageInstaller;
        }

        public void InstallPackages(EnvDTE.Project project)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                // Microsoft paketlerinin .NET 6.0 sürümünü yüklüyoruz
                InstallPackage(project, "Microsoft.EntityFrameworkCore", "6.0.0");
                InstallPackage(project, "Microsoft.EntityFrameworkCore.SqlServer", "6.0.0");
                InstallPackage(project, "Microsoft.EntityFrameworkCore.Tools", "6.0.0");
                InstallPackage(project, "Microsoft.AspNetCore.Authentication.JwtBearer", "6.0.0");
                InstallPackage(project, "System.IdentityModel.Tokens.Jwt", "6.0.0");

                // Diğer paketlerin son sürümünü yüklüyoruz
                InstallPackage(project, "Autofac", "4.9.4");
                InstallPackage(project, "Autofac.Extensions.DependencyInjection", "4.4.0");
                InstallPackage(project, "Autofac.Extras.DynamicProxy", "4.5.0");
                InstallPackage(project, "FluentValidation", "8.5.0");
                InstallPackage(project, "log4net", "2.0.17");
                InstallPackage(project, "MicroKnights.Log4NetAdoNetAppender", "1.0.2");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Paket yüklemede hata: {ex.Message}");
            }
        }

        private void InstallPackage(EnvDTE.Project project, string packageId, string version)
        {
            _packageInstaller.InstallPackage(null, project, packageId, version, false);
        }
    }
}
