using BlingLeatherProductsLtd.Data;
using BlingLeatherProductsLtd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlingLeatherProductsLtd.Controllers
{
    public class RawMaterialsController : Controller
    {
        private readonly ApplicationDBContext db;

        public RawMaterialsController(ApplicationDBContext db)
        {
            this.db = db;
        }
        public IActionResult RawMaterialsList()
        {
            IEnumerable<RawMaterials> rawMaterialsLists = db.RawMaterials;  
            return View(rawMaterialsLists);
        }
        //GET-CREATE
        public IActionResult PostRawMaterials()
        {
         
            return View();
        }
        //POST-CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostRawMaterials(RawMaterials raw)
        {
            db.RawMaterials.Add(raw);
            db.SaveChanges();
            return RedirectToAction("RawMaterialsList");
        }
        //GET-EDIT
        public IActionResult EditRawMaterials(int? id)
        {
            if(id==null|| id == 0) 
            {
                return NotFound();
            }
            var raws = db.RawMaterials.Find(id);
            if (raws == null)
            {
                return NotFound();
            }
            return View(raws);
        }
        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRawMaterials(RawMaterials raw)
        {
            db.RawMaterials.Update(raw);
            db.SaveChanges();
            return RedirectToAction("RawMaterialsList");
        }
        //GET-DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var raws = db.RawMaterials.Find(id);
            if (raws == null)
            {
                return NotFound();
            }
            return View(raws);
        }
        //POST-DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id,RawMaterials raw)
        {
            db.RawMaterials.Remove(raw);
            db.SaveChanges();
            return RedirectToAction("RawMaterialsList");
        }

        [HttpGet]
        public async Task<IActionResult> RawMaterialsList(string searches)
        {
            ViewData["RawMaterialsList"] = searches;
            var query = from x in db.RawMaterials select x;
            if (!String.IsNullOrEmpty(searches))
            {
                query = query.Where(x => x.HSCode.Contains(searches));
            }
            return View(await query.AsNoTracking().ToListAsync());
        }

        public IActionResult RawMaterialsDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var querys = from x in db.RawMaterialsDetails select x;
                querys = querys.Where(x => x.RMID.Equals(id));
                IEnumerable<RawMaterialsDetails> details = querys;
                return View(details);
            }   
        }

        public IActionResult PostRawMaterialDetails()
        {
            return View();
        }
        //POST-CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostRawMaterialDetails(RawMaterialsDetails details)
        {
            db.RawMaterialsDetails.Add(details);
            db.SaveChanges();
            return RedirectToAction("RawMaterialsList");
        }
    }
}
