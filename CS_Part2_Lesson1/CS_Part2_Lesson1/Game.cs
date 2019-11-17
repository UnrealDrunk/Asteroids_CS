using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Collections.Generic;

namespace CS_Part2_Lesson1
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        // Width and Height of the Game field

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] asteroids;
        public static BaseObject[] stars;
        public static BaseObject[] fighters;
        static Missile missile;
        private static List<Missile> missiles = new List<Missile>();
        static Ship ship;
        public static BaseObject[] powerUps;

        static Image background;

        private static Timer timer = new Timer { Interval = 100 };




        static Game()
        {

        }

        public virtual void Init(Form form)
        {
            // graphics output devise
            Graphics g;

            // Provide access to the main graphic context buffer for the current application

            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            // Create an object (drawing surface) and associate it with the form
            // Saving size of forms

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;


            //Associate a buffer in memory with a graphic object to draw in the buffer

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));



            if (GetType() == typeof(Game))
            {
                Load();
                PlaySoundtrack();


                timer.Start();
                timer.Tick += Timer_Tick;

            }


            form.KeyDown += Form_KeyDown;

            Ship.MessageDie += Finish;

        }


        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("Mission Failed", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline),
                Brushes.White, 200, 100);
            Buffer.Render();
        }





        public virtual void Draw()
        {
            //check the graphics output

            //Buffer.Graphics.Clear(Color.Black);

            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));

            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));

            //Buffer.Render();

            //Buffer.Graphics.Clear(Color.Black);

            Buffer.Graphics.DrawImage(background, new Point(0, 0));

            ObjectDraw();

            Buffer.Render();


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }




        public static void Update()
        {


            foreach (BaseObject asteroid in asteroids)
                asteroid.Update();
            foreach (BaseObject star in stars)
                star.Update();

            for (int i = 0; i < powerUps.Length; i++)
            {
                if (powerUps[i] == null)
                    continue;

                powerUps[i].Update();
                var rnd = new Random();
                if (powerUps[i].Collision(ship))
                {
                    ship.EnergyRise(rnd.Next(15, 30));
                    ship.AstroDroidUsed(1);
                    powerUps[i] = null;
                    i--;
                    System.Media.SystemSounds.Asterisk.Play();
                }

            }


            //foreach (BaseObject powerUp in powerUps)
            //{
            //    powerUp.Update();
            //    var rnd = new Random();
            //    if (powerUp.Collision(ship))
            //    {
            //        ship.EnergyRise(rnd.Next(15, 30));
            //        System.Media.SystemSounds.Asterisk.Play();
            //    }
                
             
            //}

            foreach (Missile m in missiles)
            {
                m.Update();
            }

            for (int i = 0; i < fighters.Length; i++)
            {
                if (fighters[i] == null)
                    continue;
                fighters[i].Update();

                for (int j = 0; j < missiles.Count; j++)
                {
                    if (fighters[i] != null && missiles[j].Collision(fighters[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        fighters[i] = null;
                        missiles.RemoveAt(j);
                        j--;
                        ship.FightersCount(1);
                        continue;
                    }
                }


                if (fighters[i] == null || !ship.Collision(fighters[i]))
                    continue;

                var rnd = new Random();
                ship.EnergyLow(rnd.Next(15, 30));
                System.Media.SystemSounds.Asterisk.Play();
                if (ship.Energy <= 0)
                    ship.Die();
              


            }



            //for (int i = 0; i < fighters.Length; i++)
            //{
            //    fighters[i].Update();
            //    if(!fighters[i].Collision(missile))
            //    {

            //        missile.Update();
            //    }  
            //    else
            //    {
            //        System.Media.SystemSounds.Hand.Play();
            //        Console.WriteLine("Missile Hit!");

            //        fighters[i].GetStartPosition();
            //        missile.GetStartPosition();
            //        missile.Update();
            //    }

            //}


        }

        public static void ObjectDraw()
        {


            foreach (BaseObject obj in asteroids)
                obj.Draw();
            foreach (BaseObject obj in stars)
                obj.Draw();

            foreach (BaseObject obj in fighters)
            {
                obj?.Draw();
            }
            foreach (Missile m in missiles)
            {
                m.Draw();
            }

            ship?.Draw();
            if (ship != null)
            {
                Buffer.Graphics.DrawString("Energy: " + ship.Energy, 
                    new Font(FontFamily.GenericSansSerif,16, FontStyle.Regular),
                    Brushes.White,0,0);

                Buffer.Graphics.DrawString("Figters Down: " + ship.FightersDown,
                    new Font(FontFamily.GenericSansSerif, 16, FontStyle.Regular),
                 Brushes.White, 0, 30);

                Buffer.Graphics.DrawString("R2D2 in action: " + ship.AstrDroidUsed,
              new Font(FontFamily.GenericSansSerif, 16, FontStyle.Regular),
           Brushes.White, 0, 60);

            }
            //Buffer.Graphics.DrawString("Mission Failed", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline),
            //   Brushes.White, 200, 100);
            foreach (BaseObject obj in powerUps)
                obj?.Draw();



            //foreach (BaseObject obj in fighters)
            //    obj.Draw();
            //missile.Draw();
            //ship.Draw();
        }


        public static void Load()
        {

            LoadImages();
            //LoadObjMissle();
            LoadObjAsterioids();
            LoadObjStars();
            LoadObjFighters();
            LoadShip();
            LoadPowerUp();
        }


    

        private static void LoadObjMissle()
        {
            Random rand = new Random();

            //object parameters
            int posX = ship.Rect.X + 10;
            int posY = ship.Rect.Y + 4;
            int dirX = 45;
            int dirY = 0;
            int sizewWidth = 50;
            int sizeHeight = 2;

            if (dirX < 0)
                throw new Exception("Missile flies wrong way, please check " +
                    "it's direction dirX parameter inside LoadObjMissle method");


            //object game logic
            missile = new Missile(new Point(posX, posY),
               new Point(dirX, dirY), new Size(sizewWidth, sizeHeight));

            

        }

        private static void LoadObjAsterioids()
        {
            Random rand = new Random();
            asteroids = new BaseObject[30];
            //object parameters

            int posX = 600;
            int posY = 20;
            int dirX = 10;
            int dirY = 10;
            int sizewWidth = 40;
            int sizeHeight = 40;

            //object game logic

            for (int i = 0; i < asteroids.Length; i++)
                asteroids[i] = new Asteroids(new Point(rand.Next(posX), i * posY),
                    new Point(dirX - i, dirY - i), new Size(sizewWidth, sizeHeight));

        }

        private static void LoadObjStars()
        {
            Random rand = new Random();
            stars = new BaseObject[60];
            //object parameters

            int posX = 680;
            int posY = 490;
            int dirX = 20;
            int dirY = 5;
            int sizewWidth = 20;
            int sizeHeight = 20;

            //object game logic

            for (int i = 0; i < stars.Length; i++)
                stars[i] = new Star(new Point(rand.Next(posX), rand.Next(posY)),
                    new Point(dirX - i, dirY - i), new Size(sizewWidth, sizeHeight));
        }


        private static void LoadObjFighters()
        {
            Random rand = new Random();
            fighters = new BaseObject[15];
            //object parameters

            int sizewWidth = 100;
            int sizeHeight = 109;
            int posXleft = sizewWidth + 10;
            int posXright = Game.Width - (sizewWidth + 10);
            int posYup = sizeHeight + 10;
            int posYdown = Game.Height - (sizeHeight + 10);
            int dirX = 5;
            int dirY = 5;


            //object game logic

            for (int i = 0; i < fighters.Length; i++)
                fighters[i] = new Fighter(new Point(rand.Next(posXleft, posXright),
                    rand.Next(posYup, posYdown)),
                    new Point(dirX + i, dirY - i), new Size(sizewWidth, sizeHeight));

        }




        public static void LoadShip()
        {

            int posX = 10;
            int posY = 400;
            int dirX = 5;
            int dirY = 5;
            int sizewWidth = 100;
            int sizeHeight = 82;


            ship = new Ship(new Point(posX, posY), new Point(dirX, dirY),
                new Size(sizewWidth, sizeHeight));
        }


        public static void LoadPowerUp()
        {
            Random rand = new Random();

            powerUps = new BaseObject[5];
            int sizewWidth = 30;
            int sizeHeight = 43;
            int posXleft = sizewWidth + 10;
            int posXright = Game.Width - (sizewWidth + 10);
            int posYup = sizeHeight + 10;
            int posYdown = Game.Height - (sizeHeight + 10);
            int dirX = 5;
            int dirY = 5;


            //object game logic

            for (int i = 0; i < powerUps.Length; i++)
                powerUps[i] = new PowerUp(new Point(rand.Next(posXleft, posXright),
                    rand.Next(posYup, posYdown)),
                    new Point(dirX + i, dirY - i), new Size(sizewWidth, sizeHeight));

        }






        private static void LoadImages()
        {
            Asteroids.Image = Image.FromFile("Assets//asteroid2.png");
            Star.Image = Image.FromFile("Assets\\star5.png");
            Fighter.Image = Image.FromFile("Assets\\fighter.png");
            Game.background = Image.FromFile("Assets\\galaktika4.jpg");
            Ship.Image = Image.FromFile("Assets\\ship2.png");
            PowerUp.Image = Image.FromFile("Assets\\r2d2.png");

        }


        private void PlaySoundtrack()
        {
            SoundPlayer soundPlayer = new SoundPlayer("Assets\\sound.wav");
            soundPlayer.PlayLooping();
        }



        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                missiles.Add(new Missile(new Point(ship.Rect.X + 10, 
                    ship.Rect.Y + 4), new Point(45, 0), new Size(50, 2)));
            if (e.KeyCode == Keys.Up)
                ship.Up();
            if (e.KeyCode == Keys.Down)
                ship.Down();
            if (e.KeyCode == Keys.Left)
                ship.Left();
            if (e.KeyCode == Keys.Right)
                ship.Right();

        }

    


    }




    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }

    }



}