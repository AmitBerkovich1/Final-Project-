using FinalProject.Models;

namespace FinalProject.GeneticAlgorithm
{
    public class Crossover
    {
        public static Chromosome MyCrossover(Chromosome parent1, Chromosome parent2, Fitness fitness)
        {
            Chromosome merge = new Chromosome();
            Employee[] employees1 = parent1.myTeam.ToArray();
            Employee[] employees2 = parent2.myTeam.ToArray();
            int randomIndex1, randomIndex2;
            Random rnd = new Random();

            while (merge.myTeam.Count < parent1.myTeam.Count)
            {
                randomIndex1 = rnd.Next(employees1.Length);
                randomIndex2 = rnd.Next(employees2.Length);
                merge.myTeam.Add(employees1[randomIndex1]);
                if (merge.myTeam.Count < parent1.myTeam.Count)
                    merge.myTeam.Add(employees2[randomIndex2]);
            }

            merge.fitness = fitness.CalculateFitness(merge.myTeam);

            return merge;
        }
        public static Chromosome[] TwoParents(HashSet<Chromosome> parents,Fitness fitness)
        {
            Chromosome[] parentsArray = parents.ToArray();
            HashSet<Chromosome> descendant = new HashSet<Chromosome>();
            int randomIndex1, randomIndex2;
            Random rnd = new Random();

            while (descendant.Count < (parents.Count / 0.2) * 0.8)
            {
                randomIndex1 = rnd.Next(parents.Count);
                randomIndex2 = rnd.Next(parents.Count);
                if (randomIndex1 != randomIndex2)
                {
                    descendant.Add(MyCrossover(parentsArray[randomIndex1], parentsArray[randomIndex2],fitness));
                }
            }

            foreach (Chromosome c in descendant)
            {
                parents.Add(c);
            }

            return parents.ToArray();
        }
        public static Chromosome Mutate(Chromosome descendant)
        {
            throw new NotImplementedException();
        }
    }
}
