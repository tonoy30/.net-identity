﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var gradmaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "tonoy"),
                new Claim(ClaimTypes.Email, "tonoy.sust@gmail.com"),
                new Claim("Grandma.Says", "Very nice boi.")
            };
            var licenseClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Tonoy Akando"),
                new Claim(ClaimTypes.Email, "tonoy.sust@gmail.com"),
                new Claim("Driving License", "2016A1020"),
            };
            var grandmaIdentity = new ClaimsIdentity(gradmaClaims, "Grandma Identity");
            var licenseIdentity = new ClaimsIdentity(licenseClaims, "License Identity");

            var userPrincipal = new ClaimsPrincipal(new[] {grandmaIdentity, licenseIdentity});

            HttpContext.SignInAsync(userPrincipal);
            return RedirectToAction("Index");
        }
    }
}