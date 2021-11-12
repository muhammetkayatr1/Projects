using BL.Repository;
using BL.Repository.ConcreateRepositories;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SCPDashboard.Controllers
{
    public class LoginController : Controller
    {
        readonly UserRepository _userRepository;
        public LoginController(IRepository<User> userRepository)
        {
            _userRepository = (UserRepository)userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(string userName, string password)
        {
            var x = _userRepository.GetWhere(i => i.Email == userName && i.Password == password);
            if (x .Count > 0)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, userName)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Log");
            }
            ViewBag.Error = "Kullanıcı Bulunamadı";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
