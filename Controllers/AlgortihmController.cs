using FinalProject.GeneticAlgorithm;
using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AlgortihmController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICaseRepository _caseRepository;
        private readonly IRoleRepository _roleRepository;

        public AlgortihmController(IEmployeeRepository employeeRepository, ICaseRepository caseRepository,IRoleRepository roleRepository)
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
            HashSet<Role> roles = (HashSet<Role>)await _roleRepository.GetAll();
            SortedSet<Case> cases = (SortedSet<Case>)await _caseRepository.GetAll();

            while (cases.Count > 0)
            {
                Case myCase = cases.Max;
                cases.Remove(myCase);
                assigns.Add(myCase,MainAssigningClass.AssignTeam(myCase,employees,roles));
            }
            return View(assigns);
        }
    }
}
