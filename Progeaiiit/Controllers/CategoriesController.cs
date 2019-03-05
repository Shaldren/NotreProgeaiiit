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
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            var vm = new CategoryVM();
            vm.POIs = db.POIs.ToList();
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (vm.IdSelectedPOI.Any())
                    {
                        foreach (int i in vm.IdSelectedPOI)
                        {
                            vm.POIs.Add(db.POIs.Find(i));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Exception : {0}", e);
                }

                db.Categories.Add(vm.Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var vm = new CategoryVM();
            vm.POIs = db.POIs.ToList();
            vm.Category = category;

            try
            {
                if (category.POIs.Any())
                {
                    foreach (POI poi in category.POIs)
                    {
                        vm.IdSelectedPOI.Add(poi.Id);
                    }
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : {0}", e);
            }

            return View(vm);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryVM vm)
        {
            
            POI poi = new POI();
            if (ModelState.IsValid)
            {
                var category = db.Categories.Include(p => p.POIs).FirstOrDefault(i => i.Id == vm.Category.Id);
                category.Title = vm.Category.Title;
                category.POIs = new List<POI>();
                try
                {
                    if (vm.IdSelectedPOI.Any())
                    {
                        foreach (int i in vm.IdSelectedPOI)
                        {
                            category.POIs.Add(db.POIs.Find(i));
                        }
                    }

                    vm.POIs = db.POIs.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception : {0}", e);
                }
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
