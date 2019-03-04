using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;

namespace Progeaiiit.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Index()
        {
            Race race = new Race();
            
            List<POI> pois = new List<POI>();
            
            POI poi = new POI();
            poi.Name ="Nom 1";
            poi.Id = 1;
            poi.CooX = 47.226733;
            poi.CooY = -1.620663;
            pois.Add(poi);
            POI poi2 = new POI();
            poi2.Name = "Nom 1";
            poi2.Id = 1;
            poi2.CooX = 47.224944;
            poi2.CooY = -1.632408;
            pois.Add(poi2);
            POI poi3 = new POI();
            poi3.Name = "Nom 1";
            poi3.Id = 1;
            poi3.CooX = 47.228687;
            poi3.CooY = -1.627983;
            pois.Add(poi3);
            POI poi4 = new POI();
            poi4.Name = "Nom 1";
            poi4.Id = 1;
            poi4.CooX = 47.225732;
            poi4.CooY = -1.627884;
            pois.Add(poi4);
            race.Pois = pois;
            ViewData["race"] = race;
            return View();
        }
    }
}