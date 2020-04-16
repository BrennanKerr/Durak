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
            this.cpbDeck = new CardBox.CardPictureBox();
            this.pnlAttackCards = new System.Windows.Forms.Panel();
            this.pnlDefendCards = new System.Windows.Forms.Panel();
            this.lblCardsRemaining = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.phcComputer = new PlayerHandControl.PlayerHand();
            this.phcPlayer = new PlayerHandControl.PlayerHand();
            this.btnFinishTurn = new System.Windows.Forms.Button();
            this.pbTrumpCard = new System.Windows.Forms.PictureBox();
            this.lbAttack = new System.Windows.Forms.Label();
            this.lblDefend = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpCard)).BeginInit();
            this.SuspendLayout();
            // 
            // cpbDeck
            // 
            this.cpbDeck.FaceUp = false;
            this.cpbDeck.Location = new System.Drawing.Point(12, 252);
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
            this.pnlAttackCards.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAttackCards.Location = new System.Drawing.Point(173, 325);
            this.pnlAttackCards.Name = "pnlAttackCards";
            this.pnlAttackCards.Size = new System.Drawing.Size(438, 135);
            this.pnlAttackCards.TabIndex = 5;
            // 
            // pnlDefendCards
            // 
            this.pnlDefendCards.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDefendCards.Location = new System.Drawing.Point(617, 197);
            this.pnlDefendCards.Name = "pnlDefendCards";
            this.pnlDefendCards.Size = new System.Drawing.Size(438, 135);
            this.pnlDefendCards.TabIndex = 6;
            // 
            // lblCardsRemaining
            // 
            this.lblCardsRemaining.AutoSize = true;
            this.lblCardsRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.lblCardsRemaining.Location = new System.Drawing.Point(21, 220);
            this.lblCardsRemaining.Name = "lblCardsRemaining";
            this.lblCardsRemaining.Size = new System.Drawing.Size(26, 29);
            this.lblCardsRemaining.TabIndex = 7;
            this.lblCardsRemaining.Text = "#";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 401);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.phcPlayer.Load += new System.EventHandler(this.phcPlayer_Load);
            // 
            // btnFinishTurn
            // 
            this.btnFinishTurn.Location = new System.Drawing.Point(824, 370);
            this.btnFinishTurn.Name = "btnFinishTurn";
            this.btnFinishTurn.Size = new System.Drawing.Size(75, 23);
            this.btnFinishTurn.TabIndex = 9;
            this.btnFinishTurn.Text = "Finish Turn";
            this.btnFinishTurn.UseVisualStyleBackColor = true;
            this.btnFinishTurn.Click += new System.EventHandler(this.btnFinishTurn_Click);
            // 
            // pbTrumpCard
            // 
            this.pbTrumpCard.Location = new System.Drawing.Point(26, 299);
            this.pbTrumpCard.Name = "pbTrumpCard";
            this.pbTrumpCard.Size = new System.Drawing.Size(100, 50);
            this.pbTrumpCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTrumpCard.TabIndex = 3;
            this.pbTrumpCard.TabStop = false;
            // 
            // lbAttack
            // 
            this.lbAttack.AutoSize = true;
            this.lbAttack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAttack.Location = new System.Drawing.Point(168, 297);
            this.lbAttack.Name = "lbAttack";
            this.lbAttack.Size = new System.Drawing.Size(72, 25);
            this.lbAttack.TabIndex = 10;
            this.lbAttack.Text = "Attack";
            // 
            // lblDefend
            // 
            this.lblDefend.AutoSize = true;
            this.lblDefend.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefend.Location = new System.Drawing.Point(983, 335);
            this.lblDefend.Name = "lblDefend";
            this.lblDefend.Size = new System.Drawing.Size(81, 25);
            this.lblDefend.TabIndex = 11;
            this.lblDefend.Text = "Defend";
            // 
            // DurakUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1247, 635);
            this.Controls.Add(this.lblDefend);
            this.Controls.Add(this.lbAttack);
            this.Controls.Add(this.btnFinishTurn);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblCardsRemaining);
            this.Controls.Add(this.pnlDefendCards);
            this.Controls.Add(this.pnlAttackCards);
            this.Controls.Add(this.cpbDeck);
            this.Controls.Add(this.pbTrumpCard);
            this.Controls.Add(this.phcComputer);
            this.Controls.Add(this.phcPlayer);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1263, 674);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1263, 674);
            this.Name = "DurakUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DurakUI_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PlayerHandControl.PlayerHand phcPlayer;
        private PlayerHandControl.PlayerHand phcComputer;
        private System.Windows.Forms.PictureBox pbTrumpCard;
        private CardBox.CardPictureBox cpbDeck;
        private System.Windows.Forms.Panel pnlAttackCards;
        private System.Windows.Forms.Panel pnlDefendCards;
        private System.Windows.Forms.Label lblCardsRemaining;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFinishTurn;
        private System.Windows.Forms.Label lbAttack;
        private System.Windows.Forms.Label lblDefend;
    }
}

