namespace Kulcskockas_aminacio
{
    partial class frmProba
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProba));
            this.textYCord = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.txtScal = new System.Windows.Forms.TextBox();
            this.txtXCord = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // textYCord
            // 
            this.textYCord.Location = new System.Drawing.Point(0, 39);
            this.textYCord.Name = "textYCord";
            this.textYCord.Size = new System.Drawing.Size(100, 20);
            this.textYCord.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(115, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 98);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 393);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(206, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(0, 66);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(100, 20);
            this.txtAngle.TabIndex = 5;
            // 
            // txtScal
            // 
            this.txtScal.AccessibleDescription = "jhg";
            this.txtScal.AccessibleName = "jngh";
            this.txtScal.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.txtScal.Location = new System.Drawing.Point(0, 93);
            this.txtScal.Name = "txtScal";
            this.txtScal.Size = new System.Drawing.Size(100, 20);
            this.txtScal.TabIndex = 6;
            // 
            // txtXCord
            // 
            this.txtXCord.Location = new System.Drawing.Point(0, 13);
            this.txtXCord.Name = "txtXCord";
            this.txtXCord.Size = new System.Drawing.Size(100, 20);
            this.txtXCord.TabIndex = 7;
            // 
            // frmProba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kulcskockas_aminacio.Properties.Resources.optimised_image_5;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtXCord);
            this.Controls.Add(this.txtScal);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textYCord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProba";
            this.Text = "frmProba";
            this.Load += new System.EventHandler(this.frmProba_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmProba_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmProba_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmProba_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmProba_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox textYCord;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.TextBox txtScal;
        private System.Windows.Forms.TextBox txtXCord;
    }
}