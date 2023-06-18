using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Platformy_Programowania_1.Models;
using Platformy_Programowania_1.Services.Interfaces;

namespace Platformy_Programowania_1.Controllers;

public class HomeController : Controller
{
    private readonly IUserService _userService;
    public HomeController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.isHome = true;
        return View();
    }
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
