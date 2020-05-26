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
    public partial class frmKulcskockasAnimacio : Form
    {
        Timer timer;
        int angle;
        int transX, transY, transWidth, transHeight, transAngle;
        static Rectangle rectangle = new Rectangle(-100, -100, 40, 40);
        static Rectangle rect;
        static int difWidth, difHeight;
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
        PointPairList widthPointsSpline = new PointPairList();
        PointPairList heightPointsSpline = new PointPairList();
        PointPairList xPointsSpline = new PointPairList();
        PointPairList yPointsSpline = new PointPairList();
        PointPairList anglePointsSpline = new PointPairList();
        bool withoutMouse = false;
        static List<int> widthSpline, heightSpline, xCoordsSpline, yCoordsSpline;

        static int ms=0;
        static int rajzoltTeglalapokSzama = 0;
        Color rectangleColor = Color.Blue;

        public frmKulcskockasAnimacio()
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
            timer.Stop();
            transAngle = 0;
            rectangleColor = Color.Blue;
            rectangle = new Rectangle(-100, -100, 40, 40);
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
            dataGridView1.ClearSelection();
            Graphics g = this.dataGridView1.CreateGraphics();
            SolidBrush blueBrush = new SolidBrush(rectangleColor);
            g.TranslateTransform(100, 100);
            g.FillRectangle(blueBrush, rectangle);
            rajzoltTeglalapokSzama = 0;
            dataGridView1.Refresh();
            result.Clear();
        }
        private void frmKulcskockasAnimacio_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            this.Controls.Add(dataGridView1);
            angle = 0;
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1;
        }
        List<int> SplineInterpolation(List<double> xCords,List<double> yCords)
        {
            List<int> _pointPairList = new List<int>();
            bubblesort(ref yCords, ref xCords);
            for (int i = 1; i < xCords.Count; i++)
            {
                int n = 0;
                result.Clear();
                List<double> splineResult = new List<double>();
                List<double> x = new List<double>();
                List<double> y = new List<double>();
                x.Add(xCords[i - 1]);
                x.Add(xCords[i]);
                y.Add(yCords[i - 1]);
                y.Add(yCords[i]);
                splineResult = Interpolation(x, y, 0).ToList();
                if (i == xCords.Count - 1)
                {
                    n = (int)y.Max() + 1;
                }
                else
                {
                    n = (int)y.Max();
                }

                for (int j = (int)Math.Floor(y[0]); j <= y[1]; j++)
                {
                    _pointPairList.Add(0);
                    _pointPairList[j] = (int)calc(j, splineResult, y);
                }
            }
            return _pointPairList;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            SetStyle(ControlStyles.UserPaint, true);
            if (!rectangleDrawed)
                return;
            if (rbNewton.Checked)
            {
                if (v4.Count != 0)
                {
                    angle = (int)calc(ms, v4, time);
                }
                if (calc(ms, v3, time) < 0 || calc(ms, v2, time) < 0)
                {
                    rectangleColor = Color.Green;
                }
                else
                {
                    rectangleColor = Color.Blue;
                }
                rectangle.X = (int)calc(ms, v1, time) - 100;
                rectangle.Y = (int)calc(ms, v5, time) - 100;
                rectangle.Height = Math.Abs((int)calc(ms, v3, time));
                rectangle.Width = Math.Abs((int)calc(ms, v2, time));
            }
                if (v4.Count != 0)
                {
                    anglePoints.Add(ms, (int)calc(ms, v4, time));
                }
                heightPoints.Add(ms, Math.Abs((int)calc(ms, v3, time)));
                xPoints.Add(ms, (int)calc(ms, v1, time));
                yPoints.Add(ms, (int)calc(ms, v5, time));
                widthPoints.Add(ms, Math.Abs((int)calc(ms, v2, time)));
            if (rbSpline.Checked)
            {
                rectangle.Height = heightSpline[ms];
                rectangle.Width = widthSpline[ms];
                rectangle.X = xCoordsSpline[ms] - 100;
                rectangle.Y = yCoordsSpline[ms] - 100;

                widthPointsSpline.Add(ms, widthSpline[ms]);
                heightPointsSpline.Add(ms, heightSpline[ms]);
                xPointsSpline.Add(ms, xCoordsSpline[ms]);
                yPointsSpline.Add(ms, yCoordsSpline[ms]);
            }
            if (ms > time.Max())
            {
                timer.Stop();
                btnImageMove.Enabled = true;
                btnParameters.Enabled = true;
            }
            ms++;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (xCords.Count==0 || width.Count==0 || height.Count==0 || yCords.Count == 0)
            {
                MessageBox.Show("Hiányzó paraméter!");
                return;
            }
            SetStyle(ControlStyles.UserPaint, true);
            PointPairList heightPoints = new PointPairList();
            if (rectangleDrawed)
            {
             //   if (newton.Checked)
                {
                    v1 = Interpolation(xCords, time, 0).ToList();
                    result.Clear();
                    v2 = Interpolation(width, time, 0).ToList();
                    result.Clear();
                    v3 = Interpolation(height, time, 0).ToList();
                    result.Clear();
                    v5 = Interpolation(yCords, time, 0).ToList();
                    result.Clear();
                    if (angles.Count != 0)
                    {
                        v4 = Interpolation(angles, time, 0).ToList();
                    }
                    result.Clear();
                    widthSpline = SplineInterpolation(width, time);
                    heightSpline = SplineInterpolation(height, time);
                    xCoordsSpline = SplineInterpolation(xCords, time);
                    yCoordsSpline = SplineInterpolation(yCords, time);
                    timer.Start();
                    return;
                }
          //      if (spline.Checked)
                {

                }
            }
               
                    width.Add(40);
                    width.Add(transWidth);
                    time.Add(0);
                    if (radioButton1.Checked)
                    {
                        time.Add(20);
                    }
                    else
                    {
                        time.Add(40);
                    }
                    v2 = Interpolation(width, time, 0).ToList();
                    result.Clear();
                    height.Add(40);
                    height.Add(transHeight);
                    v3 = Interpolation(height, time, 0).ToList();
                    result.Clear();
                    xCords.Add(rectangle.X+100);
                    v1 = Interpolation(xCords, time, 0).ToList();
                    result.Clear();
                    yCords.Add(rectangle.Y+100);
                    yCords.Add(transY);
                    v5 = Interpolation(yCords, time, 0).ToList();
                    result.Clear();
                    angles.Add(0);
                    angles.Add(transAngle);
                    v4 = Interpolation(angles, time, 0).ToList();
                    result.Clear();
            timer.Start();

        } 

     /*   private List<double> splineInterpolation(List<double> xCords, List<double> yCords)
        {
            for (int i = 1; i < xCords.Count; i++)
            {
                List<double> spline = new List<double>();
                List<double> x = new List<double>();
                List<double> y = new List<double>();
                x.Add(xCords[i - 1]);
                x.Add(xCords[i]);
                y.Add(yCords[i - 1]);
                y.Add(yCords[i]);
                spline = Interpolation(x, y, 0).ToList();
                result.Clear();
            }
        }*/
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            withoutMouse = false;
            rajzoltTeglalapokSzama++;
            SetStyle(ControlStyles.UserPaint, true);
            IsMouseDown = true;

            LocationXY = e.Location;
        }

        private void frmKulcskockasAnimacio_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            rectangle = new Rectangle(-100, -100, 40, 40);
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

        private void btnParameters_Click(object sender, EventArgs e)
        {
              frmParamChanged frm = new frmParamChanged(widthPoints, heightPoints, xPoints, yPoints, anglePoints, widthPointsSpline, heightPointsSpline, xPointsSpline, yPointsSpline,(int)time.Max());
              frm.Show();
        }

        private void btnImageMove_Click(object sender, EventArgs e)
        {
            frmImageMove frm = new frmImageMove(v1, v2, v3, v4, v5);
            frm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                withoutMouse = true;
                transX = Convert.ToInt32(txtXCord.Text);
                transY = Convert.ToInt32(textYCord.Text);
                transAngle = Convert.ToInt32(txtAngle.Text);
                transWidth = Convert.ToInt32(txtWidth.Text);
                transHeight = Convert.ToInt32(txtHeight.Text);
                rectangleDrawed = true;
                if (transX+transWidth > 520 || transY + transHeight > 400)
                {
                    MessageBox.Show("A kulcskocka a felületen kívülre esik.");
                    return;
                }
                if (rajzoltTeglalapokSzama == 0)
                {
                    time.Add(0);
                    xCords.Add(rectangle.X + 100);
                    yCords.Add(rectangle.Y + 100);
                    width.Add(40);
                    height.Add(40);
                    angles.Add(0);
                }
                xCords.Add(transX);
                yCords.Add(transY);
                width.Add(transWidth);
                height.Add(transHeight);
                angles.Add(transAngle);
                rajzoltTeglalapokSzama++;
                time.Add(20 * rajzoltTeglalapokSzama);
                Rectangle rectangleByNumbers = new Rectangle(transX, transY, transWidth, transHeight);
                rectangles.Add(rectangleByNumbers);
                dataGridView1.Refresh();
                txtXCord.Clear();
                textYCord.Clear();
                txtAngle.Clear();
                txtWidth.Clear();
                txtHeight.Clear();
                MessageBox.Show("Kulcskokcka hozzáadva!");
            }
            catch (Exception)
            {
                MessageBox.Show("Nem megfelelő paraméterek!");
            }
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            NewStart();
            SetStyle(ControlStyles.UserPaint, true);
            this.Controls.Add(dataGridView1);
            angle = 0;
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1;
            Graphics g = this.dataGridView1.CreateGraphics();
            SolidBrush blueBrush = new SolidBrush(rectangleColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TranslateTransform(100, 100);
            g.RotateTransform(angle);
            g.FillRectangle(blueBrush, rectangle);
            MessageBox.Show("Kulcskockák törölve!");
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
                xCords.Add(rectangle.X + 100);
                yCords.Add(rectangle.Y + 100);
                time.Add(0);
            }
            width.Add(GetRect().Width);
            time.Add(20 * rajzoltTeglalapokSzama);
            height.Add(GetRect().Height);
            xCords.Add(GetRect().X);
            yCords.Add(GetRect().Y);
            rectangleDrawed = true;
            IsMouseUp = true;
            rectangles.Add(new Rectangle(GetRect().X+100, GetRect().Y+100, GetRect().Width,GetRect().Height));
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            Graphics g = this.dataGridView1.CreateGraphics();
            SolidBrush blueBrush = new SolidBrush(rectangleColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TranslateTransform(100, 100);
            g.RotateTransform(angle);
            g.FillRectangle(blueBrush, rectangle);

            if (rajzoltTeglalapokSzama == 0)
                return;
            {
            }
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            if (!withoutMouse)
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRect());
            }
            int previousAngle = 0;
            e.Graphics.TranslateTransform(100, 100);
            foreach (Rectangle _rect in rectangles)
            {
                e.Graphics.RotateTransform((transAngle-previousAngle));
                Rectangle newRect = new Rectangle(_rect.X, _rect.Y, _rect.Width, _rect.Height);
                newRect.X = _rect.X - 100;
                newRect.Y = _rect.Y - 100;
                e.Graphics.DrawRectangle(Pens.Red, newRect);
                previousAngle = transAngle;
            }

        }

        private static Rectangle GetRect()
        {
            rect = new Rectangle();

            rect.X = LocationXY.X;
            rect.Y = LocationXY.Y;
            rect.Width = Math.Abs(LocationXY.X - LocationXY2.X);
            rect.Height = Math.Abs(LocationXY.Y - LocationXY2.Y);
            difWidth = rect.Width - rectangle.Width;
            difHeight = rect.Height - rectangle.Height;
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
        public void bubblesort(ref List<double> a, ref List<double> b)
        {
            double temp, temp2;
            for (int i = 1; i <= a.Count; i++)
                for (int j = 0; j < a.Count - i; j++)
                    if (a[j] > a[j + 1])
                    {
                        temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        temp2 = b[j];
                        b[j] = b[j + 1];
                        b[j + 1] = temp2;
                    }
        }

    }
}
