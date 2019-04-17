using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET: api/Books
        [HttpGet]
        public JArray Get()
        {
            JArray jaBooks = new JArray();
            jaBooks.Add(JObject.Parse("{ \"id\": \"1\", \"name\": \"Book1\", \"author\": \"Name1\" }"));
            jaBooks.Add(JObject.Parse("{ \"id\": \"2\", \"name\": \"Book2\", \"author\": \"Name2\" }"));
            return jaBooks;
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public JObject Get(int id)
        {
            return JObject.Parse("{ \"id\": \"1\", \"name\": \"Book1\", \"author\": \"Name1\" }");
        }

        // POST: api/Books
        [HttpPost]
        public JObject Post([FromBody] JObject value)
        {
            value["id"] = "3";
            return value;
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JObject value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
