using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Platformy_Programowania_1.Models;
using System.Collections.Generic;
using Platformy_Programowania_1.Services.Interfaces;
using Platformy_Programowania_1.Services;

namespace Platformy_Programowania_1.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        // GET: CompanyController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _companyService.GetCompanies());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Company company)
        {
            if (ModelState.IsValid)
                await _companyService.CreateCompany(company);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.DeleteCompany(id);
            return RedirectToAction("Index");
        }

    }
}
