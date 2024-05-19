using FinalProject.General;
using FinalProject.GeneticAlgorithm;
using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AlgorithmController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICaseRepository _caseRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDangerLevelRepository _levelRepository;
        private readonly ICompanyRepository _companyRepository;

        public AlgorithmController(IEmployeeRepository employeeRepository, ICaseRepository caseRepository, IRoleRepository roleRepository, IDangerLevelRepository levelRepository, ICompanyRepository companyRepository)
        {
            _employeeRepository = employeeRepository;
            _caseRepository = caseRepository;
            _roleRepository = roleRepository;
            _levelRepository = levelRepository;
            _companyRepository = companyRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Activiating The Genetic Algorithm
        /// </summary>
        /// <returns>Build the assigning Dicionary model</returns>
        public async Task<IActionResult> Assign()
        {
            //Dicitonary Model
            ShowResults assigns = new ShowResults();
            //Potntial Employees
            List<Employee> employees = (List<Employee>)await _employeeRepository.GetAll();
            //All The Roles
            List<Role> roleList = (List<Role>)await _roleRepository.GetAll();
            //Convert To HashSet
            HashSet<Role> roles = DataStructureHandle.ListToHashSet(roleList);
            //All The cases
            List<Case> cases = (List<Case>)await _caseRepository.GetAll();
            //Convert To HashSet
            HashSet<Case> myCases = DataStructureHandle.ListToHashSet(cases);
            //Team to get from algorithm
            Chromosome team;
            int hours;
            //Needed hours for each role in the case
            Dictionary<Role, float> neededHours;
            //The appearnce of each role in the team
            Dictionary<Role,int> roleappearnce;
            Case c;
            
            //Scan all cases
            while (myCases.Count > 0)
            {
                //Get The minimum case based on requierd date
                c = myCases.Min();
                //If the reqiuerd date didn't pass - Activate Algorithm
                if (!(c.requiredDate < DateTime.Now))
                {
                    c.level = await _levelRepository.GetByIdAsync(c.levelId);
                    neededHours = Fitness.CalculateNeededHours(roles, c);
                    team = MainAssigningClass.AssignTeam(c, employees, roles);
                    roleappearnce = Fitness.CountMembers(team.myTeam);
                    c.company = await _companyRepository.GetByIdAsync(c.companyId);
                    assigns.allTeams.Add(c, team);
                    assigns.neededHours.Add(neededHours);
                    assigns.roleAppearance.Add(Fitness.CountMembers(team.myTeam));
                    //Add and update each employee in the team chosen
                    foreach (Employee employee in team.myTeam)
                    {
                        hours = (int)neededHours[employee.role] / roleappearnce[employee.role];
                        employee.hoursAssigned += hours;
                    }
                }
                // remove the case
                myCases.Remove(c);
            }
            //pass the model 
            return View(assigns);
        }
    }
}
