using System;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (var item in args)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadLine();

            Car[] cars = new Car[5];

            for (int i = 0; i < cars.Length; i++)
            {
                cars[i] = new Car("red", i + 1);
            }

            Console.Write("");

            Car.LogCap();

            foreach (var item in cars)
            {
                item.Beep();
            }

            Console.ReadLine();
        }
    }
}
