/*
 * The main form for the Durak game
 * 
 * Author: Group 1
 * Since: March 30, 2020
 */

using System;
using System.Linq;
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
        int currentPlayer;                      // the player whos currently up
        bool currentlyAttacking;                // states if the player is supposed to be attacking (true) or defendng (false)


        public DurakUI()
        {
            InitializeComponent();
            dealer = new CardDealer(36);
            lblCardsRemaining.Text = (dealer.NumberOfCards).ToString();
            Card.trumpsExist = true;
            currentPlayer = 1;
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
                //MessageBox.Show(sender.ToString());
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
            int numberOfPlayers = Controls.OfType<PlayerHandControl.PlayerHandControl>().Count();
            // saves each player hand control to an array
            PlayerHandControl.PlayerHandControl[] panels = new PlayerHandControl.PlayerHandControl[numberOfPlayers];
            panels[0] = phcComputer;
            panels[1] = phcPlayer;

            // runs through each hand
            for (int playerCount = 0; playerCount < numberOfPlayers; playerCount++)
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

        /// <summary>
        /// Event called when a CardPicture box is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardClick(object sender, EventArgs e)
        {
            if (currentPlayer == 1)
            {
                CardPictureBox cpb = sender as CardPictureBox;
                if (cpb != null)
                {
                    phcPlayer.RemovePlayingCard(sender as CardPictureBox);
                    if (currentlyAttacking)
                        pnlAttackCards.Controls.Add(cpb);
                    else
                        pnlDefendCards.Controls.Add(cpb);
                }
            }
            else
            {
                MessageBox.Show("It is not your turn. Please wait until the other plays", "Unable to play");
            }
        }

        /// <summary>
        /// Resets the game
        /// </summary>
        private void ResetLayout()
        {
            // message box appears prompting for the player to make a decision
                // if they press okay, board reset
            if (MessageBox.Show("Are you sure you want to reset the game?", "Reset Game", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                // reset the dealer
                dealer.ObtainCards();
                // clear the trump card image
                pbTrumpCard.Image = null;
                // reset the cards remaining label
                lblCardsRemaining.Text = dealer.NumberOfCards.ToString();

                // reset the PlayerHandControls
                phcPlayer.ResetHand();
                phcComputer.ResetHand();

                pnlAttackCards.Controls.Clear();
                pnlDefendCards.Controls.Clear();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetLayout();
        }

        /// <summary>
        /// Fires when the player finishes their turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinishTurn_Click(object sender, EventArgs e)
        {
            // flips the attack boolean
            currentlyAttacking = !currentlyAttacking;
            btnFinishTurn.Enabled = false;

            if (currentlyAttacking)
            {
                // AI Attack Logic Will go here
            }
            else
            {
                // AI Defend Logic will go here
            }
        }
    }
}
