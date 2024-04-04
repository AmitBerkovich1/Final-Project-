using FinalProject.Models;

namespace FinalProject.GeneticAlgorithm
{
    public class Fitness
    {
        public  Dictionary<Role, float> needed {  get; set; }
        public  Dictionary<Role, int> roleAndApearnce { get; set; }

        public Fitness(List<Employee> employees, HashSet<Role> roles, Case c)
        {
            needed = CalculateNeededHours(roles,c);
            roleAndApearnce = CountMembers(employees);
        }
        public float CalculateFitness(HashSet<Employee> team)
        {
            float totalFitness = 0;
           
            //Penalty if all same role
            if (roleAndApearnce.Count < 3)
                totalFitness += 100;
            //Employee With lesser job - higher hours
            Dictionary<Role, float> totalHours = new Dictionary<Role, float>();
            foreach (Employee emp in team)
            {
                if (totalHours.ContainsKey(emp.role))
                    totalHours[emp.role] += needed[emp.role] / roleAndApearnce[emp.role];
                else
                    totalHours.Add(emp.role, needed[emp.role] / roleAndApearnce[emp.role]);
                emp.hoursAssigned += (int)needed[emp.role] / roleAndApearnce[emp.role];
                //Penalty if employee passes his roles hours
                if (emp.hoursAssigned > emp.role.maxHours * 1.15)
                    totalFitness += 50;
            }
            //Give Points to fitness based on the difference between neede hours and given hours
            foreach (var item in totalHours)
            {
                totalFitness += (needed[item.Key] - item.Value);
            }
            //Danger Level Considiration - High Level -> High Role
            return totalFitness;
        }
        private static Dictionary<Role, int> CountMembers(List<Employee> employees)
        {
            Dictionary<Role, int> count = new Dictionary<Role, int>();
            foreach (Employee employee in employees)
            {
                if (!count.ContainsKey(employee.role))
                    count.Add(employee.role, 1);
                else
                    count[employee.role]++;
            }
            return count;
        }
        private static Dictionary<Role, float> CalculateNeededHours(HashSet<Role> roles, Case c)
        {
            Dictionary<Role, float> neededHours = new Dictionary<Role, float>();
            foreach (Role role in roles)
            {
                if (role.title == "Junior")
                    neededHours.Add(role, (float)(c.assedHours * 0.5));
                else if (role.title == "Senior")
                    neededHours.Add(role, (float)(c.assedHours * 0.3));
                else if (role.title == "Manager")
                    neededHours.Add(role, (float)(c.assedHours * 0.2));
            }
            return neededHours;
        }
    }
}
