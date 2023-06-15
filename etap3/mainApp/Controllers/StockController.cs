using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Platformy_Programowania_1.Models;
using Platformy_Programowania_1.Services.Interfaces;
using System.Dynamic;

namespace Platformy_Programowania_1.Controllers
{
    public class StockController : Controller
    {
        private readonly IDailyService _dailyService;
        private readonly IYearlyService _yearlyService;
        private readonly ICompanyService _companyService;
        public StockController(ICompanyService companyService, IDailyService dailyService, IYearlyService yearlyService)
        {
            _dailyService = dailyService;
            _yearlyService = yearlyService; 
            _companyService = companyService;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _companyService.GetCompanies());
        }

        [HttpPost]
        public async Task<IActionResult> GetData(int ID_firmy)
        {
            var dailyDatas = await _dailyService.GetDailysByCompanyId(ID_firmy);
            var yearlyDatas = await _yearlyService.GetYearlysByCompanyId(ID_firmy);
            var company = _companyService.GetCompanyById(ID_firmy);
            string dailyDatasJson = JsonConvert.SerializeObject(dailyDatas);
            string yearlyDatasJson = JsonConvert.SerializeObject(yearlyDatas);
            TempData["DailyData"] = dailyDatasJson;
            TempData["YearlyData"] = yearlyDatasJson;
            TempData["Title"] = company.Nazwa_firmy;
            return RedirectToAction("Index");
        }
    }
}
