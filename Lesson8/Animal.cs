using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8
{
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void MakeNoise()
        {
            Console.WriteLine("Default MakeNoise");
        }
    }
}
