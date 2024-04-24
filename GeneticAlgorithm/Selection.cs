namespace FinalProject.GeneticAlgorithm
{
    public class Selection
    {
        //5 best solutions - for the rest do tournemant selection for each 5 solutions
        public static HashSet<Chromosome> SelectParents(Population population)
        {
            int fiveP = (int)(population.population.Count * 0.05);
            HashSet<Chromosome> parents = new HashSet<Chromosome>();
            HashSet<Chromosome> bestParents = PickBest(population,fiveP);
            HashSet<Chromosome> tournament = ParentIntTournament(population, fiveP);
            foreach (Chromosome chromosome in bestParents)
                parents.Add(chromosome);
            foreach (Chromosome chromosome in tournament)
                parents.Add(chromosome);
            return parents;
        }
        private static HashSet<Chromosome> ParentIntTournament(Population population,int tournamentSize)
        {
            HashSet<Chromosome> parents = new HashSet<Chromosome>();
            HashSet<Chromosome> chromosomes = population.GetByHashSet();
            int fifteenP = (int)(population.population.Count * 0.15);
            int randomIndex;

            while (parents.Count < fifteenP)
            {
                List<Chromosome> tournamentIndividuals = new List<Chromosome>();
                for (int i = 0; i < tournamentSize; i++)
                {
                    randomIndex = MainAssigningClass.rnd.Next(population.population.Count);
                    tournamentIndividuals.Add(chromosomes.ElementAt(randomIndex));
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
                parents.Add(population.population.Dequeue());
            }
            foreach (Chromosome chromosome in parents)
            {
                population.population.Enqueue(chromosome,chromosome.fitness);
            }
            return parents;
        }
    }
}
