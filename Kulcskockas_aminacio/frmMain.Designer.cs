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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.interpolációsFüggvénySzámításaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kulcskockasAnimacioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCreator = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::Kulcskockas_aminacio.Properties.Resources.optimised_image_5;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.interpolációsFüggvénySzámításaToolStripMenuItem,
            this.kulcskockasAnimacioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(599, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // interpolációsFüggvénySzámításaToolStripMenuItem
            // 
            this.interpolációsFüggvénySzámításaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.interpolációsFüggvénySzámításaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.interpolációsFüggvénySzámításaToolStripMenuItem.Name = "interpolációsFüggvénySzámításaToolStripMenuItem";
            this.interpolációsFüggvénySzámításaToolStripMenuItem.Size = new System.Drawing.Size(203, 20);
            this.interpolációsFüggvénySzámításaToolStripMenuItem.Text = "Interpolációs függvény számítása";
            this.interpolációsFüggvénySzámításaToolStripMenuItem.Click += new System.EventHandler(this.interpolációsFüggvénySzámításaToolStripMenuItem_Click);
            // 
            // kulcskockasAnimacioToolStripMenuItem
            // 
            this.kulcskockasAnimacioToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.kulcskockasAnimacioToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.kulcskockasAnimacioToolStripMenuItem.Name = "kulcskockasAnimacioToolStripMenuItem";
            this.kulcskockasAnimacioToolStripMenuItem.Size = new System.Drawing.Size(138, 20);
            this.kulcskockasAnimacioToolStripMenuItem.Text = "Kulcskockás animáció";
            this.kulcskockasAnimacioToolStripMenuItem.Click += new System.EventHandler(this.kulcskockasAnimacioToolStripMenuItem_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(92, 111);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(408, 74);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "   Kulcskockás animáció \r\ninterpolációs technikákkal";
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.BackColor = System.Drawing.Color.Transparent;
            this.lblCreator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCreator.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCreator.Location = new System.Drawing.Point(12, 343);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(177, 13);
            this.lblCreator.TabIndex = 2;
            this.lblCreator.Text = "Készítette: Zsoldos Alexandra";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(599, 365);
            this.Controls.Add(this.lblCreator);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Kulcskockás animáció";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem interpolációsFüggvénySzámításaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kulcskockasAnimacioToolStripMenuItem;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCreator;
    }
}

