namespace PlantVsZombie
{
    partial class newuser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newuser));
            this.pictureBox_ok = new System.Windows.Forms.PictureBox();
            this.pictureBox_cancel = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_ok
            // 
            this.pictureBox_ok.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ok.Location = new System.Drawing.Point(30, 172);
            this.pictureBox_ok.Name = "pictureBox_ok";
            this.pictureBox_ok.Size = new System.Drawing.Size(161, 40);
            this.pictureBox_ok.TabIndex = 0;
            this.pictureBox_ok.TabStop = false;
            this.pictureBox_ok.Click += new System.EventHandler(this.pictureBox_ok_Click);
            // 
            // pictureBox_cancel
            // 
            this.pictureBox_cancel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_cancel.Location = new System.Drawing.Point(206, 172);
            this.pictureBox_cancel.Name = "pictureBox_cancel";
            this.pictureBox_cancel.Size = new System.Drawing.Size(161, 40);
            this.pictureBox_cancel.TabIndex = 1;
            this.pictureBox_cancel.TabStop = false;
            this.pictureBox_cancel.Click += new System.EventHandler(this.pictureBox_cancel_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.Location = new System.Drawing.Point(42, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(315, 25);
            this.textBox1.TabIndex = 2;
            // 
            // newuser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(398, 224);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox_cancel);
            this.Controls.Add(this.pictureBox_ok);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "newuser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "newuser";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_ok;
        private System.Windows.Forms.PictureBox pictureBox_cancel;
        private System.Windows.Forms.TextBox textBox1;
    }
}