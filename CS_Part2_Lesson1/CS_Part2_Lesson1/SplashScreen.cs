using System;
using System.Drawing;
using System.Windows.Forms;

namespace CS_Part2_Lesson1
{
    /// <summary>
    /// Main menu
    /// </summary>
    class SplashScreen : Game
    {
        Form mainForm;
        public override void Init (Form form)
        {
            base.Init(form);
            mainForm = form;
        }

        private Button CreateBtn(string title)
        {
            Size size = new Size(100, 30);
            Point location;
            if (mainForm.Controls.Count < 1)
                location = new Point(Width / 2 - 50, Height / 2 - 105);
            else
                location = new Point(
                    mainForm.Controls[mainForm.Controls.Count - 1].Location.X,
                    mainForm.Controls[mainForm.Controls.Count - 1].Location.Y + 35);
            Button newBtn = new Button()
            {
                Text = title,
                Name = title,
                Size = size,
                Location = location,
            };

            mainForm.Controls.Add(newBtn);
            return newBtn;
        }

        public override void Draw()
        {
            Button startBtn = CreateBtn("Start Game");
            startBtn.Click += startBtn_Click;

            Button records = CreateBtn("Records");
            records.Click += records_Click;

            Button quit = CreateBtn("Quit");
            quit.Click += quit_Click;

            Label authorLabel = new Label()
            {
                Text = "Vladimir Kozhevnikov 2019",
                Size = new Size(180, 30),
                Location = new Point(quit.Location.X, quit.Location.Y + 35)

            };
            mainForm.Controls.Add(authorLabel);

            Label TitleLabel = new Label()
            {
                Text = "Asteroid Wars",
                Size = new Size(380, 130),
                Location = new Point(mainForm.Width / 2 - 120, 60),
                Font = new Font("Microsoft Sans Serif", 30, FontStyle.Bold)

            };
            mainForm.Controls.Add(TitleLabel);

        }

        private void quit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void records_Click(object sender, EventArgs e)
        {
            Form recordform = new Form()
            {
                Text = "Records",
                Width = 450,
                Height = 450
            };

            recordform.Controls.Add(
                new Label()
                {
                    Text = "The best place for future records",
                    Location = new Point(recordform.Width / 3, recordform.Height / 3),
                    Size = new Size(200, 400)

                });
            recordform.ShowDialog();

        }
        /// <summary>
        /// Delete all SplashScreen elements
        /// </summary>
        private void CloseMenu()
        {
            while (mainForm.Controls.Count != 0)
                mainForm.Controls[0].Dispose();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            CloseMenu();
            Game game = new Game();
            game.Init(mainForm);
            game.Draw();
        }



    }
}
