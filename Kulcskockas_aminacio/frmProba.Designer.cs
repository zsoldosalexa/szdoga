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
            this.textXCor = new System.Windows.Forms.TextBox();
            this.textYCord = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textXCor
            // 
            this.textXCor.Location = new System.Drawing.Point(0, 12);
            this.textXCor.Name = "textXCor";
            this.textXCor.Size = new System.Drawing.Size(100, 20);
            this.textXCor.TabIndex = 0;
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
            this.button1.Location = new System.Drawing.Point(120, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(735, 400);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(53, 38);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // frmProba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textYCord);
            this.Controls.Add(this.textXCor);
            this.Name = "frmProba";
            this.Text = "frmProba";
            this.Load += new System.EventHandler(this.frmProba_Load);
            this.Click += new System.EventHandler(this.frmProba_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textXCor;
        private System.Windows.Forms.MaskedTextBox textYCord;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}