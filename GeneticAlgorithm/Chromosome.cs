using FinalProject.Models;
using FinalProject.Repository;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace FinalProject.GeneticAlgorithm
{
    public class Chromosome : IComparable<Chromosome>
    {
        public HashSet<Employee> myTeam { get; set; }
        public float fitness { get; set; }
        public Chromosome()
        {
            myTeam = new HashSet<Employee>();
            fitness = 0;
        }
        public Chromosome(List<Employee> potnialGenes, int size)
        {
            myTeam = CreateRandom(potnialGenes, size);
        }

        public HashSet<Employee> CreateRandom(List<Employee> employees, int size)
        {
            HashSet<Employee> buildTeam = new HashSet<Employee>();
            int randomIndex;

            while (buildTeam.Count < size)
            {
                randomIndex = MainAssigningClass.rnd.Next(employees.Count);
                buildTeam.Add(employees[randomIndex]);
            }

            return buildTeam;
        }
        public int CompareTo(Chromosome? other)
        {
           return this.fitness.CompareTo(other.fitness);
        }
    }
}
