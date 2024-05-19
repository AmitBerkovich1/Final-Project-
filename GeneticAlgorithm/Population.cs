using FinalProject.Models;
using System.Data;
using System.Runtime.CompilerServices;

namespace FinalProject.GeneticAlgorithm
{
    public class Population
    {
        public PriorityQueue<Chromosome,float> population { get; set; } // main population
        public Fitness fitness { get; set; } // Object to help calculate fitness

        /// <summary>
        /// Construcut
        /// </summary>
        /// <param name="employees">Potntial employees</param>
        /// <param name="roles">all relvant roles</param>
        /// <param name="c">case to assign team</param>
        public Population(List<Employee> employees, HashSet<Role> roles, Case c)
        {
            population = new PriorityQueue<Chromosome, float>();
            fitness = new Fitness(employees, roles, c);
        }
        /// <summary>
        /// Function to help start a new population
        /// </summary>
        /// <param name="employees">employees to assemble team</param>
        /// <param name="size">size of team</param>
        public void IntiallizePopulation(List<Employee> employees, int size)
        {
            Chromosome myChromosome;
            for (int i = 0; i < (int)MyEnums.Size.PopulationSize; i++)
            {
                myChromosome = new Chromosome(employees, size);
                myChromosome.fitness = fitness.CalculateFitness(myChromosome.myTeam);
                population.Enqueue(myChromosome, fitness.CalculateFitness(myChromosome.myTeam));
            }
        }
        /// <summary>
        /// Convert to population to hashset
        /// </summary>
        /// <returns>hashset of population instead of priority queue</returns>
        public HashSet<Chromosome> GetByHashSet()
        {
            HashSet<Chromosome> chromosomes = new HashSet<Chromosome>();
            int numOfItration = population.Count;
            for (int i = 0;i < numOfItration;i++)
            {
                chromosomes.Add(population.Dequeue());
            }
            foreach (Chromosome chromosome in chromosomes)
            {
                population.Enqueue(chromosome, chromosome.fitness);
            }
            return chromosomes;
        }
    }
}
