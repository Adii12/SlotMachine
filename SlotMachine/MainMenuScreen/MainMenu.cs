using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainMenuScreen
{
    public partial class MainMenu : Form
    {
        PrivateFontCollection egyptFont;
        public MainMenu()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            setupFont();
            setupScreen();

        }

        private void setupFont()
        {
            egyptFont = new PrivateFontCollection();
            int fontLength = Properties.Resources.ISIS.Length;
            byte[] fontData = Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);
        }

        private void setupScreen()
        {
            //background and logo locations and appearence

            backgroundPicture.Dock = DockStyle.Fill;
            int x = this.Height / 2;
            int y = this.Width / 2;
            logoPicture.Location = new Point(x, y-750);
            logoPicture.Parent = backgroundPicture;
            logoPicture.BackColor = Color.Transparent;

            //button setup
            setupButton(quitButton, "Quit", x+950, y+150);
            setupButton(logoutButton, "Logout", x + 950, y+50 );
            setupButton(aboutButton, "About", x+200, y-50);
            setupButton(leaderboardButton, "Leaderboard", x + 200, y - 180);
            setupButton(addcreditButton, "Add Credit", x + 200, y - 310);
            setupButton(playButton, "Play", x + 200, y - 440);

        }


        private void setupButton(Button button, String text, int x, int y)
        {
            button.Font = new Font(egyptFont.Families[0], 30);
            button.BackColor = Color.Orange;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Yellow;
            button.Text = text;
            button.Location = new Point(x, y);
            button.Anchor = AnchorStyles.None;
            button.Width = 180;
            button.Height = 60;
            button.UseCompatibleTextRendering = true;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
              this.Close();
        }

        private void aboutButton_Click(object sender, EventArgs e) {
            AboutScreen.AboutForm about = new AboutScreen.AboutForm();
            about.Show();
        }

        private void leaderboardButton_Click(object sender, EventArgs e) {
            JackpotWinnersScreen.JackpotWinnersForm jackpotWinners = new JackpotWinnersScreen.JackpotWinnersForm();
            jackpotWinners.Show();
        }
    }
}
