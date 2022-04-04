using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    internal class BaseObject
    {
        //Point pos;//поле
        protected Point Pos { get; set; } //автоматическое свойство
        protected Point Dir { get; set; }//VX,VY

        protected Size Size { get; set; }

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y + Dir.Y);
            //Pos.Offset(Dir);
            if (Pos.X < 0 || Pos.X > Game.Width) Dir = new Point(-Dir.X, Dir.Y);
            if (Pos.Y < 0 || Pos.Y > Game.Height) Dir = new Point(Dir.X, -Dir.Y);
        }


    }

    internal class Star : BaseObject
    {
        static Image img = Image.FromFile(@"Pictures\star.png");
        public Star(Point pos, Point dir) : base(pos, dir, new Size(img.Width, img.Height))
        {

        }

        public override void Draw()//полиморфизм
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);
        }
    }

    internal class Comet : Star
    {
        Image img;
        public Comet(Point pos, Point dir, string imgFilename) : base(pos, dir)
        {
            img = Image.FromFile(imgFilename);
            Size = new Size(img.Width, img.Height);
        }
        public override void Draw()//полиморфизм
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);
        }

    }

}