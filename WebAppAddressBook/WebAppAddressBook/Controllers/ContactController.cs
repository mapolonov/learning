﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAppAddressBook.Models;

namespace WebAppAddressBook.Controllers
{
    public class ContactController : ApiController
    {
        private EFContext db = new EFContext();

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return db.Contacts.AsEnumerable();
        }

        // GET api/<controller>/5
        public Contact Get(int id)
        {
            Contact Contact = db.Contacts.Find(id);
            if (Contact == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Contact;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Contact Contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(Contact);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, Contact);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Contact.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Contact Contact)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != Contact.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(Contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            Contact Contact = db.Contacts.Find(id);
            if (Contact == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Contacts.Remove(Contact);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Contact);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}