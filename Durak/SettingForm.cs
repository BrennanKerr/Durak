/*
 * SettingsForm.cs
 * A form that allows the settings to be set in the game
 * 
 * Author: Group 8
 * Since: April 16, 2020
 */

using System;
using System.Windows.Forms;

namespace Durak
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Closing this page will leave you with default settings. Are you sure you want to do that?", 
                                "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DurakUI.SetNumberOfCards = 36;
                DurakUI.PlayerName = "Player";
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!CheckValues())
            {
                MessageBox.Show("Please enter a name and select one of the deck size options", "Invalid Settings");
            }
        }

        private bool CheckValues()
        {
            bool returnValue = true;

            if (!rbSize1.Checked && !rbSize2.Checked && !rbSize3.Checked)
            {
                returnValue = false;
            }
            else if (tbPlayerName.Text == null || tbPlayerName.Text == "")
            {
                returnValue = false;
            }
            else
            {
                DurakUI.PlayerName = tbPlayerName.Text;
                int size = Convert.ToInt32(rbSize1.Checked ? rbSize1.Text : (rbSize2.Checked ? rbSize2.Text : rbSize3.Text));
                DurakUI.SetNumberOfCards = size;
            }

            return returnValue;
        }
    }
}
