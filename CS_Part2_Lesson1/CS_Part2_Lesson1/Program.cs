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

            form.Show();
            SplashScreen mainMenu = new SplashScreen();
            mainMenu.Init(form);
            mainMenu.Draw();
            Application.Run(form);
        }
    }
}
