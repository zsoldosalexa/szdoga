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
                DrawCurve(time);
                time = Math.Round(((double)(DateTime.Now - start).TotalMilliseconds / 1000.0), 2);
            }

        }
        static PointPairList _pointPairList = new PointPairList();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string[] points = txtCoord.Text.Split(',');
            PointPair _pointPair = new PointPair(Convert.ToInt32(points[0]), Convert.ToInt32(points[1]));
            _pointPairList.Add(_pointPair);
            for (int i = 0; i < 100; i++)
            {
                _pointPairList.Add(i, i * i);
            }
            txtCoord.Clear();

        }
        private void DrawCurve(double time)
        {
            string[] points = txtCoord.Text.Split(',');
            PointPair _pointPair = new PointPair(time, time);
            for (int i = 0; i < 100; i++)
            {
                _pointPairList.Add(i, calc(i, res, numbers));
            }
            LineItem lineItem = graphPane.AddCurve("SIne Curve", _pointPairList, Color.Red, SymbolType.None);
            Console.WriteLine(time);
            zedGraphControl1.AxisChange();
            restxt.Text = (Convert.ToString(calc(0.75, res, numbers)));
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            frmDrawFunction frm = new frmDrawFunction();
            frm.Show();
        }
        static List<double> result = new List<double>();
        static int q = 3;
        static List<double> Interpolation(List<double> x, List<int> y, int k)
        {
            result.Add(x[0]);
            q--;
            while (q>0)
            {
                var a = new List<double>();
                for (int i = 1; i < x.Count; i++)
                {
                    a.Add((x[i] - x[i - 1]) / (y[i + k] - y[i - 1]));
                }
                var b = Interpolation(a, y, ++k);
            }
            return result;
        }
        static List<double> numbers2 = new List<double>() { 0.5, 1, 2, 4 };
        static List<int> numbers = new List<int>() { -1, 0, 1, 2 };
        static List<double> res = Interpolation(numbers2, numbers, 0);
        double calc(double k, List<double> res, List<int> y)
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
    }
}

