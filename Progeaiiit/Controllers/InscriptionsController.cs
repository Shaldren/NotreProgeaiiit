using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using BO;
using Progeaiiit.Models;

namespace Progeaiiit.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using BO;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Inscription>("Inscriptions");
    builder.EntitySet<POI>("POIs"); 
    builder.EntitySet<Race>("Races"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class InscriptionsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/Inscriptions
        [EnableQuery]
        public IQueryable<Inscription> GetInscriptions()
        {
            return db.Inscriptions;
        }

        // GET: odata/Inscriptions(5)
        [EnableQuery]
        public SingleResult<Inscription> GetInscription([FromODataUri] int key)
        {
            return SingleResult.Create(db.Inscriptions.Where(inscription => inscription.Id == key));
        }

        // PUT: odata/Inscriptions(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Inscription> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Inscription inscription = db.Inscriptions.Find(key);
            if (inscription == null)
            {
                return NotFound();
            }

            patch.Put(inscription);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscriptionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(inscription);
        }

        // POST: odata/Inscriptions
        public IHttpActionResult Post(Inscription inscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inscriptions.Add(inscription);
            db.SaveChanges();

            return Created(inscription);
        }

        // PATCH: odata/Inscriptions(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Inscription> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Inscription inscription = db.Inscriptions.Find(key);
            if (inscription == null)
            {
                return NotFound();
            }

            patch.Patch(inscription);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscriptionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(inscription);
        }

        // DELETE: odata/Inscriptions(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Inscription inscription = db.Inscriptions.Find(key);
            if (inscription == null)
            {
                return NotFound();
            }

            db.Inscriptions.Remove(inscription);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Inscriptions(5)/Position
        [EnableQuery]
        public IQueryable<POI> GetPosition([FromODataUri] int key)
        {
            return db.Inscriptions.Where(m => m.Id == key).SelectMany(m => m.Position);
        }

        // GET: odata/Inscriptions(5)/Race
        [EnableQuery]
        public SingleResult<Race> GetRace([FromODataUri] int key)
        {
            return SingleResult.Create(db.Inscriptions.Where(m => m.Id == key).Select(m => m.Race));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InscriptionExists(int key)
        {
            return db.Inscriptions.Count(e => e.Id == key) > 0;
        }
    }
}
