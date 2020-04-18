using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kulcskockas_aminacio
{
    public partial class frmImageMove : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        Timer timer;
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
        double elapsed_time, start_time;
        static int x, y, w, h;
        static int ms = 0;
        Image img;
        Graphics g;

        public frmImageMove(List<double> _v1, List<double> _v2, List<double> _v3, List<double> _v4, List<double> _v5)
        {
            InitializeComponent();
            x = pictureBox1.Left;
            y = pictureBox1.Top;
            w = pictureBox1.Width;
            h = pictureBox1.Height;
            img = pictureBox1.Image;
            v1 = _v1.ToList();
            v2 = _v2.ToList();
            v3 = _v3.ToList();
            v4 = _v4.ToList();
            v5 = _v5.ToList();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ms++;
            //  pictureBox1.Height = h - (int)calc(ms, v3, time);
            //  pictureBox1.Width = w - (int)calc(ms,v2,time);
            //  pictureBox1.Left = x - (int)calc(ms, v1, time);
            // pictureBox1.Top = y - (int)calc(ms, v5, time);
            //img = (Image)RotateImage(img, ms).Clone();
     //       img = RotateImage(img, ms);
    //        g.RotateTransform(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frmImageMove_FormClosing(object sender, FormClosingEventArgs e)
        {
            pictureBox1.Left = x;
            pictureBox1.Top = y;
            pictureBox1.Width = w;
            pictureBox1.Height = h;
            ms = 0;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.pictureBox1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TranslateTransform(100, 100);
            g.RotateTransform(ms);
        }

        private void frmImageMove_Load(object sender, EventArgs e)
        {
            this.Controls.Add(pictureBox1);
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ofd.Title = "Open Image";
                ofd.Filter = "PNG Image|*.png|JPG|*.jpg";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show(ofd.FileName);
                }
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("A kép nem található!");
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            start_time = DateTime.Now.Second;
            time.Add(0);
            time.Add(20);
            timer.Start();
        }
        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }
    }
}
