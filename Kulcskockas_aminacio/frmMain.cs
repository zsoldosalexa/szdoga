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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void interpolációsFüggvénySzámításaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInterpolation frm = new frmInterpolation();
            frm.Show();
        }

        private void kulcskockasAnimacioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKulcskockasAnimacio frm = new frmKulcskockasAnimacio();
            frm.Show();
        }

    }
}
