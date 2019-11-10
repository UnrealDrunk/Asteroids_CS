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

        public int Power { get; set; }

        Random rand = new Random();

        public Fighter(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 50;
        }

        public override void Draw()
        {

            Game.Buffer.Graphics.DrawImage(Image, Pos);


        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X =- Dir.X;
            if (Pos.X > Game.Width-100) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y =- Dir.Y;
            if (Pos.Y > Game.Height-100) Dir.Y = -Dir.Y;
        }

        public override void GetStartPosition()
        {
            Pos.X = Game.Width - 100;
            Pos.Y = rand.Next(100, Game.Height - 100);

        }


    }
}
