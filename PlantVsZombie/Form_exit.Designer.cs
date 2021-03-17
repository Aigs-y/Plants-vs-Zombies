namespace PlantVsZombie
{
    partial class Form_exit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_exit));
            this.pictureBox_ok = new System.Windows.Forms.PictureBox();
            this.pictureBox_cancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_ok
            // 
            this.pictureBox_ok.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ok.Location = new System.Drawing.Point(51, 175);
            this.pictureBox_ok.Name = "pictureBox_ok";
            this.pictureBox_ok.Size = new System.Drawing.Size(170, 37);
            this.pictureBox_ok.TabIndex = 0;
            this.pictureBox_ok.TabStop = false;
            this.pictureBox_ok.Click += new System.EventHandler(this.pictureBox_ok_Click);
            this.pictureBox_ok.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_ok_MouseMove);
            // 
            // pictureBox_cancel
            // 
            this.pictureBox_cancel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_cancel.Location = new System.Drawing.Point(244, 175);
            this.pictureBox_cancel.Name = "pictureBox_cancel";
            this.pictureBox_cancel.Size = new System.Drawing.Size(180, 37);
            this.pictureBox_cancel.TabIndex = 1;
            this.pictureBox_cancel.TabStop = false;
            this.pictureBox_cancel.Click += new System.EventHandler(this.pictureBox_cancel_Click);
            this.pictureBox_cancel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_cancel_MouseMove);
            // 
            // Form_exit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.pictureBox_cancel);
            this.Controls.Add(this.pictureBox_ok);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_exit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "退出";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_ok;
        private System.Windows.Forms.PictureBox pictureBox_cancel;
    }
}