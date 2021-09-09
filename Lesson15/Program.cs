using System;
using System.Threading.Tasks;

namespace Lesson15
{
    class Program
    {
        static void Main(string[] args)
        {
            UserClient userClient = new UserClient();
            var t = userClient.AddAsync("newUser");

            Task act = Task.Run(/* async*/ () =>
            {
                //await Task.Delay(1000);
                Task.Delay(1000).GetAwaiter().GetResult();
                Console.WriteLine("Done");
            });

            for (int i = 0; i < 100000; i++)
            {
                if (t.IsCompleted)
                {
                    break;
                }

                Console.Write(i);
            }

        }
    }
}
