using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PlantVsZombie
{
    public partial class userinfor : Form
    {
        //传回主窗体
        public string z_name;
        public string z_number;
        public bool isok = false;
        string constring = "data source=localhost;database=pz;user id=root;password=1234;pooling=true;charset=utf8;";
        string[] user=new string[7];
        int i = 0;
        string delete_name = null;
        public userinfor()
        {
            InitializeComponent();
            //窗体背景透明
            this.BackColor = Color.FromArgb(255, 255, 254);
            this.TransparencyKey = Color.FromArgb(255, 255, 254);


            MySqlConnection conn = new MySqlConnection(constring);
            //写入sql语句
            string sql = "select * from login";
            //创建命令对象
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                //打开数据库连接
                conn.Open();
                //执行命令,ExcuteReader返回的是DataReader对象
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()&&i<7)
                {
                    //button1.Text = reader["name"].ToString();
                    user[i] = reader["name"].ToString();
                    i++;
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

            //赋值
            for (int j = 1; j < i+1; j++)
            {
                Controls["button" + j].Text = user[j - 1];
                Controls["button" + j].Visible = true;
            }
        }
        //更换用户
        private void pictureBox_ok_Click(object sender, EventArgs e)
        {
            isok = true;
            string sql = String.Format("select * from login where name='{0}'", delete_name);
            MySqlConnection conn = new MySqlConnection(constring);
            //创建命令对象
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                //打开数据库连接
                conn.Open();
                //执行命令,ExcuteReader返回的是DataReader对象
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    z_name = reader["name"].ToString();               
                    z_number = reader["number"].ToString();
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
            this.Close();
        }


        private void pictureBox_new_Click(object sender, EventArgs e)
        {
            newuser fn = new newuser();
            fn.Show();
            this.Close();
        }

        private void pictureBox_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //删除
        private void pictureBox_delete_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);
            string sql = String.Format("delete from login where name='{0}'", delete_name);
            try
            {
                //打开数据库连接
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            this.Close();
        }
        //获取删除
        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            delete_name = button3.Text.ToString();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            delete_name = button1.Text.ToString();
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            delete_name = button2.Text.ToString();
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            delete_name = button4.Text.ToString();
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            delete_name = button5.Text.ToString();
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            delete_name = button6.Text.ToString();
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            delete_name = button7.Text.ToString();
        }
    }
}
