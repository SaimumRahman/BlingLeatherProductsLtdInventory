using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace BlingLeatherProductsLtd.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult Login(String username,String password)
        {
            if (string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password)) {

                return NotFound();
            }
            ClaimsIdentity identity = null;
            bool isAuthentication = false;

            if (username=="admin"&& password=="bismillah") {
                identity = new ClaimsIdentity(new[]{

                    new Claim(ClaimTypes.Name,username),
                    new Claim(ClaimTypes.Role,"Admin")

                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthentication = true;
            }
            if (username == "user" && password == "alhamdulillah")
            {
                identity = new ClaimsIdentity(new[]{

                    new Claim(ClaimTypes.Name,username),
                    new Claim(ClaimTypes.Role,"User")

                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthentication = true;
            }
            if (isAuthentication) {

                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }

            return NotFound();
        }
      
      
    }
}
