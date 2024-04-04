using FinalProject.Interfaces;
using FinalProject.Models;
using FinalProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class LineOfBusinessController : Controller
    {
        private readonly ILineOfBusinessRepository _lineOfBusinessRepository;

        public LineOfBusinessController(ILineOfBusinessRepository lineOfBusinessRepository)
        {
            _lineOfBusinessRepository = lineOfBusinessRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<LineOfBusiness> lineOfBusinesses = await _lineOfBusinessRepository.GetAll();
            return View(lineOfBusinesses);
        }
        public async Task<IActionResult> Details(int id)
        {
            LineOfBusiness role = await _lineOfBusinessRepository.GetByIdAsync(id);
            return View(role);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLineOfBuisnessViewModel lineVM)
        {
            if (ModelState.IsValid)
            {
                LineOfBusiness lineOfBusiness = new LineOfBusiness { title = lineVM.title};
                _lineOfBusinessRepository.Add(lineOfBusiness);
                return RedirectToAction("Index");
            }
            return View(lineVM);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            LineOfBusiness lineOfBusiness = await _lineOfBusinessRepository.GetByIdAsync(id);
            if (lineOfBusiness == null)
            {
                return View("Error");
            }
            EditLineOfBuisnessViewModel lineVm = new EditLineOfBuisnessViewModel
            {
                id = lineOfBusiness.id,
                title = lineOfBusiness.title
            };
            return View(lineVm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditLineOfBuisnessViewModel lineVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed Edit");
                return View("Edit", lineVM);
            }
            LineOfBusiness lineOfBusiness = new LineOfBusiness
            {
                id = lineVM.id,
                title=lineVM.title
            };
            _lineOfBusinessRepository.Update(lineOfBusiness);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            LineOfBusiness lineDetails = await _lineOfBusinessRepository.GetByIdAsync(id);
            if (lineDetails == null)
            {
                return View("Error");
            }
            return View(lineDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            LineOfBusiness lineDetails = await _lineOfBusinessRepository.GetByIdAsync(id);
            if (lineDetails  == null)
            {
                return View("Error");
            }
            _lineOfBusinessRepository.Delete(lineDetails);
            return RedirectToAction("Index");
        }
    }
}
