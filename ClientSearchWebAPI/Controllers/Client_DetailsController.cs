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
using ClientSearchWebAPI.Models;

namespace ClientSearchWebAPI.Controllers
{
    public class Client_DetailsController : ApiController
    {
        private ClientDbContext db = new ClientDbContext();

        // GET: api/Client_Details
        public IQueryable<Client_Details> GetClient_Details()
        {
            return db.Client_Details;
        }

        // GET: api/Client_Details/5
        [ResponseType(typeof(Client_Details))]
        public IHttpActionResult GetClient_Details(int id)
        {
            Client_Details client_Details = db.Client_Details.Find(id);
            if (client_Details == null)
            {
                return NotFound();
            }

            return Ok(client_Details);
        }

        // PUT: api/Client_Details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient_Details(int id, Client_Details client_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client_Details.Id)
            {
                return BadRequest();
            }

            db.Entry(client_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Client_DetailsExists(id))
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

        // POST: api/Client_Details
        [ResponseType(typeof(Client_Details))]
        public IHttpActionResult PostClient_Details(Client_Details client_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Client_Details.Add(client_Details);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client_Details.Id }, client_Details);
        }

        // DELETE: api/Client_Details/5
        [ResponseType(typeof(Client_Details))]
        public IHttpActionResult DeleteClient_Details(int id)
        {
            Client_Details client_Details = db.Client_Details.Find(id);
            if (client_Details == null)
            {
                return NotFound();
            }

            db.Client_Details.Remove(client_Details);
            db.SaveChanges();

            return Ok(client_Details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Client_DetailsExists(int id)
        {
            return db.Client_Details.Count(e => e.Id == id) > 0;
        }
    }
}