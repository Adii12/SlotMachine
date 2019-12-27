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

namespace LoginScreen
{
    public partial class LoginForm : Form
    {
        System.Reflection.Assembly databaseDLL;
        dynamic db;
        PrivateFontCollection egyptFont;
        public LoginForm()
        {
<<<<<<< HEAD
=======
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
>>>>>>> e9fc81d91c8d5e216289a25039d1e3e74638411c
            setupFont();
            InitializeComponent();
            setupScreen();
            databaseDLL = System.Reflection.Assembly.Load("Database");
            if(databaseDLL == null) {
                MessageBox.Show("Could not load database assembly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }

            db = databaseDLL.CreateInstance("Database.Database");
            db.Init();
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

        public void setupScreen()
        {
            BackgroundImage.Dock = DockStyle.Fill;

            setupLabel(userLabel, "Username:", 35);
            setupLabel(passwordLabel, "Password:", 35);
            setupLabel(noAccountLabel, "Don't have an account?", 20);

            setupTextBox(usernameTextbox);
            setupTextBox(passwordTextbox);

            setupButton(loginButton, "Login");
            setupButton(registerButton, "Register");
<<<<<<< HEAD
=======
            setupButton(quitButton, "Quit");
>>>>>>> e9fc81d91c8d5e216289a25039d1e3e74638411c

            int x = this.Width / 2;
            int y = this.Height / 2;

            //locations
            userLabel.Location = new Point(x - 200, y - 100);
            passwordLabel.Location = new Point(userLabel.Location.X, y);

            usernameTextbox.Location = new Point(userLabel.Location.X + 220, y - 95);
            passwordTextbox.Location = new Point(passwordLabel.Location.X + 220, y + 8);

            loginButton.Location = new Point(passwordLabel.Location.X + 160, y + 100);
            registerButton.Location = new Point(loginButton.Location.X, loginButton.Location.Y + 105);
<<<<<<< HEAD
=======
            quitButton.Location = new Point(x + 1050, y + 619);
>>>>>>> e9fc81d91c8d5e216289a25039d1e3e74638411c

            noAccountLabel.Location = new Point(loginButton.Location.X - 15, loginButton.Location.Y + 70);

            casinoLogo.Location = new Point(usernameTextbox.Location.X - 250, usernameTextbox.Location.Y - 230);
            casinoLogo.Parent = BackgroundImage;
            casinoLogo.BackColor = Color.Transparent;
        }
        private void setupLabel(Label label, String text, int fontSize)
        {
            label.Parent = BackgroundImage;
            label.Font= new Font(egyptFont.Families[0], fontSize);
            label.BackColor = Color.Transparent;
            label.Text = text;
            label.UseCompatibleTextRendering = true;
        }

        private void setupTextBox(TextBox textBox) {
            textBox.Parent = BackgroundImage;
            textBox.BackColor = Color.Yellow;
        }

        private void setupButton(Button button,String text)
        {
            button.Font = new Font(egyptFont.Families[0], 30);
            button.BackColor = Color.Orange;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Yellow;
            button.Text = text;
<<<<<<< HEAD
=======
            button.UseCompatibleTextRendering = true;
>>>>>>> e9fc81d91c8d5e216289a25039d1e3e74638411c
        }

        private void loginButton_MouseClick(object sender, MouseEventArgs e) {

<<<<<<< HEAD
            if (db.AuthenticateUser(usernameTextbox.Text, passwordTextbox.Text) == true)
                MessageBox.Show("Succesfully logged in!");
            else
                MessageBox.Show("Incorrect username and/or password!");
        }

        private void registerButton_Click(object sender, EventArgs e) {
            RegisterScreen.RegisterForm registerScreen = new RegisterScreen.RegisterForm();
            registerScreen.Show();

            //db.InsertUser(usernameTextbox.Text, passwordTextbox.Text);
=======
            if (db.AuthenticateUser(usernameTextbox.Text, passwordTextbox.Text) == true) {
                MessageBox.Show("Logat");
            }
            else
                MessageBox.Show("Sinucide te");

        }

        private void registerButton_Click(object sender, EventArgs e) {

            if (RegisterScreen.RegisterForm.registerInstance == null)
            {
                RegisterScreen.RegisterForm.registerInstance = new RegisterScreen.RegisterForm();
                RegisterScreen.RegisterForm.registerInstance.Show();
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
>>>>>>> e9fc81d91c8d5e216289a25039d1e3e74638411c
        }
    }
}
