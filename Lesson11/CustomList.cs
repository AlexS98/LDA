using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson11
{
    public class CustomList<T>
    {
        public T[] Items { get; private set; }
        public int Count { get; set; }
        public int Capacity { get => Items.Length; }

        public CustomList()
        {
            Items = new T[0];
            Count = 0;
        }

        public CustomList(int capacity)
        {
            Items = new T[capacity];
            Count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException($"Max index - {Count - 1}");
                }
                return Items[index];
            }
        }

        public void Add(T item)
        {
            // add to Items
            if (Count < Capacity)
            {
                Items[Count] = item;
            }
            else
            {
                var newItems = new T[Capacity != 0 ? Capacity * 2 : 4];
                for (int i = 0; i < Items.Length; i++)
                {
                    newItems[i] = Items[i];
                }
                newItems[Items.Length] = item;
                Items = newItems;
            }
            Count++;
        }

        public void Remove(T item)
        {
            int elementIndex = 0;
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(Items[i]))
                {
                    elementIndex = i;
                    break;
                }
            }
            for (int i = elementIndex + 1; i < Count; i++)
            {
                Items[i - 1] = Items[i];
            }
            Count--;
            Items[Count] = default;
        }
    }
}
