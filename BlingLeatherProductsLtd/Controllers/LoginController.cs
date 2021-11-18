using BlingLeatherProductsLtd.Data;
using BlingLeatherProductsLtd.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace BlingLeatherProductsLtd.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDBContext db;

        public LoginController(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IActionResult RedirectToActon { get; private set; }

        public IActionResult StoreLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StoreLogin(StoreLogin objUser)
        {
            if (ModelState.IsValid)
            {

                {
                    var obj = db.StoreLogins.Where(a => a.Email.Equals(objUser.Email) && a.Passwords.Equals(objUser.Passwords)).FirstOrDefault();
                    if (obj != null)
                    {
                        HttpContext.Session.SetString("log", obj.Email);
                        
                        return this.RedirectToAction("Index", "Home");
                    }
                }
            }
            return RedirectToAction("StoreLogin");
        }
      
    }
}
