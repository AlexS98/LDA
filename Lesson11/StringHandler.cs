using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson11
{
    public interface IHandler<T>
    {
        string ConvertToString(T item);
    }

    public class StringHandler : IHandler<string>
    {
        public string ConvertToString(string item)
        {
            return $"STRING: {item}";
        }
    }

    public class Int32Handler : IHandler<int>
    {
        public string ConvertToString(int item)
        {
            return $"INT: {item}";
        }
    }
}
