﻿namespace JackpotWinnersScreen {
    partial class JackpotWinnersForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JackpotWinnersForm));
            this.backgroundImage = new System.Windows.Forms.PictureBox();
            this.casinoLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.casinoLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundImage
            // 
            this.backgroundImage.Image = ((System.Drawing.Image)(resources.GetObject("backgroundImage.Image")));
            this.backgroundImage.Location = new System.Drawing.Point(1, 12);
            this.backgroundImage.Name = "backgroundImage";
            this.backgroundImage.Size = new System.Drawing.Size(795, 436);
            this.backgroundImage.TabIndex = 0;
            this.backgroundImage.TabStop = false;
            // 
            // casinoLogo
            // 
            this.casinoLogo.Image = ((System.Drawing.Image)(resources.GetObject("casinoLogo.Image")));
            this.casinoLogo.Location = new System.Drawing.Point(349, 50);
            this.casinoLogo.Name = "casinoLogo";
            this.casinoLogo.Size = new System.Drawing.Size(100, 50);
            this.casinoLogo.TabIndex = 1;
            this.casinoLogo.TabStop = false;
            // 
            // JackpotWinnersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.casinoLogo);
            this.Controls.Add(this.backgroundImage);
            this.Name = "JackpotWinnersForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.casinoLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox backgroundImage;
        private System.Windows.Forms.PictureBox casinoLogo;
    }
}

