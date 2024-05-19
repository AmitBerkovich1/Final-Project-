using FinalProject.GeneticAlgorithm;

namespace FinalProject.Models
{
    public class ShowResults
    {
        public Dictionary<Case, Chromosome> allTeams { get; set; }

        public List<Dictionary<Role,float>> neededHours {  get; set; }

        public List<Dictionary<Role,int>> roleAppearance {  get; set; }

        public ShowResults()
        {
            allTeams = new Dictionary<Case, Chromosome>();
            neededHours = new List<Dictionary<Role,float>>();
            roleAppearance = new List<Dictionary<Role,int>>();
        }
    }
}
