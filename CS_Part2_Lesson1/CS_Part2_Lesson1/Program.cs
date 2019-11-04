using System;
using System.Windows.Forms;


// Сздаём шаблон приложения, где подключаем модули

namespace CS_Part2_Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form()
            {
                Text = "Asteroid wars",
                Width = 800,
                Height = 600,
            };
         
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
            Console.ReadKey();
        }
    }
}
