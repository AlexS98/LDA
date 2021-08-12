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

        public static float ToRadians(this float angleInDegrees)
        {
            return angleInDegrees * (MathF.PI / 180);
        }

        public static PointF RotatePoint(this PointF pointToRotate, PointF centerPoint, float angleInDegrees)
        {
            float angleInRadians = angleInDegrees.ToRadians();
            float cosTheta = MathF.Cos(angleInRadians);
            float sinTheta = MathF.Sin(angleInRadians);
            return new PointF
            {
                X = cosTheta * (pointToRotate.X - centerPoint.X) -
                    sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X,
                Y = sinTheta * (pointToRotate.X - centerPoint.X) +
                    cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y
            };
        }

    }
}
