using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson10.University
{
    public class Lesson
    {
        public int Number { get; set; }
        public Course Course { get; set; }
        public Teacher Teacher { get; set; }
        public Group[] Groups { get; set; }
    }
}
