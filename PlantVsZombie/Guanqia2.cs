using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Media;

namespace PlantVsZombie
{
    public partial class Guanqia2 : Form
    {
        string constring = "data source=localhost;database=pz;user id=root;password=1234;pooling=true;charset=utf8;";
        string uname;//玩家名
        bool isClick = false;   //获取点击坐标的标志
        int pno = 0;    //种植植物类别
        Point zombie2;  //第二排僵尸坐标                      
        Point location_z2;   //僵尸初始位置
        Point zombie3;  //第三排僵尸坐标                      
        Point location_z3;   //僵尸初始位置
        Point zombie4;  //第四排僵尸坐标                      
        Point location_z4;   //僵尸初始位置
        int progressbar = 0;//进度条标志
        int threadint = 0;  //僵尸进程数
        bool bulletend = false; //攻击结束标志
        bool isend2 = false; //碰撞检测
        bool isend3 = false;
        bool isend4 = false;
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
        System.Timers.Timer p21_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p21_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p22_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p22_timer_sunflower = new System.Timers.Timer();   //向日葵植物动画
        System.Timers.Timer p23_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p23_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p24_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p24_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p25_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p25_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p26_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p26_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p27_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p27_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p28_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p28_timer_sunflower = new System.Timers.Timer();   //向日葵植物动画
        System.Timers.Timer p29_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p29_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer t_attact2;  //攻击动画

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

        System.Timers.Timer p41_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p41_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p42_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p42_timer_sunflower = new System.Timers.Timer();   //向日葵植物动画
        System.Timers.Timer p43_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p43_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p44_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p44_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p45_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p45_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p46_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p46_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p47_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p47_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer p48_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p48_timer_sunflower = new System.Timers.Timer();   //向日葵植物动画
        System.Timers.Timer p49_timer_pea = new System.Timers.Timer();  //豌豆植物动画
        System.Timers.Timer p49_timer_sunflower = new System.Timers.Timer();    //向日葵植物动画
        System.Timers.Timer t_attact4;  //攻击动画

        //标志
        //子弹发射标志
        bool[,] okbullet ={
            { false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false },
        };
        //阳光产出点击标志     
        bool[,] sun_click ={
            { false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false },
        };

        //线程
        public static ManualResetEvent mre21 = new ManualResetEvent(false);
        public static ManualResetEvent mre22 = new ManualResetEvent(false);
        public static ManualResetEvent mre23 = new ManualResetEvent(false);
        public static ManualResetEvent mre24 = new ManualResetEvent(false);
        public static ManualResetEvent mre25 = new ManualResetEvent(false);
        public static ManualResetEvent mre26 = new ManualResetEvent(false);
        public static ManualResetEvent mre27 = new ManualResetEvent(false);
        public static ManualResetEvent mre28 = new ManualResetEvent(false);
        public static ManualResetEvent mre29 = new ManualResetEvent(false);  
        public static ManualResetEvent mre21_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre22_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre23_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre24_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre25_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre26_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre27_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre28_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre29_bullet = new ManualResetEvent(false);

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

        public static ManualResetEvent mre41 = new ManualResetEvent(false);
        public static ManualResetEvent mre42 = new ManualResetEvent(false);
        public static ManualResetEvent mre43 = new ManualResetEvent(false);
        public static ManualResetEvent mre44 = new ManualResetEvent(false);
        public static ManualResetEvent mre45 = new ManualResetEvent(false);
        public static ManualResetEvent mre46 = new ManualResetEvent(false);
        public static ManualResetEvent mre47 = new ManualResetEvent(false);
        public static ManualResetEvent mre48 = new ManualResetEvent(false);
        public static ManualResetEvent mre49 = new ManualResetEvent(false);
        public static ManualResetEvent mre41_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre42_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre43_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre44_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre45_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre46_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre47_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre48_bullet = new ManualResetEvent(false);
        public static ManualResetEvent mre49_bullet = new ManualResetEvent(false);

        public System.Media.SoundPlayer sp = new SoundPlayer();

