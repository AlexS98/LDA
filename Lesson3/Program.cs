using System;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string name = GetName();
            //int age = GetAge();

            //Console.WriteLine($"Hello, {GetName()}, {GetAge()}!");

            int[,] matrix = new int[5, 5];
            Random r = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = r.Next(0, 15);
                }
            }

            DisplayMatrix(matrix);

            //Console.WriteLine(matrix.GetLength(2));
        }

        static string GetName()
        {
            bool incorrectName = true;
            string name;
            do
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();

                if (name.Length <= 3)
                {
                    Console.WriteLine("Error");
                    continue;
                }

                incorrectName = false;
            }
            while (incorrectName);

            return name;
        }

        static int GetAge()
        {
            bool incorrectName = true;
            int age;
            do
            {
                Console.Write("Enter your age: ");
                string ageString = Console.ReadLine();

                if (int.TryParse(ageString, out age) && age > 0)
                {
                    incorrectName = false;
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            while (incorrectName);

            return age;
        }

        static void DisplayMatrix(int[,] matrix)
        {
            string sep = new string('_', matrix.GetLength(1) * 8 + 1);

            //for (int k = 0; k < matrix.GetLength(1) * 8; k++)
            //{
            //    sep += "_";
            //}

            for (int i = 0; i < matrix.GetLength(0); i++) // [0;4]
            {
                Console.WriteLine(sep);
                for (int k = 0; k < matrix.GetLength(1); k++) // [0;14]
                {
                    Console.Write($"|{matrix[i, k]}\t");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(sep);
        }
    }
}
