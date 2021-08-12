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

        public User()
        {
            Contacts = new Contacts("");
        }

        public User(string firstName, string lastName, int age, Contacts contacts)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Contacts = contacts;
        }

        public User GetCopy()
        {
            Contacts c = new Contacts(Contacts.Email);
            User u = new User(FirstName, LastName, Age, c);
            return u;
        }
    }
}
