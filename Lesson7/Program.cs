using System;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {

            User u1 = new User();
            User u2 = u1.GetCopy();
            //u1.Contacts.Email = "11";
            Console.WriteLine(u1.GetCopy() == u1.GetCopy());
            //Console.WriteLine(u1.Contacts == u2.Contacts);
            //Console.WriteLine(u1.Contacts.Email == u2.Contacts.Email);

            // Cell 

            Validator minLengthValidator = new Validator(CheckType.StringMinLength, 3);
            Validator noWhiteSpaceValidator = new Validator(CheckType.StringNoWhiteSpace);
            Validator firstUpperCaseValidator = new Validator(CheckType.StringFirstUpperCase);

            Validator[] defaultNameValidators = {
                minLengthValidator,
                noWhiteSpaceValidator,
                firstUpperCaseValidator
            };

            string fName = GetString("First name", defaultNameValidators);
            string lName = GetString("Last name", defaultNameValidators);

            Validator minAgeValidator = new Validator(CheckType.IntMoreOrEqualThan, 18);

            int age = GetInt("Age", minAgeValidator);

            string email = GetString("E-mail", noWhiteSpaceValidator, 
                new Validator(CheckType.StringMinLength, 6),
                new Validator(CheckType.StringContainChar, '@'));

            Contacts contacts = new Contacts(email);

            User user = new User(fName, lName, age, contacts);
        }

        static string GetString(string propName, params Validator[] validators)
        {
            bool incorrectInput = false;
            string input;
            do
            {
                incorrectInput = false;

                Console.Write($"Enter your {propName}: ");
                input = Console.ReadLine();

                foreach (var validator in validators)
                {
                    if (!validator.IsValueOk(input))
                    {
                        incorrectInput = true;
                        LogError(validator.ErrorMessage);
                    }
                }
            }
            while (incorrectInput);

            return input;
        }

        static int GetInt(string propName, params Validator[] validators)
        {
            bool incorrectInput;
            string input;
            int result;

            do
            {
                Console.Write($"Enter your {propName}: ");
                input = Console.ReadLine();

                incorrectInput = !int.TryParse(input, out result);

                if (incorrectInput)
                {
                    LogError("Not a Number!");
                }
                else
                {
                    foreach (var validator in validators)
                    {
                        if (!validator.IsValueOk(result))
                        {
                            incorrectInput = true;
                            LogError(validator.ErrorMessage);
                        }
                    }
                }
            }
            while (incorrectInput);

            return result;
        }

        static void LogError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    }
}
