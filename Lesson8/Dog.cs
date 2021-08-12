using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8
{
    public class Dog : Animal
    {
        public Dog(string name, int age) : base(name, age)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void MakeNoise()
        {
            Console.WriteLine($"Dog {Name}/{Age}: Gav");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
