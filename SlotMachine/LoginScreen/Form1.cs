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


namespace LoginScreen
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            createBackground();
            setupLabel();
            
        }

        public void createBackground()
        {
           BackgroundImage.Dock = DockStyle.Fill;
           
        }

      
    
        public void setupLabel()
        {

            userLabel.Parent = BackgroundImage;
            userLabel.BackColor = Color.Transparent;
            usernameTextbox.Parent = BackgroundImage;
          

            passwordLabel.Parent = BackgroundImage;
            passwordLabel.BackColor = Color.Transparent;
            passwordLabel.Parent = BackgroundImage;
            

 
            int x = this.Width / 2;
            int y = this.Height / 2;
            userLabel.Location = new Point(x-200,y-100);
            passwordLabel.Location = new Point(userLabel.Location.X,y);

            
            usernameTextbox.Location = new Point(userLabel.Location.X + 220, y-95);
            passwordTextbox.Location = new Point(passwordLabel.Location.X + 220, y+8);
            loginButton.Location= new Point(passwordLabel.Location.X + 160, y + 100);


            PrivateFontCollection egyptFont = new PrivateFontCollection();
            int fontLength = Properties.Resources.ISIS.Length;
            byte[] fontData = Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);

            
            

            userLabel.Font = new Font(egyptFont.Families[0], 35);       // username label font
            userLabel.Text = "Username: ";
            passwordLabel.Font = new Font(egyptFont.Families[0], 35);   // password label font
            passwordLabel.Text = "Password: ";
           
            loginButton.Font = new Font(egyptFont.Families[0], 35);
            loginButton.BackColor = Color.Orange;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderColor = Color.Yellow;

           

            registerButton.Font = new Font(egyptFont.Families[0], 35);
            registerButton.BackColor = Color.Orange;
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.FlatAppearance.BorderColor = Color.Yellow;

            registerButton.Location = new Point(loginButton.Location.X , loginButton.Location.Y+105);
            noAccountLabel.Location= new Point(loginButton.Location.X+10, loginButton.Location.Y + 80);
            

            usernameTextbox.BackColor = Color.Yellow;
            passwordTextbox.BackColor = Color.Yellow;

           casinoLogo.Location = new Point(usernameTextbox.Location.X -250,usernameTextbox.Location.Y -230);
            casinoLogo.Parent = BackgroundImage;
            casinoLogo.BackColor = Color.Transparent;

         }

           void authentication() { 




        }
    }
}
