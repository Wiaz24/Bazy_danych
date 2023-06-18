using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Platformy_Programowania_1.Models;
using System.Security.Claims;

namespace Platformy_Programowania_1.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UpgradeAccount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register registerData)
        {
            if (!ModelState.IsValid) 
            {
                return View(registerData);
            }

            var newUser = new User
            {
                Email = registerData.Email,
                UserName = registerData.FirstName,
                PhoneNumber = registerData.PhoneNumber
            };

            await _userManager.CreateAsync(newUser, registerData.Password);
            await _userManager.AddToRoleAsync(newUser, "StdUser");
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login loginData)
        {
            if (!ModelState.IsValid)
            {
                return View(loginData);
            }
            var user = await _userManager.FindByEmailAsync(loginData.Email); //znaleziono poprawnie, jeśli nie to null
            //if (!ModelState.IsValid)
            //{
            //    return View(loginData);
            //}
            if (user == null)
            {
                ViewBag.IncorrectEmail = true;
                return View(loginData);
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName!, loginData.Password, true, false);
            if (!result.Succeeded)
            {
                ViewBag.IncorrectPassword = true;
                return View(loginData);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> GoPremium()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.FindByIdAsync(userId).Result;

            var currentRoles = await _userManager.GetRolesAsync(user);
            
            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            // Dodaj nową rolę użytkownikowi
            await _userManager.AddToRoleAsync(user, "PremiumUser");
            return RedirectToAction("Index", "Home");
        }
    }
}
