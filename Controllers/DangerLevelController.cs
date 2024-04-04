using FinalProject.Interfaces;
using FinalProject.Models;
using FinalProject.Repository;
using FinalProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class DangerLevelController : Controller
    {
        private readonly IDangerLevelRepository _dangerLevelRepository;

        public DangerLevelController(IDangerLevelRepository dangerLevelRepository)
        {
            _dangerLevelRepository = dangerLevelRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<DangerLevel> dangerLevel = await _dangerLevelRepository.GetAll();
            return View(dangerLevel);
        }
        public async Task<IActionResult> Details(int id)
        {
            DangerLevel dangerLevel = await _dangerLevelRepository.GetByIdAsync(id);
            return View(dangerLevel);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDangerLevelModel dangerLevelVM)
        {
            if (ModelState.IsValid)
            {
                DangerLevel dl = new DangerLevel
                {
                    level = dangerLevelVM.level,
                    description = dangerLevelVM.description,
                    title = dangerLevelVM.title
                };
                _dangerLevelRepository.Add(dl);
                return RedirectToAction("Index");
            }
            return View(dangerLevelVM);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            DangerLevel dangerLevel = await _dangerLevelRepository.GetByIdAsync(id);
            if (dangerLevel == null)
            {
                return View("Error");
            }
            EditDangerLevelModel dangerLevelVM = new EditDangerLevelModel
            {
                id = dangerLevel.id,
                level = dangerLevel.level,
                description = dangerLevel.description,
                title = dangerLevel.title
            };
            return View(dangerLevelVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int level, EditDangerLevelModel dangerLevelVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed Edit");
                return View("Edit", dangerLevelVM);
            }
            DangerLevel dangerLevel = new DangerLevel
            {
                id = dangerLevelVM.id,
                level = dangerLevelVM.level,
                description = dangerLevelVM.description,
                title = dangerLevelVM.title
            };
            _dangerLevelRepository.Update(dangerLevel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            DangerLevel dangerLevelDetails = await _dangerLevelRepository.GetByIdAsync(id);
            if (dangerLevelDetails == null)
            {
                return View("Error");
            }
            return View(dangerLevelDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            DangerLevel dangerLevelDetails = await _dangerLevelRepository.GetByIdAsync(id);
            if (dangerLevelDetails == null)
            {
                return View("Error");
            }
            _dangerLevelRepository.Delete(dangerLevelDetails);
            return RedirectToAction("Index");
        }
    }
}
