namespace Durak
{
    partial class DurakUI
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
            PlayerLib.Player player1 = new PlayerLib.Player();
            PlayerLib.Player player2 = new PlayerLib.Player();
            this.pbTrumpCard = new System.Windows.Forms.PictureBox();
            this.cpbDeck = new CardBox.CardPictureBox();
            this.pnlAttackCards = new System.Windows.Forms.Panel();
            this.pnlDefendCards = new System.Windows.Forms.Panel();
            this.lblCardsRemaining = new System.Windows.Forms.Label();
            this.phcComputer = new PlayerHandControl.PlayerHandControl();
            this.phcPlayer = new PlayerHandControl.PlayerHandControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpCard)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTrumpCard
            // 
            this.pbTrumpCard.Location = new System.Drawing.Point(122, 300);
            this.pbTrumpCard.Name = "pbTrumpCard";
            this.pbTrumpCard.Size = new System.Drawing.Size(100, 50);
            this.pbTrumpCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTrumpCard.TabIndex = 3;
            this.pbTrumpCard.TabStop = false;
            // 
            // cpbDeck
            // 
            this.cpbDeck.FaceUp = false;
            this.cpbDeck.Location = new System.Drawing.Point(108, 253);
            this.cpbDeck.MaximumSize = new System.Drawing.Size(86, 132);
            this.cpbDeck.MinimumSize = new System.Drawing.Size(86, 132);
            this.cpbDeck.Name = "cpbDeck";
            this.cpbDeck.Rank = CardLib.CardRank.Ace;
            this.cpbDeck.Size = new System.Drawing.Size(86, 132);
            this.cpbDeck.Suit = CardLib.CardSuit.Clubs;
            this.cpbDeck.TabIndex = 4;
            this.cpbDeck.Click += new System.EventHandler(this.cpbDeck_Click);
            // 
            // pnlAttackCards
            // 
            this.pnlAttackCards.Location = new System.Drawing.Point(279, 329);
            this.pnlAttackCards.Name = "pnlAttackCards";
            this.pnlAttackCards.Size = new System.Drawing.Size(438, 135);
            this.pnlAttackCards.TabIndex = 5;
            // 
            // pnlDefendCards
            // 
            this.pnlDefendCards.Location = new System.Drawing.Point(461, 229);
            this.pnlDefendCards.Name = "pnlDefendCards";
            this.pnlDefendCards.Size = new System.Drawing.Size(438, 135);
            this.pnlDefendCards.TabIndex = 6;
            // 
            // lblCardsRemaining
            // 
            this.lblCardsRemaining.AutoSize = true;
            this.lblCardsRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.lblCardsRemaining.Location = new System.Drawing.Point(117, 221);
            this.lblCardsRemaining.Name = "lblCardsRemaining";
            this.lblCardsRemaining.Size = new System.Drawing.Size(26, 29);
            this.lblCardsRemaining.TabIndex = 7;
            this.lblCardsRemaining.Text = "#";
            // 
            // phcComputer
            // 
            this.phcComputer.FaceUp = false;
            this.phcComputer.Location = new System.Drawing.Point(122, 12);
            this.phcComputer.Name = "phcComputer";
            player1.Name = null;
            this.phcComputer.PlayerInformation = player1;
            this.phcComputer.PlayerName = null;
            this.phcComputer.Size = new System.Drawing.Size(1000, 166);
            this.phcComputer.TabIndex = 1;
            this.phcComputer.Load += new System.EventHandler(this.phcComputer_Load);
            // 
            // phcPlayer
            // 
            this.phcPlayer.FaceUp = false;
            this.phcPlayer.Location = new System.Drawing.Point(122, 457);
            this.phcPlayer.Name = "phcPlayer";
            player2.Name = null;
            this.phcPlayer.PlayerInformation = player2;
            this.phcPlayer.PlayerName = null;
            this.phcPlayer.Size = new System.Drawing.Size(1000, 166);
            this.phcPlayer.TabIndex = 0;
            // 
            // DurakUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1247, 635);
            this.Controls.Add(this.lblCardsRemaining);
            this.Controls.Add(this.pnlDefendCards);
            this.Controls.Add(this.pnlAttackCards);
            this.Controls.Add(this.cpbDeck);
            this.Controls.Add(this.pbTrumpCard);
            this.Controls.Add(this.phcComputer);
            this.Controls.Add(this.phcPlayer);
            this.Name = "DurakUI";
            this.Text = "Durak";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.cpbDeck_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PlayerHandControl.PlayerHandControl phcPlayer;
        private PlayerHandControl.PlayerHandControl phcComputer;
        private System.Windows.Forms.PictureBox pbTrumpCard;
        private CardBox.CardPictureBox cpbDeck;
        private System.Windows.Forms.Panel pnlAttackCards;
        private System.Windows.Forms.Panel pnlDefendCards;
        private System.Windows.Forms.Label lblCardsRemaining;
    }
}

