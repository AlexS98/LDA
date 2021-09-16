using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Domain.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
    }
}
