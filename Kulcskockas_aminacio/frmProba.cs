using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

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
        static List<double> result = new List<double>();
        static List<Rectangle> rectangles = new List<Rectangle>();
        static Point LocationXY;
        static Point LocationXY2;
        bool IsMouseDown = false;
        bool IsMouseUp = false;
        bool rectangleDrawed = false;
        PointPairList widthPoints = new PointPairList();
        PointPairList heightPoints = new PointPairList();
        PointPairList xPoints = new PointPairList();
        PointPairList yPoints = new PointPairList();
        PointPairList anglePoints = new PointPairList();

        static int ms=0;
        static int rajzoltTeglalapokSzama = 0;

        public frmProba()
        {
                  this.SetStyle(ControlStyles.UserPaint, true);
            //2. Enable double buffer.
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //3. Ignore a windows erase message to reduce flicker.
            this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);
            InitializeComponent();
            rajzoltTeglalapokSzama = 0;


        }
        private void NewStart()
        {
            r = new Rectangle(-100, -100, 50, 50);
            xCords = new List<double>();
            yCords = new List<double>();
            v1 = new List<double>();
            time = new List<double>();
            width = new List<double>();
            v2 = new List<double>();
            height = new List<double>();
            v3 = new List<double>();
            angles = new List<double>();
            v4 = new List<double>();
            v5 = new List<double>();
            rectangleDrawed = false;
            rectangles.Clear();

        }
        private void frmProba_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            this.Controls.Add(dataGridView1);
            angle = 0;
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (ms == time.Max())
            {
                timer.Stop();
            }
            ms++;
            this.Refresh();
            SetStyle(ControlStyles.UserPaint, true);
            if (!rectangleDrawed)
                return;
            if (v4.Count != 0)
            {
                angle = (int)calc(ms, v4, time);
            }
       //     if (r.Height < GetRect().Height || r.Height < transHeight)
                r.Height = (int)calc(ms, v3, time);
        //    if (r.X < GetRect().X-100 || r.X < transX)            
                r.X = (int)calc(ms, v1, time)-100;            
         //   if (r.Y < GetRect().Y-100 || r.Y < transY)            
                r.Y = (int)calc(ms, v5, time)-100;            
         //   if (r.Width < GetRect().Width || r.Width < transWidth)            
                r.Width = (int)calc(ms, v2, time);
            anglePoints.Add(ms, angle);
            heightPoints.Add(ms, r.Height);
            xPoints.Add(ms, r.X + 100);
            yPoints.Add(ms, r.Y + 100);
            widthPoints.Add(ms, r.Width);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start_time = DateTime.Now.Second;
            SetStyle(ControlStyles.UserPaint, true);
            PointPairList heightPoints = new PointPairList();
            if (rectangleDrawed)
            {
                v1 = Interpolation(xCords, time, 0).ToList();
                result.Clear();
                v2 = Interpolation(width, time, 0).ToList();
                result.Clear();
                v3 = Interpolation(height, time, 0).ToList();
                result.Clear();
                v5 = Interpolation(yCords, time, 0).ToList();
                result.Clear();
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
                    rectangleDrawed = true;
                    width.Add(40);
                    width.Add(transWidth);
                    time.Add(0);
                    time.Add(40);
                    v2 = Interpolation(width, time, 0).ToList();
                    result.Clear();
                    height.Add(40);
                    height.Add(transHeight);
                    v3 = Interpolation(height, time, 0).ToList();
                    result.Clear();
                    xCords.Add(r.X+100);
                    xCords.Add(transX);
                    v1 = Interpolation(xCords, time, 0).ToList();
                    result.Clear();
                    yCords.Add(r.Y+100);
                    yCords.Add(transY);
                    v5 = Interpolation(yCords, time, 0).ToList();
                    result.Clear();
                    angles.Add(0);
                    angles.Add(transAngle);
                    v4 = Interpolation(angles, time, 0).ToList();
                    result.Clear();
            }
               catch (Exception ex)
               {
                   MessageBox.Show("Nem megfelelő formátumú paraméterek!");
               }
            timer.Start();

        } 

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            rajzoltTeglalapokSzama++;
            SetStyle(ControlStyles.UserPaint, true);
            IsMouseDown = true;

            LocationXY = e.Location;
        }

        private void frmProba_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            r = new Rectangle(-100, -100, 50, 50);
            xCords = new List<double>();
            yCords = new List<double>();
            v1 = new List<double>();
            time = new List<double>();
            width = new List<double>();
            v2 = new List<double>();
            height = new List<double>();
            v3 = new List<double>();
            angles = new List<double>();
            v4 = new List<double>();
            v5 = new List<double>();
            rectangleDrawed = false;
            rectangles.Clear();
            rect = new Rectangle();
            ms = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
              frmParamChanged frm = new frmParamChanged(widthPoints, heightPoints, xPoints, yPoints, anglePoints);
              frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmImageMove frm = new frmImageMove(v1, v2, v3, v4, v5);
            frm.Show();
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
            if (!rectangleDrawed)
            {
                width.Add(40);
                height.Add(40);
                xCords.Add(r.X + 100);
                yCords.Add(r.Y + 100);
                time.Add(0);
            }
            width.Add(GetRect().Width);
            time.Add(20 * rajzoltTeglalapokSzama);
            height.Add(GetRect().Height);
            xCords.Add(GetRect().X);
            yCords.Add(GetRect().Y);
            rectangleDrawed = true;
            IsMouseUp = true;
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            Graphics g = this.dataGridView1.CreateGraphics();
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TranslateTransform(100, 100);
            g.RotateTransform(angle);
            g.FillRectangle(blueBrush, r);

            if (rajzoltTeglalapokSzama == 0)
                return;
            if (rect != null)
            {
                rectangles.Add(GetRect());
            }
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            foreach(Rectangle _rect in rectangles)
            {
                e.Graphics.DrawRectangle(Pens.Red, _rect);
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
