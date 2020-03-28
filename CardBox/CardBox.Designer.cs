namespace CardBox
{
    partial class CardBox
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
            this.pbCardBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCardBox
            // 
            this.pbCardBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCardBox.Location = new System.Drawing.Point(0, 0);
            this.pbCardBox.MaximumSize = new System.Drawing.Size(345, 528);
            this.pbCardBox.MinimumSize = new System.Drawing.Size(345, 528);
            this.pbCardBox.Name = "pbCardBox";
            this.pbCardBox.Size = new System.Drawing.Size(345, 528);
            this.pbCardBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCardBox.TabIndex = 0;
            this.pbCardBox.TabStop = false;
            // 
            // CardBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbCardBox);
            this.MaximumSize = new System.Drawing.Size(345, 528);
            this.MinimumSize = new System.Drawing.Size(345, 528);
            this.Name = "CardBox";
            this.Size = new System.Drawing.Size(345, 528);
            this.Load += new System.EventHandler(this.CardBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCardBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCardBox;
    }
}
