using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6
{
    public class Cat
    {
        private string color;

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                //check(color)
                color = value;
            }
        }

        public int MyProperty { get; set; }


        //public Leg[] Legs { get; set; }
        //public Head Head { get; set; }

        //public Cat(string color, Leg[] legs, Head head)
        //{
        //    Color = color;
        //    Legs = legs;
        //    Head = head;
        //}

        public void Meow() { }
    }
}
