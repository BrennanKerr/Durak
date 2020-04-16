namespace Durak
{
    partial class SettingForm
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
            this.tbPlayerName = new System.Windows.Forms.TextBox();
            this.gbSizes = new System.Windows.Forms.GroupBox();
            this.rbSize1 = new System.Windows.Forms.RadioButton();
            this.rbSize2 = new System.Windows.Forms.RadioButton();
            this.rbSize3 = new System.Windows.Forms.RadioButton();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.gbSizes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPlayerName
            // 
            this.tbPlayerName.Location = new System.Drawing.Point(85, 6);
            this.tbPlayerName.Name = "tbPlayerName";
            this.tbPlayerName.Size = new System.Drawing.Size(127, 20);
            this.tbPlayerName.TabIndex = 0;
            // 
            // gbSizes
            // 
            this.gbSizes.Controls.Add(this.rbSize3);
            this.gbSizes.Controls.Add(this.rbSize2);
            this.gbSizes.Controls.Add(this.rbSize1);
            this.gbSizes.Location = new System.Drawing.Point(12, 35);
            this.gbSizes.Name = "gbSizes";
            this.gbSizes.Size = new System.Drawing.Size(200, 100);
            this.gbSizes.TabIndex = 1;
            this.gbSizes.TabStop = false;
            this.gbSizes.Text = "DeckSizes";
            // 
            // rbSize1
            // 
            this.rbSize1.AutoSize = true;
            this.rbSize1.Location = new System.Drawing.Point(20, 20);
            this.rbSize1.Name = "rbSize1";
            this.rbSize1.Size = new System.Drawing.Size(37, 17);
            this.rbSize1.TabIndex = 0;
            this.rbSize1.Text = "20";
            this.rbSize1.UseVisualStyleBackColor = true;
            // 
            // rbSize2
            // 
            this.rbSize2.AutoSize = true;
            this.rbSize2.Checked = true;
            this.rbSize2.Location = new System.Drawing.Point(20, 44);
            this.rbSize2.Name = "rbSize2";
            this.rbSize2.Size = new System.Drawing.Size(37, 17);
            this.rbSize2.TabIndex = 1;
            this.rbSize2.TabStop = true;
            this.rbSize2.Text = "36";
            this.rbSize2.UseVisualStyleBackColor = true;
            // 
            // rbSize3
            // 
            this.rbSize3.AutoSize = true;
            this.rbSize3.Location = new System.Drawing.Point(20, 68);
            this.rbSize3.Name = "rbSize3";
            this.rbSize3.Size = new System.Drawing.Size(37, 17);
            this.rbSize3.TabIndex = 2;
            this.rbSize3.Text = "52";
            this.rbSize3.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Player Name";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(12, 141);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(200, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 183);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.gbSizes);
            this.Controls.Add(this.tbPlayerName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(240, 222);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(240, 222);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.gbSizes.ResumeLayout(false);
            this.gbSizes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPlayerName;
        private System.Windows.Forms.GroupBox gbSizes;
        private System.Windows.Forms.RadioButton rbSize3;
        private System.Windows.Forms.RadioButton rbSize2;
        private System.Windows.Forms.RadioButton rbSize1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnSubmit;
    }
}