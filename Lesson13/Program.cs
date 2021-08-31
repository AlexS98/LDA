using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson13
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Account>();
            var g = new Group();
            for (int i = 0; i < 10; i++)
            {
                var ac = new Account
                {
                    Username = $"Account{i + 1}"
                };

                if (i != 0)
                {
                    ac.Blacklist.Add(list[i - 1].Id);
                }

                list.Add(ac);
                g.Subscribe(ac);
            }
            g.SendMessage(new Message { Sender = list[0], Text = "Bla-bla" });

            Action<string> con = ActionProducer();
            Predicate<int> predicate = (age) => age >= 18;
            Func<int, string> ageValidator = (age) => predicate(age) ? "Adult" : "Child";

            con(ageValidator(15));

            IEnumerable<Account> newList = list.Where(a => a.Username.EndsWith("5") || a.Username.EndsWith("9")).ToList();
            con(newList.Count().ToString());
            list.Add(new Account
            {
                Username = $"Account{19}"
            });
            con(newList.Count().ToString());

            list.ForEach(x => Console.WriteLine(x));

            list
                //.Where(a => a.Username.EndsWith("5") || a.Username.EndsWith("9"))
                .Select(a => a.Id.ToString())
                .SomeAction(() => { Console.ForegroundColor = ConsoleColor.Red; })
                .ToConsole(a => a.ToString().ToUpperInvariant())
                .SomeAction(() => Console.ResetColor())
                .OrderBy(s => s)
                .ToConsole();
        }

        static Action<string> ActionProducer()
        {
            Action<string> result = (text) => Console.WriteLine(text);
            return result;
        }
    }
}
