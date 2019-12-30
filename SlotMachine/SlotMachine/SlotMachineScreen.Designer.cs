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
            this.backButton.Location = new System.Drawing.Point(713, 415);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "button1";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // SlotsColumns
            // 
            this.SlotsColumns.Image = global::SlotMachine.Properties.Resources.sluts;
            this.SlotsColumns.Location = new System.Drawing.Point(8, 8);
            this.SlotsColumns.Name = "SlotsColumns";
            this.SlotsColumns.Size = new System.Drawing.Size(111, 100);
            this.SlotsColumns.TabIndex = 1;
            this.SlotsColumns.TabStop = false;
            // 
            // BackgroundImage
            // 
            this.BackgroundImage.Image = global::SlotMachine.Properties.Resources.background_image;
            this.BackgroundImage.Location = new System.Drawing.Point(0, 0);
            this.BackgroundImage.Name = "BackgroundImage";
            this.BackgroundImage.Size = new System.Drawing.Size(803, 455);
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
            this.spinButton.Location = new System.Drawing.Point(342, 385);
            this.spinButton.Name = "spinButton";
            this.spinButton.Size = new System.Drawing.Size(150, 53);
            this.spinButton.TabIndex = 3;
            this.spinButton.Text = "SPIN";
            this.spinButton.UseVisualStyleBackColor = false;
            // 
            // moreBet
            // 
            this.moreBet.Location = new System.Drawing.Point(154, 418);
            this.moreBet.Name = "moreBet";
            this.moreBet.Size = new System.Drawing.Size(75, 23);
            this.moreBet.TabIndex = 4;
            this.moreBet.Text = "button1";
            this.moreBet.UseVisualStyleBackColor = true;
            // 
            // lessBet
            // 
            this.lessBet.Location = new System.Drawing.Point(12, 415);
            this.lessBet.Name = "lessBet";
            this.lessBet.Size = new System.Drawing.Size(75, 23);
            this.lessBet.TabIndex = 5;
            this.lessBet.Text = "button1";
            this.lessBet.UseVisualStyleBackColor = true;
            // 
            // gambleButton
            // 
            this.gambleButton.Location = new System.Drawing.Point(554, 415);
            this.gambleButton.Name = "gambleButton";
            this.gambleButton.Size = new System.Drawing.Size(75, 23);
            this.gambleButton.TabIndex = 6;
            this.gambleButton.Text = "button1";
            this.gambleButton.UseVisualStyleBackColor = true;
            // 
            // BetLabel
            // 
            this.BetLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BetLabel.AutoSize = true;
            this.BetLabel.Location = new System.Drawing.Point(94, 421);
            this.BetLabel.Name = "BetLabel";
            this.BetLabel.Size = new System.Drawing.Size(32, 16);
            this.BetLabel.TabIndex = 7;
            this.BetLabel.Text = "aaa";
            // 
            // SlotMachineScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 451);
            this.Controls.Add(this.BetLabel);
            this.Controls.Add(this.gambleButton);
            this.Controls.Add(this.lessBet);
            this.Controls.Add(this.moreBet);
            this.Controls.Add(this.spinButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.SlotsColumns);
            this.Controls.Add(this.BackgroundImage);
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

