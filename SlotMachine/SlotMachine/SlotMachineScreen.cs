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
using System.Threading;
namespace SlotMachine {
    public partial class SlotMachineScreen : Form {
        Assembly xml;
        dynamic xmlReader;
        Assembly winningsCalc;
        dynamic winningsCalculator;
        Assembly database;
        dynamic db;
       
        private int[] chances = new int[9];
        private int jackpotChance;
        PrivateFontCollection egyptFont;
        CurrentPlayer currentPlayer;

        private int[] bets = new int[6];
        int bet_pos_in_vector;

        WinningsCalculator.WinType[] winTypes;
        Random random = new Random();
        WinningsCalculator. PictureMap[,] pictureMatrix = new WinningsCalculator.PictureMap[3, 5];

        double userCredits;
        double win;

        Graphics graphics;
        public SlotMachineScreen() {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            currentPlayer = SlotMachine.CurrentPlayer.getInstance();

            database = Assembly.Load("Database");
            db = database.CreateInstance("Database.Database");
            db.Init();

            InitializeComponent();
            setupFont();
            setupScreen();

            winningsCalc = Assembly.Load("WinningsCalculator");
            winningsCalculator = winningsCalc.CreateInstance("WinningsCalculator.WinningsCalculator");
            
            xml = Assembly.Load("XmlReader");
            xmlReader = xml.CreateInstance("XmlReader.XmlReader");
            chances = xmlReader.getChances();

            winTypes = new WinningsCalculator.WinType[15];
            
            for (int i = 0; i < 9; i++) {
                Debug.WriteLine(chances[i]);
            }
           
            jackpotChance = chances[8];
            
            bet_pos_in_vector = 0;
            
            setupMatrix();
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
            setupSpinButton(gambleButton, "GAMBLE", spinButton.Location.X + 350, y + 400);
            setupButton(PaytableButton, "Paytable", x - 953, y - 430);
            //gambleButton.Enabled = false;
            gambleButton.Hide();

            createBets(bets);
            setupLabel(BetLabel, "BET: " + bets[bet_pos_in_vector], 35, x - 650, y + 440);

            userCredits = db.GetBalance(currentPlayer.getUsername());
            setupLabel(CreditsLabel, "Credits:\n"+userCredits ,28, PaytableButton.Location.X, PaytableButton.Location.Y + 300);

            setupLabel(WinLabel, "Win:\n", 28, CreditsLabel.Location.X, CreditsLabel.Location.Y + 200);
        }

        private void setupButton(Button button, String text, int x, int y) {
            button.Font = new Font(egyptFont.Families[0], 25);
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
            button.Font = new Font(egyptFont.Families[0], 45);
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
        private void createPic(int i,int j)
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(286, 286);
            pic.Parent = SlotsColumns;
            pic.BackColor = Color.Transparent;
            int y = 25 + (286 * i);
            int x = 200 + (310 * j);
            pic.Location = new Point(x, y);
            pictureMatrix[i, j].PictureBox = pic;
            pictureMatrix[i, j].PictureBox.BackgroundImageLayout = ImageLayout.Zoom;
        }
        private int[] generatePic(int i,int j)
        {
            int[] checks=new int[2];
            checks[0] = 0;
            checks[1] = 0;
            int rnd = random.Next(1, 100);
            if (rnd < chances[0])
            {
                pictureMatrix[i,j].PictureBox.Image = SlotMachine.Properties.Resources.cherry;
                pictureMatrix[i, j].ImageId = "cherry";
            }
            else if (rnd < (chances[0] + chances[1]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.orange;
                pictureMatrix[i, j].ImageId = "orange";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.lemon;
                pictureMatrix[i, j].ImageId = "lemon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.plum;
                pictureMatrix[i, j].ImageId = "plum";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.grapes;
                pictureMatrix[i, j].ImageId = "grapes";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.watermelon;
                pictureMatrix[i, j].ImageId = "watermelon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5] + chances[6]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.star;
                pictureMatrix[i, j].ImageId = "star";
                checks[0] = 1;
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5] + chances[6] + chances[7]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.seven;
                pictureMatrix[i, j].ImageId = "seven";
                checks[1] = 1;
            }
            return checks;
        }

        private void generateNoSeven(int i, int j)
        {
            int rnd = random.Next(1, 95);
            if (rnd < chances[0])
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.cherry;
                pictureMatrix[i, j].ImageId = "cherry";
            }
            else if (rnd < (chances[0] + chances[1]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.orange;
                pictureMatrix[i, j].ImageId = "orange";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.lemon;
                pictureMatrix[i, j].ImageId = "lemon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.plum;
                pictureMatrix[i, j].ImageId = "plum";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.grapes;
                pictureMatrix[i, j].ImageId = "grapes";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.watermelon;
                pictureMatrix[i, j].ImageId = "watermelon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5] + chances[6]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.star;
                pictureMatrix[i, j].ImageId = "star";
            }
        }

        private void generateNoStar(int i, int j)
        {
            int rnd = random.Next(1, 93);
            if (rnd < chances[0])
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.cherry;
                pictureMatrix[i, j].ImageId = "cherry";
            }
            else if (rnd < (chances[0] + chances[1]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.orange;
                pictureMatrix[i, j].ImageId = "orange";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.lemon;
                pictureMatrix[i, j].ImageId = "lemon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.plum;
                pictureMatrix[i, j].ImageId = "plum";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.grapes;
                pictureMatrix[i, j].ImageId = "grapes";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.watermelon;
                pictureMatrix[i, j].ImageId = "watermelon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5] + chances[7]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.seven;
                pictureMatrix[i, j].ImageId = "seven";
            }
        }

