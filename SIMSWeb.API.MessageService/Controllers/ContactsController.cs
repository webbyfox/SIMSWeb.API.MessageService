﻿//using SIMSWeb.API.MessageService.Data.Models;
//using SIMSWeb.API.MessageService.Data.Repositories;
//using SIMSWeb.API.MessageService.Data.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace SIMSWeb.API.MessageService.Controllers
{
    public class ContactsController : ApiController
    {
        //private readonly IContactRepository contactRepo = new ContactRepository();

        // GET: api/Contacts
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET: api/Contacts/5
        //[Route("api/Contacts/GetContactWithContactNumber/{contactNumber}")]
        //public Contacts GetContactWithContactNumber(int contactNumber)
        //{
        //    return contactRepo.GetContactWithContactNumber(contactNumber);
        //}

        // POST: api/Contacts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contacts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contacts/5
        public void Delete(int id)
        {
        }
    }
}
