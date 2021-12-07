using BlingLeatherProductsLtd.Data;
using BlingLeatherProductsLtd.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlingLeatherProductsLtd.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly ApplicationDBContext db;

        public AccessoriesController(ApplicationDBContext db)
        {
            this.db = db;
        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult AccessoriesLists()
        {
            IEnumerable<Accessories> accessoriesLists = db.AccessoriesList;
            return View(accessoriesLists);
        }

        //GET-CREATE
        [Authorize(Roles = "Admin")]
        public IActionResult PostAccessories()
        {

            return View();
        }


        //POST-CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostAccessories(Accessories accessories)
        {
            db.AccessoriesList.Add(accessories);
            db.SaveChanges();
            return RedirectToAction("AccessoriesLists");
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> AccessoriesLists(string searches)
        {
            ViewData["AccessoriesLists"] = searches;
            var query = from x in db.AccessoriesList select x;
            if (!String.IsNullOrEmpty(searches))
            {
                query = query.Where(x => x.AID.ToString().Contains(searches) || x.AName.Contains(searches));
            }
            return View(await query.AsNoTracking().ToListAsync());
        }
    }
}
