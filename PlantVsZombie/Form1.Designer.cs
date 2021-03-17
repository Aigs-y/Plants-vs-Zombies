namespace PlantVsZombie
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.zombieAnimateTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox_select = new System.Windows.Forms.PictureBox();
            this.pictureBox_help = new System.Windows.Forms.PictureBox();
            this.pictureBox_exit = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_maoxian = new System.Windows.Forms.PictureBox();
            this.pictureBox_user = new System.Windows.Forms.PictureBox();
            this.label_name = new System.Windows.Forms.Label();
            this.label_number = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_maoxian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_user)).BeginInit();
            this.SuspendLayout();
            // 
            // zombieAnimateTimer
            // 
            this.zombieAnimateTimer.Enabled = true;
            // 
            // pictureBox_select
            // 
            this.pictureBox_select.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_select.Location = new System.Drawing.Point(610, 438);
            this.pictureBox_select.Name = "pictureBox_select";
            this.pictureBox_select.Size = new System.Drawing.Size(61, 33);
            this.pictureBox_select.TabIndex = 1;
            this.pictureBox_select.TabStop = false;
            this.pictureBox_select.Click += new System.EventHandler(this.pictureBox_select_Click);
            this.pictureBox_select.MouseEnter += new System.EventHandler(this.pictureBox_select_MouseEnter);
            this.pictureBox_select.MouseLeave += new System.EventHandler(this.pictureBox_select_MouseLeave);
            // 
            // pictureBox_help
            // 
            this.pictureBox_help.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_help.Location = new System.Drawing.Point(678, 473);
            this.pictureBox_help.Name = "pictureBox_help";
            this.pictureBox_help.Size = new System.Drawing.Size(61, 30);
            this.pictureBox_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_help.TabIndex = 2;
            this.pictureBox_help.TabStop = false;
            this.pictureBox_help.Click += new System.EventHandler(this.pictureBox_help_Click);
            this.pictureBox_help.MouseEnter += new System.EventHandler(this.pictureBox_help_MouseEnter);
            this.pictureBox_help.MouseLeave += new System.EventHandler(this.pictureBox_help_MouseLeave);
            // 
            // pictureBox_exit
            // 
            this.pictureBox_exit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_exit.Location = new System.Drawing.Point(759, 463);
            this.pictureBox_exit.Name = "pictureBox_exit";
            this.pictureBox_exit.Size = new System.Drawing.Size(56, 24);
            this.pictureBox_exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_exit.TabIndex = 3;
            this.pictureBox_exit.TabStop = false;
            this.pictureBox_exit.Click += new System.EventHandler(this.pictureBox_exit_Click);
            this.pictureBox_exit.MouseEnter += new System.EventHandler(this.pictureBox_exit_MouseEnter);
            this.pictureBox_exit.MouseLeave += new System.EventHandler(this.pictureBox_exit_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(438, 216);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // pictureBox_maoxian
            // 
            this.pictureBox_maoxian.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_maoxian.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_maoxian.BackgroundImage")));
            this.pictureBox_maoxian.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_maoxian.Location = new System.Drawing.Point(438, 65);
            this.pictureBox_maoxian.Name = "pictureBox_maoxian";
            this.pictureBox_maoxian.Size = new System.Drawing.Size(330, 145);
            this.pictureBox_maoxian.TabIndex = 5;
            this.pictureBox_maoxian.TabStop = false;
            this.pictureBox_maoxian.Click += new System.EventHandler(this.pictureBox_maoxian_Click);
            this.pictureBox_maoxian.MouseEnter += new System.EventHandler(this.pictureBox_maoxian_MouseEnter);
            this.pictureBox_maoxian.MouseLeave += new System.EventHandler(this.pictureBox_maoxian_MouseLeave);
            // 
            // pictureBox_user
            // 
            this.pictureBox_user.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_user.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_user.BackgroundImage")));
            this.pictureBox_user.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_user.Location = new System.Drawing.Point(42, -5);
            this.pictureBox_user.Name = "pictureBox_user";
            this.pictureBox_user.Size = new System.Drawing.Size(313, 215);
            this.pictureBox_user.TabIndex = 6;
            this.pictureBox_user.TabStop = false;
            this.pictureBox_user.Click += new System.EventHandler(this.pictureBox_user_Click);
            this.pictureBox_user.MouseEnter += new System.EventHandler(this.pictureBox_user_MouseEnter);
            this.pictureBox_user.MouseLeave += new System.EventHandler(this.pictureBox_user_MouseLeave);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.BackColor = System.Drawing.Color.DimGray;
            this.label_name.Font = new System.Drawing.Font("宋体", 10.28571F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_name.ForeColor = System.Drawing.Color.GreenYellow;
            this.label_name.Location = new System.Drawing.Point(185, 81);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(0, 17);
            this.label_name.TabIndex = 7;
            // 
            // label_number
            // 
            this.label_number.AutoSize = true;
            this.label_number.BackColor = System.Drawing.Color.Black;
            this.label_number.Font = new System.Drawing.Font("黑体", 10.28571F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_number.ForeColor = System.Drawing.Color.Silver;
            this.label_number.Location = new System.Drawing.Point(598, 91);
            this.label_number.Name = "label_number";
            this.label_number.Size = new System.Drawing.Size(0, 17);
            this.label_number.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(844, 543);
            this.Controls.Add(this.label_number);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.pictureBox_user);
            this.Controls.Add(this.pictureBox_maoxian);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox_exit);
            this.Controls.Add(this.pictureBox_help);
            this.Controls.Add(this.pictureBox_select);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "植物大战僵尸";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_maoxian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_user)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer zombieAnimateTimer;
        private System.Windows.Forms.PictureBox pictureBox_select;
        private System.Windows.Forms.PictureBox pictureBox_help;
        private System.Windows.Forms.PictureBox pictureBox_exit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox_maoxian;
        private System.Windows.Forms.PictureBox pictureBox_user;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_number;
    }
}

