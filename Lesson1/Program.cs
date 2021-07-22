using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (false)
            {
                Console.Clear();
                Console.WriteLine("Calculator");

                Console.Write("First: ");
                bool s1 = int.TryParse(Console.ReadLine(), out int number1);
                
                Console.Write("Second: ");
                bool s2 = int.TryParse(Console.ReadLine(), out int number2);

                Console.Write("Operation: ");

                string op = Console.ReadLine();
                string result = "Result: ";
                string errorMessage = "";

                if (!(s1 && s2))
                {
                    errorMessage += "Incorrect input; ";
                }

                if (op == "*")
                {
                    result += number1 * number2;
                }
                else if (op == "+")
                {
                    result += number1 + number2;
                }
                else if (op == "-")
                {
                    result += number1 - number2;
                }
                else if (op == "/" && number2 != 0)
                {
                    result += number1 / number2;
                }
                else
                {
                    errorMessage += "Incorrect operation; ";
                }

                if (errorMessage.Length == 0)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine(result);
                    Console.WriteLine(errorMessage);
                }

                Console.WriteLine("Press ESC to exit.");
                ConsoleKeyInfo input = Console.ReadKey();

                if (input.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }

            int number = 1;

            //do
            //{
            //    Console.WriteLine(++number);
            //    // number++; // number += 1; // number = number + 1;
            //}
            //while (number < 11);

            ////for (;;)
            {
                //Console.WriteLine(number);
                number -= 2;

                //if (number <= -10)
                //{
                //    break;
                //}
            }

            int[] intArray = new int[15];

            intArray[0] = 15;
            //intArray[25] = 0; - ERROR

            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = i + 1;
            }

            for (int i = 0; i < intArray.Length; i++)
            {
                if (i % 2 == 1)
                {
                    continue;
                }

                Console.WriteLine(intArray[i]);
            }

            foreach (int item in intArray)
            {
                //if (i % 2 == 1)
                //{
                //    continue;
                //}

                Console.WriteLine(item);
            }

            string b = "Bye-bye"; // var b;

            Console.WriteLine(b);
        }
    }
}
