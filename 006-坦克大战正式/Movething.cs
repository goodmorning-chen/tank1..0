using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_坦克大战正式
{
    //坦克移动四个方向
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    class Movething:GameObject
    {
        private Object _lock = new object();
        //坦克一点四个方向移动的图片不一样
        public Bitmap BitmapUp { get; set; }
        public Bitmap BitmapDown { get; set; }
        public Bitmap BitmapLeft { get; set; }
        public Bitmap BitmapRight { get; set; }

        public int Speed { get; set; }//Tank的速度
        private Direction dir;
        public Direction Dir
        { 
            get { return dir; }
            set
            {
                dir = value;
                Bitmap bmp = null;

                switch (dir)
                {
                    case Direction.Up:
                        bmp = BitmapUp;
                        break;
                    case Direction.Down:
                        bmp = BitmapDown;
                        break;
                    case Direction.Left:
                        bmp = BitmapLeft;
                        break;
                    case Direction.Right:
                        bmp = BitmapRight;
                        break;
                }
                lock (_lock)
                {
                   if(bmp!=null)
                    {
                        Width = bmp.Width;
                        Height = bmp.Height;
                    }
                }
                
            }
        }//Tank的方向

        protected override Image GetImage()//得到图片以及背景透明化处理
        {
            Bitmap bitmap = null;
            switch(Dir)
            {
                case Direction.Up:
                    bitmap= BitmapUp;
                    break;
                case Direction.Down:
                    bitmap= BitmapDown;
                    break;
                case Direction.Left:
                    bitmap= BitmapLeft;
                    break;
                case Direction.Right:
                    bitmap= BitmapRight;
                    break;
            }
            bitmap.MakeTransparent(Color.Black);//背景透明化处理
            return bitmap;
        }

        public override void DrawSelf()
        {
            lock (_lock)
            {
                base.DrawSelf();
            }
        }
    }
}
