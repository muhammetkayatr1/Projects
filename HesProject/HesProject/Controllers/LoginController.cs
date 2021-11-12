﻿using HesProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HesProject.Controllers
{
    public class LoginController : Controller
    {
        string Baseurl = "https://hesservis.turkiye.gov.tr/services/g2g/saglik/hes";

        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login(string Error)
        {
            if (Error != null)
            {
                ViewBag.Error = "Email veya Şifre Hatalı";
            }     
            return View();
        }
        public async Task<IActionResult> Login(string userName, string password)
        {
            var userAdmin = _context.User.FirstOrDefault(i => i.UserName == userName && i.Password == password && i.Department == "admin");
            var userIk = _context.User.FirstOrDefault(i => i.UserName == userName && i.Password == password && i.Department == "ik");
            var userSecurity = _context.User.FirstOrDefault(i => i.UserName == userName && i.Password == password && i.Department == "security");
            var userInfirmary = _context.User.FirstOrDefault(i => i.UserName == userName && i.Password == password && i.Department == "infirmary");
            var userStudentAffairs = _context.User.FirstOrDefault(i => i.UserName == userName && i.Password == password && i.Department == "studentaffairs");
            if (userIk != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, userName)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "HumanResources");
            }
            else if (userAdmin != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, userName)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Admin");
            }
            else if (userSecurity != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, userName)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Security");
            }
            else if (userInfirmary != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, userName)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Infirmary");
            }
            else if (userStudentAffairs != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, userName)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "StudentAffairs");
            }
            return RedirectToAction("Login", "Login", new {Error = "NotFound" });
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}