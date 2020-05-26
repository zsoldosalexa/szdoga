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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInterpolation));
            this.txtCoord = new System.Windows.Forms.TextBox();
            this.lblPoints = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkNewton = new System.Windows.Forms.CheckBox();
            this.chkSpline = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCoord
            // 
            this.txtCoord.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtCoord.Location = new System.Drawing.Point(24, 76);
            this.txtCoord.Margin = new System.Windows.Forms.Padding(2);
            this.txtCoord.Name = "txtCoord";
            this.txtCoord.Size = new System.Drawing.Size(56, 20);
            this.txtCoord.TabIndex = 0;
            this.txtCoord.Text = "X Y";
            this.txtCoord.Click += new System.EventHandler(this.txtCoord_Click);
            this.txtCoord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCoord_KeyDown);
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPoints.Location = new System.Drawing.Point(21, 41);
            this.lblPoints.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(138, 17);
            this.lblPoints.TabIndex = 1;
            this.lblPoints.Text = "Add meg a pontokat!";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(84, 76);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 20);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Hozzáad";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(52, 111);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 19);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Számolj!";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkNewton
            // 
            this.chkNewton.AutoSize = true;
            this.chkNewton.Checked = true;
            this.chkNewton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewton.Location = new System.Drawing.Point(24, 162);
            this.chkNewton.Name = "chkNewton";
            this.chkNewton.Size = new System.Drawing.Size(128, 17);
            this.chkNewton.TabIndex = 4;
            this.chkNewton.Text = "Lagrange-interpoláció";
            this.chkNewton.UseVisualStyleBackColor = true;
            this.chkNewton.CheckedChanged += new System.EventHandler(this.chkNewton_CheckedChanged);
            // 
            // chkSpline
            // 
            this.chkSpline.AutoSize = true;
            this.chkSpline.Checked = true;
            this.chkSpline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSpline.Location = new System.Drawing.Point(24, 195);
            this.chkSpline.Name = "chkSpline";
            this.chkSpline.Size = new System.Drawing.Size(149, 17);
            this.chkSpline.TabIndex = 5;
            this.chkSpline.Text = "Lineáris spline interpoláció";
            this.chkSpline.UseVisualStyleBackColor = true;
            this.chkSpline.CheckedChanged += new System.EventHandler(this.chkSpline_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(40, 247);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Pontok törlése";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmInterpolation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kulcskockas_aminacio.Properties.Resources.optimised_image_5;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.chkSpline);
            this.Controls.Add(this.chkNewton);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.txtCoord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmInterpolation";
            this.Text = "Interpolációs függvény számítása";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCoord;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkNewton;
        private System.Windows.Forms.CheckBox chkSpline;
        private System.Windows.Forms.Button btnDelete;
        //   private ZedGraph.ZedGraphControl zedGraphControl1;
    }
}