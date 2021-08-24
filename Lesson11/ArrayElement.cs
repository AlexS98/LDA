using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson11
{
    public class ArrayElement<T, H> where H : IHandler<T>
    {
        public T Element { get; set; }
        public H Handler { get; set; }

        public T GetElement()
        {
            return Element;
        }

        public string GetValue()
        {
            return Handler.ConvertToString(Element);
        }
    }
}
