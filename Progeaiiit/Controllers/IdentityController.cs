using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Progeaiiit.Controllers
{
    [Authorize]
    public class IdentityController : Controller
    {
        // GET: Identity
        public ActionResult Identity()
        {
            return Content("We are using Identity");
        }
        public ActionResult NonIdentiy()
        {
            return Content("We are not using Identity");
        }
    }
}