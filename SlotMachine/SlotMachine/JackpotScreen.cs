using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace SlotMachine {
    public partial class JackpotScreen : Form {
        PrivateFontCollection egyptFont;
        CurrentPlayer currentPlayer;
        int win;
        int newWin;
        Assembly databaseDLL;
        dynamic db;
        public JackpotScreen(int win) {
            InitializeComponent();
            this.win = win;
            currentPlayer = CurrentPlayer.getInstance();
            newWin = this.win * 500;
            Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm-tt") + "Jackpot Won");
            databaseDLL = Assembly.Load("Database");
            db = databaseDLL.CreateInstance("Database.Database");
            db.Init();
            db.InsertWinner(currentPlayer.getUsername(), newWin);
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

        private void setupLabel(Label label, String text, int fontSize, int x, int y) {
            label.Parent = BackgroundImage;
            label.BackColor = Color.Transparent;
            label.Font = new Font(egyptFont.Families[0], fontSize);
            label.Text = text;
            label.UseCompatibleTextRendering = true;
            label.Anchor = AnchorStyles.None;
            label.Location = new Point(x, y);
        }

        private void setupButton(Button button, String text, int x, int y) {
            button.Font = new Font(egyptFont.Families[0], 20);
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

        private void setupScreen()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            setupFont();
            BackgroundImage.Dock = DockStyle.Fill;
            int x = this.Width / 2;
            int y = this.Height / 2;
            JackpotWin.Size = new Size(715, 715);
            JackpotWin.Location = new Point(x - 250, y - 400);
            JackpotWin.Parent = BackgroundImage;
            JackpotWin.BackColor = Color.Transparent;
            JackpotWin.Anchor = AnchorStyles.None;
            Label winLabel = new Label();
            Label winLabel2 = new Label();
            setupLabel(winLabel, "YOU WIN: "+win.ToString()+" x 500",40,x-250,y-100);
            setupLabel(winLabel, newWin.ToString() + " x 500", 40, x - 250, y);
            setupButton(CollectButton, "Collect", x + 700, y + 430);
        }

        private void CollectButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }
    } 
}
