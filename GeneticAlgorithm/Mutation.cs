using FinalProject.Models;

namespace FinalProject.GeneticAlgorithm
{
    public class Mutation
    {
        public static void Mutate(Chromosome c,List<Employee> employees,Population population)
        {
            Employee[] employeeArr = c.myTeam.ToArray();
            int replaceInd, amount,fromInd;
            amount = MainAssigningClass.rnd.Next(employeeArr.Length);

            for (int i = 0;i < amount;i++) 
            {
                replaceInd = MainAssigningClass.rnd.Next(employeeArr.Length);
                fromInd = MainAssigningClass.rnd.Next(employees.Count);
                employeeArr[replaceInd] = employees[fromInd];
            }

            c.myTeam = new HashSet<Employee>(employeeArr);
            c.fitness = population.fitness.CalculateFitness(c.myTeam);
        }

        public static bool ShouldMutate()
        {
            int num = MainAssigningClass.rnd.Next(20);
            if (num == 1)
                return true;
            return false;
        }
    }
}
