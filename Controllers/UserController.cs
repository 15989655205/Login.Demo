using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Login.Demo.Domain.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Login.Demo.Controllers
{
    public class UserController : Controller
    {  
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login( UserLoginRequest user)
        {
            if (user.Account == "admin" && user.password == "admin")
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,user.Account)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            }
            else
            {
                RedirectToAction(nameof(Login));
            }
            return Redirect(user.ReturnUrl);
        }
    }

    public class UserLoginRequest:User
    {
        public string ReturnUrl { get; set; }
    }
}