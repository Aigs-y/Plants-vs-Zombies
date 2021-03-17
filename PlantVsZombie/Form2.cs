using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using MySql.Data.MySqlClient;

namespace PlantVsZombie
{
    public partial class Form2 : Form
    {
        string constring = "data source=localhost;database=pz;user id=root;password=1234;pooling=true;charset=utf8;";
        string uname;//玩家名
        bool isClick = false;   //获取点击坐标的标志
        int pno = 0;    //种植植物类别
        Point zombie3;  //第三排僵尸坐标                      
        Point location_z3 ;   //僵尸初始位置
        int progressbar = 0;//进度条标志
        int threadint = 0;  //僵尸进程数
        bool bulletend = false; //攻击结束标志
        bool isend = false; //碰撞检测
        //植物的血量  5*9矩阵  -1代表未种植
        int[,] pblood ={
            {-1,-1,-1,-1,-1,-1,-1,-1,-1 },
            {-1,-1,-1,-1,-1,-1,-1,-1,-1 },
            {-1,-1,-1,-1,-1,-1,-1,-1,-1 },
            {-1,-1,-1,-1,-1,-1,-1,-1,-1 },
            {-1,-1,-1,-1,-1,-1,-1,-1,-1 },
        };
        //僵尸的血量 暂定一位数组
        int[] zblood = new int[5] { -1, -1, -1, -1, -1 };

        /// <summary>
        /// 计时器（实现动画效果）
        /// </summary>       
        System.Timers.Timer p31_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p31_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p32_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p32_timer_sunflower = new System.Timers.Timer();   //向日葵植物动画
        System.Timers.Timer p33_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p33_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p34_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p34_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p35_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p35_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p36_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p36_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p37_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p37_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p38_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p38_timer_sunflower = new System.Timers.Timer();   //向日葵植物动画
        System.Timers.Timer p39_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p39_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer t_attact3;  //攻击动画


        //标志
        bool[] okbullet = new bool[9] { false, false, false, false, false, false, false, false, false };//子弹发射标志
        bool[] sun_click = new bool[9] { false, false, false, false, false, false, false, false, false };//阳光产出点击标志     
        //线程
        public static ManualResetEvent mre31 = new ManualResetEvent(false);  //僵尸移动线程锁3
        public static ManualResetEvent mre32 = new ManualResetEvent(false);  //僵尸移动线程锁3
        public static ManualResetEvent mre33 = new ManualResetEvent(false);  //僵尸移动线程锁3
        public static ManualResetEvent mre34 = new ManualResetEvent(false);  //僵尸移动线程锁3
        public static ManualResetEvent mre35 = new ManualResetEvent(false);  //僵尸移动线程锁3
        public static ManualResetEvent mre36 = new ManualResetEvent(false);  //僵尸移动线程锁3
        public static ManualResetEvent mre37 = new ManualResetEvent(false);  //僵尸移动线程锁3
        public static ManualResetEvent mre38 = new ManualResetEvent(false);  //僵尸移动线程锁3
        public static ManualResetEvent mre39 = new ManualResetEvent(false);  //僵尸移动线程锁3
        public static ManualResetEvent mre31_bullet = new ManualResetEvent(false);  //子弹线程锁31
        public static ManualResetEvent mre32_bullet = new ManualResetEvent(false);  //子弹线程锁32
        public static ManualResetEvent mre33_bullet = new ManualResetEvent(false);  //子弹线程锁33
        public static ManualResetEvent mre34_bullet = new ManualResetEvent(false);  //子弹线程锁34
        public static ManualResetEvent mre35_bullet = new ManualResetEvent(false);  //子弹线程锁35
        public static ManualResetEvent mre36_bullet = new ManualResetEvent(false);  //子弹线程锁36
        public static ManualResetEvent mre37_bullet = new ManualResetEvent(false);  //子弹线程锁37
        public static ManualResetEvent mre38_bullet = new ManualResetEvent(false);  //子弹线程锁38
        public static ManualResetEvent mre39_bullet = new ManualResetEvent(false);  //子弹线程锁39

