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
        GraphPane graphPane;

      public frmDrawFunction(PointPairList _pointPairList)
        {
            InitializeComponent();
            graphPane = zedGraphControl1.GraphPane;
            LineItem lineItem = graphPane.AddCurve("Interpolált függvény", _pointPairList, Color.Red, SymbolType.Circle);
            zedGraphControl1.AxisChange();
        }

    }
}
