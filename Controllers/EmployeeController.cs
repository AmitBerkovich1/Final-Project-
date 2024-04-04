using FinalProject.Interfaces;
using FinalProject.Models;
using FinalProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRoleRepository _roleRepository;
        public EmployeeController(IEmployeeRepository employeeRepository, IRoleRepository roleRepository)
        {
            _employeeRepository = employeeRepository;
            _roleRepository = roleRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetAll();
            return View(employees);
        }
        public async Task<IActionResult> Details(int id)
        {
            Employee employee = await _employeeRepository.GetByIdAsync(id);
            return View(employee);
        }
        public async Task<IActionResult> Create()
        {
            CreateEmployeeViewModel viewModel = new CreateEmployeeViewModel();
            viewModel.roles = await _roleRepository.GetAll();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                Role myRole =  await _roleRepository.GetByIdAsync(employeeVM.roleId);
                Employee employee = new Employee();
                employee.roleId = employeeVM.roleId;
                employee.role = myRole;
                employee.firstName = employeeVM.firstName;
                employee.lastName = employeeVM.lastName;
                employee.salary = employeeVM.salary;
                _employeeRepository.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employeeVM);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Employee employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return View("Error");
            }
           
            EditEmployeeViewModel employeeVm = new EditEmployeeViewModel
            {
                id = employee.id,
                firstName = employee.firstName,
                lastName = employee.lastName,
                salary = employee.salary,
                hoursAssigned = employee.hoursAssigned,
                roleId = employee.roleId
            };
            employeeVm.roles = await _roleRepository.GetAll();
            return View(employeeVm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEmployeeViewModel employeeVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed Edit");
                return View("Edit", employeeVM);
            }
            Role myRole = await _employeeRepository.GetRoleByIdAsync(employeeVM.roleId);
            Employee employee = new Employee
            {
                id = employeeVM.id,
                firstName = employeeVM.firstName,
                lastName = employeeVM.lastName,
                salary = employeeVM.salary,
                hoursAssigned = employeeVM.hoursAssigned,
                role = myRole,
                roleId=employeeVM.roleId

            };
            _employeeRepository.Update(employee);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Employee employeeDetails = await _employeeRepository.GetByIdAsync(id);
            if (employeeDetails == null)
            {
                return View("Error");
            }
            return View(employeeDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            Employee employeeDetails = await _employeeRepository.GetByIdAsync(id);
            if (employeeDetails == null)
            {
                return View("Error");
            }
            _employeeRepository.Delete(employeeDetails);
            return RedirectToAction("Index");
        }
    }
}
