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
            DataManager dataManager = new DataManager();
            JArray jaBooks = dataManager.LoadData();
            //JArray jaBooks = new JArray();
            //jaBooks.Add(JObject.Parse("{ \"id\": \"1\", \"name\": \"Book1\", \"author\": \"Name1\" }"));
            //jaBooks.Add(JObject.Parse("{ \"id\": \"2\", \"name\": \"Book2\", \"author\": \"Name2\" }"));
            return jaBooks;
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public JObject Get(int id)
        {
            DataManager dataManager = new DataManager();
            JArray jaBooks = dataManager.LoadData();
            foreach (var it in jaBooks)
            {
                if (it["id"].ToObject<int>() == id)
                {
                    return it.ToObject<JObject>();
                }
            }
            return null;
        }

        // POST: api/Books
        [HttpPost]
        public JObject Post([FromBody] JObject value)
        {
            DataManager dataManager = new DataManager();
            JArray jaBooks = dataManager.LoadData();
            value["id"] = jaBooks[jaBooks.Count -1]["id"].ToObject<int>() + 1;
            jaBooks.Add(value);
            dataManager.SaveData(jaBooks);
            return value;
        }

        // POST: api/Books/5
        [HttpPost("{id}")]
        public void Post(int id, [FromBody] JObject value)
        {
            DataManager dataManager = new DataManager();
            JArray jaBooks = dataManager.LoadData();
            for (int i = 0; i < jaBooks.Count; i++)
            {
                if (jaBooks[i]["id"].ToObject<int>() == id)
                {
                    jaBooks[i] = value;
                    dataManager.SaveData(jaBooks);
                    break;
                }
            }
        }

        // PUT: api/Books/5
        //[HttpPut("{id}")]
        [HttpPut]
        public void Put([FromBody] JObject value)
        {
            int id = value["id"].ToObject<int>();
            DataManager dataManager = new DataManager();
            JArray jaBooks = dataManager.LoadData();
            for (int i = 0; i < jaBooks.Count; i++)
            {
                if (jaBooks[i]["id"].ToObject<int>() == id)
                {
                    jaBooks[i] = value;
                    dataManager.SaveData(jaBooks);
                    break;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DataManager dataManager = new DataManager();
            JArray jaBooks = dataManager.LoadData();
            JToken book = null;
            foreach (var it in jaBooks)
            {
                if (it["id"].ToObject<int>() == id)
                {
                    book = it;
                    break;
                }
            }
            if (book != null)
            {
                jaBooks.Remove(book);
                dataManager.SaveData(jaBooks);
            }
        }
    }
}
