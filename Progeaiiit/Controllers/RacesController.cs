﻿using System;
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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Progeaiiit.Controllers
{
    public class RacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
               
        // GET: Races
        public ActionResult Index()
        {
            return View(db.Races.ToList());
        }

        // GET: Races/Details/5
        public ActionResult Details(int? id)
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ApplicationUser currentCreator = userManager.FindById(User.Identity.GetUserId());

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            //race.Pois.OrderBy(o => o.Order);

            race.Creator = currentCreator;
            if (race == null)
            {
                return HttpNotFound();
            }
            ViewData["POIs"] = race.POIs.ToList();
            return View(race);
        }

        // GET: Races/Create
        public ActionResult Create()
        {
			var vm = new RaceVM();
			vm.POIs = db.POIs.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString()}).ToList();
			vm.Inscriptions = db.Inscriptions.Select(i => new SelectListItem { Text = i.ApplicationUser.UserName, Value = i.Id.ToString() }).ToList();
            return View(vm);
        }

        // POST: Races/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RaceVM vm)
        {
            List<POI> POIs = new List<POI>();
            List<Inscription> inscriptions = new List<Inscription>();
            POI poi = new POI();
            Inscription inscription = new Inscription();
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ApplicationUser currentCreator = userManager.FindById(User.Identity.GetUserId());
            vm.Race.Creator = currentCreator;

            if (ModelState.IsValid)
            {
                try
                {
                    if (vm.IdSelectedPOI.Any())
                    {                        
                        foreach (int i in vm.IdSelectedPOI)
                        {                            
                            poi = db.POIs.FirstOrDefault(p => p.Id == i);
                            POIs.Add(poi);                            
                        }

                        vm.Race.POIs = POIs;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Exception : {0}", e);
                }

                try
                {                
                    if (vm.IdSelectedInscription.Any())
                    {
                        foreach (int i in vm.IdSelectedInscription)
                        {
                            inscription = db.Inscriptions.FirstOrDefault(p => p.Id == i);
                            inscriptions.Add(inscription);
                        }

                        vm.Race.Inscriptions = inscriptions;
                    }                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Exception : {0}", e);
                }

                db.Races.Add(vm.Race);
                db.SaveChanges();

                return RedirectToAction("Index");
            }            

            return View(vm);
        }

        // GET: Races/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }

			var vm = new RaceVM();
            vm.POIs = db.POIs.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() }).ToList();
            vm.Inscriptions = db.Inscriptions.Select(i => new SelectListItem { Text = i.ApplicationUser.UserName, Value = i.Id.ToString() }).ToList();
            vm.Race = race;
            
            try
            {
                if (race.POIs.Any())
                {
                    foreach (POI poi in race.POIs)
                    {
                        vm.IdSelectedPOI.Add(poi.Id);
                    }
                }

                if (race.Inscriptions.Any())
                {
                    foreach (Inscription inscription in race.Inscriptions)
                    {
                        vm.IdSelectedInscription.Add(inscription.Id);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : {0}",e);
            }			

            return View(vm);
        }

        // POST: Races/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RaceVM vm)
        {
            POI poi = new POI();
            Inscription inscription = new Inscription();

            if (ModelState.IsValid)
            {
				var race = db.Races.Include(p => p.POIs).FirstOrDefault(i => i.Id == vm.Race.Id);
				race.City = vm.Race.City;
                race.DateStart = vm.Race.DateStart;
                race.DateEnd = vm.Race.DateEnd;
                race.RaceTime = vm.Race.RaceTime;
				race.Description = vm.Race.Description;
				race.Title = vm.Race.Title;
				race.ZipCode = vm.Race.ZipCode;
				race.POIs = new List<POI>();
				race.Inscriptions = new List<Inscription>();

                try
                {
                    if (vm.IdSelectedPOI.Any())
                    {

                        foreach (int i in vm.IdSelectedPOI)
                        {                            
                            poi = db.POIs.FirstOrDefault(p => p.Id == i);
                            race.POIs = db.POIs.Where(p => vm.IdSelectedPOI.Contains(p.Id)).ToList();
                        }
                        //vm.Race.POIs = POIs;
                    }
                    //vm.POIs = db.POIs.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() }).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception : {0}", e);
                }

                try
                {
                    if (vm.IdSelectedInscription.Any())
                    {
                        foreach (int i in vm.IdSelectedInscription)
                        {
                            inscription = db.Inscriptions.FirstOrDefault(p => p.Id == i);
                            race.Inscriptions = db.Inscriptions.Where(p => vm.IdSelectedInscription.Contains(p.Id)).ToList();
                        }
                    }

                    //vm.Inscriptions = db.Inscriptions.Select(i => new SelectListItem { Text = i.ApplicationUser.UserName, Value = i.Id.ToString() }).ToList();
                }                             
                catch (Exception e)
                {
                    Console.WriteLine("Exception : {0}",e);
                }

                db.Entry(race).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Races/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        // POST: Races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Race race = db.Races.Find(id);
            db.Races.Remove(race);
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
