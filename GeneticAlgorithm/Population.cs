using FinalProject.Models;
using System.Data;
using System.Runtime.CompilerServices;

namespace FinalProject.GeneticAlgorithm
{
    public class Population
    {
        public PriorityQueue<Chromosome,float> population { get; set; }
        public Fitness fitness { get; set; }

        public Population(List<Employee> employees, HashSet<Role> roles, Case c)
        {
            population = new PriorityQueue<Chromosome, float>();
            fitness = new Fitness(employees, roles, c);
        }
        public void IntiallizePopulation(List<Employee> employees, int size, HashSet<Role> roles)
        {
            Chromosome myChromosome;
            for (int i = 0; i < 100; i++)
            {
                myChromosome = new Chromosome(employees, size);
                myChromosome.fitness = fitness.CalculateFitness(myChromosome.myTeam);
                population.Enqueue(myChromosome, fitness.CalculateFitness(myChromosome.myTeam));
            }
        }

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