        private void generateBasicPic(int i, int j)
        {
            int rnd = random.Next(1, 88);
            if (rnd < chances[0])
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.cherry;
                pictureMatrix[i, j].ImageId = "cherry";
            }
            else if (rnd < (chances[0] + chances[1]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.orange;
                pictureMatrix[i, j].ImageId = "orange";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.lemon;
                pictureMatrix[i, j].ImageId = "lemon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.plum;
                pictureMatrix[i, j].ImageId = "plum";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.grapes;
                pictureMatrix[i, j].ImageId = "grapes";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.watermelon;
                pictureMatrix[i, j].ImageId = "watermelon";
            }
        }

        private void setupMatrix()
        {

            for(int i = 0; i < 3; ++i)
            {
                for(int j = 0; j < 5; ++j)
                {
                    pictureMatrix[i, j] = new WinningsCalculator.PictureMap();
                }
            }
            for(int j = 0; j < 5; j++)
            {
                int[] checks = new int[2];
                checks[0] = 0;
                checks[1] = 0;
                for(int i = 0; i < 3; i++)
                {
                    createPic(i, j);
                    if (checks[0] == 0 && checks[1] == 0)
                    {
                        checks = generatePic(i, j);
                    }
                    else if(checks[0]==1)
                    {
                        generateNoStar(i, j);
                    }
                    else if (checks[1] == 1)
                    {
                        generateNoSeven(i, j);
                    }
                    else
                    {
                        generateBasicPic(i, j);
                    }
                }
            }
        }
        private void updateMatrix()
        {
            for (int j = 0; j < 5; j++)
            {
                int[] checks = new int[2];
                checks[0] = 0;
                checks[1] = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (checks[0] == 0 && checks[1] == 0)
                    {
                        checks = generatePic(i, j);
                    }
                    else if (checks[0] == 1)
                    {
                        generateNoStar(i, j);
                    }
                    else if (checks[1] == 1)
                    {
                        generateNoSeven(i, j);
                    }
                    else
                    {
                        generateBasicPic(i, j);
                    }
                }
            }
        }

        private void spinButton_Click(object sender, EventArgs e)
        {
            win=0;
            WinLabel.Text = "Win:\n" + win;
            if (userCredits >= bets[bet_pos_in_vector]) {
                gambleButton.Hide();
                updateMatrix();
               
                userCredits -= bets[bet_pos_in_vector];
                db.UpdateBalance(currentPlayer.getUsername(), userCredits);
                CreditsLabel.Text = "Credits:\n" + userCredits;

                String s = "";
                winTypes = winningsCalculator.findWins(pictureMatrix, winTypes);
                for (int i = 0; i < 15; i++) {
                    if (winTypes[i] != null) {
                        s += winTypes[i].WinLine + " " + winTypes[i].IconAmount.ToString() + "\n";
                      
                    }
                }
                if (winTypes[0] != null) {
                    win = calculateWin(bets[bet_pos_in_vector], winTypes);
                    gambleButton.Show();
                    userCredits += win;
                    CreditsLabel.Text = "Credits:\n" + userCredits;
                    WinLabel.Text = "Win:\n" + win;
                    db.UpdateBalance(currentPlayer.getUsername(), userCredits);
                }
                if (s != "") { }
                   // MessageBox.Show(s);}
            }
            else {
                MessageBox.Show("Sorry. You don't have enough credits!");
            }
        }

        private void PaytableButton_Click(object sender, EventArgs e) {
            SlotMachine.Paytable paytable = new SlotMachine.Paytable();
            paytable.Show();
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
        private double calculateWin(int bet, WinningsCalculator.WinType[] winTypes) {
            double win = 0;
            for (int i = 0; i < 15; ++i) {
                if (winTypes[i] != null) {
                    win += bet * winTypes[i].WinAmount;
                }
            }
            return win;
        }

        private void gambleButton_Click(object sender, EventArgs e) {
            this.Hide();
            GamblingScreen gamblingScreen = new GamblingScreen(win);
            gamblingScreen.ShowDialog();
            userCredits -= win;//scade castigul curent

            userCredits+=gamblingScreen.win; //adauga castigul de dupa gambling
            
            CreditsLabel.Text = "Credits:\n" + userCredits;
            WinLabel.Text = "Win:\n" + gamblingScreen.win;
            gambleButton.Hide();
            this.Show();
        }

        private void SlotsColumns_Paint(object sender, PaintEventArgs e) {
            graphics = Graphics.FromImage(SlotsColumns.Image);
            Pen bluePen = new Pen(Color.Blue, 7);
            Pen redPen = new Pen(Color.Red, 7);
            Pen greenPen = new Pen(Color.Green, 7);
            Pen yellowPen = new Pen(Color.Yellow, 7);
            Pen purplePen = new Pen(Color.Purple, 7);
            graphics.DrawLine(bluePen, 200, 454, 1720, 454);

            graphics.DrawLine(redPen, 200, 148, 1720, 148);

            graphics.DrawLine(greenPen, 200, 760, 1720, 760);

            graphics.DrawLine(yellowPen, 200, 168, 960, 760);
            graphics.DrawLine(yellowPen, 960, 760, 1720, 168);

            graphics.DrawLine(purplePen, 200, 740, 960, 168);
            graphics.DrawLine(purplePen, 960, 168, 1720, 760);
            graphics.Dispose();
        }
    }
}
