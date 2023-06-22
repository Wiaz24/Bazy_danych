using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bazy_danych.Models;
using System.Collections.Generic;
using Bazy_danych.Services.Interfaces;
using Bazy_danych.Services;

namespace Bazy_danych.Controllers
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
