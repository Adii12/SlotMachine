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
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace SlotMachine {
    public partial class SlotMachineScreen : Form {
        Assembly xml;
        dynamic xmlReader;
        private int[] chances = new int[9];
        private int jackpotChance;
        PrivateFontCollection egyptFont;
        SlotMachine.CurrentPlayer currentPlayer;
        private int[] bets = new int[6];
        int bet_pos_in_vector;


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
            
            bet_pos_in_vector = 0;
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
            gambleButton.Hide();

            createBets(bets);
            setupLabel(BetLabel, "BET: "+bets[bet_pos_in_vector], 35, x-650, y+440);         
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

        private void createBets(int[] bets) {
            bets[0] = 50;
            bets[1] = 100;
            bets[2] = 500;
            bets[3] = 1000;
            bets[4] = 2500;
            bets[5] = 5000;
        }
       
        private void backButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void lessBet_Click(object sender, EventArgs e) {
            if (bet_pos_in_vector == 0)
                bet_pos_in_vector = 5; //daca ajunge la cel mai mic bet si se apasa butonul = > se pune pe bet cel mai mare
            else
                bet_pos_in_vector--;

            BetLabel.Text = "BET: " + bets[bet_pos_in_vector];
        }

        private void moreBet_Click(object sender, EventArgs e) {
            if (bet_pos_in_vector == 5)
                bet_pos_in_vector = 0;  //daca ajunge la cel mai mare bet si se apasa butonul = > se reseteaza bet ul
            else 
                bet_pos_in_vector++;

            BetLabel.Text = "BET: " + bets[bet_pos_in_vector];
        }
    }
}
