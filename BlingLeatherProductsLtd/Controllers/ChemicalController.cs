using BlingLeatherProductsLtd.Data;
using BlingLeatherProductsLtd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace BlingLeatherProductsLtd.Controllers
{
    public class ChemicalController : Controller
    {
        private readonly ApplicationDBContext db;

        public ChemicalController(ApplicationDBContext db)
        {
            this.db = db;
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult ChemicalMaterialsLists()
        {

             IEnumerable<ChemicalMaterials> chemicalMaterials = db.ChemicalMaterials;
             return View(chemicalMaterials);
               
        }


        //GET-CREATE
        [Authorize(Roles = "Admin")]
        public IActionResult PostChemicalMaterialsLists()
        {

            return View();
        }


        //POST-CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostChemicalMaterialsLists(ChemicalMaterials chemical)
        {
            db.ChemicalMaterials.Add(chemical);
            chemical.BalancedQuantity = chemical.RecievedQuantity;
            db.SaveChanges();
            return RedirectToAction("ChemicalMaterialsLists");
        }


        [Authorize(Roles = "Admin")]
        //GET-EDIT
        public IActionResult EditChemicalMaterials(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var chemical = db.ChemicalMaterials.Find(id);
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
        public IActionResult EditChemicalMaterials(ChemicalMaterials chemical)
        {
            chemical.BalancedQuantity = chemical.RecievedQuantity;
            db.ChemicalMaterials.Update(chemical);
            db.SaveChanges();
            return RedirectToAction("ChemicalMaterialsLists");
        }


        [Authorize(Roles = "Admin")]
        //GET-DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var chemical = db.ChemicalMaterials.Find(id);
            if (chemical == null)
            {
                return NotFound();
            }
            return View(chemical);
        }


        [Authorize(Roles = "Admin")]
        //POST-DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id, ChemicalMaterials chemical)
        {
            db.ChemicalMaterials.Remove(chemical);
            db.SaveChanges();
            return RedirectToAction("ChemicalMaterialsLists");
        }


        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> ChemicalMaterialsLists(string searches)
        {
            ViewData["ChemicalMaterialsLists"] = searches;
            var query = from x in db.ChemicalMaterials select x;
            if (!String.IsNullOrEmpty(searches))
            {
                query = query.Where(x => x.HSCode.Contains(searches) || x.MaterialName.Contains(searches) || x.CMID.ToString().Contains(searches));
            }
            return View(await query.AsNoTracking().ToListAsync());
        }


        [Authorize(Roles = "Admin,User")]
        public IActionResult ChemicalMaterialsDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var querys = from x in db.ChemicalMaterialsDetails select x;
                querys = querys.Where(x => x.CMID.Equals(id));
                IEnumerable<ChemicalMaterialsDetails> details = querys;
                return View(details);
            }
        }



        [Authorize(Roles = "Admin")]
        public IActionResult PostChemicalMaterialDetails(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var det = db.ChemicalMaterialsDetails.Find(id);
            return View(det.CMID);
        }


        [Authorize(Roles = "Admin")]
        //POST-CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostChemicalMaterialDetails(ChemicalMaterialsDetails details)
        {
            ChemicalMaterials mat = new();
            string iss = details.IssuedQuantity;
            int id = details.CMID;

            var querys = from x in db.ChemicalMaterials select x;
            string re = querys.Where(x => x.CMID.Equals(id)).SingleOrDefault()?.BalancedQuantity;
            float res = float.Parse(re) - float.Parse(iss);
            mat.BalancedQuantity = res.ToString();

            var p = db.ChemicalMaterials.Find(id);
            p.BalancedQuantity = res.ToString();
            db.ChemicalMaterials.Update(p);
            details.BalanceQuantity = res.ToString();
            db.ChemicalMaterialsDetails.Add(details);
            db.SaveChanges();
            return RedirectToAction("ChemicalMaterialsLists");
        }


        //[Authorize(Roles = "Admin")]
        ////GET-EDIT
        //public IActionResult EditChemicalMaterialsDetails(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var chemical = db.ChemicalMaterialsDetails.Find(id);
        //    if (chemical == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(chemical);
        //}


        [Authorize(Roles = "Admin")]
        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditChemicalMaterialsDetails(ChemicalMaterialsDetails chemical)
        {
            
            db.ChemicalMaterialsDetails.Update(chemical);
            db.SaveChanges();
            return RedirectToAction("ChemicalMaterialsLists");
        }
    }
   

}
