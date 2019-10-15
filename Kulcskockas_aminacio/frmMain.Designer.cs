namespace Kulcskockas_aminacio
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.leírásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interpolációsFüggvénySzámításaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proba3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leírásToolStripMenuItem,
            this.interpolációsFüggvénySzámításaToolStripMenuItem,
            this.proba3ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // leírásToolStripMenuItem
            // 
            this.leírásToolStripMenuItem.Name = "leírásToolStripMenuItem";
            this.leírásToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.leírásToolStripMenuItem.Text = "Leírás";
            // 
            // interpolációsFüggvénySzámításaToolStripMenuItem
            // 
            this.interpolációsFüggvénySzámításaToolStripMenuItem.Name = "interpolációsFüggvénySzámításaToolStripMenuItem";
            this.interpolációsFüggvénySzámításaToolStripMenuItem.Size = new System.Drawing.Size(194, 20);
            this.interpolációsFüggvénySzámításaToolStripMenuItem.Text = "Interpolációs függvény számítása";
            this.interpolációsFüggvénySzámításaToolStripMenuItem.Click += new System.EventHandler(this.interpolációsFüggvénySzámításaToolStripMenuItem_Click);
            // 
            // proba3ToolStripMenuItem
            // 
            this.proba3ToolStripMenuItem.Name = "proba3ToolStripMenuItem";
            this.proba3ToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.proba3ToolStripMenuItem.Text = "proba3";
            this.proba3ToolStripMenuItem.Click += new System.EventHandler(this.proba3ToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem leírásToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interpolációsFüggvénySzámításaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proba3ToolStripMenuItem;
    }
}

