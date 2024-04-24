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

        public AlgorithmController(IEmployeeRepository employeeRepository, ICaseRepository caseRepository,IRoleRepository roleRepository)
        {
            _employeeRepository = employeeRepository;
            _caseRepository = caseRepository;
            _roleRepository = roleRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Assign()
        {
            Dictionary<Case, HashSet<Employee>> assigns = new Dictionary<Case, HashSet<Employee>>();
            List<Employee> employees = (List<Employee>)await _employeeRepository.GetAll();
            List<Role> roleList = (List<Role>)await _roleRepository.GetAll();
            HashSet<Role> roles = DataStructureHandle.ListToHashSet(roleList);
            List<Case> cases = (List<Case>)await _caseRepository.GetAll();
            HashSet<Employee> team;
            int hours;
            Dictionary<Role, float> neededHours;

           foreach (Case myCase in  cases) 
            {
                neededHours = Fitness.CalculateNeededHours(roles, myCase);
                team = MainAssigningClass.AssignTeam(myCase,employees,roles);
                assigns.Add(myCase,team);
                foreach (Employee employee in team)
                {
                    hours = (int)neededHours[employee.role];
                    employee.hoursAssigned += hours;
                }
            }
            return View(assigns);
        }
    }
}
