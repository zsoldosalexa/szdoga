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
    public partial class frmDrawFunction : Form
    {
        PointPairList points;
        LineItem myCurve;
        GraphPane graphPane;

      public frmDrawFunction(PointPairList _pointPairList)
        {
            InitializeComponent();
            graphPane = zedGraphControl1.GraphPane;
            LineItem lineItem = graphPane.AddCurve("Interpolált függvény", _pointPairList, Color.Red, SymbolType.Circle);
            zedGraphControl1.AxisChange();
        }
        private void CreateGraphics(ZedGraphControl zgc)
        { }
        /* myPane = zedGraphControl1.GraphPane;

         myPane.YAxis.Scale.Min = -1.2;
         myPane.YAxis.Scale.Max = 1.2;
         myPane.YAxis.Scale.MajorStep = 1;
         myPane.YAxis.Scale.MinorStep = 1;

         myPane.XAxis.Type = AxisType.Date;
         myPane.XAxis.Scale.Format = "mm:ss:fff";
         myPane.XAxis.Scale.FontSpec.Angle = 60;
         myPane.XAxis.Scale.FontSpec.Size = 12;
         myPane.XAxis.Scale.MajorUnit = DateUnit.Millisecond;
         myPane.XAxis.Scale.MajorStep = 500;
         myPane.XAxis.Scale.MinorUnit = DateUnit.Millisecond;
         myPane.XAxis.Scale.MinorStep = 250;
         myPane.XAxis.Scale.Min = new XDate(DateTime.Now);
         myPane.XAxis.Scale.Max = new XDate(DateTime.Now.AddMinutes(1));
         myPane.XAxis.Scale.MinorUnit = DateUnit.Second;
         myPane.XAxis.Scale.MajorUnit = DateUnit.Minute;
         myPane.XAxis.Scale.MinorStep = 1;
         myPane.XAxis.Scale.MajorStep = 10;

         points = new PointPairList();
         myCurve = myPane.AddCurve("Test Curve1", points, Color.Blue, SymbolType.None);

         points.Add(new XDate(DateTime.Now), 0);
         points.Add(new XDate(DateTime.Now), 1);
         points.Add(new XDate(DateTime.Now), 2);
         zedGraphControl1.AxisChange();
         zedGraphControl1.Invalidate();*/

    }
}
