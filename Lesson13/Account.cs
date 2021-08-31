using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson13
{
    public class Account
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Username { get; set; }
        public List<Guid> Blacklist { get; set; } = new List<Guid>();

        public void ReceiveMessage(Message m)
        {
            if (IsBlacklisted(m.Sender))
            {
                Console.WriteLine($"{Username} message blocked");
            }
            else
            {
                Console.WriteLine($"{Username} received {m}");
            }
        }

        public bool IsBlacklisted(Account a)
        {
            foreach (var item in Blacklist)
            {
                if (a.Id == item)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Id}, {Username}";
        }
    }
}
