using FinalProject.Interfaces;
using FinalProject.Models;
using FinalProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILineOfBusinessRepository _lineOfBusinessRepository;
        public CompanyController(ICompanyRepository companyRepository, ILineOfBusinessRepository lineOfBusinessRepository)
        {
            _companyRepository = companyRepository;
            _lineOfBusinessRepository = lineOfBusinessRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Company> companies = await _companyRepository.GetAll();
            return View(companies);
        }
        public async Task<IActionResult> Details(int id)
        {
            Company company = await _companyRepository.GetByIdAsync(id);
            return View(company);
        }
        public async Task<IActionResult> Create()
        {
            CreateCompanyViewModel viewModel = new CreateCompanyViewModel();
            viewModel.lines = await _lineOfBusinessRepository.GetAll();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyViewModel companyVM)
        {
            if (ModelState.IsValid)
            {
                LineOfBusiness myLine = await _lineOfBusinessRepository.GetByIdAsync(companyVM.businessId);
                Company company = new Company();
                company.businessId = company.businessId;
                company.lineOfBusiness = myLine;
                company.headquarters = companyVM.headquarters;
                company.name = companyVM.name;
                _companyRepository.Add(company);
                return RedirectToAction("Index");
            }
            return View(companyVM);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Company company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                return View("Error");
            }

            EditCompanyViewModel companyVM = new EditCompanyViewModel
            {
                id = company.id,
                name = company.name,
                headquarters = company.headquarters,
                businessId = company.businessId
            };
            companyVM.lines = await _lineOfBusinessRepository.GetAll();
            return View(companyVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCompanyViewModel companyVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed Edit");
                return View("Edit", companyVM);
            }
            LineOfBusiness myLine = await _lineOfBusinessRepository.GetByIdAsync(companyVM.businessId);
            Company company = new Company
            {
                id = companyVM.id,
                name = companyVM.name,
                headquarters = companyVM.headquarters,
                lineOfBusiness = myLine,
                businessId = companyVM.businessId

            };
            _companyRepository.Update(company);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Company companyDetails = await _companyRepository.GetByIdAsync(id);
            if (companyDetails == null)
            {
                return View("Error");
            }
            return View(companyDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            Company companyDetails = await _companyRepository.GetByIdAsync(id);
            if (companyDetails == null)
            {
                return View("Error");
            }
            _companyRepository.Delete(companyDetails);
            return RedirectToAction("Index");
        }
    }
}
