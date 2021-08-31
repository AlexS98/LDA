using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson13
{
    public delegate void OnMessage(Message text);
    public delegate void OnMessageEvent(object sender, MessageEventArgs args);

    public class Group
    {
        public string Name { get; set; }
        public List<Account> Participants { get; private set; } = new List<Account>();

        public OnMessage OnMessageDelegate { get; set; } = (m) => { Console.WriteLine(m); };
        public event OnMessageEvent OnMessageEvent;

        public Group()
        {
            OnMessageEvent += ExampleHandler;
        }

        public void Subscribe(Account user)
        {
            Participants.Add(user);
            OnMessageDelegate += user.ReceiveMessage;
        }

        public void SendMessage(Message mes)
        {
            OnMessageDelegate.Invoke(mes);
            OnMessageEvent?.Invoke(this, new MessageEventArgs(mes));
        }

        public void ExampleHandler(object s, EventArgs e)
        {

        }
    }

    public class MessageEventArgs : EventArgs
    {
        public Message Message { get; set; }

        public MessageEventArgs(Message message)
        {
            Message = message;
        }
    }
}
