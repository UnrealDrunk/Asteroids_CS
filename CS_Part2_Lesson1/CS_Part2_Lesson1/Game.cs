using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace CS_Part2_Lesson1
{
     class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] asteroids;
        public static BaseObject[] stars;
        public static BaseObject[] fighters;
        static Missle missle;


        static Image background;


        static Game()
        {

        }

        public virtual void Init(Form form)
        {
            //графическое устройство для вывода графики
            Graphics g;

            // Предоставляет доступ к главному буферу графического контекста для текущего приложения

            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

           

            if(GetType()==typeof(Game))
            {
                Load();
                PlaySoundtrack();

                Timer timer = new Timer { Interval = 100 };
                timer.Start();
                timer.Tick += Timer_Tick;

            }


        }

        public virtual void Draw()
        {
            // проверяем вывод графики

            //Buffer.Graphics.Clear(Color.Black);

            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));

            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));

            //Buffer.Render();

            //Buffer.Graphics.Clear(Color.Black);

            Buffer.Graphics.DrawImage(background, new Point(0, 0));
      
            ObjectDraw();
          
          
            Buffer.Render();




        }

        private  void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }




        public static void Update()
        {
           

            foreach (BaseObject obj in asteroids)
                obj.Update();
            foreach (BaseObject obj in stars)
                obj.Update();
            for (int i = 0; i < fighters.Length; i++)
            {
                fighters[i].Update();
                if(!fighters[i].Collision(missle))
                {

                    missle.Update();
                }  
                else
                {
                    System.Media.SystemSounds.Hand.Play();
                    Console.WriteLine("Missle Hit!");
                    
                    fighters[i].GetStartPosition();
                    missle.GetStartPosition();
                    missle.Update();
                }
               
            }
            

                //missle.Update();

        }

        public static void ObjectDraw()
        {
            foreach (BaseObject obj in asteroids)
                obj.Draw();
            foreach (BaseObject obj in stars)
                obj.Draw();
            foreach (BaseObject obj in fighters)
                obj.Draw();
            missle.Draw();
        }



       



        public static void Load()
        {
            
            asteroids = new BaseObject[30];
            stars = new BaseObject[60];
            fighters = new BaseObject[5];

            Random rand = new Random();

            missle = new Missle(new Point(0, rand.Next(400)), new Point(15, 0), new Size(50, 2));

            LoadImages();

            for (int i = 0; i < asteroids.Length; i++)
                asteroids[i] = new Asteroids(new Point(rand.Next(600), i * 20), new Point(10- i, 10- i), new Size(40, 40));

            for (int i = 0; i < stars.Length; i++)
                stars[i] = new Star(new Point(rand.Next(780), rand.Next(590)), new Point(20-i, 5-i), new Size(20, 20));

            for (int i = 0; i < fighters.Length; i++)
                fighters[i] = new Fighter(new Point(rand.Next(700), rand.Next(550)), new Point(5 + i, 5 - i), new Size(100, 109));


            
        }


        private static void LoadImages()
        {
            Asteroids.Image = Image.FromFile("Assets//asteroid2.png");
            Star.Image = Image.FromFile("Assets\\star5.png");
            Fighter.Image = Image.FromFile("Assets\\fighter.png");
            Game.background = Image.FromFile("Assets\\galaktika4.jpg");
         

        }

        private void PlaySoundtrack()
        {
            SoundPlayer soundPlayer = new SoundPlayer("Assets\\sound.wav");
            soundPlayer.PlayLooping();
        }

        




    }

    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }

    }



}
