using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using Progeaiiit.Models;
using BO.Auth;

namespace Progeaiiit.Controllers
{
    public class POIsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: POIs
        public ActionResult Index()
        {
            return View(db.POIs.ToList());
        }

        // GET: POIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POI pOI = db.POIs.Find(id);
            if (pOI == null)
            {
                return HttpNotFound();
            }
            return View(pOI);
        }

        // GET: POIs/Create
        public ActionResult Create()
        {
            var vm = new POIVM();
            vm.Categories = db.Categories.ToList();
            return View(vm);
        }

        // POST: POIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(POIVM vm)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    int idSelected = vm.IdSelectedCategory;
                    Category newCategory = new Category();
                    newCategory = db.Categories.SingleOrDefault(c => c.Id == idSelected);
                    vm.POI.Category = newCategory;
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Exception : {0}", e);
                }

                db.POIs.Add(vm.POI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: POIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POI pOI = db.POIs.Find(id);
            if (pOI == null)
            {
                return HttpNotFound();
            }

            var vm = new POIVM();
            vm.Categories = db.Categories.ToList();
            vm.POI = pOI;
            
            if (pOI.Category != null)
            {
                vm.IdSelectedCategory = pOI.Category.Id;
            }                 
            
            return View(vm);
        }

        // POST: POIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(POIVM vm)
        {
            Category category = new Category();
            if (ModelState.IsValid)
            {
                var poi = db.POIs.Include(p => p.Category).FirstOrDefault(i => i.Id == vm.POI.Id);
                poi.CooX = vm.POI.CooX;
                poi.CooY = vm.POI.CooY;
                poi.Name = vm.POI.Name;
                poi.Race = vm.POI.Race;
                try
                {
                    int idSelected = vm.IdSelectedCategory;
                    Category newCategory = new Category();
                    newCategory = db.Categories.SingleOrDefault(c => c.Id == idSelected);
                    poi.Category = newCategory;
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Exception : {0}", e);
                }
                
                db.Entry(poi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: POIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POI pOI = db.POIs.Find(id);
            if (pOI == null)
            {
                return HttpNotFound();
            }
            return View(pOI);
        }

        // POST: POIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POI pOI = db.POIs.Find(id);
            db.POIs.Remove(pOI);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
