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

namespace Progeaiiit.Controllers
{
    public class DisplayConfigurationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DisplayConfigurations
        public ActionResult Index()
        {
            return View(db.DisplayConfigurations.ToList());
        }

        // GET: DisplayConfigurations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisplayConfiguration displayConfiguration = db.DisplayConfigurations.Find(id);
            if (displayConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(displayConfiguration);
        }

        // GET: DisplayConfigurations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisplayConfigurations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeviceName,SpeedAvg,SpeedMax,UnitDistance")] DisplayConfiguration displayConfiguration)
        {
            if (ModelState.IsValid)
            {
                displayConfiguration.Id = Guid.NewGuid();
                db.DisplayConfigurations.Add(displayConfiguration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(displayConfiguration);
        }

        // GET: DisplayConfigurations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisplayConfiguration displayConfiguration = db.DisplayConfigurations.Find(id);
            if (displayConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(displayConfiguration);
        }

        // POST: DisplayConfigurations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeviceName,SpeedAvg,SpeedMax,UnitDistance")] DisplayConfiguration displayConfiguration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(displayConfiguration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(displayConfiguration);
        }

        // GET: DisplayConfigurations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisplayConfiguration displayConfiguration = db.DisplayConfigurations.Find(id);
            if (displayConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(displayConfiguration);
        }

        // POST: DisplayConfigurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DisplayConfiguration displayConfiguration = db.DisplayConfigurations.Find(id);
            db.DisplayConfigurations.Remove(displayConfiguration);
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
