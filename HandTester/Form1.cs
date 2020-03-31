using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardBox;
using CardLib;
using PlayerHandControl;

namespace HandTester
{
    public partial class Form1 : Form
    {
        CardDealer deck;

        public Form1()
        {
            InitializeComponent();
            deck = new CardDealer();
        }

        /// <summary>
        /// Adds a new card to the players hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cpbDeck_Click(object sender, EventArgs e)
        {
            CardPictureBox newCard = new CardPictureBox(deck.GetNextCard());
            newCard.Click += CardPictureBox_Click;

            phcHand.AddPlayingCard(newCard);

            //MessageBox.Show(newCard.ToString());
        }

        /// <summary>
        /// Sorts the cards in the players hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSort_Click(object sender, EventArgs e)
        {
            phcHand.OrderCards();
        }

        /// <summary>
        /// Adds functionality to the card control once clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardPictureBox_Click(object sender, EventArgs e)
        {
            phcHand.RemovePlayingCard(sender as CardPictureBox);
        }
    }
}
