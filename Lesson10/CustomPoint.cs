using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson10
{
    public readonly struct CustomPoint
    {
        public int X { get; }
        public int Y { get; }

        public CustomPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public float Distance(CustomPoint p2)
        {
            return 1;
        }
    }
}
