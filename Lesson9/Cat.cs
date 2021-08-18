using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lesson9
{
    public class Cat : Animal, IMoveable
    {
        public Cat(string name, int age, float speed) : base(name, age)
        {
            Speed = speed;
        }

        public Vector3 Position { get; set; }
        public float Speed { get; set; }


        public override void MakeNoise()
        {
            //base.MakeNoise();
            Console.WriteLine($"Cat {Name}/{Age}: Meow");
        }

        public void Move(Vector3 newPosition)
        {
            var distance = (newPosition - Position).Length();
            var time = distance / Speed;
            Console.WriteLine($"Distance: {distance}, time: {time}");
            Position = newPosition;
        }

        public override string ToString()
        {
            return $"Cat {Name}/{Age}";
        }
    }
}
