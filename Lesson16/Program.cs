using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson16
{
    class Program
    {
        static void Main(string[] args)
        {
            UTF8Encoding encoding = new UTF8Encoding(true);
            using (var fileStream = new FileStream("data.txt", FileMode.Open))
            {
                var buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, (int)fileStream.Length);
                Console.WriteLine(encoding.GetString(buffer));
            }
        }

        static void File()
        {
            Console.WriteLine(GetFileValueAsync().GetAwaiter().GetResult());

            WriteToFile(Console.ReadLine());

            Func<string, List<string>> func = (a) => a.Split(Environment.NewLine).ToList();
            var linesInList = GetFileValueAsync(func)
                .GetAwaiter().GetResult();

            for (int i = 0; i < linesInList.Count; i++)
            {
                Console.WriteLine($"Line {i + 1}. {linesInList[i]}");
            }
        }

        static async Task<string> GetFileValueAsync()
        {
            var result = "";
            using (var reader = new StreamReader("data.txt"))
            {
                var value = await reader.ReadToEndAsync();
                result = value.Length > 0 ? value : "EMPTY FILE";
            }
            return result;
        }

        static async Task<T> GetFileValueAsync<T>(Func<string, T> formatter)
        {
            var result = "";
            using (var reader = new StreamReader("data.txt"))
            {
                var value = await reader.ReadToEndAsync();
                result = value.Length > 0 ? value : "EMPTY FILE";
            }
            return formatter(result);
        }

        static void WriteToFile<T>(T input, Func<T, string> formatter = null)
        {
            formatter ??= (t) => t.ToString();
            using (var writer = new StreamWriter("data.txt", append: true))
            {
                writer.WriteLine();
                writer.WriteLine(formatter(input));
            }
        }

        #region ex3
        static void ReferenceExample()
        {
            List<int> list = new List<int> { 9, 8, 7, 6 }; // 1234 [1598] /*[0000]

            list?.ForEach(x => Console.Write($"{x}; ")); // -
            Console.WriteLine(); // +

            ReferenceAsUsually(list); // 9876 [1598] /*[0000] => 9876 [1472]
            list?.ForEach(x => Console.Write($"{x}; ")); // + /*-
            Console.WriteLine(); // +

            ReferenceAsRef(ref list); // 6547 [1234] [1598] /*[0000] => 6547 [1234] [5678] 
            list?.ForEach(x => Console.Write($"{x}; ")); // +
            Console.WriteLine(); // +

            ReferenceAsOut(out list);
            list?.ForEach(x => Console.Write($"{x}; "));
            Console.WriteLine();

            List<int> list2;

            //ReferenceAsRef(ref list2);
            //list2?.ForEach(x => Console.Write($"{x}; "));
            //Console.WriteLine();

            ReferenceAsOut(out list2);
            list2?.ForEach(x => Console.Write($"{x}; "));
            Console.WriteLine();
        }

        static void ReferenceAsUsually(List<int> list)
        {
            // list[0] = 10000;
            list = new List<int> { 1, 2, 3, 4 };
        }
        static void ReferenceAsRef(ref List<int> list)
        {
            // list[0] = 10000;
            list = new List<int> { 1, 2, 3, 4 };
        }
        static void ReferenceAsOut(out List<int> list)
        {
            list = new List<int> { 1, 2, 3, 4 };
        }
        #endregion

        #region ex2
        static void SwapExample()
        {
            int a = 5, b = 10;
            Console.WriteLine($"Real - a: {a}, b: {b}");
            FakeSwap(a, b);
            Console.WriteLine($"Real - a: {a}, b: {b}");
            RealSwap(ref a, ref b);
            Console.WriteLine($"Real - a: {a}, b: {b}");
        }

        static void FakeSwap(int a, int b)
        {
            int c = a;
            a = b;
            b = c;
            Console.WriteLine($"Inside - a: {a}, b: {b}");
        }

        static void RealSwap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
            Console.WriteLine($"Inside - a: {a}, b: {b}");
        }
        #endregion

        #region ex1
        static void ThreadExample()
        {
            var totalNumber = 100;
            Thread thread1 = new Thread((a) =>
            {
                if (a is int aInt)
                {
                    for (int i = 0; i < totalNumber; i++)
                    {
                        Console.WriteLine($"{aInt}. {i}");
                    }
                }
            });
            thread1.Priority = ThreadPriority.Highest;
            Thread thread2 = new Thread(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < totalNumber; i++)
                {
                    Console.WriteLine($"A. {i}");
                }
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            });
            thread1.Start(1);
            thread2.Start();
            Console.WriteLine("STARTED!");
        }
        #endregion
    }
}
