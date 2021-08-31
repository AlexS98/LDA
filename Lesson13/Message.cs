using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson13
{
    public class Message
    {
        public string Text { get; set; }
        public Account Sender { get; set; }

        public override string ToString()
        {
            return $"{Sender?.Username}:{Text}";
        }
    }
}
