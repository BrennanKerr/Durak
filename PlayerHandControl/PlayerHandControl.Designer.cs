namespace PlayerHandControl
{
    partial class PlayerHandControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHand = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNumberOfCards = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlHand
            // 
            this.pnlHand.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlHand.Location = new System.Drawing.Point(0, 86);
            this.pnlHand.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHand.Name = "pnlHand";
            this.pnlHand.Size = new System.Drawing.Size(1000, 132);
            this.pnlHand.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblName.Location = new System.Drawing.Point(4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            // 
            // lblNumberOfCards
            // 
            this.lblNumberOfCards.AutoSize = true;
            this.lblNumberOfCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNumberOfCards.Location = new System.Drawing.Point(4, 50);
            this.lblNumberOfCards.Name = "lblNumberOfCards";
            this.lblNumberOfCards.Size = new System.Drawing.Size(46, 17);
            this.lblNumberOfCards.TabIndex = 2;
            this.lblNumberOfCards.Text = "label1";
            // 
            // PlayerHandControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNumberOfCards);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pnlHand);
            this.Name = "PlayerHandControl";
            this.Size = new System.Drawing.Size(1000, 224);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHand;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNumberOfCards;
    }
}
