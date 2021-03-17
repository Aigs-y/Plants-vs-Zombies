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
    public partial class newuser : Form
    {
        string constring = "data source=localhost;database=pz;user id=root;password=1234;pooling=true;charset=utf8;";
        
        string newname = null;
        public newuser()
        {
            InitializeComponent();
            //窗体背景透明
            this.BackColor = Color.FromArgb(255, 255, 254);
            this.TransparencyKey = Color.FromArgb(255, 255, 254);
            
        }

        private void pictureBox_ok_Click(object sender, EventArgs e)
        {
            newname = textBox1.Text.ToString();
            MySqlConnection conn = new MySqlConnection(constring);
            string sql = String.Format("insert into login(name,number) values('{0}',1)", newname);
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

        private void pictureBox_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
