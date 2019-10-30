using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Part2_Lesson1
{
    class Fighter: BaseObject
    {
        public static Image Image { get; set; }

        public Fighter(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {

            Game.Buffer.Graphics.DrawImage(Image, Pos);


        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 100) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 100) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }

    }
}
