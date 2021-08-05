using System;
using System.Linq;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            int[,] field = new int[5, 5];

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    field[i, k] = 0;
                }
            }

            field[1, 1] = 7;

            while (false)
            {
                Render(field);

                int direct = GetDirection();

                Move(field, direct);
            }

            //Console.WriteLine(FactorNoRec(5));

            var array = new int[,] { 
                { 5, 1, 2, 8, 99, 10 }, 
                { 5, 1, 2, 8, 10, 5 } 
            };

            Console.WriteLine(Max(15, 100, -10, 0));

            Console.WriteLine(double.IsNaN(double.NaN));

            // 1
            int someVar = array[0, 0] > 0 && array[0, 1] > 0 ? Factor(array[0, 0]) : array[0, 1]; // > 0
                    //? Factor(array[0, 1])
                    //: -15;

            // 2
            int someVar1;
            if (array[0, 0] > 0 && array[0, 1] > 0)
            {
                someVar1 = Factor(array[0, 0]);
            }
            else
            {
                if (array[0, 1] > 0)
                {
                    someVar1 = Factor(array[0, 1]);
                }
                else
                {
                    someVar1 = -15;
                }
            }

            // 3
            if (array[0, 0] > 0 && array[0, 1] > 0)
            {
                someVar1 = Factor(array[0, 0]);
            }
            else if (array[0, 1] > 0)
            {
                someVar1 = Factor(array[0, 1]);
            }
            else
            {
                someVar1 = -15;
            }
        }

        static int Factor(int value)
        {
            if (value <= 1)
            {
                return value;
            }

            return value * Factor(value - 1);
        }

        static int FactorNoRec(int value)
        {
            int result = 1;
            for (int i = 1; i <= value; i++)
            {
                result *= i;
            }
            return result;
        }

        static void Render(int[,] field)
        {
            Console.Clear();

            string sep = new string('_', field.GetLength(1) * 8 + 1);

            for (int i = 0; i < field.GetLength(0); i++) 
            {
                Console.WriteLine(sep);
                for (int k = 0; k < field.GetLength(1); k++) 
                {
                    Console.Write($"|{GetCellView(field[i, k])}\t");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(sep);
        }

        static string GetCellView(int value)
        {
            string player = "☻";
            switch (value)
            {
                case 7:
                    return player;
                default:
                    return "";
            }
        }

        // w - 0, a - 1, s - 2, d - 3

        static int GetDirection()
        {
            ConsoleKey[] possibleKeys = { ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D };

            do {
                Console.Write("Input direction: ");
                ConsoleKeyInfo input = Console.ReadKey();
                Console.WriteLine();

                for (int i = 0; i < possibleKeys.Length; i++)
                {
                    if (input.Key == possibleKeys[i])
                    {
                        return i;
                    }
                }

                Console.WriteLine("Wrong input.");
            }
            while (true);
        }

        static void Move(int[,] field, int direct)
        {
            int x = -1, y = -1;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    if (field[i, k] == 7)
                    {
                        x = i;
                        y = k;
                        break;
                    }
                }

                if (x >= 0)
                {
                    break;
                }
            }

            field[x, y] = 0;

            switch (direct)
            {
                case 0 when x > 0: // u
                    x--;
                    break;
                case 1 when y > 0: // l
                    y--;
                    break;
                case 2 when x < field.GetLength(0) - 1: // d
                    x++;
                    break;
                case 3 when y < field.GetLength(1) - 1: // r
                    y++;
                    break;
            }

            field[x, y] = 7;
        }

        static int GetNumber(string message = "Enter number: ")
        {
            bool incorrectName = true;
            int age;
            do
            {
                Console.Write(message);
                string ageString = Console.ReadLine();

                if (int.TryParse(ageString, out age))
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
    
        static double Max(params double[] values)
        {
            if (values.Length < 1)
            {
                return double.NaN;
            }

            double result = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                if(result < values[i])
                {
                    result = values[i];
                }
            }
            return result;
        }
    }
}
