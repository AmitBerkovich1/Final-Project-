using FinalProject.Models;

namespace FinalProject.GeneticAlgorithm
{
    public class Crossover
    {
        public static Chromosome MyCrossover(Chromosome parent1, Chromosome parent2,Population population,List<Employee> emp)
        {
            Chromosome merge = new Chromosome();
            Employee[] employees1 = parent1.myTeam.ToArray();
            Employee[] employees2 = parent2.myTeam.ToArray();
            int randomIndex1, randomIndex2;

            while (merge.myTeam.Count < parent1.myTeam.Count)
            {
                randomIndex1 = MainAssigningClass.rnd.Next(employees1.Length);
                randomIndex2 = MainAssigningClass.rnd.Next(employees2.Length);
                merge.myTeam.Add(employees1[randomIndex1]);
                if (merge.myTeam.Count < parent1.myTeam.Count)
                    merge.myTeam.Add(employees2[randomIndex2]);
            }
            if (Mutation.ShouldMutate())
                Mutation.Mutate(merge, emp, population);

            merge.fitness = population.fitness.CalculateFitness(merge.myTeam);

            return merge;
        }
        public static PriorityQueue<Chromosome,float> NewGeneration(HashSet<Chromosome> parents,Population population,List<Employee> employees)
        {
            Chromosome[] parentsArray = parents.ToArray();
            HashSet<Chromosome> descendant = new HashSet<Chromosome>();
            PriorityQueue<Chromosome,float> newPopulation = new PriorityQueue<Chromosome,float>();
            int randomIndex1, randomIndex2;

            while (descendant.Count < parents.Count * 4)
            {
                randomIndex1 = MainAssigningClass.rnd.Next(parents.Count);
                randomIndex2 = MainAssigningClass.rnd.Next(parents.Count);
                if (randomIndex1 != randomIndex2)
                {
                    descendant.Add(MyCrossover(parentsArray[randomIndex1], parentsArray[randomIndex2],population,employees));
                }
            }

            foreach (Chromosome c in descendant)
            {
                newPopulation.Enqueue(c,c.fitness);
            }
            foreach (Chromosome c in parents)
            {
                newPopulation.Enqueue(c, c.fitness);
            }

            return newPopulation;
        }
    }
}
