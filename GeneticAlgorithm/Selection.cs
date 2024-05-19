namespace FinalProject.GeneticAlgorithm
{
    public class Selection
    {
        /// <summary>
        /// merge the best chromosomes and the chromosomes from the tournament
        /// </summary>
        /// <param name="population">current population</param>
        /// <returns>parents to crate the next generation</returns>
        public static HashSet<Chromosome> SelectParents(Population population)
        {
            float myPrecent = (float)((int)MyEnums.Precent.BestParentsAmount / 100.0);
            int fiveP = (int)(population.population.Count * myPrecent);
            HashSet<Chromosome> parents = new HashSet<Chromosome>();
            HashSet<Chromosome> bestParents = PickBest(population, fiveP);
            HashSet<Chromosome> tournament = ParentIntTournament(population, bestParents, fiveP);
            foreach (Chromosome chromosome in bestParents)
                parents.Add(chromosome);
            foreach (Chromosome chromosome in tournament)
                parents.Add(chromosome);
            return parents;
        }
        /// <summary>
        /// Choose parents in tournament selection. create subgroups and choose the best in each subgroup
        /// </summary>
        /// <param name="population">current population</param>
        /// <param name="curParents">parents that has already been chosen</param>
        /// <param name="tournamentSize">size of each subgroup</param>
        /// <returns></returns>
        private static HashSet<Chromosome> ParentIntTournament(Population population, HashSet<Chromosome> curParents, int tournamentSize)
        {
            float myPrecent = (float)((int)MyEnums.Precent.TournamaentParentAmount / 100.0);
            HashSet<Chromosome> parents = new HashSet<Chromosome>();
            HashSet<Chromosome> chromosomes = population.GetByHashSet();
            int fifteenP = (int)(population.population.Count * myPrecent);
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
                if (!curParents.Contains(best))
                    parents.Add(best);
            }
            return parents;
        }
        /// <summary>
        /// Pick the best solutions from the population
        /// </summary>
        /// <param name="population">currentn population</param>
        /// <param name="n">how many solutions</param>
        /// <returns>n best solutions</returns>
        private static HashSet<Chromosome> PickBest(Population population, int n)
        {
            HashSet<Chromosome> parents = new HashSet<Chromosome>();
            for (int i = 0; i < n; i++)
            {
                parents.Add(population.population.Dequeue());
            }
            foreach (Chromosome chromosome in parents)
            {
                population.population.Enqueue(chromosome, chromosome.fitness);
            }
            return parents;
        }
    }
}
