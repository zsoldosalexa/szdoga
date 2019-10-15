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
        Rectangle r = new Rectangle(0, 0, 50, 50);
        static int w = 0;
        static int h = 0;
        static int x = 0;
        static int y = 0;
        public frmProba()
        {
            InitializeComponent();
        }
        private void frmProba_Load(object sender, EventArgs e)
        { 
            this.Paint += new PaintEventHandler(Form1_Paint);
            angle = 0;
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 10;
            timer.Start();
        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            //the central point of the rotation
            g.TranslateTransform(100, 100);
            //rotation procedure
            g.RotateTransform(angle);
          //  Rectangle r = new Rectangle(0, 0, 50, 50);
            g.DrawRectangle(Pens.Red, r);
      //      r.X = x - 250;
        //    r.Y = y - 250;
        }
        void timer_Tick(object sender, EventArgs e)
        {

            //angle++;
            r.Width += 1;
            r.Height += 1;
       //     while (r.X < 1000 && r.Y < 1000)
            {
                r.X -= 1;

                r.Y += 10;
                r.Y -= 10; 
            }
           // r.X = x - 250;
        //    r.Y = y - 250;
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            w = Convert.ToInt32(textXCor.Text);
            h = Convert.ToInt32(textYCord.Text);
        }

        private void frmProba_Click(object sender, EventArgs e)
        {
            x = MousePosition.X;
            y = MousePosition.Y;
            MessageBox.Show(string.Format("X: {0} Y: {1}", MousePosition.X, MousePosition.Y));
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
