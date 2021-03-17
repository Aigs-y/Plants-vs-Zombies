using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PlantVsZombie
{
    public partial class Form1 : Form
    {
        public System.Media.SoundPlayer sp = new SoundPlayer();
        string constring = "data source=localhost;database=pz;user id=root;password=1234;pooling=true;charset=utf8;";
        string user;
        string t_number;
        userinfor fu;
        public Form1()
        {
            InitializeComponent();
            
            sp.SoundLocation = @"F:\操作系统课设\PlantVsZombie\music\1.wav";
            sp.PlayLooping();
            MySqlConnection conn = new MySqlConnection(constring);
            //写入sql语句
            string sql = "select * from login";
            //创建命令对象
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            try
            {
                //打开数据库连接
                conn.Open();
                //执行命令,ExcuteReader返回的是DataReader对象
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    label_name.Text = reader["name"].ToString();
                    label_number.Text= reader["number"].ToString();
                    user = label_name.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
       


        //选项按钮
        private void pictureBox_select_MouseEnter(object sender, EventArgs e)
        {
            Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\images\\interface\\xuanxiang.png");
            pictureBox_select.Image = image;
        }
        private void pictureBox_select_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂时没有内容", "抱歉", MessageBoxButtons.OK);
        }
        private void pictureBox_select_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_select.Image = null;
        }
        //帮助按钮
        private void pictureBox_help_MouseEnter(object sender, EventArgs e)
        {
            Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\images\\interface\\helpbutton.png");
            pictureBox_help.Image = image;
        }
        private void pictureBox_help_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_help.Image = null;
        }
        private void pictureBox_help_Click(object sender, EventArgs e)
        {
            Form_help fh = new Form_help();
            fh.Show();
        }
        //退出按钮
        private void pictureBox_exit_MouseEnter(object sender, EventArgs e)
        {
            Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\images\\interface\\exitbutton.png");
            pictureBox_exit.Image = image;
        }

        private void pictureBox_exit_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_exit.Image = null;
        }

        private void pictureBox_exit_Click(object sender, EventArgs e)
        {
            Form_exit fe = new Form_exit();
            fe.Show();
        }
        //冒险按钮
        private void pictureBox_maoxian_MouseEnter(object sender, EventArgs e)
        {
            Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\images\\interface\\maoxian2.png");
            pictureBox_maoxian.Image = image;
        }

        private void pictureBox_maoxian_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_maoxian.Image = null;
        }
        private void pictureBox_maoxian_Click(object sender, EventArgs e)
        {
            Form2 f1;
            Guanqia2 f2;
            string na = label_name.Text;
            if (label_number.Text=="1")
            {
                f1 = new Form2(na);//子窗体
                f1.Show();
            }
            else if(label_number.Text == "2")
            {
                f2 = new Guanqia2(na);//子窗体
                f2.Show();
            }
        }
        //玩玩小游戏按钮
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\images\\interface\\wanwan2.png");
            pictureBox1.Image = image;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            minigame fm = new minigame();
            fm.Show();
            this.Hide();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\images\\interface\\wanwan2.png");
            pictureBox_user.Image = image;
        }
        //存档栏
        private void pictureBox_user_Click(object sender, EventArgs e)
        {
            fu = new userinfor();
            fu.FormClosing += fuClose;
            fu.Show();
        }
        private void fuClose(object sender, FormClosingEventArgs e)
        {
            if(fu.isok)
            {
                label_name.Text = fu.z_name;
                label_number.Text = fu.z_number.ToString();
            }
            
        }
        private void pictureBox_user_MouseEnter(object sender, EventArgs e)
        {
            Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\images\\interface\\存档栏反应.png");
            pictureBox_user.Image = image;
        }

        private void pictureBox_user_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_user.Image = null;
        }
    }
}
