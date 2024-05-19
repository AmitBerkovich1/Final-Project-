using FinalProject.Models;
using FinalProject.Repository;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace FinalProject.GeneticAlgorithm
{
    public class Chromosome : IComparable<Chromosome>
    {
        public HashSet<Employee> myTeam { get; set; } // Team
        public float fitness { get; set; } // fitness of the team
        public Chromosome()
        {
            myTeam = new HashSet<Employee>();
            fitness = 0;
        }
        /// <summary>
        /// Create a random chromosome
        /// </summary>
        /// <param name="potnialGenes">List of potntial employees</param>
        /// <param name="size">size of the team</param>
        public Chromosome(List<Employee> potnialGenes, int size)
        {
            myTeam = CreateRandom(potnialGenes, size);
        }
        /// <summary>
        /// Randomly Create a team
        /// </summary>
        /// <param name="employees">Potntial employees</param>
        /// <param name="size">size of the team</param>
        /// <returns>The team built</returns>
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
        /// <summary>
        /// Compare two chromosome based on fitness
        /// </summary>
        /// <param name="other">chromosome we want to compare</param>
        /// <returns>positive if this is better, 0 if equal, negative if other is better</returns>
        public int CompareTo(Chromosome? other)
        {
           return this.fitness.CompareTo(other.fitness);
        }
    }
}
