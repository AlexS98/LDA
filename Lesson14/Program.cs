using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson14
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new UserBuilder();
            List<User> users = new List<User>();
            for (int i = 0; i < 2000; i++)
            {
                users.Add(builder.GenerateUser());
            }
            foreach (var item in users)
            {
                Console.Write(item.Username + "; ");
            }
            //users.Where(user => )
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < users.Count; i++)
            {
                var sameName = users.Where(x => x.Username == users[i].Username).Count();
                if (sameName > 3)
                {
                    Console.WriteLine($"{users[i].Username} - {sameName}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;

            users.ForEach(user =>
            {
                var sameName = users.Where(x => x.Username == user.Username).Count();
                if (sameName > 3)
                {
                    Console.WriteLine($"{user.Username} - {sameName}");
                }
            });

            Console.ForegroundColor = ConsoleColor.Yellow;

            Dictionary<string, int> paper = new Dictionary<string, int>();

            users.ForEach(user =>
            {
                if (paper.Keys.Contains(user.Username))
                {
                    paper[user.Username] += 1;
                }
                else
                {
                    paper.Add(user.Username, 1);
                }
            });

            paper.Where(x => x.Value > 3).ToList().ForEach(x => {
                Console.WriteLine($"{x.Key} - {x.Value}");
            });

            Console.ForegroundColor = ConsoleColor.Cyan;

            users
                .GroupBy(user => user.Username)
                .Where(group => group.Count() > 3)
                .ToList()
                .ForEach(group => Console.WriteLine($"{group.First().Username} - {group.Count()}"));

            Console.ForegroundColor = ConsoleColor.White;

            users
                .GroupBy(user => user.Username)
                .Where(group => group.Count() > 3)
                .ToDictionary(x => x.Key, y => y.Count())
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key} - {x.Value}"));

            /*
            .Select(group => new { name = group.Key, count = group.Count() })
            .ToList()
            .ForEach(anon => Console.WriteLine($"{anon.name} - {anon.count}"));
            */

            var a = new
            {
                Count = 1,
                Name = "qweqwe"
            };

            Console.WriteLine(a.GetType().Name);

            Console.WriteLine(users.Any(x => x.Username == "Abc123"));

            Console.WriteLine(users.TrueForAll(x => !string.IsNullOrEmpty(x.Username)));
            Console.WriteLine(users.FirstOrDefault(x => x.Username.StartsWith("Abq"))?.Username ?? "Default");
            Console.WriteLine(users.First(x => x.Username.StartsWith("Abc"))?.Username ?? "Default");
            Console.WriteLine(users.SingleOrDefault(x => x.Username.StartsWith("Abq"))?.Username ?? "Default");


            Console.WriteLine(users.Max(x => x.Age));
            Console.WriteLine(users.Min(x => x.Age));
            Console.WriteLine(users.Average(x => x.Age));
        }
    }
}
