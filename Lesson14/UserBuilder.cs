using System;
using System.Collections.Generic;

namespace Lesson14
{
    public class UserBuilder
    {
        private List<string> usernames = new List<string> { "Qwe", "Abc", "Wer", "Tyu", "Opd", "Ngr", "Dcf" };

        public User GenerateUser()
        {
            return new User
            {
                Username = GetUsername(),
                Age = new Random().Next(12, 100)
            };
        }

        private string GetUsername()
        {
            Random r = new Random();
            return $"{usernames[r.Next(0, usernames.Count)]}{r.Next(0, 1000)}";
        }
    }
}
