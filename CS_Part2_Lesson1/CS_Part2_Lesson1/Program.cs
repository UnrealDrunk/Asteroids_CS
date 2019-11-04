using System;
using System.Windows.Forms;


// Creating the Application template to connect modules

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
                Height = 600
            };

            // Checking the form size before start.
            //It's necessary W = 800, H = 600
            if (form.Width < 800 || form.Width > 800 ||
                form.Height <600 || form.Height >600)
                throw new ArgumentOutOfRangeException("Wrong screen sizes," +
                    " please check Width & Height");
           
            form.Show();
            SplashScreen mainMenu = new SplashScreen();
            mainMenu.Init(form);
            mainMenu.Draw();
            Application.Run(form);
        }
    }
}
