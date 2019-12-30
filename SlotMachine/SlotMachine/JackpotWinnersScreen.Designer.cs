namespace SlotMachine {
    partial class JackpotWinnersScreen {
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
            this.backgroundImage = new System.Windows.Forms.PictureBox();
            this.casinoLogo = new System.Windows.Forms.PictureBox();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.casinoLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundImage
            // 
            this.backgroundImage.Image = global::SlotMachine.Properties.Resources.background_image;
            this.backgroundImage.Location = new System.Drawing.Point(1, 15);
            this.backgroundImage.Margin = new System.Windows.Forms.Padding(4);
            this.backgroundImage.Name = "backgroundImage";
            this.backgroundImage.Size = new System.Drawing.Size(1060, 537);
            this.backgroundImage.TabIndex = 0;
            this.backgroundImage.TabStop = false;
            // 
            // casinoLogo
            // 
            this.casinoLogo.Image = global::SlotMachine.Properties.Resources.vegascasino_logo;
            this.casinoLogo.Location = new System.Drawing.Point(179, 46);
            this.casinoLogo.Margin = new System.Windows.Forms.Padding(4);
            this.casinoLogo.Name = "casinoLogo";
            this.casinoLogo.Size = new System.Drawing.Size(676, 166);
            this.casinoLogo.TabIndex = 1;
            this.casinoLogo.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(753, 425);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "button1";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // JackpotWinnersScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.casinoLogo);
            this.Controls.Add(this.backgroundImage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "JackpotWinnersScreen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.casinoLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox backgroundImage;
        private System.Windows.Forms.PictureBox casinoLogo;
        private System.Windows.Forms.Button cancelButton;
    }
}

