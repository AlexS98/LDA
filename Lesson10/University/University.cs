using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson10.University
{
    public class University
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public Student[] Students { get; set; }
        public Teacher[] Teachers { get; set; }
        public Course[] Courses { get; set; }
        public Group[] Groups { get; set; }
    }
}
