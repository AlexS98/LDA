using Lesson18.Data.Context;
using Lesson18.Data.Models;
using Lesson18.Dto;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbService _dbService;

        public UserController(DbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _dbService.Users.Include(x => x.UserData).ToList();
        } 

        [HttpPost("add")]
        public IEnumerable<User> AddUser(UserDto dto)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Username = dto.Username,
                Age = dto.Age
            };

            if (!string.IsNullOrEmpty(dto.PhoneNumber))
            {
                newUser.UserData = new UserData
                {
                    Id = Guid.NewGuid(),
                    PhoneNumber = dto.PhoneNumber,
                    UserId = newUser.Id
                };
            }

            _dbService.Users.Add(newUser);
            _dbService.SaveChanges();

            return GetUsers();
        }


        [HttpGet("find")]
        public User FindUser([FromQuery] string name)
        {
            var user = _dbService.Users
                .Include(x => x.UserData)
                .FirstOrDefault(x => x.Username == name);
            return user;
        }
    }
}
