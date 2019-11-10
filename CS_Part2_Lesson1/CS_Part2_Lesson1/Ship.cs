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
        private int energy = 100;
        public int Energy => energy;

        public void EnergyLow(int n)
        {
            energy = -n;
        }

        public Ship(Point pos, Point dir, Size size): base(pos,dir,size)
        {

        }





        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, size.Width, size.Height);
        }



        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;

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
