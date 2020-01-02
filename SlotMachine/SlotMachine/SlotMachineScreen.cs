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
        private int[] chances = new int[9];
        private int jackpotChance;
        PrivateFontCollection egyptFont;
        CurrentPlayer currentPlayer;
        WinningsCalculator.WinType[] winTypes;
        Random random = new Random();
        WinningsCalculator. PictureMap[,] pictureMatrix = new WinningsCalculator.PictureMap[3, 5];
        public SlotMachineScreen() {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;


            
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
            currentPlayer = SlotMachine.CurrentPlayer.getInstance();
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
            setupButton(gambleButton, "GAMBLE", spinButton.Location.X + 350, y + 430);
            //gambleButton.Enabled = false;
            gambleButton.Hide();

            setupLabel(BetLabel, "BET: 5000", 35, x - 650, y + 440);   
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
            updateMatrix();
            String s="";
            winTypes = winningsCalculator.findWins(pictureMatrix,winTypes);
            for (int i = 0; i < 15; i++)
            {
                if (winTypes[i] != null)
                {
                    s+=winTypes[i].WinLine+" "+winTypes[i].IconAmount.ToString()+"\n";
                }
            }
            MessageBox.Show(s);
        }
    }
}
