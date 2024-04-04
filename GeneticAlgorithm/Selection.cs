namespace FinalProject.GeneticAlgorithm
{
    public class Generation
    {
        //5 best solutions - for the rest do tournemant selection for each 5 solutions
        public static HashSet<Chromosome> SelectParents(Population population)
        {
            HashSet<Chromosome> parents = new HashSet<Chromosome>();
            HashSet<Chromosome> bestParents = PickBest(population,5);
            HashSet<Chromosome> tournament = ParentIntTournament(population, 5);
            foreach (Chromosome chromosome in bestParents)
                parents.Add(chromosome);
            foreach (Chromosome chromosome in tournament)
                parents.Add(chromosome);
            return parents;
        }
        private static HashSet<Chromosome> ParentIntTournament(Population population,int tournamentSize)
        {
            HashSet<Chromosome> parents = new HashSet<Chromosome>();
            Random rnd = new Random();
            int randomIndex;

            while (parents.Count < population.population.Count * 0.2)
            {
                List<Chromosome> tournamentIndividuals = new List<Chromosome>();
                for (int i = 0; i < tournamentSize; i++)
                {
                    randomIndex = rnd.Next(population.population.Count);
                    tournamentIndividuals.Add(population.population.ElementAt(randomIndex));
                }
                Chromosome best = tournamentIndividuals.OrderByDescending(i => i).First();
                parents.Add(best);
            }
            return parents;
        }
        private static HashSet<Chromosome> PickBest(Population population,int n)
        {
            HashSet<Chromosome> parents = new HashSet<Chromosome>();
            for (int i = 0; i < n; i++)
            {
                parents.Add(population.population.Min);
                population.population.Remove(population.population.Min);
            }
            foreach (Chromosome chromosome in parents)
            {
                population.population.Add(chromosome);
            }
            return parents;
        }
    }
}
