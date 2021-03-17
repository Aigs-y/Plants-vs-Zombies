namespace PlantVsZombie
{
    partial class minigame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(minigame));
            this.pictureBox_m1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_last = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_m1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_last)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_m1
            // 
            this.pictureBox_m1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_m1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_m1.Location = new System.Drawing.Point(30, 90);
            this.pictureBox_m1.Name = "pictureBox_m1";
            this.pictureBox_m1.Size = new System.Drawing.Size(115, 120);
            this.pictureBox_m1.TabIndex = 0;
            this.pictureBox_m1.TabStop = false;
            this.pictureBox_m1.Click += new System.EventHandler(this.pictureBox_m1_Click);
            this.pictureBox_m1.MouseEnter += new System.EventHandler(this.pictureBox_m1_MouseEnter);
            this.pictureBox_m1.MouseLeave += new System.EventHandler(this.pictureBox_m1_MouseLeave);
            // 
            // pictureBox_last
            // 
            this.pictureBox_last.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_last.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_last.Location = new System.Drawing.Point(21, 570);
            this.pictureBox_last.Name = "pictureBox_last";
            this.pictureBox_last.Size = new System.Drawing.Size(105, 29);
            this.pictureBox_last.TabIndex = 1;
            this.pictureBox_last.TabStop = false;
            this.pictureBox_last.Click += new System.EventHandler(this.pictureBox_last_Click);
            this.pictureBox_last.MouseEnter += new System.EventHandler(this.pictureBox_last_MouseEnter);
            this.pictureBox_last.MouseLeave += new System.EventHandler(this.pictureBox_last_MouseLeave);
            // 
            // minigame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(778, 601);
            this.Controls.Add(this.pictureBox_last);
            this.Controls.Add(this.pictureBox_m1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "minigame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "minigame";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_m1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_last)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_m1;
        private System.Windows.Forms.PictureBox pictureBox_last;
    }
}