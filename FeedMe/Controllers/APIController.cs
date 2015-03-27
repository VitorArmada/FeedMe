using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FeedMe.Models;

namespace FeedMe.Controllers
{
    public class APIController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET api/API
        public IEnumerable<Ingrediente> GetIngredientes()
        {
            return db.Ingredientes.AsEnumerable();
        }

        // GET api/API/5
        public Ingrediente GetIngrediente(int id)
        {
            Ingrediente ingrediente = db.Ingredientes.Find(id);
            if (ingrediente == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return ingrediente;
        }

        // PUT api/API/5
        public HttpResponseMessage PutIngrediente(int id, Ingrediente ingrediente)
        {
            if (ModelState.IsValid && id == ingrediente.IngredienteId)
            {
                db.Entry(ingrediente).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/API
        public HttpResponseMessage PostIngrediente(Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                db.Ingredientes.Add(ingrediente);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, ingrediente);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = ingrediente.IngredienteId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/API/5
        public HttpResponseMessage DeleteIngrediente(int id)
        {
            Ingrediente ingrediente = db.Ingredientes.Find(id);
            if (ingrediente == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Ingredientes.Remove(ingrediente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ingrediente);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}