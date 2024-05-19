using FinalProject.Models;

namespace FinalProject.GeneticAlgorithm
{
    public class Fitness
    {
        public Dictionary<Role, float> needed {  get; set; }

        public Fitness(List<Employee> employees, HashSet<Role> roles, Case c)
        {
            needed = CalculateNeededHours(roles, c);
        }
        public float CalculateFitness(HashSet<Employee> team)
        {
            float totalFitness = 0;
            float myHours = 0;
            Dictionary<Role,int> roleAndApearnce = CountMembers(team);

            //Penalty if all same role
            if (roleAndApearnce.Count < (int)MyEnums.Size.NumberOfRoles)
                totalFitness += (int)MyEnums.Penalty.MaxPenalty;
            //Employee With lesser job - higher hours
            Dictionary<Role, float> totalHours = new Dictionary<Role, float>();
            foreach (Employee emp in team)
            {
                myHours = emp.hoursAssigned + (int)needed[emp.role] / roleAndApearnce[emp.role];
                if (totalHours.ContainsKey(emp.role) && myHours < emp.role.maxHours *1.15)
                    totalHours[emp.role] += needed[emp.role] / roleAndApearnce[emp.role];
                else if (!totalHours.ContainsKey(emp.role) && myHours < emp.role.maxHours * 1.15)
                    totalHours.Add(emp.role, needed[emp.role] / roleAndApearnce[emp.role]);

                //Penalty if employee passes his roles hours
                else if (totalHours.ContainsKey(emp.role) && myHours > emp.role.maxHours * 1.15)
                    totalHours[emp.role] += ((int)(emp.role.maxHours*1.15) - emp.hoursAssigned);
                else if (!totalHours.ContainsKey(emp.role) && myHours > emp.role.maxHours * 1.15)
                    totalHours.Add(emp.role,(float)(emp.role.maxHours * 1.15) - emp.hoursAssigned);
            }
            //Give Points to fitness based on the difference between neede hours and given hours
            foreach (var item in totalHours)
            {
                totalFitness += (needed[item.Key] - item.Value);
            }
            //If one of the employees is yet to be assaigned - better result
            foreach (Employee emp in team)
            {
                if (emp.hoursAssigned == 0)
                    totalFitness -= (int)MyEnums.Penalty.Positive;
            }
            //Danger Level Considiration - High Level -> High Role
            return totalFitness;
        }
        public static Dictionary<Role, int> CountMembers(HashSet<Employee> employees)
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
        public static Dictionary<Role, float> CalculateNeededHours(HashSet<Role> roles, Case c)
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
                else
                    neededHours.Add(role, (float)(MyEnums.Hours.AdditionRoleHours));
            }
            return neededHours;
        }
    }
}