        public Guanqia2(string myname)
        {
            InitializeComponent();
            uname = myname;
            pictureBox_2_zombie.BringToFront();     //把僵尸框放在上面
            pictureBox_3_zombie.BringToFront();
            pictureBox_4_zombie.BringToFront();
            //取消控件跨线程访问检测
            Control.CheckForIllegalCrossThreadCalls = false;
            //进度条设置
            progressBar1.Maximum = 100;//设置最大长度值
            progressBar1.Value = 0;//设置当前值
            progressBar1.Step = 10;//设置每次增长多少
            progressBar1.RightToLeft = RightToLeft.Yes;
            progressBar1.RightToLeftLayout = true;//设置从左向右
            t_attact2 = new System.Timers.Timer();
            t_attact2.Interval = 300;
            int i2 = 0;
            t_attact2.Elapsed += delegate
            {
                i2++;
                Image image = Image.FromFile(" F:\\操作系统课设\\PlantVsZombie\\img\\zombies\\zombie\\attack\\z" + i2 + ".png");
                pictureBox_2_zombie.Image = image;

                if (i2 == 3)
                {
                    i2 = 0;
                }
            };
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
            t_attact4 = new System.Timers.Timer();
            t_attact4.Interval = 300;
            int i4 = 0;
            t_attact4.Elapsed += delegate
            {
                i4++;
                Image image = Image.FromFile(" F:\\操作系统课设\\PlantVsZombie\\img\\zombies\\zombie\\attack\\z" + i4 + ".png");
                pictureBox_4_zombie.Image = image;

                if (i4 == 3)
                {
                    i4 = 0;
                }
            };

            sp.SoundLocation = @"F:\操作系统课设\PlantVsZombie\music\2.wav";
            sp.PlayLooping();
            //赋值
            zombie2 = pictureBox_2_zombie.Location;
            location_z2 = pictureBox_2_zombie.Location;
            zombie3 = pictureBox_3_zombie.Location;
            location_z3 = pictureBox_3_zombie.Location;
            zombie4 = pictureBox_4_zombie.Location;
            location_z4 = pictureBox_4_zombie.Location;

            //子线程创建以及执行
            //1.僵尸移动线程
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadMethod2));
            //2.植物和僵尸碰撞线程
            Thread thread_contract2 = new Thread(new ThreadStart(pz_contract_2));
            thread_contract2.IsBackground = true;
            thread_contract2.Start();
            Thread thread_contract3 = new Thread(new ThreadStart(pz_contract_3));
            thread_contract3.IsBackground = true;
            thread_contract3.Start();
            Thread thread_contract4 = new Thread(new ThreadStart(pz_contract_4));
            thread_contract4.IsBackground = true;
            thread_contract4.Start();
            //3.豌豆射手子弹线程
            Thread thread_bullet21 = new Thread(new ThreadStart(BulletThread21));
            thread_bullet21.IsBackground = true;
            thread_bullet21.Start();
            Thread thread_bullet22 = new Thread(new ThreadStart(BulletThread22));
            thread_bullet22.IsBackground = true;
            thread_bullet22.Start();
            Thread thread_bullet23 = new Thread(new ThreadStart(BulletThread23));
            thread_bullet23.IsBackground = true;
            thread_bullet23.Start();
            Thread thread_bullet24 = new Thread(new ThreadStart(BulletThread24));
            thread_bullet24.IsBackground = true;
            thread_bullet24.Start();
            Thread thread_bullet25 = new Thread(new ThreadStart(BulletThread25));
            thread_bullet25.IsBackground = true;
            thread_bullet25.Start();
            Thread thread_bullet26 = new Thread(new ThreadStart(BulletThread26));
            thread_bullet26.IsBackground = true;
            thread_bullet26.Start();
            Thread thread_bullet27 = new Thread(new ThreadStart(BulletThread27));
            thread_bullet27.IsBackground = true;
            thread_bullet27.Start();
            Thread thread_bullet28 = new Thread(new ThreadStart(BulletThread28));
            thread_bullet28.IsBackground = true;
            thread_bullet28.Start();
            Thread thread_bullet29 = new Thread(new ThreadStart(BulletThread29));
            thread_bullet29.IsBackground = true;
            thread_bullet29.Start();

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

