using FinalProject.Models;

namespace FinalProject.GeneticAlgorithm
{
    public class Population
    {
        public SortedSet<Chromosome> population { get; set; }
        public static Fitness fitness { get; set; }

        public Population()
        {
            population = new SortedSet<Chromosome>();
        }
        public void IntiallizePopulation(List<Employee> employees, Case c, int size, HashSet<Role> roles)
        {
            fitness = new Fitness(employees, roles, c);
            for (int i = 0; i < 100; i++)
            {
                this.population.Add(new Chromosome(employees, size, fitness));
            }
        }

        public Population NextGeneration()
        {
            throw new NotImplementedException();
        }
    }
}
