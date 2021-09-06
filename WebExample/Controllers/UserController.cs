using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace WebExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static List<string> Users = new List<string>();

        static UserController()
        {
            //Users.AddRange(new[] { "qwe", "asd", "zcx" });
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Users;
        }


        [HttpGet("add")]
        public IEnumerable<string> AddUser(string username)
        {
            Users.Add(username);
            return Users;
        }
    }
}
