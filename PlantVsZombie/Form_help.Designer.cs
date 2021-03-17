namespace PlantVsZombie
{
    partial class Form_help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_help));
            this.pictureBox_ok = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ok)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_ok
            // 
            this.pictureBox_ok.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_ok.Location = new System.Drawing.Point(343, 465);
            this.pictureBox_ok.Name = "pictureBox_ok";
            this.pictureBox_ok.Size = new System.Drawing.Size(165, 33);
            this.pictureBox_ok.TabIndex = 0;
            this.pictureBox_ok.TabStop = false;
            this.pictureBox_ok.Click += new System.EventHandler(this.pictureBox_ok_Click);
            this.pictureBox_ok.MouseEnter += new System.EventHandler(this.pictureBox_ok_MouseEnter);
            this.pictureBox_ok.MouseLeave += new System.EventHandler(this.pictureBox_ok_MouseLeave);
            // 
            // Form_help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(846, 535);
            this.Controls.Add(this.pictureBox_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_help";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "帮助";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ok)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_ok;
    }
}