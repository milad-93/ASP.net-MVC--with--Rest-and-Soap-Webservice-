using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi;

namespace WebApi.Controllers
{
    public class PersonerController : ApiController
    {
        private PersonModell db = new PersonModell();

        // GET: api/Personer
        public IQueryable<Personer> GetPersoner()
        {
            return db.Personer;
        }

        // GET: api/Personer/5
        [ResponseType(typeof(Personer))]
        public IHttpActionResult GetPersoner(int id)
        {

            try
            {
                Personer personer = db.Personer.Find(id);
                if (personer == null)
                {
                    return NotFound();
                }

                return Ok(personer);
            }

            catch
            {
                return null;
            }
   
        }

        // PUT: api/Personer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersoner(int id, Personer personer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personer.Id)
            {
                return BadRequest();
            }

            db.Entry(personer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonerExists(id))
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

        // POST: api/Personer
        [ResponseType(typeof(Personer))]
        public IHttpActionResult PostPersoner(Personer personer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personer.Add(personer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personer.Id }, personer);
        }

        // DELETE: api/Personer/5
        [ResponseType(typeof(Personer))]
        public IHttpActionResult DeletePersoner(int id)
        {
            Personer personer = db.Personer.Find(id);
            if (personer == null)
            {
                return NotFound();
            }

            db.Personer.Remove(personer);
            db.SaveChanges();

            return Ok(personer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonerExists(int id)
        {
            return db.Personer.Count(e => e.Id == id) > 0;
        }
    }
}