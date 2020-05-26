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
           PointPairList width, height, shiftX, shiftY, angle, widthSpline, heightSpline, shiftXSpline, shiftYSpline;
        int time;

        private void chkNewton_CheckedChanged(object sender, EventArgs e)
        {
            checkStateChanged();
        }

        private void chkSpline_CheckedChanged(object sender, EventArgs e)
        {
            checkStateChanged();
        }

        public frmParamChanged(PointPairList width, PointPairList height, PointPairList shiftX, PointPairList shiftY, PointPairList angle, PointPairList widthSpline, PointPairList heightSpline, PointPairList shiftXSpline, PointPairList shiftYSpline, int time)
          {
              InitializeComponent();
              this.width = width;
              this.height = height;
              this.shiftX = shiftX;
              this.shiftY = shiftY;
              this.angle = angle;
              this.widthSpline = widthSpline;
              this.heightSpline = heightSpline;
              this.shiftXSpline = shiftXSpline;
              this.shiftYSpline = shiftYSpline;
              this.time = time;
              checkStateChanged();
        }

        private void checkStateChanged()
        {
            if (this.Controls.Contains(zedGraphControl2))
            {
                this.Controls.Remove(zedGraphControl2);
            }
            zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.Controls.Add(zedGraphControl2);
            graphPane = zedGraphControl2.GraphPane;
            graphPane.Title.Text = "A kulcskocka paramétereinek változása az idő függvényében.";
            graphPane.XAxis.Title.Text = "Idő";
            graphPane.YAxis.Title.Text = "Paraméterek";
            graphPane.XAxis.Scale.Max = time;
            zedGraphControl2.Location = new System.Drawing.Point(0,0);
            zedGraphControl2.Size = new System.Drawing.Size(800, 480);
          //  if (chkNewton.Checked)
            {
                LineItem widthLineItem = graphPane.AddCurve("Szélesség", width, Color.Red, SymbolType.None);
                LineItem heightLineItem = graphPane.AddCurve("Magasság", height, Color.Blue, SymbolType.None);
                LineItem shiftXLineItem = graphPane.AddCurve("X koordináta", shiftX, Color.Green, SymbolType.None);
                LineItem shiftYLineItem = graphPane.AddCurve("Y koordináta", shiftY, Color.Yellow, SymbolType.None);
                LineItem angleLineItem = graphPane.AddCurve("Forgatási szög", angle, Color.Purple, SymbolType.None);

                widthLineItem.Line.Width = 5.0F;
                heightLineItem.Line.Width = 5.0F;
                shiftXLineItem.Line.Width = 5.0F;
                shiftYLineItem.Line.Width = 5.0F;
                angleLineItem.Line.Width = 5.0F;
            }
            //if (chkSpline.Checked)
            {
                LineItem widthLineItemSpline = graphPane.AddCurve("", widthSpline, Color.Red, SymbolType.None);
                LineItem heightLineItemSpline = graphPane.AddCurve("", heightSpline, Color.Blue, SymbolType.None);
                LineItem shiftXLineItemSpline = graphPane.AddCurve("", shiftXSpline, Color.Green, SymbolType.None);
                LineItem shiftYLineItemSpline = graphPane.AddCurve("", shiftYSpline, Color.Yellow, SymbolType.None);

                widthLineItemSpline.Line.Width = 5.0F;
                heightLineItemSpline.Line.Width = 5.0F;
                shiftXLineItemSpline.Line.Width = 5.0F;
                shiftYLineItemSpline.Line.Width = 5.0F;
            }
            zedGraphControl2.AxisChange();
        }
    }
}
