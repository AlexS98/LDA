using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson12
{
    public class LinkedList<T> where T : class
    {
        public int Count { get; private set; }
        public LinkedListElement<T> Head { get; private set; }

        public LinkedList(T head)
        {
            Head = new LinkedListElement<T>
            {
                Value = head
            };
            Count = 1;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                var el = Head;
                for (int i = 0; i < index; i++)
                {
                    el = el.Next;
                }
                return el.Value;
            }
        }

        public void Add(T value)
        {
            var newElement = new LinkedListElement<T>
            {
                Value = value,
                Prev = Last()
            };
            Last().Next = newElement;
            Count++;
        }

        public LinkedListElement<T> Last()
        {
            var current = Head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current;
        }

        public void Reverse()
        {
            Head = Last();
            var current = Last();
            Swap(current);
            while (current.Next != null)
            {
                current = current.Next;
                Swap(current);
            }
        }

        private void Swap(LinkedListElement<T> element)
        {
            var prev = element.Prev;
            element.Prev = element.Next;
            element.Next = prev;
        }
    }
}
