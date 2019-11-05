using System;
using System.Drawing;


namespace CS_Part2_Lesson1
{
    class Missile: BaseObject
    {
        int speed;
        Random rand = new Random();

        public Missile(Point pos, Point dir, Size size): base(pos, dir, size)
        {
            speed = dir.X;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.LightBlue, Pos.X, Pos.Y, size.Width, size.Height);
        }

        public override void Update()
        {
           
            Pos.X = Pos.X + speed;
            
       
            if (Pos.X >= Game.Width + size.Width)
            {
                Pos.X = 0;
                Pos.Y += ChangePosY();
            }
               
        }

        public override void GetStartPosition()
        {
            Pos.X = 0;
           
        }


        private int ChangePosY()
        {
            int randomizer =0;
            int step = 150;
            int stepLimit = step++;

            if (Pos.Y > stepLimit && Pos.Y < Game.Height - stepLimit)
                randomizer = rand.Next(-step, step);
            else if (Pos.Y < stepLimit)
                randomizer = rand.Next(step);
            else if (Pos.Y > Game.Height - stepLimit)
                randomizer = rand.Next(-step, 0);

            return randomizer;

        }


    }
}
