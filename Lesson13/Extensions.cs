using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson13
{
    public static class Extensions
    {
        public static IEnumerable<T> SomeAction<T>(this IEnumerable<T> enumer, Action act)
        {
            act?.Invoke();
            return enumer;
        }

        public static IEnumerable<T> ToConsole<T>(this IEnumerable<T> enumer, Func<T, string> function = null) 
        {
            //if (function != null)
            //{
            //    foreach (var item in enumer.Select(x => function(x)))
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            //else
            {
                foreach (var item in enumer)
                {
                    Console.WriteLine(function?.Invoke(item) ?? item.ToString());
                }
            }
            return enumer;
        }
    }
}
