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
        static int x, y;

        public frmImageMove()
        {
            InitializeComponent();
            x = pictureBox1.Left;
            y = pictureBox1.Top;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            elapsed_time = (DateTime.Now.Second - start_time);
            if (pictureBox1.Left < pictureBox2.Left + pictureBox2.Width - 1)
            {
                pictureBox1.Left = (int)calc(elapsed_time, v1, time) + x;
            }
            if (pictureBox1.Top < pictureBox3.Top + pictureBox3.Height-1)
            {
                pictureBox1.Top = (int)calc(elapsed_time, v5, time) + y;
            }
        }
        static List<double> Interpolation(List<double> x, List<double> y, int k)
        {
            List<double> result = new List<double>();
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

        private void button2_Click(object sender, EventArgs e)
        {
            ofd.Title = "Open Image";
            ofd.Filter = "PNG Image|*.png|JPG|*.jpg";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show(ofd.FileName);
            }
            pictureBox1.Image = Image.FromFile(ofd.FileName);

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
            xCords.Add(0);
            xCords.Add(200);
            v1 = Interpolation(xCords, time, 0);
            yCords.Add(0);
            yCords.Add(200);
            v5 = Interpolation(yCords, time, 0);
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1;
            timer.Start();
        }

    }
}
