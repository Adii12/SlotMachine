using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text.RegularExpressions;

namespace JackpotWinnersScreen {
    public partial class JackpotWinnersForm : Form {
        Assembly databaseDLL;
        dynamic db;
        private PrivateFontCollection egyptFont;
        string data = "";
        string[] lines;
        public JackpotWinnersForm() {
            InitializeComponent();
            databaseDLL = Assembly.Load("Database");
            if (databaseDLL == null) {
                MessageBox.Show("Could not load database assembly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }
            db = databaseDLL.CreateInstance("Database.Database");
            db.Init();
            setupScreen();
        }

        private void setupScreen() {
            setupFont();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            backgroundImage.Dock = DockStyle.Fill;
                       
            int x = this.Width / 2;
            int y = this.Height / 2;

            casinoLogo.Location = new Point(x, y - 300);
            casinoLogo.Parent = backgroundImage;
            casinoLogo.BackColor = Color.Transparent;

            int i = 1;
            getData(data);
            foreach (string line in lines) {
                setupLabel(line, x - 400, (y - 400) + (i * 75));
                ++i;
            }
        }

        private void setupFont() {
            egyptFont = new PrivateFontCollection();
            int fontLength = Properties.Resources.ISIS.Length;
            byte[] fontData = Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);
        }

        private void setupLabel(String text, int x, int y) {
            Label label = new Label();
            label.Parent = backgroundImage;
            label.BackColor = Color.Transparent;
            label.Font = new Font(egyptFont.Families[0], 35);
            label.Text = text;
            label.UseCompatibleTextRendering = true;
            label.Size = new Size(100, 75);
            label.Anchor = AnchorStyles.None;
            label.Location = new Point(x, y);
        }
        private void getData(string data) {
            db.InsertWinner("alqaida", 1000);
            db.InsertWinner("obama", 999);
            db.InsertWinner("biciclentiu", 427);
            data=db.SelectWinners();
          
            lines = Regex.Split(data, "\n");
            MessageBox.Show(lines[0]);
        }
    }
}
