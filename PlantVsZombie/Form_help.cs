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
    public partial class Form_help : Form
    {
        public Form_help()
        {
            InitializeComponent();
        }

        private void pictureBox_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_ok_MouseEnter(object sender, EventArgs e)
        {
            Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\images\\interface\\zhu2.png");
            pictureBox_ok.BackgroundImage = image;
        }

        private void pictureBox_ok_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_ok.BackgroundImage = null;
        }
    }
}
