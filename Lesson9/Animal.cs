using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lesson9
{
    public abstract class Animal : IPositionHolder
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Vector3 Position { get; set; }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract void MakeNoise();
    }
}
