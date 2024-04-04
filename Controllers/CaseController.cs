using FinalProject.Interfaces;
using FinalProject.Models;
using FinalProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class CaseController : Controller
    {
        private readonly ICaseRepository _caseRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IDangerLevelRepository _levelRepository;
        public CaseController(ICaseRepository caseRepository, ICompanyRepository companyRepository, IDangerLevelRepository dangerLevelRepository)
        {
            _caseRepository = caseRepository;
            _companyRepository = companyRepository;
            _levelRepository = dangerLevelRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Case> cases = await _caseRepository.GetAll();
            return View(cases);
        }
        public async Task<IActionResult> Details(int id)
        {
            Case myCase = await _caseRepository.GetByIdAsync(id);
            return View(myCase);
        }
        public async Task<IActionResult> Create()
        {
            CreateCaseViewModel viewModel = new CreateCaseViewModel();
            viewModel.companies = await _companyRepository.GetAll();
            viewModel.dangerLevels = await _levelRepository.GetAll();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCaseViewModel caseVm)
        {
            if (ModelState.IsValid)
            {
                Company company = await _companyRepository.GetByIdAsync(caseVm.companyId);
                DangerLevel dangerLevel = await _levelRepository.GetByIdAsync(caseVm.dangerId);
                Case myCase = new Case();
                myCase.companyId = caseVm.companyId;
                myCase.company = company;
                myCase.levelId = caseVm.dangerId;
                myCase.level = dangerLevel;
                myCase.requiredDate = caseVm.reqiredDate;
                myCase.assedHours = caseVm.assedHours;
                _caseRepository.Add(myCase);
                return RedirectToAction("Index");
            }
            return View(caseVm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Case myCase = await _caseRepository.GetByIdAsync(id);
            if (myCase == null)
            {
                return View("Error");
            }

            EditCaseViewModel caseVM = new EditCaseViewModel
            {
                id = myCase.id,
                reqiredDate = myCase.requiredDate,
                dangerId = myCase.levelId,
                companyId = myCase.companyId,
                assedHours = myCase.assedHours
            };
            caseVM.companies = await _companyRepository.GetAll();
            caseVM.dangerLevels = await _levelRepository.GetAll();
            return View(caseVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCaseViewModel caseVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed Edit");
                return View("Edit", caseVM);
            }
            Company company = await _companyRepository.GetByIdAsync(caseVM.companyId);
            DangerLevel dangerLevel = await _levelRepository.GetByIdAsync(caseVM.dangerId);
            Case myCase = new Case
            {
                id = caseVM.id,
                requiredDate = caseVM.reqiredDate,
                levelId = caseVM.dangerId,
                level = dangerLevel,
                company = company,
                companyId = caseVM.companyId,
                assedHours = caseVM.assedHours
            };
            _caseRepository.Update(myCase);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Case caseDetails = await _caseRepository.GetByIdAsync(id);
            if (caseDetails == null)
            {
                return View("Error");
            }
            return View(caseDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            Case caseDetails = await _caseRepository.GetByIdAsync(id);
            if (caseDetails == null)
            {
                return View("Error");
            }
            _caseRepository.Delete(caseDetails);
            return RedirectToAction("Index");
        }
    }
}
