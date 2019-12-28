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

namespace JackpotWinnersScreen
{
    public partial class JackpotWinnersForm : Form
    {
        private PrivateFontCollection egyptFont;
        public JackpotWinnersForm()
        {
            InitializeComponent();
            setupScreen();
        }

        private void setupScreen()
        {
            setupFont();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            backgroundImage.Dock = DockStyle.Fill;

            int x = this.Width/2;
            int y = this.Height/2;

            for (int i = 1; i <= 10; i++)
            {
                setupLabel("test"+i, x-400, (y-400)+(i*75));
            }
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

        private void setupLabel(String text,int x, int y)
        {
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
        
    }
}
