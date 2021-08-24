using Lesson10;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson11
{
    class Program
    {
        static void Main(string[] args)
        {
            var element = new ArrayElement<int, Int32Handler>
            {
                Element = 0,
                Handler = new Int32Handler()
            }; 
            var element2 = new ArrayElement<string, StringHandler>
            {
                Element = "wjeghdqcyjgb",
                Handler = new StringHandler()
            };

            //Console.WriteLine(element.GetValue());
            //Console.WriteLine(element2.GetValue());

            var intList = new CustomList<int>(256);

            int lastCapacity = intList.Capacity;
            int lastCount = intList.Count;

            for (int i = 0; i < 250; i++)
            {
                intList.Add(i);
                //if (lastCapacity != intList.Capacity)
                //{
                //    Console.ForegroundColor = ConsoleColor.Green;
                //    Console.WriteLine($"Capacity {lastCapacity} => {intList.Capacity}");
                //    Console.ResetColor();
                //    lastCapacity = intList.Capacity;
                //}
                //if (lastCount != intList.Count)
                //{
                //    Console.ForegroundColor = ConsoleColor.Blue;
                //    Console.WriteLine($"Count {lastCount} => {intList.Count}");
                //    Console.ResetColor();
                //    lastCount = intList.Count;
                //}
            }

            for (int i = 0; i < intList.Count; i++)
            {
                //Console.Write($"{intList[i]}; ");
            }

            for (int i = 10; i < 220; i++)
            {
                intList.Remove(i);
            }


            for (int i = 0; i < intList.Count; i++)
            {
                //Console.Write($"{intList[i]}; ");
            }


            for (int i = 0; i < intList.Capacity; i++)
            {
                //Console.Write($"{intList.Items[i]}; ");
            }

            for (int i = 0; i < 10; i++)
            {
                intList.Add(i);
            }

            Console.WriteLine();
            for (int i = 0; i < intList.Capacity; i++)
            {
                //Console.Write($"{intList.Items[i]}; ");
            }

            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            for (int i = 0; i < 10; i++)
            {
                keyValuePairs.Add(i, new string('a', i));
            }

            foreach (var item in keyValuePairs)
            {
                //Console.WriteLine(item.ToString());
            }

            var a = keyValuePairs.ContainsKey(11) ? keyValuePairs[11] : "Missing key";

            if(keyValuePairs.TryGetValue(11, out var s))
            {
                Console.WriteLine(s);
            }

            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(new string('a', i));
            }

            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Peek());
                stack.Pop();
            }

            Queue<string> queue = new Queue<string>();
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(new string('a', i));
            }
            while (queue.TryDequeue(out var str))
            {
                Console.WriteLine(str);
            }


            var input = "{{[()]}()}";

            Stack<char> inputElements = new Stack<char>();
            var open = new char[] { '{', '[', '(' };
            var close = new char[] { '}', ']', ')' };

            foreach (var item in input)
            {
                if(open.Contains(item))
                {
                    inputElements.Push(item);
                }
                else if(close.Contains(item) && Array.IndexOf(close, item) == Array.IndexOf(open, inputElements.Peek()))
                {
                    inputElements.Pop();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"Is valid: {inputElements.Count == 0}");

            Console.ReadKey();
        }


    }
}
