/*
 * The main form for the Durak game
 * 
 * Author: Group 1
 * Since: March 30, 2020
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using CardLib;
using CardBox;
using PlayerLib;
using PlayerHandControl;

namespace Durak
{
    public partial class DurakUI : Form
    {
        const int MINIMUM_NUMBER_OF_CARDS = 6;  // the minimum number of cards in a players hand at the end of each round
        CardDealer dealer;                      // the dealer object that will disperse the cards
        Player[] players = new Player[2];

        public DurakUI()
        {
            InitializeComponent();
            dealer = new CardDealer(52);
            lblCardsRemaining.Text = (dealer.NumberOfCards).ToString();
            Card.trumpsExist = true;
        }

        /// <summary>
        /// Loads the computers hand control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void phcComputer_Load(object sender, EventArgs e)
        {
            phcComputer.PlayerName = "Computer";
            phcComputer.FaceUp = false;
            phcComputer.FlipControl();
        }

        /// <summary>
        /// Loads the player's hand control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void phcPlayer_Load(object sender, EventArgs e)
        {
            phcPlayer.PlayerName = "Player";
            phcPlayer.FaceUp = true;

            
        }

        private void pbTrumpCard_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Loads the deck control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cpbDeck_Click(object sender, EventArgs e)
        {
            // if the first card is being pulled, make it the trump card
            if (dealer.CurrentCardIndex == 0)
            {
                // draws the first card and faces it up
                Card firstCard = dealer.GetNextCard();
                firstCard.IsFaceUp = true;

                // make the card's suit the trump
                Card.TrumpSuit = firstCard.Suit;
                // saves and rotates the image
                pbTrumpCard.Image = firstCard.GetImage();
                pbTrumpCard.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // resizes the picture box
                pbTrumpCard.Size = new Size(CardBox.CardPictureBox.cardSize.Height, CardBox.CardPictureBox.cardSize.Width);
                // updates the label
                lblCardsRemaining.Text = (dealer.NumberOfCards - 1).ToString();
            }
            else
            {
                // dispenses the cards into each players hand
                DisperseCards();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // back colour to be determined
        }

        /// <summary>
        /// Dispenses the cards to each player
        /// </summary>
        private void DisperseCards()
        {
            // saves each player hand control to an array
            PlayerHandControl.PlayerHandControl[] panels = new PlayerHandControl.PlayerHandControl[players.Length];
            panels[0] = phcComputer;
            panels[1] = phcPlayer;

            // runs through each hand
            for (int playerCount = 0; playerCount < players.Length; playerCount++)
            {
                PlayerHandControl.PlayerHandControl currentPanel = panels[playerCount];

                // runs until the player reachers the required number of cards
                for (int count = currentPanel.PlayerInformation.CardsRemaining(); count < MINIMUM_NUMBER_OF_CARDS; count++)
                {
                    // draws the next card and adds it to the appropriate hand
                    CardPictureBox cardBox = new CardPictureBox(dealer.GetNextCard());
                    cardBox.FaceUp = currentPanel.FaceUp;
                    if (playerCount == 1)
                        cardBox.Click += CardClick;
                    currentPanel.AddPlayingCard(cardBox);
                }
            }

            // updates the cards remaining label
            lblCardsRemaining.Text = (dealer.NumberOfCards - dealer.CurrentCardIndex).ToString();
        }

        private void PanelClick(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void CardClick(object sender, EventArgs e)
        {
            phcPlayer.RemovePlayingCard(sender as CardPictureBox);
        }
    }
}
