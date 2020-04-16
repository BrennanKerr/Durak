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
    /// <summary>
    /// The settings form is used to allow the player to set their desired controls of the game
    /// </summary>
    public partial class SettingForm : Form
    {
        /// <summary>
        /// Stores the state of the information
        /// </summary>
        private bool valuesValid;

        /// <summary>
        /// Initializes the form
        /// </summary>
        public SettingForm()
        {
            InitializeComponent();
            valuesValid = false;
        }

        /// <summary>
        /// Overrides the form closing event to ensure the player knows that settings are not being stored.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if the data is not valid
            if (!valuesValid)
            {
                // notify the player that their settings will not be saved
                // if the player confirms, save the default settings and close the settigns form
                if (MessageBox.Show("Closing this page will leave you with default settings. Are you sure you want to do that?",
                                    "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DurakUI.SetNumberOfCards = 36;
                    DurakUI.PlayerName = "Player";
                }
                // otherwise cancel the event
                else
                {
                    e.Cancel = true;
                }
            }
            // other wise, data is valid. store it and exit the form
            else
            {
                DurakUI.PlayerName = tbPlayerName.Text;
                int size = Convert.ToInt32(rbSize1.Checked ? rbSize1.Text : (rbSize2.Checked ? rbSize2.Text : rbSize3.Text));
                DurakUI.SetNumberOfCards = size;
            }
        }

        /// <summary>
        /// Verify's the data is valid. If so, the form closes and main form execution continues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // stores the valid state
            valuesValid = CheckValues();

            // checks to ensure the 
            if (!valuesValid)
            {
                MessageBox.Show("Please enter a name (without any \':\') and select one of the deck size options", "Invalid Settings");
            }
            // otherwise, close the application
            else
                this.Close();
        }

        /// <summary>
        /// Checks to make sure the input was valid
        /// </summary>
        /// <returns></returns>
        private bool CheckValues()
        {
            bool returnValue = true;    // the return state, defaulted to true

            // if no radio buttons are selected, set the return value to false
            if (!rbSize1.Checked && !rbSize2.Checked && !rbSize3.Checked)
            {
                returnValue = false;
            }
            // if no text was entered for the players name, set the return value to false
            else if (tbPlayerName.Text == null || tbPlayerName.Text == "")
            {
                returnValue = false;
            }
            // if the player name contains a colon, set the return value to false and set focus to the textbox
            else if (tbPlayerName.Text.Contains(":"))
            {
                tbPlayerName.Focus();
                tbPlayerName.Text = "";
                returnValue = false;
            }

            return returnValue; // return the value
        }

        /// <summary>
        /// If the text is changed the submission button must be selected again to ensure the values are allowed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPlayerName_TextChanged(object sender, EventArgs e)
        {
            valuesValid = false;
        }
    }
}
