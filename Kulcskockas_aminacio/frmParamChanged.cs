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
    public partial class frmParamChanged : Form
    {
           GraphPane graphPane;

          public frmParamChanged(PointPairList width, PointPairList height, PointPairList shiftX, PointPairList shiftY, PointPairList angle)
          {
              InitializeComponent();
              graphPane = zedGraphControl2.GraphPane;
              graphPane.Title.Text = "A kulcskocka paramétereinek változása az idő függvényében.";
              graphPane.XAxis.Title.Text = "Idő";

              LineItem widthLineItem = graphPane.AddCurve("Szélesség", width, Color.Red, SymbolType.None);
              LineItem heightLineItem = graphPane.AddCurve("Magasság", height, Color.Blue, SymbolType.None);
              LineItem shiftXLineItem = graphPane.AddCurve("X koordináta", shiftX, Color.Green, SymbolType.None);
              LineItem shiftYLineItem = graphPane.AddCurve("Y koordináta", shiftY, Color.Yellow, SymbolType.None);
              LineItem angleLineItem = graphPane.AddCurve("Forgatási szög", angle, Color.Purple, SymbolType.None);

              widthLineItem.Line.Width = 3.0F;
              heightLineItem.Line.Width = 3.0F;
              shiftXLineItem.Line.Width = 3.0F;
              shiftYLineItem.Line.Width = 3.0F;
              angleLineItem.Line.Width = 3.0F;

              zedGraphControl2.AxisChange();
          }
    }
}
