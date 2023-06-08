using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Platformy_Programowania_1.Models;

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
    }
}
