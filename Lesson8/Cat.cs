using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8
{
    public class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age) { }

        public override void MakeNoise()
        {
            //base.MakeNoise();
            Console.WriteLine($"Cat {Name}/{Age}: Meow");
        }

        public override string ToString()
        {
            return $"Cat {Name}/{Age}";
        }
    }
}
