using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Contacts Contacts { get; set; }

        public User(string firstName, string lastName, int age, Contacts contacts)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Contacts = contacts;
        }
    }
}
