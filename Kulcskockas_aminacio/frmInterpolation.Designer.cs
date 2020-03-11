namespace Kulcskockas_aminacio
{
    partial class frmInterpolation
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInterpolation));
            this.txtCoord = new System.Windows.Forms.TextBox();
            this.lblPoints = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // txtCoord
            // 
            this.txtCoord.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtCoord.Location = new System.Drawing.Point(22, 56);
            this.txtCoord.Margin = new System.Windows.Forms.Padding(2);
            this.txtCoord.Name = "txtCoord";
            this.txtCoord.Size = new System.Drawing.Size(98, 20);
            this.txtCoord.TabIndex = 0;
            this.txtCoord.Text = "(X,Y)";
            this.txtCoord.Click += new System.EventHandler(this.txtCoord_Click);
            this.txtCoord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCoord_KeyDown);
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(22, 37);
            this.lblPoints.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(106, 13);
            this.lblPoints.TabIndex = 1;
            this.lblPoints.Text = "Add meg a pontokat!";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(137, 28);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 28);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "button1";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(24, 97);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 19);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Számolj!";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("zedGraphControl1.BackgroundImage")));
            this.zedGraphControl1.Location = new System.Drawing.Point(184, 11);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(413, 336);
            this.zedGraphControl1.TabIndex = 4;
            this.zedGraphControl1.ZoomButtons = System.Windows.Forms.MouseButtons.None;
            // 
            // frmInterpolation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kulcskockas_aminacio.Properties.Resources.optimised_image_5;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.txtCoord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmInterpolation";
            this.Text = "frmInterpolation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCoord;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private ZedGraph.ZedGraphControl zedGraphControl1;
    }
}