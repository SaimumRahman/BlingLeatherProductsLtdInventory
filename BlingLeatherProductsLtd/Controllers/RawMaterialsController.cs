using BlingLeatherProductsLtd.Data;
using BlingLeatherProductsLtd.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles ="Admin")]
        public IActionResult RawMaterialsList()
        {
            IEnumerable<RawMaterials> rawMaterialsLists = db.RawMaterials;  
            return View(rawMaterialsLists);
        }


        //GET-CREATE
        [Authorize(Roles = "Admin")]
        public IActionResult PostRawMaterials()
        {
         
            return View();
        }
        //POST-CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostRawMaterials(RawMaterials raw)
        {
            db.RawMaterials.Add(raw);
            raw.BalancedQuantity = raw.RecievedQuantity;
            db.SaveChanges();
            return RedirectToAction("RawMaterialsList");
        }
        //GET-EDIT
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRawMaterials(RawMaterials raw)
        {
            raw.BalancedQuantity = raw.RecievedQuantity;
            db.RawMaterials.Update(raw);
            db.SaveChanges();
            return RedirectToAction("RawMaterialsList");
        }
        //GET-DELETE

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id,RawMaterials raw)
        {
            db.RawMaterials.Remove(raw);
            db.SaveChanges();
            return RedirectToAction("RawMaterialsList");
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> RawMaterialsList(string searches)
        {
            ViewData["RawMaterialsList"] = searches;
            var query = from x in db.RawMaterials select x;
            if (!String.IsNullOrEmpty(searches))
            {
                query = query.Where(x => x.HSCode.Contains(searches) || x.MaterialName.Contains(searches) || x.RMID.ToString().Contains(searches)
                || x.ArticleNumber.Contains(searches)
                );
            }
            return View(await query.AsNoTracking().ToListAsync());
        }

        [Authorize(Roles = "Admin,User")]
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
   

        [Authorize(Roles = "Admin")]
        public IActionResult PostRawMaterialDetails(int? id)
        {
            if (id == null) {
                return View();
            }
            var det = db.RawMaterialsDetails.Find(id);
            return View(det.RMID);
        }

        //POST-CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostRawMaterialDetails(RawMaterialsDetails details)
        {
            RawMaterials mat = new();
            string iss = details.IssuedQuantity;
            int id = details.RMID;
           
            var querys = from x in db.RawMaterials select x;
            string re = querys.Where(x => x.RMID.Equals(id)).SingleOrDefault()?.BalancedQuantity;
            int res = int.Parse(re) - int.Parse(iss);
            mat.BalancedQuantity = res.ToString();

            var p = db.RawMaterials.Find(id);
            p.BalancedQuantity = res.ToString();
            db.RawMaterials.Update(p);
            details.BalanceQuantity = res.ToString();
            db.RawMaterialsDetails.Add(details);
            db.SaveChanges();
            return RedirectToAction("RawMaterialsList");
        }
    }
}
