using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson10
{
    public class User
    {
        public string Username { get; set; }
        public int Age { get; set; }

        public User(string username, int age)
        {
            Username = username;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Username}, {Age}";
        }
    }
}
