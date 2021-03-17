using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlantVsZombie
{
    public partial class Form_exit : Form
    {
        public Form_exit()
        {
            InitializeComponent();
            //窗体背景透明
            this.BackColor = Color.FromArgb(255, 255, 254);
            this.TransparencyKey = Color.FromArgb(255, 255, 254);
        }

        private void pictureBox_ok_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_ok_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;//设置鼠标为手指形
        }

        private void pictureBox_cancel_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;//设置鼠标为手指形
        }
    }
}
