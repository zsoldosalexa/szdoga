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
        public frmInterpolation()
        {
            InitializeComponent();

            /*         private void Form1_Resize(object sender, EventArgs e)
                     {
                         SetSize();
                     }

                     // SetSize() is separate from Resize() so we can 
                     // call it independently from the Form1_Load() method
                     // This leaves a 10 px margin around the outside of the control
                     // Customize this to fit your needs
                     private void SetSize()
                     {
                         zedGraphControl1.Location = new Point(10, 10);
                         // Leave a small margin around the outside of the control
                         zedGraphControl1.Size = new Size(ClientRectangle.Width - 20,
                                                 ClientRectangle.Height - 20);
                     }

                     // Respond to form 'Load' event
                     private void zedGraphControl1_Load(object sender, EventArgs e)
                     {
                         // Setup the graph
                         CreateGraph(zedGraphControl1);
                         // Size the control to fill the form with a margin
                         SetSize();
                     }

                     // Build the Chart
                     private void CreateGraph(ZedGraphControl zgc)
                     {
                         // get a reference to the GraphPane
                         GraphPane myPane = zgc.GraphPane;

                         // Set the Titles
                         myPane.Title.Text = "My Test Graph\n(For CodeProject Sample)";
                         myPane.XAxis.Title.Text = "My X Axis";
                         myPane.YAxis.Title.Text = "My Y Axis";

                         // Make up some data arrays based on the Sine function
                         double x, y1, y2;
                         PointPairList list1 = new PointPairList();
                         PointPairList list2 = new PointPairList();
                         for (int i = 0; i < 36; i++)
                         {
                             x = (double)i + 5;
                             y1 = 1.5 + Math.Sin((double)i * 0.2);
                             y2 = 3.0 * (1.5 + Math.Sin((double)i * 0.2));
                             list1.Add(x, y1);
                             list2.Add(x, y2);
                         }

                         // Generate a red curve with diamond
                         // symbols, and "Porsche" in the legend
                         LineItem myCurve = myPane.AddCurve("Porsche",
                               list1, Color.Red, SymbolType.Diamond);

                         // Generate a blue curve with circle
                         // symbols, and "Piper" in the legend
                         LineItem myCurve2 = myPane.AddCurve("Piper",
                               list2, Color.Blue, SymbolType.Circle);

                         // Tell ZedGraph to refigure the
                         // axes since the data have changed
                         zgc.AxisChange();
                     }*/

            graphPane = zedGraphControl1.GraphPane;
            DateTime start = DateTime.Now;
            double time = Math.Round(((double)(DateTime.Now - start).TotalMilliseconds / 1000.0), 2);
            //  while (time < 100)
            {
               // DrawCurve(time);
                time = Math.Round(((double)(DateTime.Now - start).TotalMilliseconds / 1000.0), 2);
            }

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
            //    double ds = Convert.ToDouble("0,75");
            //    ds *= 2;
            //    txtCoord.Text = Convert.ToString(ds);
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
       /* private void DrawCurve(double time)
        {
            string[] points = txtCoord.Text.Split(',');
            PointPair _pointPair = new PointPair(time, time);
            PointPairList _pointPairList = new PointPairList();
            for (int i = 0; i < 10; i++)
            {
                _pointPairList.Add(i, calc(i, res, numbers));
            }
            LineItem lineItem = graphPane.AddCurve("SIne Curve", _pointPairList, Color.Red, SymbolType.None);
            Console.WriteLine(time);
            zedGraphControl1.AxisChange();
        //    restxt.Text = (Convert.ToString(calc(0.75, res, numbers)));
        }*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<double> v1 = new List<double>();
            v1 = Interpolation(xCords, yCords, 0);
            PointPairList _pointPairList = new PointPairList();
            for (int i = 0; i < 7; i++)
            {
                _pointPairList.Add(i, calc(i, v1, yCords));
            }
            newCalculation = true;
            v1.Clear();
            frmDrawFunction frm = new frmDrawFunction(_pointPairList);
            frm.Show();
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
        static List<double> numbers2 = new List<double>() { 0.5, 1, 2, 4 };
        static List<double> numbers = new List<double>() { -1, 0, 1, 2 };
     //   static List<double> res = Interpolation(numbers2, numbers, 0);
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

