using KariyerMerkezi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.SignalR;
using KariyerMerkezi.Hubs;
using Microsoft.Extensions.DependencyInjection;

namespace KariyerMerkezi.Controllers
{
    public class LoginController : Controller
    {
        private readonly StudentContext _context;

        public LoginController(StudentContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(string userName, string password)
        {
            var userAdmin = _context.Kullanici.FirstOrDefault(i => i.KullaniciAdi == userName && i.Sifre == password);
            if (userAdmin != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, userName)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Home", "Admin");
            }
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

