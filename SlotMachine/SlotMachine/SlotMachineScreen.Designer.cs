namespace SlotMachine {
    partial class SlotMachineScreen {
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
            xmlReader.updateJackpot(jackpotChance);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.backButton = new System.Windows.Forms.Button();
            this.SlotsColumns = new System.Windows.Forms.PictureBox();
            this.BackgroundImage = new System.Windows.Forms.PictureBox();
            this.spinButton = new System.Windows.Forms.Button();
            this.moreBet = new System.Windows.Forms.Button();
            this.lessBet = new System.Windows.Forms.Button();
            this.gambleButton = new System.Windows.Forms.Button();
            this.BetLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SlotsColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(535, 337);
            this.backButton.Margin = new System.Windows.Forms.Padding(2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(56, 19);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "button1";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // SlotsColumns
            // 
            this.SlotsColumns.Image = global::SlotMachine.Properties.Resources.sluts;
            this.SlotsColumns.Location = new System.Drawing.Point(6, 6);
            this.SlotsColumns.Margin = new System.Windows.Forms.Padding(2);
            this.SlotsColumns.Name = "SlotsColumns";
            this.SlotsColumns.Size = new System.Drawing.Size(83, 81);
            this.SlotsColumns.TabIndex = 1;
            this.SlotsColumns.TabStop = false;
            this.SlotsColumns.Paint += new System.Windows.Forms.PaintEventHandler(this.SlotsColumns_Paint);
            // 
            // BackgroundImage
            // 
            this.BackgroundImage.Image = global::SlotMachine.Properties.Resources.background_image;
            this.BackgroundImage.Location = new System.Drawing.Point(0, 0);
            this.BackgroundImage.Margin = new System.Windows.Forms.Padding(2);
            this.BackgroundImage.Name = "BackgroundImage";
            this.BackgroundImage.Size = new System.Drawing.Size(602, 370);
            this.BackgroundImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackgroundImage.TabIndex = 0;
            this.BackgroundImage.TabStop = false;
            // 
            // spinButton
            // 
            this.spinButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spinButton.AutoSize = true;
            this.spinButton.BackColor = System.Drawing.Color.Red;
            this.spinButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.spinButton.Location = new System.Drawing.Point(256, 313);
            this.spinButton.Margin = new System.Windows.Forms.Padding(2);
            this.spinButton.Name = "spinButton";
            this.spinButton.Size = new System.Drawing.Size(112, 43);
            this.spinButton.TabIndex = 3;
            this.spinButton.Text = "SPIN";
            this.spinButton.UseVisualStyleBackColor = false;
            this.spinButton.Click += new System.EventHandler(this.spinButton_Click);
            // 
            // moreBet
            // 
            this.moreBet.Location = new System.Drawing.Point(116, 340);
            this.moreBet.Margin = new System.Windows.Forms.Padding(2);
            this.moreBet.Name = "moreBet";
            this.moreBet.Size = new System.Drawing.Size(56, 19);
            this.moreBet.TabIndex = 4;
            this.moreBet.Text = "button1";
            this.moreBet.UseVisualStyleBackColor = true;
            // 
            // lessBet
            // 
            this.lessBet.Location = new System.Drawing.Point(9, 337);
            this.lessBet.Margin = new System.Windows.Forms.Padding(2);
            this.lessBet.Name = "lessBet";
            this.lessBet.Size = new System.Drawing.Size(56, 19);
            this.lessBet.TabIndex = 5;
            this.lessBet.Text = "button1";
            this.lessBet.UseVisualStyleBackColor = true;
            // 
            // gambleButton
            // 
            this.gambleButton.Location = new System.Drawing.Point(416, 337);
            this.gambleButton.Margin = new System.Windows.Forms.Padding(2);
            this.gambleButton.Name = "gambleButton";
            this.gambleButton.Size = new System.Drawing.Size(56, 19);
            this.gambleButton.TabIndex = 6;
            this.gambleButton.Text = "button1";
            this.gambleButton.UseVisualStyleBackColor = true;
            // 
            // BetLabel
            // 
            this.BetLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BetLabel.AutoSize = true;
            this.BetLabel.Location = new System.Drawing.Point(70, 342);
            this.BetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BetLabel.Name = "BetLabel";
            this.BetLabel.Size = new System.Drawing.Size(25, 13);
            this.BetLabel.TabIndex = 7;
            this.BetLabel.Text = "aaa";
            // 
            // SlotMachineScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 366);
            this.Controls.Add(this.BetLabel);
            this.Controls.Add(this.gambleButton);
            this.Controls.Add(this.lessBet);
            this.Controls.Add(this.moreBet);
            this.Controls.Add(this.spinButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.SlotsColumns);
            this.Controls.Add(this.BackgroundImage);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SlotMachineScreen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SlotsColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BackgroundImage;
        private System.Windows.Forms.PictureBox SlotsColumns;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button spinButton;
        private System.Windows.Forms.Button moreBet;
        private System.Windows.Forms.Button lessBet;
        private System.Windows.Forms.Button gambleButton;
        private System.Windows.Forms.Label BetLabel;
    }
}

