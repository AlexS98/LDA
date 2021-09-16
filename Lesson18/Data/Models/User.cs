using System;
using System.ComponentModel.DataAnnotations;

namespace Lesson18.Data.Models
{
    public class User
    {
        [Key] public Guid Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }

        public UserData UserData { get; set; }
    }
}
