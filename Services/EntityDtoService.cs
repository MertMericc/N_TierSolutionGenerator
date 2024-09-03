using System.IO;

namespace N_TierSolutionGenerator.Services
{
    internal class EntityDtoService
    {
        public void AddDtos(string entityName, string projectDir)
        {
            string dtosDir = Path.Combine(projectDir, "Dtos", entityName + "s");
            Directory.CreateDirectory(dtosDir);

            CreateDtoFile(Path.Combine(dtosDir, entityName + "GetAllDto.cs"), entityName + "GetAllDto");
            CreateDtoFile(Path.Combine(dtosDir, entityName + "GetByIdDto.cs"), entityName + "GetByIdDto");
            CreateDtoFile(Path.Combine(dtosDir, entityName + "AddDto.cs"), entityName + "AddDto");
            CreateDtoFile(Path.Combine(dtosDir, entityName + "UpdateDto.cs"), entityName + "UpdateDto");
        }

        private void CreateDtoFile(string path, string className)
        {
            if (!File.Exists(path))
            {
                string content = $@"
namespace Solution13.Entity.Dtos.{Path.GetFileNameWithoutExtension(Path.GetDirectoryName(path))}
{{
    public class {className}
    {{
        // Properties
    }}
}}";
                File.WriteAllText(path, content);
            }
        }
    }
}
