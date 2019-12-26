﻿namespace LoginScreen
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
       

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BackgroundImage = new System.Windows.Forms.PictureBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.casinoLogo = new System.Windows.Forms.PictureBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.noAccountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.casinoLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundImage
            // 
            this.BackgroundImage.Image = ((System.Drawing.Image)(resources.GetObject("BackgroundImage.Image")));
            this.BackgroundImage.Location = new System.Drawing.Point(-1, -1);
            this.BackgroundImage.Margin = new System.Windows.Forms.Padding(0);
            this.BackgroundImage.Name = "BackgroundImage";
            this.BackgroundImage.Size = new System.Drawing.Size(1331, 717);
            this.BackgroundImage.TabIndex = 0;
            this.BackgroundImage.TabStop = false;
            // 
            // userLabel
            // 
            this.userLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userLabel.AutoSize = true;
            this.userLabel.BackColor = System.Drawing.SystemColors.Window;
            this.userLabel.Font = new System.Drawing.Font("Matura MT Script Capitals", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.Location = new System.Drawing.Point(437, 242);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(176, 52);
            this.userLabel.TabIndex = 1;
            this.userLabel.Text = "Username:";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.userLabel.UseCompatibleTextRendering = true;
            this.userLabel.UseMnemonic = false;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(437, 335);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(182, 50);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.passwordLabel.UseCompatibleTextRendering = true;
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameTextbox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.usernameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTextbox.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextbox.Location = new System.Drawing.Point(705, 250);
            this.usernameTextbox.Multiline = true;
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(200, 38);
            this.usernameTextbox.TabIndex = 3;
            this.usernameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordTextbox.BackColor = System.Drawing.Color.White;
            this.passwordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextbox.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextbox.Location = new System.Drawing.Point(705, 350);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(200, 36);
            this.passwordTextbox.TabIndex = 4;
            this.passwordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordTextbox.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginButton.BackColor = System.Drawing.Color.Yellow;
            this.loginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loginButton.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.Color.Black;
            this.loginButton.Location = new System.Drawing.Point(611, 447);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(146, 48);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            // 
            // casinoLogo
            // 
            this.casinoLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.casinoLogo.BackColor = System.Drawing.Color.Transparent;
            this.casinoLogo.Image = global::LoginScreen.Properties.Resources.vegascasino_logo;
            this.casinoLogo.Location = new System.Drawing.Point(408, 43);
            this.casinoLogo.Name = "casinoLogo";
            this.casinoLogo.Size = new System.Drawing.Size(530, 148);
            this.casinoLogo.TabIndex = 6;
            this.casinoLogo.TabStop = false;
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.Yellow;
            this.registerButton.FlatAppearance.BorderSize = 0;
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.Location = new System.Drawing.Point(611, 569);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(146, 48);
            this.registerButton.TabIndex = 7;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = false;
            // 
            // noAccountLabel
            // 
            this.noAccountLabel.AutoSize = true;
            this.noAccountLabel.BackColor = System.Drawing.Color.Transparent;
            this.noAccountLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noAccountLabel.ForeColor = System.Drawing.Color.Black;
            this.noAccountLabel.Location = new System.Drawing.Point(626, 543);
            this.noAccountLabel.Name = "noAccountLabel";
            this.noAccountLabel.Size = new System.Drawing.Size(122, 13);
            this.noAccountLabel.TabIndex = 8;
            this.noAccountLabel.Text = "Don\'t have an account?";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 715);
            this.Controls.Add(this.noAccountLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.casinoLogo);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.BackgroundImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.casinoLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BackgroundImage;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.PictureBox casinoLogo;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label noAccountLabel;
    }
}

