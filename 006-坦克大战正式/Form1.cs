using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _006_坦克大战正式
{
    public partial class Form1 : Form
    {
        private Thread t;
        private static Graphics windowG;
        private static Bitmap tempBmp;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//屏幕居中
            //阻塞

            windowG = this.CreateGraphics();//得到图形窗口可以修改绘制

            tempBmp = new Bitmap(450, 450);//为什么要创建一个临时的bmp ？？？？？？？？解决闪烁问题
            Graphics bmpG = Graphics.FromImage(tempBmp);//这能临时绘制在上面吗？？？？能

            GameFramework.g = bmpG;

            t = new Thread(new ThreadStart(GameMainThread));
            t.Start();

        }
        //为什么要再开一个线程，主线程在干什么？？？？？主线程在绘制。再开一个线程处理
        private void GameMainThread()
        {
            //GameFramework
            GameFramework.Start();

            int sleepTime = 1000 / 60;
            while(true)
            {
                GameFramework.g.Clear(Color.Black);
                GameFramework.Update();
                windowG.DrawImage(tempBmp, 0, 0);//先在temoBmp上绘制完成之后再复制到窗体windowG上
                Thread.Sleep(sleepTime);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Abort();
        }
        //事件 消息 事件消息
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyDown(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyUp(e);
        }
    }
}
