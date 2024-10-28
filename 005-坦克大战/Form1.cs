using _005_坦克大战.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _005_坦克大战
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.CenterScreen;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(1000,500);

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            #region 怎么画线，输入字符串，打印图片
            //画线
            Graphics g = this.CreateGraphics();//相当于画布
            Pen p = new Pen(Color.Black);//绘制画笔
            g.DrawLine(p, new Point(0, 0), new Point(100, 100));//画线

            //输入字符串
            g.DrawString("去你的", new Font("隶书", 20),
                new SolidBrush(Color.Red),
                new Point(100, 100));

            //添加资源，自动帮你加载资源
            //绘制图片
            Image image=Properties.Resources.Boss;

            Bitmap bm = Properties.Resources.Star1;
            bm.MakeTransparent(Color.Black);//Bitmap比Image多点功能，如去除黑色背景变成透明背景

            g.DrawImage(bm, 250, 250);
            g.DrawImage(image, 200, 200);

            #endregion
        }
    }
}
 