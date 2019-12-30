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

namespace SlotMachine {
    public partial class MainMenuScreen : Form {
        PrivateFontCollection egyptFont;
<<<<<<< HEAD:SlotMachine/SlotMachine/MainMenuScreen.cs
        //CurrentPlayer.CurrentPlayer currentPlayer;
=======
>>>>>>> bb88726c59962a3df6a4cd7c1586eba428ab59e8:SlotMachine/MainMenuScreen/MainMenu.cs
        public MainMenuScreen() {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            setupFont();
            setupScreen();
        }

        private void setupFont() {
            egyptFont = new PrivateFontCollection();
            int fontLength = SlotMachine.Properties.Resources.ISIS.Length;
            byte[] fontData = SlotMachine.Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);
        }

        private void setupScreen() {
            //background and logo locations and appearence

            backgroundPicture.Dock = DockStyle.Fill;
            int x = this.Height / 2;
            int y = this.Width / 2;
            logoPicture.Location = new Point(x, y - 750);
            logoPicture.Parent = backgroundPicture;
            logoPicture.BackColor = Color.Transparent;

            //button setup
            setupButton(quitButton, "Quit", x + 950, y + 150);
            setupButton(logoutButton, "Logout", x + 950, y + 50);
            setupButton(aboutButton, "About", x + 200, y - 50);
            setupButton(leaderboardButton, "Leaderboard", x + 200, y - 180);
            setupButton(addcreditButton, "Add Credit", x + 200, y - 310);
            setupButton(playButton, "Play", x + 200, y - 440);

        }


        private void setupButton(Button button, String text, int x, int y) {
<<<<<<< HEAD:SlotMachine/SlotMachine/MainMenuScreen.cs
            button.Font = new Font(egyptFont.Families[0], 30);
=======
            button.Font = new Font(egyptFont.Families[0], 20);
>>>>>>> bb88726c59962a3df6a4cd7c1586eba428ab59e8:SlotMachine/MainMenuScreen/MainMenu.cs
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

        private void quitButton_Click(object sender, EventArgs e) {
            System.Environment.Exit(1);
        }

        private void logoutButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void aboutButton_Click(object sender, EventArgs e) {
           SlotMachine.AboutScreen about = new SlotMachine.AboutScreen();
           about.Show();
        }

        private void leaderboardButton_Click(object sender, EventArgs e) {
            SlotMachine.JackpotWinnersScreen jackpotWinners = new SlotMachine.JackpotWinnersScreen();
            jackpotWinners.Show();
        }

        private void playButton_Click(object sender, EventArgs e) {
           SlotMachine.SlotMachineScreen slotMachine = new SlotMachine.SlotMachineScreen();
           slotMachine.Show();
        }
    }
}
