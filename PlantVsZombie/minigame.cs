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
    public partial class minigame : Form
    {
        public minigame()
        {
            InitializeComponent();
        }

        //返回菜单
        private void pictureBox_last_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_last_MouseEnter(object sender, EventArgs e)
        {
            Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\images\\interface\\lastbutton2.png");
            pictureBox_last.Image = image;
        }

        private void pictureBox_last_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_last.Image = null;
        }

        private void pictureBox_m1_MouseEnter(object sender, EventArgs e)
        {
            Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\images\\interface\\bao2.png");
            pictureBox_m1.Image = image;
        }

        private void pictureBox_m1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_m1.Image = null;
        }

        private void pictureBox_m1_Click(object sender, EventArgs e)
        {

        }
    }
}
