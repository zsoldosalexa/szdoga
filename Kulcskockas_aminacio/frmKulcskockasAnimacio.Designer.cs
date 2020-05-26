namespace Kulcskockas_aminacio
{
    partial class frmKulcskockasAnimacio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKulcskockasAnimacio));
            this.btnStart = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtXCord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textYCord = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnImageMove = new System.Windows.Forms.Button();
            this.btnParameters = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnRestart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSpline = new System.Windows.Forms.RadioButton();
            this.rbNewton = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStart.Location = new System.Drawing.Point(190, 95);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(59, 29);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Indítás";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(125, 69);
            this.txtAngle.Multiline = true;
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(45, 15);
            this.txtAngle.TabIndex = 5;
            // 
            // txtHeight
            // 
            this.txtHeight.AccessibleDescription = "jhg";
            this.txtHeight.AccessibleName = "jngh";
            this.txtHeight.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.txtHeight.Location = new System.Drawing.Point(125, 95);
            this.txtHeight.Multiline = true;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(45, 15);
            this.txtHeight.TabIndex = 6;
            // 
            // txtXCord
            // 
            this.txtXCord.Location = new System.Drawing.Point(125, 19);
            this.txtXCord.Multiline = true;
            this.txtXCord.Name = "txtXCord";
            this.txtXCord.Size = new System.Drawing.Size(45, 15);
            this.txtXCord.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Eltolás az X mentén";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Eltolás az Y mentén";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Elforgatás(szög)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(13, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Magasság";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textYCord
            // 
            this.textYCord.Location = new System.Drawing.Point(125, 42);
            this.textYCord.Multiline = true;
            this.textYCord.Name = "textYCord";
            this.textYCord.Size = new System.Drawing.Size(45, 15);
            this.textYCord.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Szélesség";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWidth
            // 
            this.txtWidth.AccessibleDescription = "jhg";
            this.txtWidth.AccessibleName = "jngh";
            this.txtWidth.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.txtWidth.Location = new System.Drawing.Point(125, 123);
            this.txtWidth.Multiline = true;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(45, 15);
            this.txtWidth.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(255, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(517, 403);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            this.dataGridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseUp);
            // 
            // btnImageMove
            // 
            this.btnImageMove.Enabled = false;
            this.btnImageMove.Location = new System.Drawing.Point(28, 162);
            this.btnImageMove.Name = "btnImageMove";
            this.btnImageMove.Size = new System.Drawing.Size(142, 23);
            this.btnImageMove.TabIndex = 17;
            this.btnImageMove.Text = "Ábrázolás képpel";
            this.btnImageMove.UseVisualStyleBackColor = true;
            this.btnImageMove.Click += new System.EventHandler(this.btnImageMove_Click);
            // 
            // btnParameters
            // 
            this.btnParameters.Enabled = false;
            this.btnParameters.Location = new System.Drawing.Point(16, 202);
            this.btnParameters.Name = "btnParameters";
            this.btnParameters.Size = new System.Drawing.Size(171, 45);
            this.btnParameters.TabIndex = 18;
            this.btnParameters.Text = "A paraméterek értékeinek változása függvénnyel ábrázolva";
            this.btnParameters.UseVisualStyleBackColor = true;
            this.btnParameters.Click += new System.EventHandler(this.btnParameters_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(116, 352);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 17);
            this.radioButton1.TabIndex = 19;
            this.radioButton1.Text = "20 mp";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(28, 352);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 17);
            this.radioButton2.TabIndex = 20;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "10 mp";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(43, 384);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(92, 23);
            this.btnRestart.TabIndex = 21;
            this.btnRestart.Text = "Kezdeti pozíció";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSpline);
            this.groupBox1.Controls.Add(this.rbNewton);
            this.groupBox1.Location = new System.Drawing.Point(16, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 65);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interpolációs-technika";
            // 
            // rbSpline
            // 
            this.rbSpline.AutoSize = true;
            this.rbSpline.Location = new System.Drawing.Point(12, 42);
            this.rbSpline.Name = "rbSpline";
            this.rbSpline.Size = new System.Drawing.Size(91, 17);
            this.rbSpline.TabIndex = 1;
            this.rbSpline.Text = "Lineáris spline";
            this.rbSpline.UseVisualStyleBackColor = true;
            // 
            // rbNewton
            // 
            this.rbNewton.AutoSize = true;
            this.rbNewton.Checked = true;
            this.rbNewton.Location = new System.Drawing.Point(12, 20);
            this.rbNewton.Name = "rbNewton";
            this.rbNewton.Size = new System.Drawing.Size(70, 17);
            this.rbNewton.TabIndex = 0;
            this.rbNewton.TabStop = true;
            this.rbNewton.Text = "Lagrange";
            this.rbNewton.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(190, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 27);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Hozzáad";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmKulcskockasAnimacio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kulcskockas_aminacio.Properties.Resources.optimised_image_5;
            this.CancelButton = this.btnStart;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.btnParameters);
            this.Controls.Add(this.btnImageMove);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textYCord);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtXCord);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.btnStart);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmKulcskockasAnimacio";
            this.Text = "Kulcskockás Animáció";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKulcskockasAnimacio_FormClosing);
            this.Load += new System.EventHandler(this.frmKulcskockasAnimacio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtXCord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textYCord;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnImageMove;
        private System.Windows.Forms.Button btnParameters;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSpline;
        private System.Windows.Forms.RadioButton rbNewton;
        private System.Windows.Forms.Button btnAdd;
    }
}