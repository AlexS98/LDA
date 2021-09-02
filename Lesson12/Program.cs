using System;

namespace Lesson12
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListElement<SomeT, SomeU> listElement = new ListElement<SomeT, SomeU>();
            //SomeU some = new SomeU();
            //SomeT somem = listElement.Creator(some);

            LinkedList<string> linkedList = new LinkedList<string>("-1");
            for (int i = 0; i < 10; i++)
            {
                linkedList.Add(i.ToString());
            }

            //PrintLinkedList(linkedList);
            Console.WriteLine(linkedList[0]);
            Console.WriteLine(linkedList[10]);
            //PrintLinkedListReversed(linkedList);
            linkedList.Reverse();
            PrintLinkedList(linkedList);
        }

        static void PrintLinkedList<T>(LinkedList<T> list) where T : class
        {
            //var current = list.Head;
            //do
            //{
            //    Console.WriteLine(current);
            //    current = current.Next;
            //}
            //while (current != null);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            //foreach (var item in list)
            //{

            //}
        }

        static void PrintLinkedListReversed<T>(LinkedList<T> list) where T : class
        {
            var current = list.Last();
            do
            {
                Console.WriteLine(current);
                current = current.Prev;
            }
            while (current != null);
        }
    }
}
