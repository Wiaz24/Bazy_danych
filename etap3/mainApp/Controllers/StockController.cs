using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Platformy_Programowania_1.Models;
using Platformy_Programowania_1.Services.Interfaces;
using System.Dynamic;
using System.Linq;

namespace Platformy_Programowania_1.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IDailyService _dailyService;
        private readonly IYearlyService _yearlyService;
        private readonly ICompanyService _companyService;
        private readonly IOrderService _orderService;
        public StockController( ICompanyService companyService, 
                                IDailyService dailyService, 
                                IYearlyService yearlyService,
                                IOrderService orderService,
                                UserManager<User> userManager)
        {
            _userManager = userManager;
            _dailyService = dailyService;
            _yearlyService = yearlyService; 
            _companyService = companyService;
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _companyService.GetCompanies());
        }

        [HttpPost]
        public async Task<IActionResult> GetData(int ID_firmy)
        {
            //await _dailyService.New_Daily(ID_firmy);
            var dailyDatas = await _dailyService.GetDailysAsYearlys(ID_firmy);
            var yearlyDatas = await _yearlyService.GetYearlysByCompanyId(ID_firmy);
            var company = _companyService.GetCompanyById(ID_firmy);
            string dailyDatasJson = JsonConvert.SerializeObject(dailyDatas);
            string yearlyDatasJson = JsonConvert.SerializeObject(yearlyDatas);
            TempData["DailyData"] = dailyDatasJson;
            TempData["YearlyData"] = yearlyDatasJson;
            TempData["Title"] = company.Nazwa_firmy;
            TempData["CompanyID"] = ID_firmy;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Buy(int amount)
        {
            int CompanyID = (int)TempData["CompanyID"];
            List<DailyData> data = (List<DailyData>)await _dailyService.GetDailysByCompanyId(CompanyID);
            var price = data.Last().Cena;
            var user = await _userManager.GetUserAsync(User);
            if (amount*price > user.Balance)
            {
                TempData["NotEnoughCash"] = true;
                return RedirectToAction("Index");
            }
            Order order = new Order();
            order.Ilosc= amount;
            order.Cena= price;
            order.ID_uzytkownika = user.Id;
            order.ID_firmy = CompanyID;
            await _orderService.CreateOrder(order);
            user.Balance -= amount*price;
            var result = await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> Sell(int amount)
        {
            int CompanyID = (int)TempData["CompanyID"];
            List<DailyData> dailys = (List<DailyData>)await _dailyService.GetDailysByCompanyId(CompanyID);
            var price = dailys.Last().Cena;
            var user = await _userManager.GetUserAsync(User);

            List<Order> orders = await _orderService.GetOrdersByUserId(user.Id);
            var companyOrders = orders.Where(x => x.ID_firmy == CompanyID);
            var numStocks = orders.Sum(x => x.Ilosc);
            if (amount > numStocks)
            {
                TempData["NotEnoughStocks"] = true;
                return RedirectToAction("Index");
            }
            Order order = new Order();
            order.Ilosc = -1*amount;
            order.Cena = price;
            order.ID_uzytkownika = user.Id;
            order.ID_firmy = CompanyID;
            await _orderService.CreateOrder(order);
            user.Balance += amount * price;
            var result = await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Account");
        }
    }
}
