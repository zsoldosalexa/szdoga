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
        static int pointsCount = 0;
        static List<PointPairList> pointPairList = new List<PointPairList>();
        static List<LineItem> lineItems = new List<LineItem>();
        ZedGraph.ZedGraphControl zedGraphControl;
        ZedGraph.ZedGraphControl zedGraphControl1;
        PointPairList lagrangePoints = new PointPairList();
        PointPairList splinePoints = new PointPairList();
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
                pointPairList.Clear();
                lineItems.Clear();
                pointsCount = 0;
            }

            newCalculation = false;

            string[] points = txtCoord.Text.Split(' ');
            try
            {
                addPoint(points);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem megfelelő bemenet!");
            }
            txtCoord.Clear();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<double> v1 = new List<double>();
            result.Clear();
            if (xCords.Count > 1 && yCords.Count > 1)
            {
                v1 = Interpolation(xCords, yCords, 0).ToList();
            }
            else
            {
                MessageBox.Show("Előbb adjon meg legalább két pontot!");
                return;
            }
            for (int i = (int)Math.Floor(yCords.Min()); i <= yCords.Max(); i++)
            {
                lagrangePoints.Add(i, calc(i, v1, yCords));
            }
            v1.Clear();
            bubblesort(ref yCords, ref xCords);
            for (int i = 1; i < xCords.Count; i++)
            {
                int n = 0;
                result.Clear();
                List<double> v2 = new List<double>();
                List<double> x = new List<double>();
                List<double> y = new List<double>();
                x.Add(xCords[i - 1]);
                x.Add(xCords[i]);
                y.Add(yCords[i - 1]);
                y.Add(yCords[i]);
                v2 = Interpolation(x, y, 0).ToList();
                if (i == xCords.Count - 1)
                {
                    n = (int)y.Max() + 1;
                }
                else
                {
                    n = (int)y.Max();
                }

                for (int j = (int)Math.Floor(y[0]); j <= (int)y[1]; j++)
                {
                    splinePoints.Add(j, calc(j, v2, y));
                }
            }
            chkChanged();
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
                for (int j = 0; j < i; j++)
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
                    pointPairList.Clear();
                    lineItems.Clear();
                    pointsCount = 0;
                }

                newCalculation = false;

                string[] points = txtCoord.Text.Split(' ');
                try
                {
                    addPoint(points);
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

        private void addPoint(string[] points)
        {
            PointPair _pointPair = new PointPair(Convert.ToDouble(points[0]), Convert.ToDouble(points[1]));
            PointPairList ppl = new PointPairList();
            if (yCords.Contains(Convert.ToDouble(points[0])))
            {
                MessageBox.Show("Ehhez az alapponthoz már egy másik érték tartozik.");
                return;
            }
            ppl.Add(_pointPair);
            pointPairList.Add(ppl);
            yCords.Add(Convert.ToDouble(points[0]));
            xCords.Add(Convert.ToDouble(points[1]));
            MessageBox.Show("Az alappont és az érték hozzáadva.");
            if (this.Controls.Contains(zedGraphControl1))
            {
                this.Controls.Remove(zedGraphControl1);
            }
            if (this.Controls.Contains(zedGraphControl))
            {
                this.Controls.Remove(zedGraphControl);
            }
            zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.Controls.Add(zedGraphControl1);
            zedGraphControl1.Location = new System.Drawing.Point(184, 11);
            zedGraphControl1.Size = new System.Drawing.Size(413, 336);
            graphPane = zedGraphControl1.GraphPane;
            graphPane.XAxis.Title.Text = "X";
            graphPane.YAxis.Title.Text = "Y";
            graphPane.Title.Text = "A megadott pontok";
            pointsCount++;
            for (int i = 0; i < pointsCount; i++)
            {
                lineItems.Add(graphPane.AddCurve("", pointPairList[i], Color.Red, SymbolType.Default));
            }
            zedGraphControl1.AxisChange();
        }
        public void bubblesort(ref List<double> a, ref List<double> b)
        {
            double temp,temp2;
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

        private void chkNewton_CheckedChanged(object sender, EventArgs e)
        {
            chkChanged();
        }

        private void chkSpline_CheckedChanged(object sender, EventArgs e)
        {
            chkChanged();
        }

        private void chkChanged()
        {
            if (this.Controls.Contains(zedGraphControl1))
            {
                this.Controls.Remove(zedGraphControl1);
            }
            if (this.Controls.Contains(zedGraphControl))
            {
                this.Controls.Remove(zedGraphControl);
            }
            zedGraphControl = new ZedGraph.ZedGraphControl();
            this.Controls.Add(zedGraphControl);
            zedGraphControl.Location = new System.Drawing.Point(184, 11);
            zedGraphControl.Size = new System.Drawing.Size(413, 336);
            graphPane.Legend.IsVisible = false;
            graphPane = zedGraphControl.GraphPane;
            graphPane.XAxis.Scale.Max = yCords.Max();
            graphPane.XAxis.Scale.Min = yCords.Min();
            graphPane.XAxis.Title.Text = "X";
            graphPane.YAxis.Title.Text = "Y";
            graphPane.Title.Text = "Interpolált függvény";
            if (chkNewton.Checked)
            {
                LineItem lineItem = graphPane.AddCurve("Lagrange-interpoláció", lagrangePoints, Color.Red, SymbolType.Circle);
                lineItem.Line.Width = 2.0F;
            }
            if (chkSpline.Checked)
            {
                LineItem lineItem2 = graphPane.AddCurve("Lineáris spline interpoláció", splinePoints, Color.Green, SymbolType.Circle);
                lineItem2.Line.Width = 2.0F;
            }
            zedGraphControl.AxisChange();
            newCalculation = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            xCords.Clear();
            yCords.Clear();
            lagrangePoints.Clear();
            splinePoints.Clear();
            pointsCount = 0;
            pointPairList.Clear();
            lineItems.Clear();
            if (this.Controls.Contains(zedGraphControl))
            {
                this.Controls.Remove(zedGraphControl);
            }
            if (this.Controls.Contains(zedGraphControl1))
            {
                this.Controls.Remove(zedGraphControl1);
            }
            MessageBox.Show("A pontok sikeresen törölve.");
        }
    }
}

