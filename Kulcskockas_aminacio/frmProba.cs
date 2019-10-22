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
        int scar;
        Rectangle r = new Rectangle(0, 0, 50, 50);
        Rectangle rect;

        Point LocationXY;
        Point LocationXY2;

        bool IsMouseDown = false;
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
            this.Paint += new PaintEventHandler(Form1_Paint);
            angle = 0;
            timer = new Timer();
           // if (r.X < 10 && r.Y < 10)
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 100;
            timer.Start();
        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            //the central point of the rotation
            g.TranslateTransform(100, 100);
            //rotation procedure
            g.RotateTransform(angle);
          //  Rectangle r = new Rectangle(0, 0, 50, 50);
            g.DrawRectangle(Pens.White, r);
            g.FillRectangle(blueBrush, r);
            //      r.X = x - 250;
            //    r.Y = y - 250;
        }
        void timer_Tick(object sender, EventArgs e)
        {

        //    angle++;
        //    r.Width += 1;
        //    r.Height += 1;
            {
         //       r.X -= 1;

          //      r.Y += 1;
            }

           // r.X = x - 250;
        //    r.Y = y - 250;
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                r.X = Convert.ToInt32(txtXCord.Text);
                r.Y = Convert.ToInt32(textYCord.Text);
                angle = Convert.ToInt32(txtAngle.Text);
                scar = Convert.ToInt32(txtScal.Text);
                Graphics g = this.CreateGraphics();
                g.TranslateTransform(100, 100);
                //rotation procedure
                g.RotateTransform(angle);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nem megfelelő bemenet!");
            }
        }

     /*   private void frmProba_Click(object sender, EventArgs e)
        {
            x = MousePosition.X;
            y = MousePosition.Y;
            MessageBox.Show(string.Format("X: {0} Y: {1}", MousePosition.X, MousePosition.Y));
        }*/

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            r.X++;
            r.Y++;
            r.Width++;
            r.Height++;
            angle++;
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
        }

        private void frmProba_Paint(object sender, PaintEventArgs e)
        {
            if (rect != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRect());
            }
        }

        private Rectangle GetRect()
        {
            rect = new Rectangle();

            rect.X = Math.Min(LocationXY.X, LocationXY2.X);
            rect.Y = Math.Min(LocationXY.Y, LocationXY2.Y);
            rect.Width = Math.Abs(LocationXY.X - LocationXY2.X);
            rect.Height = Math.Abs(LocationXY.Y - LocationXY2.Y);

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
    }
}
