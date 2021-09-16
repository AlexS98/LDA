using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication.Domain;
using WebApplication.Domain.Models;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly DbService _db;

        public UserController(DbService db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<User> Index(string username)
        {
            _db.Users.Add(new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                Age = new Random().Next(18, 99)
            });
            _db.SaveChanges();
            return _db.Users;
        }
    }
}
