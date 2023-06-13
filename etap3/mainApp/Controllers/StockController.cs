using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Platformy_Programowania_1.Services.Interfaces;
using System.Dynamic;

namespace Platformy_Programowania_1.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        private readonly ICompanyService _companyService;
        public StockController(ICompanyService companyService, IStockService stockService)
        {
            _stockService = stockService;
            _companyService = companyService;
        }
        public IActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Companies = _companyService.GetCompanies();
            mymodel.Stocks = _stockService.GetStocks();
            ViewBag.CompanyList = new SelectList(mymodel.Companies, "ID_firmy", "Nazwa_firmy");
            return View(mymodel);
        }
    }
}
