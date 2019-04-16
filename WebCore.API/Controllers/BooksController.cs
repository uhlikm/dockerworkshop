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
            jaBooks.Add(JObject.Parse("{ \"title\": \"Book1\", \"author\": \"Name1\" }"));
            jaBooks.Add(JObject.Parse("{ \"title\": \"Book2\", \"author\": \"Name2\" }"));
            return jaBooks;
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public JObject Get(int id)
        {
            return JObject.Parse("{ \"title\": \"Book1\", \"author\": \"Name1\" }");
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] JObject value)
        {
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
