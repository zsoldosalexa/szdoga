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
        static Rectangle r = new Rectangle(-100, -100, 50, 50);
        static Rectangle rect;
        static int kulonbsegx, kuly;
        static List<double> xCords = new List<double>();
        static List<double> yCords = new List<double>();
        static List<double> v1 = new List<double>();

        static Point LocationXY;
        static Point LocationXY2;

        bool IsMouseDown = false;
        bool rectangleDrawed = false;
        /*   static int w = 0;
           static int h = 0;
           static int x = 0;
           static int y = 0;*/
        public frmProba()
        {
            InitializeComponent();
        }
        private void frmProba_Load(object sender, EventArgs e)
        {
            trackBar1.TickFrequency = 10;
            this.Paint += new PaintEventHandler(Form1_Paint);
            angle = 0;
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1;
        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            g.TranslateTransform(100, 100);
            g.RotateTransform(angle);
            g.FillRectangle(blueBrush, r);
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (!rectangleDrawed)
                return;
            if (angle < transAngle)
                    angle++;
            if (r.Width < transWidth || r.Width < GetRect().Width)
            {
                r.Width += 1;
            }
            if (r.Width > GetRect().Width)
            {
                r.Width--;
            }
            if (r.Height < transHeight || r.Height < GetRect().Height)
            {
                r.Height += 1;
            }
            if (r.Height > GetRect().Height)
            {
                r.Height -= 1;
            }
            if (r.Y < GetRect().Y-100 || r.Y < transY)
            {
                r.Y++;
                r.X = (int)calc(r.Y, v1, yCords);
            }  
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                //  angle = Convert.ToInt32(txtAngle.Text);
                //   scar = Convert.ToInt32(txtScal.Text);
                /*                  Graphics g = this.CreateGraphics();
                                  g.TranslateTransform(100, 100);
                                  //rotation procedure
                                  g.RotateTransform(angle);*/
                rectangleDrawed = true;
                xCords.Add(r.X);
                xCords.Add(GetRect().X - 100);
                yCords.Add(r.Y);
                yCords.Add(GetRect().Y - 100);
                v1 = Interpolation(xCords, yCords, 0);
            }
               catch (Exception ex)
               {
                   MessageBox.Show("Nem megfelelő formátumú paraméterek!");
               }
            timer.Start();

        }

        /*   private void frmProba_Click(object sender, EventArgs e)
           {
               x = MousePosition.X;
               y = MousePosition.Y;
               MessageBox.Show(string.Format("X: {0} Y: {1}", MousePosition.X, MousePosition.Y));
           }*/
    //    static Rectangle r2 = GetRect();
        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            //          MessageBox.Show(trackBar1.Value.ToString());
            //   r.Width = trackBar1.Value * r.Width;
            //   r.Height = trackBar1.Value * r.Height;
            int s = trackBar1.Value;
            if (r.Y < GetRect().Y - 100)
            {
                r.Y = s - 100;
                r.X = (int)calc(r.Y, v1, yCords);
            }
            this.Invalidate();
            //   r2.Width = 10 + trackBar1.Value;
            //   r2.Height = 10 + trackBar1.Value;
        }

        private void frmProba_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;

            LocationXY = e.Location;
        }

        private void frmProba_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                LocationXY2 = e.Location;

                Refresh();
            }
        }

        private void frmProba_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                LocationXY2 = e.Location;

                IsMouseDown = false;
            }
            rectangleDrawed = true;
            xCords.Add(r.X);
            xCords.Add(GetRect().X-100);
            yCords.Add(r.Y);
            yCords.Add(GetRect().Y-100);
            v1 = Interpolation(xCords, yCords, 0);
        }

        private void frmProba_Paint(object sender, PaintEventArgs e)
        {
            if (rect != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRect());
            }
        }

        private static Rectangle GetRect()
        {
            rect = new Rectangle();

            rect.X = LocationXY.X;//Math.Min(LocationXY.X, LocationXY2.X);
            rect.Y = LocationXY.Y;// Math.Min(LocationXY.Y, LocationXY2.Y);
            rect.Width = Math.Abs(LocationXY.X - LocationXY2.X);
            rect.Height = Math.Abs(LocationXY.Y - LocationXY2.Y);
            kulonbsegx = rect.Width - r.Width;
            kuly = rect.Height - r.Height;
            return rect;

        }


        /*
                Rectangle r;
                Graphics g;

                Timer t = new Timer();

                int x = 200;
                int y = 0;

                int move_x = 0;
                int move_y = 0;

                private void frmProba_Load(object sender, EventArgs e)
                {
                    r = new Rectangle(100, 100, 60, 60);
                    g = this.CreateGraphics();
                    r.RenderTransform = new RotateTransform(30);

                    t.Interval = 10;
                    t.Tick += new EventHandler(t_Tick);
                    t.Start();
                }

                void t_Tick(object sender, EventArgs e)
                {
                    g.Clear(Color.DarkBlue);
                    g.DrawRectangle(new Pen(Brushes.Cornsilk, 6), r);

                    r.X += move_x;
                    r.Y += move_y;
                }
                private void frmProba_MouseClick(object sender, MouseEventArgs e)
                {

                }

                private void frmProba_Click(object sender, EventArgs e)
                {
                    /*   x = Cursor.Position.X;
                       y = Cursor.Position.Y;
                    double dif_x = Cursor.Position.X - r.X;
                    double dif_y = Cursor.Position.X - r.Y;

                    move_x = (int)(dif_x / 100);
                    move_y = (int)(dif_y / 100);
                }*/
        static List<double> result = new List<double>();
        static List<double> Interpolation(List<double> x, List<double> y, int k)
        {
          //  if (newCalculation)
            {
                result.Clear();
            }
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
