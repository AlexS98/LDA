using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson9
{
    public class CatHouse
    {
        public Cat[] Cats { get; set; }

        public CatHouse(Cat[] cats)
        {
            Cats = cats;
        }

        public void RollCall()
        {
            foreach (var cat in Cats)
            {
                Console.WriteLine(cat.ToString());
            }
        }
    }
}
