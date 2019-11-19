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
    public class ClientsController : ApiController
    {
        private ClientDbContext db = new ClientDbContext();

        [Route("EnterName/{name}")]

        [ResponseType(typeof(Client))]
        public IHttpActionResult getByName(string name)
        {
            IList<Client> clist = null;
            clist = db.Clients.Include(c => c.Id).Where(cdd => (cdd.Firstname.Contains(name)) || (cdd.Lastname.Contains(name))).ToList();
            if (clist == null)
            {
                return NotFound();
            }
            return Ok(clist);
        }

        [Route("EnterName/{firstname}/{lastname}")]

        [ResponseType(typeof(Client))]
        public IHttpActionResult getAllDetails(string firstname, string lastname)
        {
            var Clients = db.Clients.Include(c => c.Id).Where(cd => cd.Firstname == firstname && cd.Lastname == lastname);

            if (Clients == null)
            {
                return NotFound();
            }
            return Ok(Clients);
        }

        // GET: api/Clients
        [Route("EnterName/")]
        public IQueryable<Client> GetClients()
        {
            int NumberOfRec = 5;
            return db.Clients.Include(c => c.Id).Take(NumberOfRec);
        }        
 
        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientId)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.ClientId == id) > 0;
        }
    }
}