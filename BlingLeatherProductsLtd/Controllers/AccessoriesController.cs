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

        [Authorize(Roles = "Admin")]
        //GET-EDIT
        public IActionResult EditAccessoriesName(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var accesories = db.AccessoriesList.Find(id);
            if (accesories == null)
            {
                return NotFound();
            }
            return View(accesories);
        }


        [Authorize(Roles = "Admin")]
        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAccessoriesName(Accessories accessories)
        {
            
            db.AccessoriesList.Update(accessories);
            db.SaveChanges();
            return RedirectToAction("AccessoriesLists");
        }

        [Authorize(Roles = "Admin")]
        //GET-DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var accessories = db.AccessoriesList.Find(id);
            if (accessories == null)
            {
                return NotFound();
            }
            return View(accessories);
        }

        [Authorize(Roles = "Admin")]
        //POST-DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id, Accessories accessories)
        {
            db.AccessoriesList.Remove(accessories);
            db.SaveChanges();
            return RedirectToAction("AccessoriesLists");
        }


        [Authorize(Roles = "Admin,User")]
        public IActionResult RecievedDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var querys = from x in db.RecievedAccessories select x;
                querys = querys.Where(x => x.AID.Equals(id));
                IEnumerable<RecievedAccessoriess> details = querys;
                return View(details);
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult PostRecieved(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var det = db.RecievedAccessories.Find(id);
            return View(det.AID);
        }

        //POST-CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostRecieved(RecievedAccessoriess details)
        {
            Accessories mat = new();
            int iss = int.Parse(details.RecievedQnty);
            int id = details.AID;

            var querys = from x in db.AccessoriesList select x;
            string re = querys.Where(x => x.AID.Equals(id)).SingleOrDefault()?.ATotalQuantity;
            int res = int.Parse(re) + iss;
            mat.ATotalQuantity = res.ToString();

            var p = db.AccessoriesList.Find(id);
            p.ATotalQuantity = res.ToString();
            db.AccessoriesList.Update(p);

            db.RecievedAccessories.Add(details);
            db.SaveChanges();

            db.SaveChanges();
            return RedirectToAction("AccessoriesLists");
        }

        [Authorize(Roles = "Admin")]
       // GET-EDIT
        public IActionResult EditRecievedAccess(int? id)
        {
            if (id == null || id == 0)
            {
              return NotFound();
            }
            var chemical = db.RecievedAccessories.Find(id);
            if (chemical == null)
           {
              return NotFound();
            }
            return View(chemical);
       }


        [Authorize(Roles = "Admin")]
        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRecievedAccess(RecievedAccessoriess chemical)
        {

            db.RecievedAccessories.Update(chemical);
            db.SaveChanges();
            return RedirectToAction("AccessoriesLists");
        }


        [Authorize(Roles = "Admin,User")]
        public IActionResult RequisitionDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var querys = from x in db.RequisitionAccessories select x;
                querys = querys.Where(x => x.AID.Equals(id));
                IEnumerable<RequisitionAccessories> details = querys;
                return View(details);
            }
        }


        [Authorize(Roles = "Admin")]
        public IActionResult PostRequisition(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var det = db.RequisitionAccessories.Find(id);
            return View(det.AID);
        }

        //POST-CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostRequisition(RequisitionAccessories details)
        {
            Accessories mat = new();
            int iss = int.Parse(details.IssuedQnty);
            int id = details.AID;

            var querys = from x in db.AccessoriesList select x;
            string re = querys.Where(x => x.AID.Equals(id)).SingleOrDefault()?.ATotalQuantity;
            int res = int.Parse(re) - iss;
            mat.ATotalQuantity = res.ToString();

            var p = db.AccessoriesList.Find(id);
            p.ATotalQuantity = res.ToString();
            db.AccessoriesList.Update(p);

            db.RequisitionAccessories.Add(details);
            db.SaveChanges();

            db.SaveChanges();
            return RedirectToAction("AccessoriesLists");
        }


        [Authorize(Roles = "Admin")]
        // GET-EDIT
        public IActionResult EditRequistionAcc(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var chemical = db.RequisitionAccessories.Find(id);
            if (chemical == null)
            {
                return NotFound();
            }
            return View(chemical);
        }


        [Authorize(Roles = "Admin")]
        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRequistionAcc(RequisitionAccessories chemical)
        {

            db.RequisitionAccessories.Update(chemical);
            db.SaveChanges();
            return RedirectToAction("AccessoriesLists");
        }



    }


}
