using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Part2_Lesson1
{
    class Star: BaseObject
    {
        public static Image Image { get; set; }
        
        public Star(Point pos, Point dir, Size size): base(pos,dir,size)
        {

        }

        public override void Draw()
        {
          
            Game.Buffer.Graphics.DrawImage(Image, Pos);
    

        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
        }

        public override void GetStartPosition()
        {
            

        }


    }
}
