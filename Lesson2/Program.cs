using System;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
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

            switch (op)
            {
                case "*":
                    result += number1 * number2;
                    break;
                case "+":
                    result += number1 + number2;
                    break;
                case "-":
                    result += number1 - number2;
                    break;
                case "/" when number2 != 0:
                    result += number1 / number2;
                    break;
                default:
                    errorMessage += "Incorrect operation; ";
                    break;
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
        }
    }
}
