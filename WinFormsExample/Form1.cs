using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsExample
{
    public partial class Form1 : Form
    {
        public Graphics Graphics { get; set; }
        public Pen DefaultPen { get; set; }
        public Point LastClick { get; set; }
        public bool PlotAppeared { get; set; }
        public Brush DefaultBrush { get; set; }

        public Form1()
        {
            InitializeComponent();

            Graphics = this.CreateGraphics();

            // set center to center of form (by default - upper left corner)
            Graphics.TranslateTransform(Width / 2, Height / 2);

            DefaultPen = new Pen(Color.Red, 3);

            EventHandler onScrollChanged = delegate (object sender, EventArgs e) 
            {
                int lastCypher = (int)numericUpDown1.Value % 10;
                if (lastCypher != 0)
                {
                    numericUpDown1.Value -= lastCypher;
                }

                if (PlotAppeared)
                {
                    Clear();
                    DrawSinPlot((float)numericUpDown1.Value);
                }
            };

            numericUpDown1.ValueChanged += onScrollChanged;

            DefaultBrush = Brushes.Black;
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Graphics = CreateGraphics();
            Graphics.TranslateTransform(Width / 2, Height / 2);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            var mouseClick = e as MouseEventArgs;

            Point coordsInOurSystem = new Point(mouseClick.Location.X - Width / 2, mouseClick.Location.Y - Height / 2);
            if (!PlotAppeared)
            {
                Graphics.DrawLine(DefaultPen, LastClick, coordsInOurSystem);
            }
            else
            {
                MessageBox.Show($"Mouse click coords: {mouseClick.Location}{Environment.NewLine}Our click coords: {coordsInOurSystem}");
            }

            LastClick = coordsInOurSystem;
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            Clear();
            DrawSinPlot((float)numericUpDown1.Value);
        }        

        private void Clear()
        {
            Graphics.Clear(DefaultBackColor);
            PlotAppeared = false;
            // reset to form center
            LastClick = new Point();
        }

        private void DrawSinPlot(float scale)
        {
            var scaleInt = (int) scale; 
            var blackPen = new Pen(Color.Black, 3);
            var greenPen = new Pen(Color.Green, 5);
            var blackPenThin = new Pen(Color.Black, 2);

            Graphics.DrawLine(blackPen, 0, -(Height / 2), 0, Height / 2);
            Graphics.DrawLine(blackPen, -(Width / 2), 0, Width / 2, 0);

            PointF? prevSinPoint = null;

            int size = scaleInt >= 70 ? 7 : scaleInt >= 30 ? 4 : 3;

            for (int i = -(Height / 2); i < Height / 2; i += 1)
            {
                if (i % scaleInt == 0)
                {
                    Graphics.DrawLine(blackPen, size, i, -size, i);
                    if (scaleInt >= 30 && i / scaleInt != 0)
                    {
                        Graphics.DrawString((i / scaleInt).ToString(), DefaultFont, DefaultBrush, new Point(7, i));
                    }
                }
                else if (scaleInt >= 100 && i % (scaleInt / 10) == 0)
                {
                    Graphics.DrawLine(blackPenThin, -3, i, 3, i);
                }
            }

            for (int i = -(Width / 2); i < Width / 2; i += 1)
            {
                if (i % scaleInt == 0)
                {
                    Graphics.DrawLine(blackPen, i, -size, i, size);
                    if (scaleInt >= 30)
                    {
                        Graphics.DrawString((i / scaleInt).ToString(), DefaultFont, DefaultBrush, new Point(i, 7));
                    }
                } 
                else if (scaleInt >= 100 && i % (scaleInt / 10) == 0)
                {
                    Graphics.DrawLine(blackPenThin, i, -3, i, 3);
                }

                PointF newPoint = new PointF(i, scale * MathF.Sin(-(i / scale)));
                if (prevSinPoint == null)
                {
                    prevSinPoint = newPoint;
                }
                else
                {
                    if (MathF.Abs(MathF.Abs(newPoint.Y) - scale) <= 0.15 / scale)
                    {
                        ShowPoint(points: newPoint);
                    }

                    Graphics.DrawLine(greenPen, prevSinPoint.Value, newPoint);
                    prevSinPoint = newPoint;
                }
            }

            PlotAppeared = true;
        }

        private void ShowPoint(Pen pen = null, int halfSize = 5, params PointF[] points)
        {
            foreach (var point in points)
            {
                Graphics.DrawEllipse(pen ?? DefaultPen, point.X - halfSize, point.Y - halfSize, halfSize * 2, halfSize * 2);
            }
        }

        private void brnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnTree_Click(object sender, EventArgs e)
        {
            Clear();
            PointF startPoint = new PointF(0, 300);
            PointF endPoint = new PointF(0, 0);
            DrawTree(startPoint, endPoint, (int)numericUpDown2.Value);
        }

        private void DrawTree(PointF startPoint, PointF endPoint, int deep)
        {
            var greenPen = new Pen(Color.Green, 1);

            float length = startPoint.Distance(endPoint);
            PointF shortChild, rightChild, leftChild, centralChild, sLeftChild, sRightChild, sCentralChild;

            float childLength = length / 2;

            if (deep != (int)numericUpDown2.Value && length > 1)
            {
                Graphics.DrawLine(greenPen, startPoint, endPoint);
            }
            else
            {
                PlotAppeared = true;
            }

            shortChild = new PointF(endPoint.X + (endPoint.X - startPoint.X) / 2, endPoint.Y + (endPoint.Y - startPoint.Y) / 2);
            centralChild = new PointF(endPoint.X + (endPoint.X - startPoint.X) / 2, endPoint.Y + (endPoint.Y - startPoint.Y) / 2);
            sCentralChild = RotatePoint(shortChild, endPoint, 180);
            leftChild = RotatePoint(centralChild, endPoint, -120);
            rightChild = RotatePoint(centralChild, endPoint, 120);
            sLeftChild = RotatePoint(shortChild, endPoint, -60);
            sRightChild = RotatePoint(shortChild, endPoint, 60);

            if (deep != 0)
            {
                DrawTree(endPoint, centralChild, deep - 1);
                DrawTree(endPoint, rightChild, deep - 1);
                DrawTree(endPoint, leftChild, deep - 1);

                DrawTree(endPoint, sCentralChild, deep - 1);
                DrawTree(endPoint, sRightChild, deep - 1);
                DrawTree(endPoint, sLeftChild, deep - 1);
            }
            else if (length > 1)
            {
                Graphics.DrawLine(greenPen, endPoint, rightChild);
                Graphics.DrawLine(greenPen, endPoint, centralChild);
                Graphics.DrawLine(greenPen, endPoint, leftChild);

                Graphics.DrawLine(greenPen, endPoint, sRightChild);
                Graphics.DrawLine(greenPen, endPoint, sCentralChild);
                Graphics.DrawLine(greenPen, endPoint, sLeftChild);
            }
        }

        private float ToRadians(float angleInDegrees)
        {
            return angleInDegrees * (MathF.PI / 180);
        }

        private PointF RotatePoint(PointF pointToRotate, PointF centerPoint, float angleInDegrees)
        {
            float angleInRadians = ToRadians(angleInDegrees);
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
