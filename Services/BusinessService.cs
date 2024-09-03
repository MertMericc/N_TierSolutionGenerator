using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class BusinessService
    {
        public void AddAbstractInterface(string entityName, string projectDir)
        {
            string abstractDir = Path.Combine(projectDir, "Abstract");
            Directory.CreateDirectory(abstractDir);

            string interfaceFile = Path.Combine(abstractDir, "I" + entityName + "Service.cs");
            if (!File.Exists(interfaceFile))
            {
                string content = $@"
namespace Solution13.Business.Abstract
{{
    public interface I{entityName}Service
    {{
        // Method signatures
    }}
}}";
                File.WriteAllText(interfaceFile, content);
            }
        }

        public void AddConcreteManager(string entityName, string projectDir)
        {
            string concreteDir = Path.Combine(projectDir, "Concrete");
            Directory.CreateDirectory(concreteDir);

            string classFile = Path.Combine(concreteDir, entityName + "Manager.cs");
            if (!File.Exists(classFile))
            {
                string content = $@"
using Solution13.Business.Abstract;

namespace Solution13.Business.Concrete
{{
    public class {entityName}Manager : I{entityName}Service
    {{
        // Implement methods
    }}
}}";
                File.WriteAllText(classFile, content);
            }
        }
    }
}
