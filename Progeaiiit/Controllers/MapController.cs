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
            race.setCity("Nantes");
            List<POI> pois = new List<POI>();

            POI poi = new POI();
            poi.setName("Nom 1");
            poi.setId(1);
            poi.setCooX(47.226733);
            poi.setCooY(-1.620663);
            pois.Add(poi);
            POI poi2 = new POI();
            poi2.setName("Nom 1");
            poi2.setId(1);
            poi2.setCooX(47.224944);
            poi2.setCooY(-1.632408);
            pois.Add(poi2);
            POI poi3 = new POI();
            poi3.setName("Nom 1");
            poi3.setId(1);
            poi3.setCooX(47.228687);
            poi3.setCooY(-1.627983);
            pois.Add(poi3);
            POI poi4 = new POI();
            poi4.setName("Nom 1");
            poi4.setId(1);
            poi4.setCooX(47.225732);
            poi4.setCooY(-1.627884);
            pois.Add(poi4);
            ViewData["race"] = pois;
            return View();
        }
    }
}