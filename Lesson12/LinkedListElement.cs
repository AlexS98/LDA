using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson12
{
    public class LinkedListElement<T> where T : class
    {
        public T Value { get; set; }
        public LinkedListElement<T> Prev { get; set; }
        public LinkedListElement<T> Next { get; set; }

        public override string ToString()
        {
            return $"PV: {Prev?.Value.ToString() ?? "Empty"}, V: {Value}, NV: {Next?.Value.ToString() ?? "Empty"}";
        }
    }
}
