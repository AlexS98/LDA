﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract void MakeNoise();

        public virtual void Foo()
        {

        }
    }
}
