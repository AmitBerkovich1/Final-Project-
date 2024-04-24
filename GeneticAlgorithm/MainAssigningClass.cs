using FinalProject.Models;

namespace FinalProject.GeneticAlgorithm
{
    public class MainAssigningClass
    {
        public static Random rnd = new Random();
        public static HashSet<Employee> AssignTeam(Case c, List<Employee> employees,HashSet<Role> roles)
        {
            int size = 3,count = 0;
            float oldFitness;
            HashSet<Chromosome> parents;
            Population population = new Population(employees, roles, c);
            population.IntiallizePopulation(employees, size, roles);
            oldFitness = population.population.Peek().fitness;
            for (int i = 0;i<100;i++)
            {
                parents = Selection.SelectParents(population);
                population.population = Crossover.NewGeneration(parents, population, employees);
                if (oldFitness == population.population.Peek().fitness)
                    count++;
                else
                    count = 0;
            }
            //while (count < 5)
            //{ 
            //    parents = Selection.SelectParents(population);
            //    population.population = Crossover.NewGeneration(parents, population,employees);
            //    if (oldFitness == population.population.Peek().fitness)
            //        count++;
            //    else
            //        count = 0;
            //}
            
            return population.population.Dequeue().myTeam;
        }
    }
}
