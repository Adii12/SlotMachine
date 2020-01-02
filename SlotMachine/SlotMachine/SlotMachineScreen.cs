using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
<<<<<<< HEAD
=======
using System.Drawing.Text;
using System.Runtime.InteropServices;
>>>>>>> bb88726c59962a3df6a4cd7c1586eba428ab59e8

namespace SlotMachine {
    public partial class SlotMachineScreen : Form {
        Assembly xml;
        dynamic xmlReader;
<<<<<<< HEAD
        private int[] chances = new int[8];
        private int jackpotChance;
        public SlotMachineScreen() {
            InitializeComponent();
            xml = Assembly.Load("XmlReader");
            xmlReader = xml.CreateInstance("XmlReader.XmlReader");
            chances = xmlReader.getChances();
            for (int i = 0; i < 8; i++) {
                Debug.WriteLine(chances[i]);
            }
            jackpotChance = chances[7];
=======
        private int[] chances = new int[9];
        private int jackpotChance;
        PrivateFontCollection egyptFont;
        SlotMachine.CurrentPlayer currentPlayer;
        public SlotMachineScreen() {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            
            InitializeComponent();
            setupFont();
            setupScreen();
           
            xml = Assembly.Load("XmlReader");
            xmlReader = xml.CreateInstance("XmlReader.XmlReader");
            chances = xmlReader.getChances();
            for (int i = 0; i < 9; i++) {
                Debug.WriteLine(chances[i]);
            }
            jackpotChance = chances[8];
            currentPlayer = SlotMachine.CurrentPlayer.getInstance();
        }

        private void setupScreen() {
            BackgroundImage.Dock = DockStyle.Fill;
            SlotsColumns.Parent = BackgroundImage;
            SlotsColumns.Dock = DockStyle.Fill;
            SlotsColumns.BackColor = Color.Transparent;

            int x = this.Width / 2;
            int y = this.Height / 2;

            setupButton(backButton, "Back", x + 700, y + 430);
            setupButton(lessBet, "BET -", x - 860, y + 430);
            setupButton(moreBet, "BET +", lessBet.Location.X + 450, y + 430);
            setupSpinButton(spinButton, "SPIN", x-100, y + 400);
            setupButton(gambleButton, "GAMBLE", spinButton.Location.X + 350, y + 430);
            //gambleButton.Enabled = false;
            gambleButton.Hide();

            setupLabel(BetLabel, "BET: 5000", 35, x-650, y+440);
           
           
        }

        private void setupButton(Button button, String text, int x, int y) {
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

        private void setupSpinButton(Button button, String text, int x, int y) {
            button.Font = new Font(egyptFont.Families[0], 50);
            button.BackColor = Color.Red;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Red;
            button.Text = text;
            button.Location = new Point(x, y);
            button.Anchor = AnchorStyles.None;
            button.Width = 250;
            button.Height = 100;
            button.UseCompatibleTextRendering = true;
        }
        private void setupLabel(Label label, String text, int fontSize, int x, int y) {
            label.Parent = SlotsColumns;
            label.BackColor = Color.Orange;
            label.Font = new Font(egyptFont.Families[0], fontSize);
            label.Text = text;
            label.UseCompatibleTextRendering = true;
            label.Anchor = AnchorStyles.None;
            label.Location = new Point(x, y);
        }

        private void setupFont() {
            egyptFont = new PrivateFontCollection();
            int fontLength = Properties.Resources.ISIS.Length;
            byte[] fontData = Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);
        }

        private void backButton_Click(object sender, EventArgs e) {
            this.Dispose();
>>>>>>> bb88726c59962a3df6a4cd7c1586eba428ab59e8
        }
    }
}
