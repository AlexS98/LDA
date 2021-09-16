using System;
using System.Text.Json.Serialization;

namespace Lesson18.Data.Models
{
    public class UserData
    {
        public Guid Id { get; set; }

        public string PhoneNumber { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
