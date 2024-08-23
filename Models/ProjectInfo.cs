using EnvDTE80;

namespace N_TierSolutionGenerator.Models
{
    internal class ProjectInfo
    {
        public string SolutionDir { get; set; }
        public string SolutionName { get; set; }
        public DTE2 DTE { get; set; }
    }
}
