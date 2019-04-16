using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public JObject Get()
        {
            var user = new JObject();
            user["login"] = User.Identity.Name;
            user["writepermission"] = false;
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                if (User.Identity.IsAuthenticated)
                {
                    UserPrincipal principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
                    if (principal != null)
                    {
                        user["name"] = principal.GivenName;
                        user["surname"] = principal.Surname;
                        user["mail"] = principal.EmailAddress;
                        user["username"] = principal.DisplayName;
                    }
                }
                else
                {
                    user["username"] = "Anonymous";
                }
            }
            return user;
        }
        /*
        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
