using FinalProject.Models;

namespace FinalProject.GeneticAlgorithm
{
    public class Mutation
    {
        /// <summary>
        /// change a gene in the chromosome
        /// </summary>
        /// <param name="c">the chromosome</param>
        /// <param name="employees">genes to be the replace</param>
        /// <param name="population">current population</param>
        public static void Mutate(Chromosome c, List<Employee> employees, Population population)
        {
            Employee[] employeeArr = c.myTeam.ToArray();
            int replaceInd, fromInd;
            replaceInd = MainAssigningClass.rnd.Next(employeeArr.Length);
            fromInd = MainAssigningClass.rnd.Next(employees.Count);
            if (!c.myTeam.Contains(employees[fromInd]))
            {
                employeeArr[replaceInd] = employees[fromInd];
            }

            c.myTeam = new HashSet<Employee>(employeeArr);
            c.fitness = population.fitness.CalculateFitness(c.myTeam);
        }
        /// <summary>
        /// generate 5% chance of returning true
        /// </summary>
        /// <returns>if number betweeb 0-20 is 1 ture, else false</returns>
        public static bool ShouldMutate()
        {
            int num = MainAssigningClass.rnd.Next((int)MyEnums.Guesses.Range);
            if (num == (int)MyEnums.Guesses.CorrectGuess)
                return true;
            return false;
        }
    }
}
