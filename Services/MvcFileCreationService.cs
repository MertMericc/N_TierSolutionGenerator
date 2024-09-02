using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class MvcFileCreationService
    {
        public void AddMvcFiles(string projectDir)
        {
            CreateMvcFolders(projectDir);
            CreateMvcFiles(projectDir);
            CreateProgramFile(projectDir);
        }

        private void CreateMvcFolders(string projectDir)
        {
            Directory.CreateDirectory(Path.Combine(projectDir, "wwwroot"));
            Directory.CreateDirectory(Path.Combine(projectDir, "Controllers"));
            Directory.CreateDirectory(Path.Combine(projectDir, "Models"));
            Directory.CreateDirectory(Path.Combine(projectDir, "Views", "Home"));
            Directory.CreateDirectory(Path.Combine(projectDir, "Views", "Shared"));
        }

        private void CreateMvcFiles(string projectDir)
        {
            // Controller
            string controllerPath = Path.Combine(projectDir, "Controllers", "HomeController.cs");
            if (!File.Exists(controllerPath))
            {
                string controllerContent = @"
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}";
                File.WriteAllText(controllerPath, controllerContent);
            }

            // Model
            string modelPath = Path.Combine(projectDir, "Models", "ErrorViewModel.cs");
            if (!File.Exists(modelPath))
            {
                string modelContent = @"
namespace WebApplication1.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}";
                File.WriteAllText(modelPath, modelContent);
            }

            // Views/Home/Index.cshtml
            string indexViewPath = Path.Combine(projectDir, "Views", "Home", "Index.cshtml");
            if (!File.Exists(indexViewPath))
            {
                string indexViewContent = @"
@{
    ViewData[""Title""] = ""Home Page"";
}

<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <p>Welcome to your MVC web application.</p>
</div>";
                File.WriteAllText(indexViewPath, indexViewContent);
            }

            // Views/Home/Privacy.cshtml
            string privacyViewPath = Path.Combine(projectDir, "Views", "Home", "Privacy.cshtml");
            if (!File.Exists(privacyViewPath))
            {
                string privacyViewContent = @"
@{
    ViewData[""Title""] = ""Privacy Policy"";
}

<h1>Privacy Policy</h1>
<p>Your privacy is important to us.</p>";
                File.WriteAllText(privacyViewPath, privacyViewContent);
            }

            // Views/Shared/_Layout.cshtml
            string layoutPath = Path.Combine(projectDir, "Views", "Shared", "_Layout.cshtml");
            if (!File.Exists(layoutPath))
            {
                string layoutContent = @"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <title>@ViewData[""Title""] - WebApplication1</title>
    <link rel=""stylesheet"" href=""~/css/site.css"" />
</head>
<body>
    <header>
        <nav>
            <ul>
                <li><a href=""/Home/Index"">Home</a></li>
                <li><a href=""/Home/Privacy"">Privacy</a></li>
            </ul>
        </nav>
    </header>
    <main role=""main"" class=""pb-3"">
        @RenderBody()
    </main>
    <footer>
        <p>&copy; 2024 - WebApplication1</p>
    </footer>
</body>
</html>";
                File.WriteAllText(layoutPath, layoutContent);
            }

            // Views/Shared/Error.cshtml
            string errorViewPath = Path.Combine(projectDir, "Views", "Shared", "Error.cshtml");
            if (!File.Exists(errorViewPath))
            {
                string errorViewContent = @"
@model WebApplication1.Models.ErrorViewModel

@{
    ViewData[""Title""] = ""Error"";
}

<h1 class=""text-danger"">Error</h1>
<h2 class=""text-danger"">An error occurred while processing your request.</h2>
<p class=""text-danger"">Request ID: <code>@Model?.RequestId</code></p>";
                File.WriteAllText(errorViewPath, errorViewContent);
            }

            // Views/Shared/_ValidationScriptsPartial.cshtml
            string validationScriptsPath = Path.Combine(projectDir, "Views", "Shared", "_ValidationScriptsPartial.cshtml");
            if (!File.Exists(validationScriptsPath))
            {
                string validationScriptsContent = @"<partial name=""_ValidationScriptsPartial"" />";
                File.WriteAllText(validationScriptsPath, validationScriptsContent);
            }

            // wwwroot files (can be customized further if needed)
            string wwwrootCssPath = Path.Combine(projectDir, "wwwroot", "css", "site.css");
            Directory.CreateDirectory(Path.Combine(projectDir, "wwwroot", "css"));

            if (!File.Exists(wwwrootCssPath))
            {
                string siteCssContent = @"body { font-family: Arial, sans-serif; }";
                File.WriteAllText(wwwrootCssPath, siteCssContent);
            }
        }

        private void CreateProgramFile(string projectDir)
        {
            string programFilePath = Path.Combine(projectDir, "Program.cs");
            if (!File.Exists(programFilePath))
            {
                string programContent = @"
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}";
                File.WriteAllText(programFilePath, programContent);
            }

            CreateStartupFile(projectDir);
        }

        private void CreateStartupFile(string projectDir)
        {
            string startupFilePath = Path.Combine(projectDir, "Startup.cs");
            if (!File.Exists(startupFilePath))
            {
                string startupContent = @"
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler(""/Home/Error"");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: ""default"",
                pattern: ""{controller=Home}/{action=Index}/{id?}"");
        });
    }
}";
                File.WriteAllText(startupFilePath, startupContent);
            }
        }
    }
}
