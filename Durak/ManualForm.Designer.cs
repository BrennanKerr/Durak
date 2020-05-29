namespace Durak
{
    partial class frmManualForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManualForm));
            this.rtbHowToPlay = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbHowToPlay
            // 
            this.rtbHowToPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHowToPlay.Location = new System.Drawing.Point(0, 0);
            this.rtbHowToPlay.Name = "rtbHowToPlay";
            this.rtbHowToPlay.Size = new System.Drawing.Size(465, 594);
            this.rtbHowToPlay.TabIndex = 0;
            this.rtbHowToPlay.Text = resources.GetString("rtbHowToPlay.Text");
            // 
            // frmManualForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 594);
            this.Controls.Add(this.rtbHowToPlay);
            this.Name = "frmManualForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbHowToPlay;
    }
}