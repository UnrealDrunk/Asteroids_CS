using System;
using System.Drawing;

namespace CS_Part2_Lesson1
{
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            this.size = size;
        }

        public Rectangle Rect => new Rectangle(Pos, size);

        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }

        public abstract void Draw();


        public abstract void Update();
    

      

    }
}
