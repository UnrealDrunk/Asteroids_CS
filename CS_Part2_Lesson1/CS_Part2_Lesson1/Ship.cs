using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CS_Part2_Lesson1
{
    class Ship: BaseObject
    {
        private int energy = 300;
        public int Energy => energy;

        private int fightersDown;
        public int FightersDown => fightersDown;

        public static Image Image { get; set; }



        public void EnergyLow(int n)
        {
            energy -=n;
        }


        public void FightersCount(int n)
        {
            fightersDown += n;
        }

        public Ship(Point pos, Point dir, Size size): base(pos,dir,size)
        {

        }


        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }



        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < Game.Height-50) Pos.Y = Pos.Y + Dir.Y;

        }


        public void Left()
        {
            if(Pos.X > 0) Pos.X = Pos.X - Dir.X;
        }

        public void Right()
        {
            if (Pos.Y < Game.Width-50) Pos.X = Pos.X + Dir.X;

        }


        public delegate void Message();
        public static event Message MessageDie;

        public void Die()
        {
            MessageDie?.Invoke();
        }

        public override void GetStartPosition()
        {
            
        }

        public override void Update()
        {
           
        }
    }
}
