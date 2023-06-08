using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using Platformy_Programowania_1.Controllers;
using Platformy_Programowania_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatformy
{
    public class AccountControllerTests
    {
        private readonly Mock<UserManager<User>> _mockUserManager;
        private readonly Mock<SignInManager<User>> _mockSignInManager;
        private readonly AccountController _controller;

        public AccountControllerTests()
        {
            _mockUserManager = new Mock<UserManager<User>>
                (Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            _mockSignInManager = new Mock<SignInManager<User>>(_mockUserManager.Object,
                                                              Mock.Of<IHttpContextAccessor>(),
                                                              Mock.Of<IUserClaimsPrincipalFactory<User>>(),
                                                              null, null, null, null);
            _controller = new AccountController(_mockUserManager.Object, _mockSignInManager.Object);
        }
        [Fact]
        public async Task Login_WhenEmailEmpty_ShouldRedirect()
        {
            var incorrectLogin = new Login
            {
                Email = String.Empty,
                Password = "Testo123"
            };

            var result = await _controller.Login(incorrectLogin);

            // Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = (ViewResult)result;
            Assert.Same(incorrectLogin, viewResult.Model);
        }

        [Fact]
        public async Task Login_WhenPasswordEmpty_ShouldRedirect()
        {
            var incorrectLogin = new Login
            {
                Email = "testo@wp.pl",
                Password = String.Empty
            };
            var result = await _controller.Login(incorrectLogin);

            // Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = (ViewResult)result;
            Assert.Same(incorrectLogin, viewResult.Model);
        }
        [Fact]
        public async Task Login_WhenDataCorrect_ShouldSignIn()
        {
            var correctLogin = new Login
            {
                Email = "testo@wp.pl",
                Password = "Testo123"
            };
            var correctUser = new User
            {
                UserName = "Hub",
                Email = "testo@wp.pl"
            };

            //jeżeli wywoła się metodę FindByEmailAsync z poprawnymi danymi to powinien zostać zwrócony rzeczywisty użytkownik
            _mockUserManager.Setup(u => u.FindByEmailAsync(correctLogin.Email)).ReturnsAsync(correctUser);

            _mockSignInManager.Setup(s => s.PasswordSignInAsync(correctUser.UserName, correctLogin.Password, true, false))
                              .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            // Act
            var result = await _controller.Login(correctLogin);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Home", redirectResult.ControllerName);
        }
        [Fact]
        public async Task Login_WhenEmailIncorrect_ShouldReturnView_WithError()
        {
            var incorrectLogin = new Login
            {
                Email = "notregistered@wp.pl",
                Password = "Testo123"
            };


            var correctUser = new User
            {
                UserName = "Hub",
                Email = "testo@wp.pl"
            };

            _mockUserManager.Setup(u => u.FindByEmailAsync(incorrectLogin.Email)).ReturnsAsync((User)null);

            // Act
            var result = await _controller.Login(incorrectLogin);

            // Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = (ViewResult)result;
            Assert.Same(incorrectLogin, viewResult.Model);
            Assert.True(_controller.ViewBag.IncorrectEmail);
        }
        [Fact]
        public async Task Login_WhenPasswordIncorrect_ShouldReturnView_WithError()
        {
            var incorrectLogin = new Login
            {
                Email = "testo@wp.pl",
                Password = "IncorrectPassword"
            };

            var correctUser = new User
            {
                UserName = "Hub",
                Email = "testo@wp.pl"
            };

            _mockUserManager.Setup(u => u.FindByEmailAsync(incorrectLogin.Email)).ReturnsAsync(correctUser);

            _mockSignInManager.Setup(s => s.PasswordSignInAsync(correctUser.UserName, incorrectLogin.Password, true, false))
                              .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);
            // Act
            var result = await _controller.Login(incorrectLogin);

            // Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = (ViewResult)result;
            Assert.Same(incorrectLogin, viewResult.Model);
            Assert.True(_controller.ViewBag.IncorrectPassword);
        }
        [Fact]
        public async Task Register_WhenEmailEmpty_ShouldReturnView()
        {
            _controller.ViewData.ModelState.Clear();
            
            var incorrectRegister = new Register
            {
                FirstName = "John",
                LastName = "Smith",
                Email = string.Empty,
                Password = "MyPasswd123#",
                PhoneNumber = "123456789"
            };
            _controller.ModelState.AddModelError("Email", "Email is empty");
            // Act
            var result = await _controller.Register(incorrectRegister);
            
            // Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = (ViewResult)result;
            Assert.Same(incorrectRegister, viewResult.Model);
        }
        [Fact]
        public async Task Register_WhenCredentialsCorrect_ShouldRedirect()
        {
            _controller.ViewData.ModelState.Clear();

            var correctRegister = new Register
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "smith@wp.pl",
                Password = "MyPasswd123#",
                PhoneNumber = "123456789"
            };
            // Act
            var result = await _controller.Register(correctRegister);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Home", redirectResult.ControllerName);
        }
        [Fact]
        public async Task Logout_Succesfull()
        {
            _mockSignInManager.Setup(u => u.SignOutAsync());
            var result = await _controller.Logout();
            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Home", redirectResult.ControllerName);
        }
    }
}
