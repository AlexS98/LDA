using System;

namespace Lesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal cat1 = new Cat("Tom", 10);
            Animal dog1 = new Dog("Bob", 5);

            //(dog1 as Cat)?.Eat();

            //if (cat1 is Cat realCat)
            //{
            //    realCat.Eat();
            //}

            //if (dog1 is Cat)
            //{
            //    //.Eat();
            //}

            cat1.MakeNoise();
            dog1.MakeNoise();

            //int[] array = new int[5];

            CatHouse house = new CatHouse(new Cat[5]);

            for (int i = 0; i < house.Cats.Length; i++)
            {
                house.Cats[i] = new Cat($"Cat{i}", i + 1);
            }

            house.RollCall();
        }

        private void ArrayProblem()
        {
            int[] a1 = { 1, 2, 3, 4, 5 };
            int[] a2 = a1;
            int[] a3 = Copy(a1);

            int i1 = 1;
            int i2 = i1;

            Console.WriteLine(i1 == i2);

            //ShowArray(array);
            //ShowArray(a2);
            //ShowArray(a3);

            //a2[3] = -1;

            ShowArray(a1);
            ShowArray(a2);
            ShowArray(a3);

            Console.WriteLine(a1 == a2);
            Console.WriteLine(a1 == a3);
        }

        private static int[] Copy(int[] array)
        {
            int[] result = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i];
            }

            return result;
        }

        private static void ShowArray(int[] a)
        {
            foreach (var item in a)
            {
                Console.Write($"{item}; ");
            }
            Console.WriteLine();
        }
    }
}
