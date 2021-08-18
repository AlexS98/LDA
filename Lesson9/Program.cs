using System;
using System.Numerics;

namespace Lesson9
{
    class Program
    {
        static void Main(string[] args)
        {
            //IMoveable moveable = new IMoveable();
            IMoveable cat = new Cat("Tom", 10, 1);

            
            cat.Move(new Vector3(1, 1, 0));
            cat.Move(new Vector3(-1, -1, 0));

            if (cat is Cat fullCat)
            {
                //fullCat.Position;
                fullCat.MakeNoise();
            }
        }
    }
}
