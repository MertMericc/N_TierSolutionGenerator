using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class DataAccessService
    {
        public void AddAbstractInterface(string entityName, string projectDir)
        {
            string abstractDir = Path.Combine(projectDir, "Abstract");
            Directory.CreateDirectory(abstractDir);

            string interfaceFile = Path.Combine(abstractDir, "I" + entityName + "Dal.cs");
            if (!File.Exists(interfaceFile))
            {
                string content = $@"
using Solution13.Core.DataAccess;
using Solution13.Core.Entities.Concrete;

namespace Solution13.DataAccess.Abstract
{{
    public interface I{entityName}Dal : IEntityRepository<{entityName}>
    {{
    }}
}}";
                File.WriteAllText(interfaceFile, content);
            }
        }



        public void AddConcreteEntityFramework(string entityName, string projectDir)
        {
            string efDir = Path.Combine(projectDir, "Concrete", "EntityFramework");
            Directory.CreateDirectory(efDir);

            string classFile = Path.Combine(efDir, "Ef" + entityName + "Dal.cs");
            if (!File.Exists(classFile))
            {
                string content = $@"
using Solution13.Core.DataAccess.EntityFramework;
using Solution13.Core.Entities.Concrete;
using Solution13.DataAccess.Abstract;
using Solution13.DataAccess.Concrete.EntityFramework.Contexts;

public class Ef{entityName}Dal : EfEntityRepositoryBase<{entityName}, NorthwindContext>, I{entityName}Dal
{{
    
}}";
                File.WriteAllText(classFile, content);
            }
        }




        public void AddDbSetToContext(string entityName, string contextFilePath)
        {
            if (File.Exists(contextFilePath))
            {
                string[] lines = File.ReadAllLines(contextFilePath);
                using (StreamWriter writer = new StreamWriter(contextFilePath))
                {
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                        if (line.Contains("public class NorthwindContext"))
                        {
                            writer.WriteLine($"    public DbSet<{entityName}> {entityName}s {{ get; set; }}");
                        }
                    }
                }
            }
        }


    }
}
