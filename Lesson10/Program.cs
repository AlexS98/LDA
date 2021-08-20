using System;

namespace Lesson10
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomPoint point = new CustomPoint();

            User[] users = new User[10];

            for (int i = 0; i < users.Length; i++)
            {
                try
                {
                    try
                    {
                        Console.Write($"{i + 1} User creation: ");
                        users[i] = UserCreator($"User{i + 1}", (i + 1) * 10);
                        Console.WriteLine("User created!");
                    }
                    catch (UserEmptyException e)
                    {
                        users[i] = e.User;
                        throw new Exception("Error: User thrown by Exception!", e);
                    }
                    finally
                    {
                        Console.WriteLine("Finally block");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(((Exception)e.InnerException).Message + " " + e.Message);
                }
            }

            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine(users[i].ToString());
            }
        }

        static User UserCreator(string name, int age)
        {
            Random r = new Random();
            int randomValue = r.Next(2);

            if (randomValue != 0)
            {
                return new User(name, age);
            }

            throw new UserEmptyException(new User(name, age));
        }
    }
}
