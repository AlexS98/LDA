using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson10.University
{
    public class Group
    {
        public int Identifier { get; set; }
        public Marks Marks { get; set; }
        public Student[] Students { get; set; }
        public Teacher Curator { get; set; }

        public Group(int identifier, Student[] students, Teacher curator)
        {
            Identifier = identifier;
            Students = students;
            Curator = curator;
            Marks = new Marks
            {
                Grades = new Grade[1000],
                Responsible = students[0]
            };
        }
    }
}
