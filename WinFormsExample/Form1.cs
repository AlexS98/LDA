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
                        ShowPoint(newPoint);
                    }

                    Graphics.DrawLine(greenPen, prevSinPoint.Value, newPoint);
                    prevSinPoint = newPoint;
                }
            }

            PlotAppeared = true;
        }

        private void ShowPoint(PointF point, Pen pen = null, int halfSize = 5)
        {
            Graphics.DrawEllipse(pen ?? DefaultPen, point.X - halfSize, point.Y - halfSize, halfSize * 2, halfSize * 2);
        }

        private void brnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
