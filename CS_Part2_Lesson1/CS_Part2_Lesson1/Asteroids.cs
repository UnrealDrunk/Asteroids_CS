using System.Drawing;


namespace CS_Part2_Lesson1
{
    class Asteroids : BaseObject
    {
        public static Image Image { get; set; }
        

        public Asteroids(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            
            Game.Buffer.Graphics.DrawImage(Image, Pos);
           

        }

        public override void Update()
        {
            Pos.Y = Pos.Y + Dir.Y;

            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }


        public override void GetStartPosition()
        {
      

        }


    }
}
