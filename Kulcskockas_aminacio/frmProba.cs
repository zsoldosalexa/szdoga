using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kulcskockas_aminacio
{
    public partial class frmProba : Form
    {
        Timer timer;
        int angle;
        int transX, transY, transWidth, transHeight, transAngle;
        double start_time, elapsed_time;
        static Rectangle r = new Rectangle(-100, -100, 50, 50);
        static Rectangle rect;
        static int kulonbsegx, kuly;
        static List<double> xCords = new List<double>();
        static List<double> yCords = new List<double>();
        static List<double> v1 = new List<double>();
        static List<double> time = new List<double>();
        static List<double> width = new List<double>();
        static List<double> v2 = new List<double>();
        static List<double> height = new List<double>();
        static List<double> v3 = new List<double>();
        static List<double> angles = new List<double>();
        static List<double> v4 = new List<double>();
        static List<double> v5 = new List<double>();

        static Point LocationXY;
        static Point LocationXY2;
        bool IsMouseDown = false;
        bool rectangleDrawed = false;
        static bool newCalculation = false;

        public frmProba()
        {
                  this.SetStyle(ControlStyles.UserPaint, true);
            //2. Enable double buffer.
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //3. Ignore a windows erase message to reduce flicker.
            this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);
            InitializeComponent();

        }

        private void frmProba_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            trackBar1.TickFrequency = 1;
            dataGridView1.Paint += new PaintEventHandler(Rectangle_Paint);
            this.Controls.Add(dataGridView1);
            angle = 0;
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            SetStyle(ControlStyles.UserPaint, true);
            elapsed_time = (DateTime.Now.Second - start_time)*2;
            if (!rectangleDrawed)
                return;
            if (angle < transAngle)
            {
                angle = (int)calc(elapsed_time, v4, time);
            }
            if (r.Height < GetRect().Height || r.Height < transHeight)
            {
                r.Height = (int)calc(elapsed_time, v3, time);
            }
            if (r.X < GetRect().X-100 || r.X < transX)
            {
                r.X = (int)calc(elapsed_time, v1, time)-100;
            }
            if (r.Y < GetRect().Y-100 || r.Y < transY)
            {
                r.Y = (int)calc(elapsed_time, v5, time)-100;
            }
            if (r.Width < GetRect().Width || r.Width < transWidth)
            {
                r.Width = (int)calc(elapsed_time, v2, time);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start_time = DateTime.Now.Second;
            SetStyle(ControlStyles.UserPaint, true);
            if (rectangleDrawed)
            {
                timer.Start();
                return;
            }
               
               try
               {
                    transX = Convert.ToInt32(txtXCord.Text);
                    transY = Convert.ToInt32(textYCord.Text);
                    transAngle = Convert.ToInt32(txtAngle.Text);
                    transWidth = Convert.ToInt32(txtWidth.Text);
                    transHeight = Convert.ToInt32(txtHeight.Text);
                    transAngle = Convert.ToInt32(txtAngle.Text);
                    rectangleDrawed = true;
                    width.Add(40);
                    width.Add(transWidth);
                    time.Add(0);
                    time.Add(20);
                    v2 = Interpolation(width, time, 0);
                    height.Add(40);
                    height.Add(transHeight);
                    v3 = Interpolation(height, time, 0);
                    xCords.Add(r.X+100);
                    xCords.Add(transX);
                    v1 = Interpolation(xCords, time, 0);
                    yCords.Add(r.Y+100);
                    yCords.Add(transY);
                    v5 = Interpolation(yCords, time, 0);
                    angles.Add(0);
                    angles.Add(transAngle);
                    v4 = Interpolation(angles, time, 0);
                }
               catch (Exception ex)
               {
                   MessageBox.Show("Nem megfelelő formátumú paraméterek!");
               }
            timer.Start();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

         //   MessageBox.Show(trackBar1.Value.ToString());
            r.Width = trackBar1.Value * r.Width;
            r.Height = trackBar1.Value * r.Height;
            int s = trackBar1.Value;
            if (r.Y < GetRect().Y - 100)
            {
                r.Y = s - 100;
                r.X = (int)calc(r.Y, v1, yCords);
            }
            this.Invalidate();
            r.Width = 10 + trackBar1.Value;
            r.Height = 10 + trackBar1.Value;
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            IsMouseDown = true;

            LocationXY = e.Location;
        }

        private void Rectangle_Paint(object sender, PaintEventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            Graphics g = this.dataGridView1.CreateGraphics();
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TranslateTransform(100, 100);
            g.RotateTransform(angle);
            g.FillRectangle(blueBrush, r);
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            if (IsMouseDown == true)
            {
                LocationXY2 = e.Location;

                Refresh();
            }
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            if (IsMouseDown == true)
            {
                LocationXY2 = e.Location;

                IsMouseDown = false;
            }
            rectangleDrawed = true;
            width.Add(40);
            width.Add(GetRect().Width);
            time.Add(0);
            time.Add(20);
            v2 = Interpolation(width, time, 0);
            height.Add(40);
            height.Add(GetRect().Height);
            v3 = Interpolation(height, time, 0);
            xCords.Add(r.X + 100);
            xCords.Add(GetRect().X);
            v1 = Interpolation(xCords, time, 0);
            yCords.Add(r.Y + 100);
            yCords.Add(GetRect().Y);
            v5 = Interpolation(yCords, time, 0);
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            if (rect != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRect());
            }
        }

        private static Rectangle GetRect()
        {
            rect = new Rectangle();

            rect.X = LocationXY.X;
            rect.Y = LocationXY.Y;
            rect.Width = Math.Abs(LocationXY.X - LocationXY2.X);
            rect.Height = Math.Abs(LocationXY.Y - LocationXY2.Y);
            kulonbsegx = rect.Width - r.Width;
            kuly = rect.Height - r.Height;
            return rect;

        }
        static List<double> Interpolation(List<double> x, List<double> y, int k)
        {
            List<double> result = new List<double>();
  /*          if (newCalculation)
            {
                result.Clear();
            }*/
            result.Add(x[0]);
            var a = new List<double>();
            for (int i = 1; i < x.Count; i++)
            {
                a.Add((x[i] - x[i - 1]) / (y[i + k] - y[i - 1]));
            }
            if (a.Count > 1)
            {
                var b = Interpolation(a, y, ++k);
            }
            else
            {
                result.Add(a[0]);
            }
            return result;
        }
        double calc(double k, List<double> res, List<double> y)
        {
            double result = res[0];
            for (int i = 1; i < res.Count; i++)
            {
                double szorzo = 1;
                for (int j = 0; j < i; j++)
                {
                    szorzo *= (k - y[j]);
                }
                result += res[i] * szorzo;
            }
            return result;

        }
    }
}
