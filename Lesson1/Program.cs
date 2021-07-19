using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Part1
            //Console.Write("Enter your name: ");
            //string nameOfUser = Console.ReadLine();

            //Console.Write("Enter your age: ");
            //string ageString = Console.ReadLine();

            //int age = 25;

            ////age = int.Parse(ageString);

            ////bool success = int.TryParse(ageString, out age);

            ////bool failed = success == false;

            //if (int.TryParse(ageString, out age))
            //{
            //    Console.WriteLine("Hello, " + nameOfUser + ", " + age + "!");
            //}
            //else
            //{
            //    Console.WriteLine("ERROR!");
            //}
            #endregion

            while (true)
            {
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

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
