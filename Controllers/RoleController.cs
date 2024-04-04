using FinalProject.Data;
using FinalProject.Interfaces;
using FinalProject.Models;
using FinalProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace FinalProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Role> roles = await _roleRepository.GetAll();
            return View(roles);
        }
        public async Task<IActionResult> Details(int id)
        {
            Role role = await _roleRepository.GetByIdAsync(id);
            return View(role);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel roleVM)
        {
            if (ModelState.IsValid)
            {
                Role role = new Role { title = roleVM.title, jobDescription = roleVM.jobDescription, maxHours = roleVM.maxHours };
                _roleRepository.Add(role);
                return RedirectToAction("Index");
            }
            return View(roleVM);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Role role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
            {
                return View("Error");
            }
            EditRoleViewModel roleVM = new EditRoleViewModel
            {
                id = role.id,
                jobDescription = role.jobDescription,
                maxHours = role.maxHours,
                title = role.title
            };
            return View(roleVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRoleViewModel roleVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed Edit");
                return View("Edit", roleVM);
            }
            Role role = new Role
            {
                id = roleVM.id,
                title = roleVM.title,
                jobDescription = roleVM.jobDescription,
                maxHours = roleVM.maxHours
            };
            _roleRepository.Update(role);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Role roleDetails = await _roleRepository.GetByIdAsync(id);
            if (roleDetails == null)
            {
                return View("Error");
            }
            return View(roleDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            Role roleDetails = await _roleRepository.GetByIdAsync(id);
            if (roleDetails == null)
            {
                return View("Error");
            }
            _roleRepository.Delete(roleDetails);
            return RedirectToAction("Index");
        }
    }
}
