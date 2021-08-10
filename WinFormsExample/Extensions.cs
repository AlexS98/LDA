using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WinFormsExample
{
    public static class Extensions
    {
        public static float Distance(this PointF startPoint, PointF endPoint)
        {
            return MathF.Sqrt(MathF.Pow(startPoint.X - endPoint.X, 2) + MathF.Pow(startPoint.Y - endPoint.Y, 2));
        }
    }
}
