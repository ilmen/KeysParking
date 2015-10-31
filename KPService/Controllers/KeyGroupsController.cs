using KPLibrary;
using KPService.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace KPService.Controllers
{
    public class KeyGroupsController : ApiController
    {
        private KPDbContext db = new KPDbContext();

        // GET: api/KeyGroups
        public IQueryable<KeyGroup> GetKeyGroups()
        {
            return db.KeyGroups;
        }

        // GET: api/KeyGroups/5
        [ResponseType(typeof(KeyGroup))]
        public IHttpActionResult GetKeyGroup(Guid id)
        {
            KeyGroup keyGroup = db.KeyGroups.Find(id);
            if (keyGroup == null)
            {
                return NotFound();
            }

            return Ok(keyGroup);
        }

        // PUT: api/KeyGroups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKeyGroup(Guid id, KeyGroup keyGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != keyGroup.Id)
            {
                return BadRequest();
            }

            db.Entry(keyGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/KeyGroups
        [ResponseType(typeof(KeyGroup))]
        public IHttpActionResult PostKeyGroup(KeyGroup keyGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KeyGroups.Add(keyGroup);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KeyGroupExists(keyGroup.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = keyGroup.Id }, keyGroup);
        }

        // DELETE: api/KeyGroups/5
        [ResponseType(typeof(KeyGroup))]
        public IHttpActionResult DeleteKeyGroup(Guid id)
        {
            KeyGroup keyGroup = db.KeyGroups.Find(id);
            if (keyGroup == null)
            {
                return NotFound();
            }

            db.KeyGroups.Remove(keyGroup);
            db.SaveChanges();

            return Ok(keyGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KeyGroupExists(Guid id)
        {
            return db.KeyGroups.Count(e => e.Id == id) > 0;
        }
    }
}