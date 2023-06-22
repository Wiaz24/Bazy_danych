using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bazy_danych.Models;
using Bazy_danych.Services.Interfaces;

namespace Bazy_danych.Controllers;

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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
