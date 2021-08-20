using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson10.University
{
    public class Grade
    {
        public Lesson Lesson { get; set; }
        public Student Student { get; set; }
        public int Mark { get; set; }
        public string Notes { get; set; }
    }
}
