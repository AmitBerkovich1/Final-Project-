using FinalProject.Models;
using FinalProject.Repository;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace FinalProject.GeneticAlgorithm
{
    public class Chromosome : IComparer<Chromosome>
    {
        public HashSet<Employee> myTeam { get; set; }
        public float fitness { get; set; }
        public Chromosome()
        {
            myTeam = new HashSet<Employee>();
            fitness = 0;
        }
        public Chromosome(List<Employee> potnialGenes, int size, Fitness fitness)
        {
            myTeam = CreateRandom(potnialGenes, size);
            this.fitness = fitness.CalculateFitness(myTeam);
        }

        public HashSet<Employee> CreateRandom(List<Employee> employees, int size)
        {
            HashSet<Employee> buildTeam = new HashSet<Employee>();
            Random rnd = new Random();
            int randomIndex;

            while (myTeam.Count < size)
            {
                randomIndex = rnd.Next(employees.Count);
                buildTeam.Add(employees[randomIndex]);
            }

            return buildTeam;
        }

        public int Compare(Chromosome? x, Chromosome? y)
        {
            return y.fitness.CompareTo(x?.fitness);
        }
    }
}
