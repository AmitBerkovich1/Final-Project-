using FinalProject.Models;

namespace FinalProject.GeneticAlgorithm
{
    public class MainAssigningClass
    {
        public static Random rnd = new Random(); // random variable - all classes uses him

        /// <summary>
        /// Main assigning clase, generate a new team
        /// </summary>
        /// <param name="c">case to assgin a team</param>
        /// <param name="employees">employess to create the team</param>
        /// <param name="roles">roles of the employees</param>
        /// <returns>best team to the case</returns>
        public static Chromosome AssignTeam(Case c, List<Employee> employees,HashSet<Role> roles)
        {
            int size = (int)(MyEnums.Size.baseSize
                + (c.level.level - 1) 
                + (int)((c.assedHours - (int)MyEnums.Hours.BaseHours) / (int) MyEnums.Hours.AdditonHours))
                , count = 0;
            float bestFitness;
            HashSet<Chromosome> parents;
            Population population = new Population(employees, roles, c);
            population.IntiallizePopulation(employees, size);
            bestFitness = population.population.Peek().fitness;
            while (count < (int)MyEnums.End.MaxWithNoImprovment)
            {
                parents = Selection.SelectParents(population);
                population.population = Crossover.NewGeneration(parents, population, employees);
                if (bestFitness == population.population.Peek().fitness)
                {
                    count++;
                }
                else
                {
                    count = 0;
                    bestFitness = population.population.Peek().fitness;
                }
            }

            return population.population.Dequeue();
        }
    }
}
