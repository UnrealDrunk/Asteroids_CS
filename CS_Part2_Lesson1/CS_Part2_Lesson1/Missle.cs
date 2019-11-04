﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Part2_Lesson1
{
    class Missle: BaseObject
    {
        int speed;
        Random rand = new Random();

        public Missle(Point pos, Point dir, Size size): base(pos, dir, size)
        {
            speed = dir.X;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, size.Width, size.Height);
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

        private int ChangePosY()
        {
            int randomizer =0;
            int step = 100;
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
