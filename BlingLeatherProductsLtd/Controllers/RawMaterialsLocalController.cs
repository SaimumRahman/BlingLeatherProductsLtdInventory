using BlingLeatherProductsLtd.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BlingLeatherProductsLtd.Models;
using Microsoft.EntityFrameworkCore;

namespace BlingLeatherProductsLtd.Controllers
{
    public class RawMaterialsLocalController : Controller
    {
        private readonly ApplicationDBContext db;
        public RawMaterialsLocalController(ApplicationDBContext db)
        {
            this.db = db;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult RawMaterialsListLocal()
        {
            IEnumerable<RawMaterialsLocal> rawMaterialsLists = db.RawMaterialsLocal;
            return View(rawMaterialsLists);
        }


        //GET-CREATE
        [Authorize(Roles = "Admin")]
        public IActionResult PostRawMaterialsLocal()
        {

            return View();
        }
        //POST-CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostRawMaterialsLocal(RawMaterialsLocal raw)
        {
            db.RawMaterialsLocal.Add(raw);
            raw.BalancedQuantity = raw.RecievedQuantity;
            db.SaveChanges();
            return RedirectToAction("RawMaterialsListLocal");
        }
        //GET-EDIT
        [Authorize(Roles = "Admin")]
        public IActionResult EditRawMaterialslocal(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var raws = db.RawMaterialsLocal.Find(id);
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
        public IActionResult EditRawMaterialsLocal(RawMaterialsLocal raw)
        {
            raw.BalancedQuantity = raw.RecievedQuantity;
            db.RawMaterialsLocal.Update(raw);
            db.SaveChanges();
            return RedirectToAction("RawMaterialsListLocal");
        }
        //GET-DELETE

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var raws = db.RawMaterialsLocal.Find(id);
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
        public IActionResult DeletePost(int? id, RawMaterialsLocal raw)
        {
            db.RawMaterialsLocal.Remove(raw);
            db.SaveChanges();
            return RedirectToAction("RawMaterialsListLocal");
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> RawMaterialsListLocal(string searches)
        {
            ViewData["RawMaterialsListLocal"] = searches;
            var query = from x in db.RawMaterialsLocal select x;
            if (!String.IsNullOrEmpty(searches))
            {
                query = query.Where(x => x.HSCode.Contains(searches) || x.MaterialName.Contains(searches) || x.RMIDL.ToString().Contains(searches)
                || x.ArticleNumber.Contains(searches)
                );
            }
            return View(await query.AsNoTracking().ToListAsync());
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult RawMaterialsDetailsLocal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var querys = from x in db.RawMaterialsDetailsLocal select x;
                querys = querys.Where(x => x.RMIDL.Equals(id));
                IEnumerable<RawMaterialsDetailsLocal> details = querys;
                return View(details);
            }
        }


        [Authorize(Roles = "Admin")]
        public IActionResult PostRawMaterialDetailsLocal(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var det = db.RawMaterialsDetailsLocal.Find(id);
            return View(det.RMIDL);
        }

        //POST-CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostRawMaterialDetailsLocal(RawMaterialsDetailsLocal details)
        {
            RawMaterialsLocal mat = new();
            string iss = details.IssuedQuantity;
            int id = details.RMIDL;

            var querys = from x in db.RawMaterialsLocal select x;
            string re = querys.Where(x => x.RMIDL.Equals(id)).SingleOrDefault()?.BalancedQuantity;
            int res = int.Parse(re) - int.Parse(iss);
            mat.BalancedQuantity = res.ToString();

            var p = db.RawMaterialsLocal.Find(id);
            p.BalancedQuantity = res.ToString();
            db.RawMaterialsLocal.Update(p);
            details.BalanceQuantity = res.ToString();
            db.RawMaterialsDetailsLocal.Add(details);
            db.SaveChanges();
            return RedirectToAction("RawMaterialsListLocal");
        }
    }
}
