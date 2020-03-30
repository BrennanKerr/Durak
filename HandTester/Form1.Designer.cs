namespace HandTester
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
            PlayerLib.Player player1 = new PlayerLib.Player();
            this.cpbDeck = new CardBox.CardPictureBox();
            this.phcHand = new PlayerHandControl.PlayerHandControl();
            this.btnSort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cpbDeck
            // 
            this.cpbDeck.FaceUp = false;
            this.cpbDeck.Location = new System.Drawing.Point(460, 66);
            this.cpbDeck.MaximumSize = new System.Drawing.Size(86, 132);
            this.cpbDeck.MinimumSize = new System.Drawing.Size(86, 132);
            this.cpbDeck.Name = "cpbDeck";
            this.cpbDeck.Rank = CardLib.CardRank.Ace;
            this.cpbDeck.Size = new System.Drawing.Size(86, 132);
            this.cpbDeck.Suit = CardLib.CardSuit.Clubs;
            this.cpbDeck.TabIndex = 0;
            this.cpbDeck.Click += new System.EventHandler(this.cpbDeck_Click);
            // 
            // phcHand
            // 
            this.phcHand.Location = new System.Drawing.Point(12, 224);
            this.phcHand.Name = "phcHand";
            player1.Name = null;
            this.phcHand.PlayerInformation = player1;
            this.phcHand.PlayerName = null;
            this.phcHand.Size = new System.Drawing.Size(1000, 224);
            this.phcHand.TabIndex = 1;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(460, 224);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 2;
            this.btnSort.Text = "Order Cards";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 450);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.phcHand);
            this.Controls.Add(this.cpbDeck);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CardBox.CardPictureBox cpbDeck;
        private PlayerHandControl.PlayerHandControl phcHand;
        private System.Windows.Forms.Button btnSort;
    }
}

