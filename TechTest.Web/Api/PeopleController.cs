using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechTest.Core.Implementation.Service;
using TechTest.Core.Interfaces.Service;
using TechTest.Core.Models;
using TechTest.Entity;

namespace TechTest.Web.Api
{
    public class PeopleController : ApiController
    {
        private readonly IPersonService _service;

        public PeopleController(IPersonService service)
        {
            _service = service;
        }

        // GET api/<controller>
        public IEnumerable<PersonModel> Get()
        {
            return _service.GetPeople(); 
        }

        // GET api/<controller>/5
        public PersonModel Get(int id)
        {
            return _service.GetPerson(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] PersonModel personModel)
        {
            _service.Update(id, personModel);
            return Request.CreateResponse(HttpStatusCode.OK, personModel);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}