            Thread thread_bullet41 = new Thread(new ThreadStart(BulletThread41));
            thread_bullet41.IsBackground = true;
            thread_bullet41.Start();
            Thread thread_bullet42 = new Thread(new ThreadStart(BulletThread42));
            thread_bullet42.IsBackground = true;
            thread_bullet42.Start();
            Thread thread_bullet43 = new Thread(new ThreadStart(BulletThread43));
            thread_bullet43.IsBackground = true;
            thread_bullet43.Start();
            Thread thread_bullet44 = new Thread(new ThreadStart(BulletThread44));
            thread_bullet44.IsBackground = true;
            thread_bullet44.Start();
            Thread thread_bullet45 = new Thread(new ThreadStart(BulletThread45));
            thread_bullet45.IsBackground = true;
            thread_bullet45.Start();
            Thread thread_bullet46 = new Thread(new ThreadStart(BulletThread46));
            thread_bullet46.IsBackground = true;
            thread_bullet46.Start();
            Thread thread_bullet47 = new Thread(new ThreadStart(BulletThread47));
            thread_bullet47.IsBackground = true;
            thread_bullet47.Start();
            Thread thread_bullet48 = new Thread(new ThreadStart(BulletThread48));
            thread_bullet48.IsBackground = true;
            thread_bullet48.Start();
            Thread thread_bullet49 = new Thread(new ThreadStart(BulletThread49));
            thread_bullet49.IsBackground = true;
            thread_bullet49.Start();
        }
        //种植植物-----------------------------------------------------
        //植物种植方法
        public void addPlant(PictureBox pb, PictureBox pbs, System.Timers.Timer timer1, System.Timers.Timer timer2, int x, int y, ManualResetEvent mrebullet)
        {
            if (isClick)
            {
                if (pno == 1 && pblood[x, y] == -1)
                {
                    isClick = false;        //取消点击响应
                    okbullet[x,y] = true;  //允许发射子弹
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
                            sun_click[x,y] = true;
                        }
                    };
                    timer2.Start();
                }
            }
        }
        private void pictureBox_21_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_21, pictureBox_sun21, p21_timer_pea, p21_timer_sunflower, 1, 0, mre21_bullet);
        }

        private void pictureBox_22_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_22, pictureBox_sun22, p22_timer_pea, p22_timer_sunflower, 1, 1, mre22_bullet);
        }

        private void pictureBox_23_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_23, pictureBox_sun23, p23_timer_pea, p23_timer_sunflower, 1, 2, mre23_bullet);
        }

        private void pictureBox_24_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_24, pictureBox_sun24, p24_timer_pea, p24_timer_sunflower, 1, 3, mre24_bullet);
        }

        private void pictureBox_25_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_25, pictureBox_sun25, p25_timer_pea, p25_timer_sunflower, 1, 4, mre25_bullet);
        }

        private void pictureBox_26_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_26, pictureBox_sun26, p26_timer_pea, p26_timer_sunflower, 1, 5, mre26_bullet);
        }

        private void pictureBox_27_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_27, pictureBox_sun27, p27_timer_pea, p27_timer_sunflower, 1, 6, mre27_bullet);
        }

        private void pictureBox_28_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_28, pictureBox_sun28, p28_timer_pea, p28_timer_sunflower, 1, 7, mre28_bullet);
        }

        private void pictureBox_29_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_29, pictureBox_sun29, p29_timer_pea, p29_timer_sunflower, 1, 8, mre29_bullet);
        }

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

        private void pictureBox_41_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_41, pictureBox_sun41, p41_timer_pea, p41_timer_sunflower, 3, 0, mre41_bullet);
        }

        private void pictureBox_42_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_42, pictureBox_sun42, p42_timer_pea, p42_timer_sunflower, 3, 1, mre42_bullet);
        }

        private void pictureBox_43_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_43, pictureBox_sun43, p43_timer_pea, p43_timer_sunflower, 3, 2, mre43_bullet);
        }

        private void pictureBox_44_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_44, pictureBox_sun44, p44_timer_pea, p44_timer_sunflower, 3, 3, mre44_bullet);
        }

        private void pictureBox_45_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_45, pictureBox_sun45, p45_timer_pea, p45_timer_sunflower, 3, 4, mre45_bullet);
        }

        private void pictureBox_46_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_46, pictureBox_sun46, p46_timer_pea, p46_timer_sunflower, 3, 5, mre46_bullet);
        }

        private void pictureBox_47_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_47, pictureBox_sun47, p47_timer_pea, p47_timer_sunflower, 3, 6, mre47_bullet);
        }

        private void pictureBox_48_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_48, pictureBox_sun48, p48_timer_pea, p48_timer_sunflower, 3, 7, mre48_bullet);
        }

        private void pictureBox_49_Click(object sender, EventArgs e)
        {
            addPlant(pictureBox_49, pictureBox_sun49, p49_timer_pea, p49_timer_sunflower, 3, 8, mre49_bullet);
        }

        //点击阳光----------------------------------------
        //收集阳光方法
        public void clickCard(int x,int y, PictureBox pb)
        {
            if (sun_click[x,y])
            {
                sun_click[x,y] = false;
                pb.Image = null;
                label_sun.Text = Convert.ToString(Convert.ToInt32(label_sun.Text) + 50); //阳光增加
            }

        }
        private void pictureBox_sun21_Click(object sender, EventArgs e)
        {
            clickCard(1, 0, pictureBox_sun21);
        }

        private void pictureBox_sun22_Click(object sender, EventArgs e)
        {
            clickCard(1, 1, pictureBox_sun22);
        }

        private void pictureBox_sun23_Click(object sender, EventArgs e)
        {
            clickCard(1, 2, pictureBox_sun23);
        }

        private void pictureBox_sun24_Click(object sender, EventArgs e)
        {
            clickCard(1, 3, pictureBox_sun24);
        }

        private void pictureBox_sun25_Click(object sender, EventArgs e)
        {
            clickCard(1, 4, pictureBox_sun25);
        }

        private void pictureBox_sun26_Click(object sender, EventArgs e)
        {
            clickCard(1, 5, pictureBox_sun26);
        }

        private void pictureBox_sun27_Click(object sender, EventArgs e)
        {
            clickCard(1, 6, pictureBox_sun27);
        }

        private void pictureBox_sun28_Click(object sender, EventArgs e)
        {
            clickCard(1, 7, pictureBox_sun28);
        }

        private void pictureBox_sun29_Click(object sender, EventArgs e)
        {
            clickCard(1, 8, pictureBox_sun29);
        }

        private void pictureBox_sun31_Click(object sender, EventArgs e)
        {
            clickCard(2, 0, pictureBox_sun31);
        }

        private void pictureBox_sun32_Click(object sender, EventArgs e)
        {
            clickCard(2, 1, pictureBox_sun32);
        }

        private void pictureBox_sun33_Click(object sender, EventArgs e)
        {
            clickCard(2, 2, pictureBox_sun33);
        }

        private void pictureBox_sun34_Click(object sender, EventArgs e)
        {
            clickCard(2, 3, pictureBox_sun34);
        }

        private void pictureBox_sun35_Click(object sender, EventArgs e)
        {
            clickCard(2, 4, pictureBox_sun35);
        }

        private void pictureBox_sun36_Click(object sender, EventArgs e)
        {
            clickCard(2, 5, pictureBox_sun36);
        }

        private void pictureBox_sun37_Click(object sender, EventArgs e)
        {
            clickCard(2, 6, pictureBox_sun37);
        }

        private void pictureBox_sun38_Click(object sender, EventArgs e)
        {
            clickCard(2, 7, pictureBox_sun38);
        }

        private void pictureBox_sun39_Click(object sender, EventArgs e)
        {
            clickCard(2, 8, pictureBox_sun39);
        }

        private void pictureBox_sun41_Click(object sender, EventArgs e)
        {
            clickCard(3, 0, pictureBox_sun41);
        }

        private void pictureBox_sun42_Click(object sender, EventArgs e)
        {
            clickCard(3, 1, pictureBox_sun42);
        }

        private void pictureBox_sun43_Click(object sender, EventArgs e)
        {
            clickCard(3, 2, pictureBox_sun43);
        }

        private void pictureBox_sun44_Click(object sender, EventArgs e)
        {
            clickCard(3, 3, pictureBox_sun44);
        }

        private void pictureBox_sun45_Click(object sender, EventArgs e)
        {
            clickCard(3, 4, pictureBox_sun45);
        }

        private void pictureBox_sun46_Click(object sender, EventArgs e)
        {
            clickCard(3, 5, pictureBox_sun46);
        }

        private void pictureBox_sun47_Click(object sender, EventArgs e)
        {
            clickCard(3, 6, pictureBox_sun47);
        }

        private void pictureBox_sun48_Click(object sender, EventArgs e)
        {
            clickCard(3, 7, pictureBox_sun48);
        }

        private void pictureBox_sun49_Click(object sender, EventArgs e)
        {
            clickCard(3, 8, pictureBox_sun49);
        }
        //点击植物卡片
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
        /// <summary>
        /// 线程执行方法
        /// </summary>
        //1.第二行僵尸移动线程方法
        public void ThreadMethod2(object sender)
        {
            progressBar1.Value += progressBar1.Step; //让进度条增加一次
            progressbar += 5;
            zblood[1] = 1;          //暂定僵尸1滴血
            Thread.Sleep(2000);
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 100;
            int i = 0;
            timer.Elapsed += delegate
            {
                i++;
                Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\img\\zombies\\zombie\\Zombie1\\Zombie" + i + ".png");
                pictureBox_2_zombie.Image = image;

                if (i == 22)
                {
                    i = 0;
                }
            };
            timer.Start();



            //移动
            for (int z3 = 0; (zombie2.X >= 0); z3++)
            {
                bool dool = true;      //确保碰撞处理只出现一次
                zombie2.X -= 5;
                pictureBox_2_zombie.Location = zombie2;
                if (pictureBox_29.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_29.Location.X)
                {
                    dool = false;
                    if (pictureBox_29.Location.X + pictureBox_29.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact2.Start();
                        mre29.WaitOne();
                        t_attact2.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_28.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_28.Location.X)
                {
                    dool = false;
                    if (pictureBox_28.Location.X + pictureBox_28.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact2.Start();
                        mre28.WaitOne();
                        t_attact2.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_27.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_27.Location.X)
                {
                    dool = false;
                    if (pictureBox_27.Location.X + pictureBox_27.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact2.Start();
                        mre27.WaitOne();
                        t_attact2.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_26.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_26.Location.X)
                {
                    dool = false;
                    if (pictureBox_26.Location.X + pictureBox_26.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact2.Start();
                        mre26.WaitOne();
                        t_attact2.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_25.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_25.Location.X)
                {
                    dool = false;
                    if (pictureBox_25.Location.X + pictureBox_25.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact2.Start();
                        mre25.WaitOne();
                        t_attact2.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_24.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_24.Location.X)
                {
                    dool = false;
                    if (pictureBox_24.Location.X + pictureBox_24.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact2.Start();
                        mre24.WaitOne();
                        t_attact2.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_23.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_23.Location.X)
                {
                    dool = false;
                    if (pictureBox_23.Location.X + pictureBox_23.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact2.Start();
                        mre23.WaitOne();
                        t_attact2.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_22.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_22.Location.X)
                {
                    dool = false;
                    if (pictureBox_22.Location.X + pictureBox_22.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact2.Start();
                        mre22.WaitOne();
                        t_attact2.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_21.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_21.Location.X)
                {
                    dool = false;
                    if (pictureBox_21.Location.X + pictureBox_21.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact2.Start();
                        mre21.WaitOne();
                        t_attact2.Close();
                        timer.Start();
                    }
                }

                //判断僵尸是否死亡
                if (zblood[1] == 0)
                {
                    zblood[1] = -1; //僵尸死亡，重置矩阵
                    timer.Close();
                    pictureBox_2_zombie.Image = null;
                    pictureBox_2_zombie.Location = location_z2;
                    zombie2 = location_z2;
                    break;
                }
                Thread.Sleep(100);      //合适间断值为500
            }
            if (zblood[1] != -1)
            {
                isend2 = false;  //碰撞检测结束
                MessageBox.Show("您的脑子被僵尸吃掉了！！", "提示", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
            threadint++;
            if (threadint < 20)
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadMethod3));
            else
            {
                isend2 = false;  //碰撞检查结束
                bulletend = true;
                MessageBox.Show("您胜利了！！", "恭喜", MessageBoxButtons.OK);
                MySqlConnection conn = new MySqlConnection(constring);
                string sql = String.Format("update login set number=3 where name='{0}'", uname);
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

        //1.第三行僵尸移动线程方法
        public void ThreadMethod3(object sender)
        {
            progressBar1.Value += progressBar1.Step; //让进度条增加一次
            progressbar += 5;
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
                else if (pictureBox_38.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_38.Location.X)
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
                if (zblood[2] == 0)
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
                isend3 = false;  //碰撞检测结束
                MessageBox.Show("您的脑子被僵尸吃掉了！！", "提示", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
            threadint++;
            if (threadint < 20)
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadMethod4));  //线程池添加线程---------------------------------------------------
            else
            {
                isend3 = false;  //碰撞检查结束
                bulletend = true;
                MessageBox.Show("您胜利了！！", "恭喜", MessageBoxButtons.OK);
                MySqlConnection conn = new MySqlConnection(constring);
                string sql = String.Format("update login set number=3 where name='{0}'", uname);
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

        //第四行僵尸移动线程方法
        public void ThreadMethod4(object sender)
        {
            progressBar1.Value += progressBar1.Step; //让进度条增加一次
            progressbar += 5;
            zblood[3] = 1;          //暂定僵尸1滴血
            Thread.Sleep(2000);
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 100;
            int i = 0;
            timer.Elapsed += delegate
            {
                i++;
                Image image = Image.FromFile("F:\\操作系统课设\\PlantVsZombie\\img\\zombies\\zombie\\Zombie1\\Zombie" + i + ".png");
                pictureBox_4_zombie.Image = image;

                if (i == 22)
                {
                    i = 0;
                }
            };
            timer.Start();



            //移动
            for (int z3 = 0; (zombie4.X >= 0); z3++)
            {
                bool dool = true;      //确保碰撞处理只出现一次
                zombie4.X -= 5;
                pictureBox_4_zombie.Location = zombie4;
                if (pictureBox_49.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_49.Location.X)
                {
                    dool = false;
                    if (pictureBox_49.Location.X + pictureBox_49.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact4.Start();
                        mre49.WaitOne();
                        t_attact4.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_48.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_48.Location.X)
                {
                    dool = false;
                    if (pictureBox_48.Location.X + pictureBox_48.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact4.Start();
                        mre48.WaitOne();
                        t_attact4.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_47.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_47.Location.X)
                {
                    dool = false;
                    if (pictureBox_47.Location.X + pictureBox_47.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact4.Start();
                        mre47.WaitOne();
                        t_attact4.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_46.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_46.Location.X)
                {
                    dool = false;
                    if (pictureBox_46.Location.X + pictureBox_46.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact4.Start();
                        mre46.WaitOne();
                        t_attact4.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_45.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_45.Location.X)
                {
                    dool = false;
                    if (pictureBox_45.Location.X + pictureBox_45.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact4.Start();
                        mre45.WaitOne();
                        t_attact4.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_44.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_44.Location.X)
                {
                    dool = false;
                    if (pictureBox_44.Location.X + pictureBox_44.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact4.Start();
                        mre44.WaitOne();
                        t_attact4.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_43.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_43.Location.X)
                {
                    dool = false;
                    if (pictureBox_43.Location.X + pictureBox_43.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact4.Start();
                        mre43.WaitOne();
                        t_attact4.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_42.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_42.Location.X)
                {
                    dool = false;
                    if (pictureBox_42.Location.X + pictureBox_42.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact4.Start();
                        mre42.WaitOne();
                        t_attact4.Close();
                        timer.Start();
                    }
                }
                else if (pictureBox_41.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_41.Location.X)
                {
                    dool = false;
                    if (pictureBox_41.Location.X + pictureBox_41.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        timer.Close();
                        t_attact4.Start();
                        mre41.WaitOne();
                        t_attact4.Close();
                        timer.Start();
                    }
                }

                //判断僵尸是否死亡
                if (zblood[3] == 0)
                {
                    zblood[3] = -1; //僵尸死亡，重置矩阵
                    timer.Close();
                    pictureBox_4_zombie.Image = null;
                    pictureBox_4_zombie.Location = location_z4;
                    zombie4 = location_z4;
                    break;
                }
                Thread.Sleep(100);      //合适间断值为500
            }
            if (zblood[3] != -1)
            {
                isend4 = false;  //碰撞检测结束
                MessageBox.Show("您的脑子被僵尸吃掉了！！", "提示", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
            threadint++;
            if (threadint < 20)
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadMethod2));
            else
            {
                isend4 = false;  //碰撞检查结束
                bulletend = true;
                MessageBox.Show("您胜利了！！", "恭喜", MessageBoxButtons.OK);
                MySqlConnection conn = new MySqlConnection(constring);
                string sql = String.Format("update login set number=3 where name='{0}'", uname);
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
        //第二行植物僵尸碰撞---植物掉血
        public void pz_contract_2()
        {
            bool dool = true;   //处理一次
            while (!isend2)
            {
                dool = true;
                if (pictureBox_29.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_29.Location.X)
                {
                    if (pictureBox_29.Location.X + pictureBox_29.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[1, 8]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[1, 8] == 0)
                            {
                                mre29.Set();     //唤醒僵尸移动进程
                                pblood[1, 8] = -1;      //植物死亡，重置矩阵
                                pictureBox_29.Image = null;

                                okbullet[1,8] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p29_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p29_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_28.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_28.Location.X)
                {
                    if (pictureBox_28.Location.X + pictureBox_28.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[1, 7]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[1, 7] == 0)
                            {
                                mre28.Set();     //唤醒僵尸移动进程
                                pblood[1, 7] = -1;      //植物死亡，重置矩阵
                                pictureBox_28.Image = null;

                                okbullet[1,7] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p28_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p28_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_27.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_27.Location.X)
                {
                    if (pictureBox_27.Location.X + pictureBox_27.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[1, 6]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[1, 6] == 0)
                            {
                                mre27.Set();     //唤醒僵尸移动进程
                                pblood[1, 6] = -1;      //植物死亡，重置矩阵
                                pictureBox_27.Image = null;

                                okbullet[1,6] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p27_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p27_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_26.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_26.Location.X)
                {
                    if (pictureBox_26.Location.X + pictureBox_26.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[1, 5]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[1, 5] == 0)
                            {
                                mre26.Set();     //唤醒僵尸移动进程
                                pblood[1, 5] = -1;      //植物死亡，重置矩阵
                                pictureBox_26.Image = null;

                                okbullet[1,5] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p26_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p26_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_25.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_25.Location.X)
                {
                    if (pictureBox_25.Location.X + pictureBox_25.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[1, 4]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[1, 4] == 0)
                            {
                                mre25.Set();     //唤醒僵尸移动进程
                                pblood[1, 4] = -1;      //植物死亡，重置矩阵
                                pictureBox_25.Image = null;

                                okbullet[1,4] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p25_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p25_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_24.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_24.Location.X)
                {
                    if (pictureBox_24.Location.X + pictureBox_24.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[1, 3]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[1, 3] == 0)
                            {
                                mre24.Set();     //唤醒僵尸移动进程
                                pblood[1, 3] = -1;      //植物死亡，重置矩阵
                                pictureBox_24.Image = null;

                                okbullet[1,3] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p24_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p24_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_23.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_23.Location.X)
                {
                    if (pictureBox_23.Location.X + pictureBox_23.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[1, 2]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[1, 2] == 0)
                            {
                                mre23.Set();     //唤醒僵尸移动进程
                                pblood[1, 2] = -1;      //植物死亡，重置矩阵
                                pictureBox_23.Image = null;

                                okbullet[1,2] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p23_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p23_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_22.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_22.Location.X)
                {
                    if (pictureBox_22.Location.X + pictureBox_22.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[1, 1]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[1, 1] == 0)
                            {
                                mre22.Set();     //唤醒僵尸移动进程
                                pblood[1, 1] = -1;      //植物死亡，重置矩阵
                                pictureBox_22.Image = null;

                                okbullet[1,1] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p22_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p22_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_21.Image != null && zblood[1] != 0 && dool && pictureBox_2_zombie.Location.X > pictureBox_21.Location.X)
                {
                    if (pictureBox_21.Location.X + pictureBox_21.Width > pictureBox_2_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[1, 0]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[1, 0] == 0)
                            {
                                mre21.Set();     //唤醒僵尸移动进程
                                pblood[1, 0] = -1;      //植物死亡，重置矩阵
                                pictureBox_21.Image = null;

                                okbullet[1,0] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p21_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p21_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }

            }
        }
        //2.植物僵尸碰撞---植物掉血
        public void pz_contract_3()
        {
            bool dool = true;   //处理一次
            while (!isend3)
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

                                okbullet[1,8] = false; //植物死亡，不允许发射子弹
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

                                okbullet[1,7] = false; //植物死亡，不允许发射子弹
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

                                okbullet[1,6] = false; //植物死亡，不允许发射子弹
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

                                okbullet[1,5] = false; //植物死亡，不允许发射子弹
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

                                okbullet[1,4] = false; //植物死亡，不允许发射子弹
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

                                okbullet[1,3] = false; //植物死亡，不允许发射子弹
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
                else if (pictureBox_33.Image != null && zblood[2] != 0 && dool && pictureBox_3_zombie.Location.X > pictureBox_33.Location.X)
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

                                okbullet[1,2] = false; //植物死亡，不允许发射子弹
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

                                okbullet[1,1] = false; //植物死亡，不允许发射子弹
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

                                okbullet[1,0] = false; //植物死亡，不允许发射子弹
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
        //第四行植物僵尸碰撞---植物掉血
        public void pz_contract_4()
        {
            bool dool = true;   //处理一次
            while (!isend4)
            {
                dool = true;
                if (pictureBox_49.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_49.Location.X)
                {
                    if (pictureBox_49.Location.X + pictureBox_49.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[3, 8]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[3, 8] == 0)
                            {
                                mre49.Set();     //唤醒僵尸移动进程
                                pblood[3,8] = -1;      //植物死亡，重置矩阵
                                pictureBox_49.Image = null;

                                okbullet[3, 8] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p49_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p49_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_48.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_48.Location.X)
                {
                    if (pictureBox_48.Location.X + pictureBox_48.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[3, 7]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[3, 7] == 0)
                            {
                                mre48.Set();     //唤醒僵尸移动进程
                                pblood[3, 7] = -1;      //植物死亡，重置矩阵
                                pictureBox_48.Image = null;

                                okbullet[3, 7] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p48_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p48_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_47.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_47.Location.X)
                {
                    if (pictureBox_47.Location.X + pictureBox_47.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[3, 6]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[3, 6] == 0)
                            {
                                mre47.Set();     //唤醒僵尸移动进程
                                pblood[3, 6] = -1;      //植物死亡，重置矩阵
                                pictureBox_47.Image = null;

                                okbullet[3, 6] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p47_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p47_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_46.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_46.Location.X)
                {
                    if (pictureBox_46.Location.X + pictureBox_46.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[3, 5]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[3, 5] == 0)
                            {
                                mre46.Set();     //唤醒僵尸移动进程
                                pblood[3, 5] = -1;      //植物死亡，重置矩阵
                                pictureBox_46.Image = null;

                                okbullet[3, 5] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p46_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p46_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_45.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_45.Location.X)
                {
                    if (pictureBox_45.Location.X + pictureBox_45.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[3, 4]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[3, 4] == 0)
                            {
                                mre45.Set();     //唤醒僵尸移动进程
                                pblood[3, 4] = -1;      //植物死亡，重置矩阵
                                pictureBox_45.Image = null;

                                okbullet[3, 4] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p45_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p45_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_44.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_44.Location.X)
                {
                    if (pictureBox_44.Location.X + pictureBox_44.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[3, 3]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[3, 3] == 0)
                            {
                                mre44.Set();     //唤醒僵尸移动进程
                                pblood[3, 3] = -1;      //植物死亡，重置矩阵
                                pictureBox_44.Image = null;

                                okbullet[3, 3] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p44_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p44_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_43.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_43.Location.X)
                {
                    if (pictureBox_43.Location.X + pictureBox_43.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[3, 2]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[3, 2] == 0)
                            {
                                mre43.Set();     //唤醒僵尸移动进程
                                pblood[3, 2] = -1;      //植物死亡，重置矩阵
                                pictureBox_43.Image = null;

                                okbullet[3, 2] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p43_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p43_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_42.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_42.Location.X)
                {
                    if (pictureBox_42.Location.X + pictureBox_42.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[3, 1]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[3, 1] == 0)
                            {
                                mre42.Set();     //唤醒僵尸移动进程
                                pblood[3, 1] = -1;      //植物死亡，重置矩阵
                                pictureBox_42.Image = null;

                                okbullet[3, 1] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p42_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p42_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }
                else if (pictureBox_41.Image != null && zblood[3] != 0 && dool && pictureBox_4_zombie.Location.X > pictureBox_41.Location.X)
                {
                    if (pictureBox_41.Location.X + pictureBox_41.Width > pictureBox_4_zombie.Location.X)        //如果植物框与僵尸框相遇
                    {
                        dool = false;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 1000;
                        timer.Elapsed += delegate
                        {
                            pblood[3, 0]--; //每秒减少一血量
                            //植物死亡
                            if (pblood[3, 0] == 0)
                            {
                                mre41.Set();     //唤醒僵尸移动进程
                                pblood[3, 0] = -1;      //植物死亡，重置矩阵
                                pictureBox_41.Image = null;

                                okbullet[3, 0] = false; //植物死亡，不允许发射子弹
                                if (pno == 1)
                                {
                                    p41_timer_pea.Close();
                                }
                                else if (pno == 2)
                                {
                                    p41_timer_sunflower.Close();
                                }
                                timer.Close();
                            }
                        };
                        timer.Start();
                    }
                }

            }
        }
        //子弹攻击方法
        public void bulletAttack(ManualResetEvent mrebullet, PictureBox pb, PictureBox pbz, int x, int y, int xz,Point zp)
        {
            //pb 子弹       pbz 僵尸  x y  横纵坐标     xz第几行僵尸   zp僵尸坐标
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
                while (zblood[xz] != 0 && zblood[xz] != -1 && okbullet[x,y] && pbz.Location.X > pb.Location.X)
                {
                    Thread.Sleep(500);
                    move = pb.Location;     //移动后位置
                    pb.Image = image;
                    zp = pbz.Location;//重新定位一下
                    for (int b31 = 0; move.X + pb.Width < zp.X; b31++)
                    {
                        zp = pbz.Location;
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
        //第二行子弹线程
        public void BulletThread21()
        {
            bulletAttack(mre21_bullet, pictureBox_b21, pictureBox_2_zombie, 1, 0, 1,zombie2);
        }
        public void BulletThread22()
        {
            bulletAttack(mre22_bullet, pictureBox_b22, pictureBox_2_zombie, 1, 1, 1, zombie2);
        }
        public void BulletThread23()
        {
            bulletAttack(mre23_bullet, pictureBox_b23, pictureBox_2_zombie, 1, 2, 1, zombie2);
        }
        public void BulletThread24()
        {
            bulletAttack(mre24_bullet, pictureBox_b24, pictureBox_2_zombie, 1, 3, 1, zombie2);
        }
        public void BulletThread25()
        {
            bulletAttack(mre25_bullet, pictureBox_b25, pictureBox_2_zombie, 1, 4, 1, zombie2);
        }
        public void BulletThread26()
        {
            bulletAttack(mre26_bullet, pictureBox_b26, pictureBox_2_zombie, 1, 5, 1, zombie2);
        }
        public void BulletThread27()
        {
            bulletAttack(mre27_bullet, pictureBox_b27, pictureBox_2_zombie, 1, 6, 1, zombie2);
        }
        public void BulletThread28()
        {
            bulletAttack(mre28_bullet, pictureBox_b28, pictureBox_2_zombie, 1, 7, 1, zombie2);
        }
        public void BulletThread29()
        {
            bulletAttack(mre29_bullet, pictureBox_b29, pictureBox_2_zombie, 1, 8, 1, zombie2);
        }
        //第三行子弹线程
        public void BulletThread31()
        {
            bulletAttack(mre31_bullet, pictureBox_b31, pictureBox_3_zombie, 2, 0, 2,zombie3);
        }
        public void BulletThread32()
        {
            bulletAttack(mre32_bullet, pictureBox_b32, pictureBox_3_zombie, 2, 1, 2, zombie3);
        }
        public void BulletThread33()
        {
            bulletAttack(mre33_bullet, pictureBox_b33, pictureBox_3_zombie, 2, 2, 2, zombie3);
        }
        public void BulletThread34()
        {
            bulletAttack(mre34_bullet, pictureBox_b34, pictureBox_3_zombie, 2, 3, 2, zombie3);
        }
        public void BulletThread35()
        {
            bulletAttack(mre35_bullet, pictureBox_b35, pictureBox_3_zombie, 2, 4, 2, zombie3);
        }
        public void BulletThread36()
        {
            bulletAttack(mre36_bullet, pictureBox_b36, pictureBox_3_zombie, 2, 5, 2, zombie3);
        }
        public void BulletThread37()
        {
            bulletAttack(mre37_bullet, pictureBox_b37, pictureBox_3_zombie, 2, 6, 2, zombie3);
        }
        public void BulletThread38()
        {
            bulletAttack(mre38_bullet, pictureBox_b38, pictureBox_3_zombie, 2, 7, 2, zombie3);
        }
        public void BulletThread39()
        {
            bulletAttack(mre39_bullet, pictureBox_b39, pictureBox_3_zombie, 2, 8, 2, zombie3);
        }
        //第四行子弹线程
        public void BulletThread41()
        {
            bulletAttack(mre41_bullet, pictureBox_b41, pictureBox_4_zombie, 3, 0, 3,zombie4);
        }
        public void BulletThread42()
        {
            bulletAttack(mre42_bullet, pictureBox_b42, pictureBox_4_zombie, 3, 1, 3, zombie4);
        }
        public void BulletThread43()
        {
            bulletAttack(mre43_bullet, pictureBox_b43, pictureBox_4_zombie, 3, 2, 3, zombie4);
        }
        public void BulletThread44()
        {
            bulletAttack(mre44_bullet, pictureBox_b44, pictureBox_4_zombie, 3, 3, 3, zombie4);
        }
        public void BulletThread45()
        {
            bulletAttack(mre45_bullet, pictureBox_b45, pictureBox_4_zombie, 3, 4, 3, zombie4);
        }
        public void BulletThread46()
        {
            bulletAttack(mre46_bullet, pictureBox_b46, pictureBox_4_zombie, 3, 5, 3, zombie4);
        }
        public void BulletThread47()
        {
            bulletAttack(mre47_bullet, pictureBox_b47, pictureBox_4_zombie, 3, 6, 3, zombie4);
        }
        public void BulletThread48()
        {
            bulletAttack(mre48_bullet, pictureBox_b48, pictureBox_4_zombie, 3, 7, 3, zombie4);
        }
        public void BulletThread49()
        {
            bulletAttack(mre49_bullet, pictureBox_b49, pictureBox_4_zombie, 3, 8, 3, zombie4);
        }
        //窗口关闭
        private void Guanqia2_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Guanqia2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
