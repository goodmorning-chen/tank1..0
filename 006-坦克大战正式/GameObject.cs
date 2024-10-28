using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_坦克大战正式
{
    abstract class GameObject
    {
        //坐标
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        //自己画出图片前要自己得到图片，父类不需要实现
        protected abstract Image GetImage();
        //自己画出图片
        public virtual void DrawSelf()//
        {
           //GameFramework一个启动项只有一个
            Graphics g = GameFramework.g;

            g.DrawImage(GetImage(),X,Y);
        }
        public virtual void Update()//动态更新游戏
        {
            DrawSelf();
        }
        public Rectangle GetRectangle()//后面碰撞检查要用
        {
            Rectangle rectangle = new Rectangle(X, Y, Width, Height);//左上角坐标，宽，长
            return rectangle;
        }
    }
}
