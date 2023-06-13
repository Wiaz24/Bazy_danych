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
            //ViewBag.DailyData = TempData["DailyData"];
            //ViewBag.YearlyData = TempData["YearlyData"];
            ////if (ViewBag.DailyData != null) Console.WriteLine(ViewBag.DailyData);
            //ViewBag.YearlyData = JsonConvert.SerializeObject(TempData["YearlyData"]);
            return View(await _companyService.GetCompanies());
        }

        [HttpPost]
        public async Task<IActionResult> GetData(int idFirmy)
        {
            var dailyDatas = await _dailyService.GetDailysByCompanyId(idFirmy);
            var yearlyDatas = await _yearlyService.GetYearlysByCompanyId(idFirmy);
            string dailyDatasJson = JsonConvert.SerializeObject(dailyDatas);
            string yearlyDatasJson = JsonConvert.SerializeObject(yearlyDatas);
            TempData["DailyData"] = dailyDatasJson;
            TempData["YearlyData"] = yearlyDatasJson;
            return RedirectToAction("Index");
        }
    }
}
