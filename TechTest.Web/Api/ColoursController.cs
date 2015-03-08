using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechTest.Core.Interfaces.Service;
using TechTest.Entity;

namespace TechTest.Web.Api
{
    public class ColoursController : ApiController
    {
        private readonly IColourService _service;

        public ColoursController(IColourService service)
        {
            _service = service;
        }

        // GET api/<controller>
        public IEnumerable<Colour> Get()
        {
            return _service.GetAllColours();
        }

        // GET api/<controller>/5
        public Colour Get(int id)
        {
            return _service.GetColour(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}