        public System.Media.SoundPlayer sp = new SoundPlayer();
        public Form2(string myname)
        {
            InitializeComponent();
            uname = myname;
            pictureBox_3_zombie.BringToFront();     //把僵尸框放在上面
            //取消控件跨线程访问检测
            Control.CheckForIllegalCrossThreadCalls = false;
            //进度条设置
            progressBar1.Maximum = 100;//设置最大长度值
            progressBar1.Value = 0;//设置当前值
            progressBar1.Step = 10;//设置每次增长多少
            progressBar1.RightToLeft = RightToLeft.Yes;
            progressBar1.RightToLeftLayout = true;//设置从左向右
            t_attact3 = new System.Timers.Timer();
            t_attact3.Interval = 300;
            int i = 0;
            t_attact3.Elapsed += delegate
            {
                i++;
                Image image = Image.FromFile(" F:\\操作系统课设\\PlantVsZombie\\img\\zombies\\zombie\\attack\\z" + i + ".png");
                pictureBox_3_zombie.Image = image;

                if (i == 3)
                {
                    i = 0;
                }
            };
            sp.SoundLocation = @"F:\操作系统课设\PlantVsZombie\music\2.wav";
            sp.PlayLooping();
            //赋值
            zombie3 = pictureBox_3_zombie.Location;
            location_z3 = pictureBox_3_zombie.Location;
            //子线程创建以及执行
            //1.僵尸移动线程
            /*Thread thread_move3 = new Thread(new ThreadStart(ThreadMethod));
            thread_move3.IsBackground = true;     //设置为后台线程，不会阻塞进程的退出
            thread_move3.Start();*/
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadMethod));
            //2.植物和僵尸碰撞线程
            Thread thread_contract = new Thread(new ThreadStart(pz_contract_3));
            thread_contract.IsBackground = true;
            thread_contract.Start();
            //3.豌豆射手子弹线程
            Thread thread_bullet31 = new Thread(new ThreadStart(BulletThread31));
            thread_bullet31.IsBackground = true;
            thread_bullet31.Start();
            Thread thread_bullet32 = new Thread(new ThreadStart(BulletThread32));
            thread_bullet32.IsBackground = true;
            thread_bullet32.Start();
            Thread thread_bullet33 = new Thread(new ThreadStart(BulletThread33));
            thread_bullet33.IsBackground = true;
            thread_bullet33.Start();
            Thread thread_bullet34 = new Thread(new ThreadStart(BulletThread34));
            thread_bullet34.IsBackground = true;
            thread_bullet34.Start();
            Thread thread_bullet35 = new Thread(new ThreadStart(BulletThread35));
            thread_bullet35.IsBackground = true;
            thread_bullet35.Start();
            Thread thread_bullet36 = new Thread(new ThreadStart(BulletThread36));
            thread_bullet36.IsBackground = true;
            thread_bullet36.Start();
            Thread thread_bullet37 = new Thread(new ThreadStart(BulletThread37));
            thread_bullet37.IsBackground = true;
            thread_bullet37.Start();
            Thread thread_bullet38 = new Thread(new ThreadStart(BulletThread38));
            thread_bullet38.IsBackground = true;
            thread_bullet38.Start();
            Thread thread_bullet39 = new Thread(new ThreadStart(BulletThread39));
            thread_bullet39.IsBackground = true;
            thread_bullet39.Start();
        }
        //窗口关闭
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("关闭窗体后，程序会退出！！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 植物卡片点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_pea_Click(object sender, EventArgs e)
        {
            isClick = true;             //允许添加植物
            pno = 1;    //种植豌豆
            if (Convert.ToInt32(label_sun.Text) >= 100)
            {
                label_sun.Text = Convert.ToString(Convert.ToInt32(label_sun.Text) - 100); //阳光减少

            }

        }
        private void button_sunflower_Click(object sender, EventArgs e)
        {
            isClick = true;             //允许添加植物
            pno = 2;    //种植向日葵
            if (Convert.ToInt32(label_sun.Text) >= 50)
            {
                label_sun.Text = Convert.ToString(Convert.ToInt32(label_sun.Text) - 50); //阳光减少

            }
        }
        //产出阳光的点击
        private void pictureBox_sun31_Click(object sender, EventArgs e)
        {
            clickCard(0, pictureBox_sun31);
        }
        private void pictureBox_sun32_Click(object sender, EventArgs e)
        {
            clickCard(1, pictureBox_sun32);
        }

        private void pictureBox_sun33_Click(object sender, EventArgs e)
        {
            clickCard(2, pictureBox_sun33);
        }

        private void pictureBox_sun34_Click(object sender, EventArgs e)
        {
            clickCard(3, pictureBox_sun34);
        }

        private void pictureBox_sun35_Click(object sender, EventArgs e)
        {
            clickCard(4, pictureBox_sun35);
        }

        private void pictureBox_sun36_Click(object sender, EventArgs e)
        {
            clickCard(5, pictureBox_sun36);
        }

        private void pictureBox_sun37_Click(object sender, EventArgs e)
        {
            clickCard(6, pictureBox_sun37);
        }

        private void pictureBox_sun38_Click(object sender, EventArgs e)
        {
            clickCard(7, pictureBox_sun38);
        }

        private void pictureBox_sun39_Click(object sender, EventArgs e)
        {
            clickCard(8, pictureBox_sun39);
        }
        //收集阳光方法
        public void clickCard(int y,PictureBox pb)
        {
            if (sun_click[y])
            {
                sun_click[y] = false;
                pb.Image = null;
                label_sun.Text = Convert.ToString(Convert.ToInt32(label_sun.Text) + 50); //阳光增加
            }

        }
        /// <summary>
        /// 种植物
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //1.第三行植物种植
        private void pictureBox_31_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_31, pictureBox_sun31, p31_timer_pea, p31_timer_sunflower, 2, 0, mre31_bullet);
        }
        private void pictureBox_32_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_32, pictureBox_sun32, p32_timer_pea, p32_timer_sunflower, 2, 1, mre32_bullet);
        }

        private void pictureBox_33_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_33, pictureBox_sun33, p33_timer_pea, p33_timer_sunflower, 2, 2, mre33_bullet);
        }

        private void pictureBox_34_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_34, pictureBox_sun34, p34_timer_pea, p34_timer_sunflower, 2, 3, mre34_bullet);
        }

        private void pictureBox_35_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_35, pictureBox_sun35, p35_timer_pea, p35_timer_sunflower, 2, 4, mre35_bullet);
        }

        private void pictureBox_36_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_36, pictureBox_sun36, p36_timer_pea, p36_timer_sunflower, 2, 5, mre36_bullet);
        }

        private void pictureBox_37_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_37, pictureBox_sun37, p37_timer_pea, p37_timer_sunflower, 2, 6, mre37_bullet);
        }

        private void pictureBox_38_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_38, pictureBox_sun38, p38_timer_pea, p38_timer_sunflower, 2, 7, mre38_bullet);
        }

        private void pictureBox_39_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_39, pictureBox_sun39, p39_timer_pea, p39_timer_sunflower, 2, 8, mre39_bullet);
        }
        //植物种植方法
        public void addPlant(PictureBox pb, PictureBox pbs, System.Timers.Timer timer1, System.Timers.Timer timer2, int x,int y,ManualResetEvent mrebullet)
        {
            if (isClick)
            {
                if (pno == 1 && pblood[x, y] == -1)
                {
                    isClick = false;        //取消点击响应
                    okbullet[y] = true;  //允许发射子弹
                    mrebullet.Set();     //唤醒子弹线程3
                    pblood[x, y] = 5;          //给植物赋予血量
                    timer1.Interval = 150;
                    int p31 = 0;
                    timer1.Elapsed += delegate
                    {
                        p31++;
                        Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\img\\Plants\\pea\\pea" + p31 + ".png");
                        pb.Image = image;

                        if (p31 == 10)
                        {
                            p31 = 0;
                        }
                    };
                    timer1.Start();

                }
                else if (pno == 2 && pblood[x, y] == -1)
                {
                    isClick = false;        //取消点击响应
                    pblood[x, y] = 5;          //给植物赋予血量
                    int suntime = 0;        //阳光产出计时
                    timer2.Interval = 150;
                    int p31 = 0;
                    timer2.Elapsed += delegate
                    {
                        p31++;
                        Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\img\\Plants\\SunFlower\\sunflower" + p31 + ".png");
                        pb.Image = image;

                        Image image_sun = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\img\\Plants\\Sun\\sun.png");
                        if (p31 == 16)
                        {
                            p31 = 0;
                            suntime++;
                        }
                        if (suntime == 4)
                        {
                            suntime = 0;
                            pbs.Image = image_sun;
                            sun_click[y] = true;
                        }
                    };
                    timer2.Start();
                }
            }
        }
        /// <summary>
        /// 线程执行方法
        /// </summary>
        //1.僵尸移动线程方法
        public void ThreadMethod(object sender)
        {
            progressBar1.Value += progressBar1.Step; //让进度条增加一次
            progressbar += 10;
            zblood[2] = 1;          //暂定僵尸1滴血
            Thread.Sleep(2000);
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 100;
            int i = 0;
            timer.Elapsed += delegate
            {
                i++;
                Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\img\\zombies\\zombie\\Zombie1\\Zombie" + i + ".png");
                pictureBox_3_zombie.Image = image;

                if (i == 22)
                {
                    i = 0;
                }
            };
            timer.Start();
            


            //移动
            for (int z3 = 0; (zombie3.X >= 0); z3++)
            {
                bool dool = true;      //确保碰撞处理只出现一次
                zombie3.X -= 5;
                pictureBox_3_zombie.Location = zombie3;
                if (pictureBox_39.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_39.Location.X)
                {
                    dool = false;
                    if (pictureBox_39.Location.X + pictureBox_39.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {                    
                        timer.Close();
                        t_attact3.Start();
                        mre39.WaitOne();
                        t_attact3.Close();
                        timer.Start();
                    }
                }
                else if(pictureBox_38.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_38.Location.X)
                {
                    dool = false;
                    if (pictureBox_38.Location.X + pictureBox_38.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {                        
                        timer.Close();
                        t_attact3.Start();
                        mre38.WaitOne();
                        t_attact3.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_37.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_37.Location.X)
                {
                    dool = false;
                    if (pictureBox_37.Location.X + pictureBox_37.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact3.Start();
                        mre37.WaitOne();
                        t_attact3.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_36.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_36.Location.X)
                {
                    dool = false;
                    if (pictureBox_36.Location.X + pictureBox_36.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact3.Start();
                        mre36.WaitOne();
                        t_attact3.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_35.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_35.Location.X)
                {
                    dool = false;
                    if (pictureBox_35.Location.X + pictureBox_35.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact3.Start();
                        mre35.WaitOne();
                        t_attact3.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_34.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_34.Location.X)
                {
                    dool = false;
                    if (pictureBox_34.Location.X + pictureBox_34.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact3.Start();
                        mre34.WaitOne();
                        t_attact3.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_33.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_33.Location.X)
                {
                    dool = false;
                    if (pictureBox_33.Location.X + pictureBox_33.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact3.Start();
                        mre33.WaitOne();
                        t_attact3.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_32.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_32.Location.X)
                {
                    dool = false;
                    if (pictureBox_32.Location.X + pictureBox_32.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact3.Start();
                        mre32.WaitOne();
                        t_attact3.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_31.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_31.Location.X)
                {
                    dool = false;
                    if (pictureBox_31.Location.X + pictureBox_31.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact3.Start();
                        mre31.WaitOne();
                        t_attact3.Close();
                        timer.Start();
                    }
                }

                //判断僵尸是否死亡
                if (zblood[2]==0)
                {
                    zblood[2] = -1; //僵尸死亡，重置矩阵
                    timer.Close();
                    pictureBox_3_zombie.Image = null;
                    pictureBox_3_zombie.Location = location_z3;
                    zombie3 = location_z3;
                    break;
                }
                Thread.Sleep(100);      //合适间断值为500
            }
            if (zblood[2] != -1)
            {
                isend = false;  //碰撞检测结束
                MessageBox.Show("您的脑子被僵尸吃掉了！！", "提示", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
            threadint++;
            if (threadint < 10)
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadMethod));
            else
            {
                isend = false;  //碰撞检查结束
                bulletend = true;
                MessageBox.Show("您胜利了！！", "恭喜", MessageBoxButtons.OK);
                MySqlConnection conn = new MySqlConnection(constring);
                string sql = String.Format("update login set number=2 where name='{0}'", uname);
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
                Environment.Exit(0);
  
            }
        }


        //2.植物僵尸碰撞---植物掉血
        public void pz_contract_3()
        {
            bool dool = true;   //处理一次
            while (!isend)
            {
                dool = true;
                if (pictureBox_39.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_39.Location.X)
                {
                    if (pictureBox_39.Location.X + pictureBox_39.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[2, 8]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[2, 8] == 0)
                            {
                                mre39.Set();     //唤醒僵尸移动进程
                                pblood[2, 8] = -1;      //植物死亡，重置矩阵
                                pictureBox_39.Image = null;

                                okbullet[8] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p39_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p39_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_38.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_38.Location.X)
                {
                    if (pictureBox_38.Location.X + pictureBox_38.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[2, 7]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[2, 7] == 0)
                            {
                                mre38.Set();     //唤醒僵尸移动进程
                                pblood[2, 7] = -1;      //植物死亡，重置矩阵
                                pictureBox_38.Image = null;

                                okbullet[7] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p38_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p38_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_37.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_37.Location.X)
                {
                    if (pictureBox_37.Location.X + pictureBox_37.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[2, 6]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[2, 6] == 0)
                            {
                                mre37.Set();     //唤醒僵尸移动进程
                                pblood[2, 6] = -1;      //植物死亡，重置矩阵
                                pictureBox_37.Image = null;

                                okbullet[6] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p37_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p37_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_36.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_36.Location.X)
                {
                    if (pictureBox_36.Location.X + pictureBox_36.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[2, 5]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[2, 5] == 0)
                            {
                                mre36.Set();     //唤醒僵尸移动进程
                                pblood[2, 5] = -1;      //植物死亡，重置矩阵
                                pictureBox_36.Image = null;

                                okbullet[5] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p36_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p36_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_35.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_35.Location.X)
                {
                    if (pictureBox_35.Location.X + pictureBox_35.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[2, 4]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[2, 4] == 0)
                            {
                                mre35.Set();     //唤醒僵尸移动进程
                                pblood[2, 4] = -1;      //植物死亡，重置矩阵
                                pictureBox_35.Image = null;

                                okbullet[4] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p35_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p35_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_34.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_34.Location.X)
                {
                    if (pictureBox_34.Location.X + pictureBox_34.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[2, 3]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[2, 3] == 0)
                            {
                                mre34.Set();     //唤醒僵尸移动进程
                                pblood[2, 3] = -1;      //植物死亡，重置矩阵
                                pictureBox_34.Image = null;

                                okbullet[3] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p34_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p34_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_33.Image != null && zblood[2] != 0 && dool&& pictureBox_3_zombie.Location.X> pictureBox_33.Location.X)
                {
                    if (pictureBox_33.Location.X + pictureBox_33.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[2, 2]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[2, 2] == 0)
                            {
                                mre33.Set();     //唤醒僵尸移动进程
                                pblood[2, 2] = -1;      //植物死亡，重置矩阵
                                pictureBox_33.Image = null;

                                okbullet[2] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p33_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p33_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_32.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_32.Location.X)
                {
                    if (pictureBox_32.Location.X + pictureBox_32.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[2, 1]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[2, 1] == 0)
                            {
                                mre32.Set();     //唤醒僵尸移动进程
                                pblood[2, 1] = -1;      //植物死亡，重置矩阵
                                pictureBox_32.Image = null;

                                okbullet[1] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p32_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p32_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_31.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_31.Location.X)
                {
                    if (pictureBox_31.Location.X + pictureBox_31.Width > pictureBox_3_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[2, 0]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[2, 0] == 0)
                            {
                                mre31.Set();     //唤醒僵尸移动进程
                                pblood[2, 0] = -1;      //植物死亡，重置矩阵
                                pictureBox_31.Image = null;

                                okbullet[0] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p31_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p31_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }

            }
        }
        //3.第三行子弹线程
        public void BulletThread31()
        {
            bulletAttack(mre31_bullet, pictureBox_b31, pictureBox_3_zombie, 2, 0, 2);
        }
        public void BulletThread32()
        {
            bulletAttack(mre32_bullet, pictureBox_b32, pictureBox_3_zombie, 2, 1, 2);
        }
        public void BulletThread33()
        {
            bulletAttack(mre33_bullet, pictureBox_b33, pictureBox_3_zombie, 2, 2, 2);
        }
        public void BulletThread34()
        {
            bulletAttack(mre34_bullet, pictureBox_b34, pictureBox_3_zombie, 2, 3, 2);
        }
        public void BulletThread35()
        {
            bulletAttack(mre35_bullet, pictureBox_b35, pictureBox_3_zombie, 2, 4, 2);
        }
        public void BulletThread36()
        {
            bulletAttack(mre36_bullet, pictureBox_b36, pictureBox_3_zombie, 2, 5, 2);
        }
        public void BulletThread37()
        {
            bulletAttack(mre37_bullet, pictureBox_b37, pictureBox_3_zombie, 2, 6, 2);
        }
        public void BulletThread38()
        {
            bulletAttack(mre38_bullet, pictureBox_b38, pictureBox_3_zombie, 2, 7, 2);
        }
        public void BulletThread39()
        {
            bulletAttack(mre39_bullet, pictureBox_b39, pictureBox_3_zombie, 2, 8, 2);
        }
        //子弹攻击方法
        public void bulletAttack(ManualResetEvent mrebullet,PictureBox pb, PictureBox pbz,int x,int y,int xz)
        {
            mrebullet.WaitOne(); //先暂停，等植物种后再唤醒
            Thread.Sleep(1000);
            Point location = pb.Location;   //子弹最初位置
            Point move;
            Image image;
            Image image2;
            image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\img\\Plants\\PeaBullet\\Bullet.png");
            image2 = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\img\\Plants\\PeaBullet\\PeaBulletHit.png");
            while (!bulletend)
            {
                while (zblood[xz] != 0 && zblood[xz] != -1 && okbullet[y] && pbz.Location.X > pb.Location.X)
                {
                    Thread.Sleep(500);
                    move = pb.Location;     //移动后位置
                    pb.Image = image;
                    for (int b31 = 0; move.X + pb.Width < zombie3.X; b31++)
                    {
                        Thread.Sleep(100);
                        move.X += 5;
                        pb.Location = move;

                    }
                    zblood[xz]--;
                    pb.Image = image2;
                    Thread.Sleep(100);
                    pb.Location = location;
                    pb.Image = null;
                }
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
   
}