﻿using System;
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

        public static BaseObject[] _objsA;
        public static BaseObject[] _objsB;
        public static BaseObject[] _objsC;
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
            foreach (BaseObject obj in _objsA)
                obj.Update();
            foreach (BaseObject obj in _objsB)
                obj.Update();
            foreach (BaseObject obj in _objsC)
            {
                obj.Update();
                if (obj.Collision(missle))
                {
                    System.Media.SystemSounds.Hand.Play();
                    Console.WriteLine("Missle Hit!");
                    
                    
                };
               
            }

            missle.Update();

        }

        public static void ObjectDraw()
        {
            foreach (BaseObject obj in _objsA)
                obj.Draw();
            foreach (BaseObject obj in _objsB)
                obj.Draw();
            foreach (BaseObject obj in _objsC)
                obj.Draw();
            missle.Draw();
        }



       



        public static void Load()
        {
            
            _objsA = new BaseObject[30];
            _objsB = new BaseObject[60];
            _objsC = new BaseObject[5];

            Random rand = new Random();

            missle = new Missle(new Point(0, rand.Next(400)), new Point(25, 0), new Size(25, 4));

            Asteroids.Image = Image.FromFile("Assets//asteroid2.png");
            for (int i = 0; i < _objsA.Length; i++)
                _objsA[i] = new Asteroids(new Point(rand.Next(600), i * 20), new Point(10- i, 10- i), new Size(40, 40));

            Star.Image = Image.FromFile("Assets\\star5.png");
            for (int i = 0; i < _objsB.Length; i++)
                _objsB[i] = new Star(new Point(rand.Next(780), rand.Next(590)), new Point(20-i, 5-i), new Size(20, 20));

            Fighter.Image = Image.FromFile("Assets\\fighter.png");
            for (int i = 0; i < _objsC.Length; i++)
                _objsC[i] = new Fighter(new Point(rand.Next(700), rand.Next(550)), new Point(5 + i, 5 - i), new Size(100, 109));

            Game.background = Image.FromFile("Assets\\galaktika4.jpg");

            SoundPlayer soundPlayer = new SoundPlayer("Assets\\sound.wav");
            soundPlayer.Play();

           

        }

        






    }

    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }

    }



}
