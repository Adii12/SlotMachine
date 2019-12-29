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

namespace AboutScreen {
    public partial class AboutScreen : Form {
        PrivateFontCollection egyptFont;
        public AboutScreen() {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            setupFont();
            InitializeComponent();
            setupScreen();
        }

        private void setupFont() {
            egyptFont = new PrivateFontCollection();
            int fontLength = Properties.Resources.ISIS.Length;
            byte[] fontData = Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);
        }

        private void setupScreen() {
            BackgroundImage.Dock = DockStyle.Fill;

            int x = this.Width / 2;
            int y = this.Height / 2;

            setupButton(QuitButton, "Back");
            QuitButton.Location = new Point(x + 970, y + 650);

            setupLabel(DevelopersLabel, "DEVELOPERS:", 55);
            DevelopersLabel.Location = new Point(casinoLogo.Location.X + 470, casinoLogo.Location.Y+200);

            casinoLogo.Location = new Point(x + 50, y - 300);
            casinoLogo.Parent = BackgroundImage;
            casinoLogo.BackColor = Color.Transparent;
        }
        private void setupLabel(Label label, String text, int fontSize) {
            label.Parent = BackgroundImage;
            label.Font = new Font(egyptFont.Families[0], fontSize);
            label.BackColor = Color.Transparent;
            label.Text = text;
            label.UseCompatibleTextRendering = true;
        }

        private void setupButton(Button button, String text) {
            button.Font = new Font(egyptFont.Families[0], 30);
            button.BackColor = Color.Orange;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Yellow;
            button.Text = text;
            button.UseCompatibleTextRendering = true;
        }

        private void QuitButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }
    }
}
