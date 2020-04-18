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
    public partial class frmInterpolation : Form
    {
        GraphPane graphPane;
        static List<double> xCords = new List<double>();
        static List<double> yCords = new List<double>();
        static bool newCalculation = false;
        ZedGraph.ZedGraphControl zedGraphControl;
        public frmInterpolation()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (newCalculation == true)
            {
                xCords.Clear();
                yCords.Clear();
            }

            newCalculation = false;

            string[] points = txtCoord.Text.Split(' ');
            try
            {
               PointPair _pointPair = new PointPair(Convert.ToDouble(points[0]), Convert.ToDouble(points[1]));
                yCords.Add(Convert.ToDouble(points[0]));
                xCords.Add(Convert.ToDouble(points[1]));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nem megfelelő bemenet!");
            }
            txtCoord.Clear();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<double> v1 = new List<double>();
            v1 = Interpolation(xCords, yCords, 0);
            PointPairList _pointPairList = new PointPairList();
            for (int i = (int)Math.Floor(xCords.Min()); i <= xCords.Max(); i++)
            {
                _pointPairList.Add(i, calc(i, v1, yCords));
            }
            newCalculation = true;
            v1.Clear();
            if (this.Controls.Contains(zedGraphControl))
            {
                this.Controls.Remove(zedGraphControl);
            }
            if (this.Controls.Contains(zedGraphControl1))
            {
                this.Controls.Remove(zedGraphControl1);
            }
            zedGraphControl = new ZedGraph.ZedGraphControl();
            this.Controls.Add(zedGraphControl);
            zedGraphControl.Location = new System.Drawing.Point(184, 11);
            zedGraphControl.Size = new System.Drawing.Size(413, 336);
            graphPane = zedGraphControl.GraphPane;
            LineItem lineItem = graphPane.AddCurve("Interpolált függvény", _pointPairList, Color.Red, SymbolType.Circle);
            zedGraphControl.AxisChange();
        }
        static List<double> result = new List<double>();
        static List<double> Interpolation(List<double> x, List<double> y, int k)
        {
            if (newCalculation)
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
                for (int j = 0; j<i; j++)
                {
                    szorzo *= (k - y[j]);
                }
                result += res[i] * szorzo;  
            }
            return result;

        }

        private void txtCoord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (newCalculation == true)
                {
                    xCords.Clear();
                    yCords.Clear();
                }

                newCalculation = false;

                string[] points = txtCoord.Text.Split(' ');
                try
                {
                    PointPair _pointPair = new PointPair(Convert.ToDouble(points[0]), Convert.ToDouble(points[1]));
                    yCords.Add(Convert.ToDouble(points[0]));
                    xCords.Add(Convert.ToDouble(points[1]));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nem megfelelő bemenet!");
                }
                txtCoord.Clear();
            }
        }

        private void txtCoord_Click(object sender, EventArgs e)
        {
            txtCoord.Clear();
            txtCoord.ForeColor = System.Drawing.SystemColors.ControlText;
        }

    }
}

