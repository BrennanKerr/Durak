/*
 * The main form for the Durak game
 * 
 * Author: Group 1
 * Since: March 30, 2020
 * 
 */

using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using CardLib;
using CardBox;
using PlayerHandControl;
using System.Collections.Generic;

namespace Durak
{
    public partial class DurakUI : Form
    {
        const int MINIMUM_NUMBER_OF_CARDS = 6;  // the minimum number of cards in a players hand at the end of each round
        CardDealer dealer;                      // the dealer object that will disperse the cards
        int currentPlayer;                      // the player whos currently up
        bool playerAttacking;                   // states if the player is supposed to be attacking (true) or defendng (false)

        /// <summary>
        /// Loads the main form
        /// </summary>
        public DurakUI()
        {
            InitializeComponent();
            dealer = new CardDealer(36);
            lblCardsRemaining.Text = (dealer.NumberOfCards).ToString();
            Card.trumpsExist = true;
            playerAttacking = true;
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
            phcComputer.FaceUp = true;
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
            // if the atttack and defend panels are empty
            if (pnlAttackCards.Controls.Count == 0 && pnlDefendCards.Controls.Count == 0)
            {
                // if cards are able to be used
                if (dealer.CurrentCardIndex < dealer.NumberOfCards)
                {
                    bool cardsLeft = true;
                    int numberOfPlayers = Controls.OfType<PlayerHand>().Count();
                    // saves each player hand control to an array
                    PlayerHand[] panels = new PlayerHand[numberOfPlayers];
                    panels[0] = phcComputer;
                    panels[1] = phcPlayer;

                    // runs through each hand
                    for (int playerCount = 0; playerCount < numberOfPlayers && cardsLeft; playerCount++)
                    {
                        PlayerHand currentPanel = panels[playerCount];

                        // runs until the player reachers the required number of cards
                        for (int count = currentPanel.PlayerInformation.CardsRemaining(); count < MINIMUM_NUMBER_OF_CARDS && cardsLeft; count++)
                        {
                            // draws the next card and adds it to the appropriate hand
                            CardPictureBox cardBox = new CardPictureBox(dealer.GetNextCard());
                            cardBox.FaceUp = currentPanel.FaceUp;
                            if (playerCount == 1)
                                cardBox.Click += CardClick;
                            currentPanel.AddPlayingCard(cardBox);

                            if (dealer.CurrentCardIndex >= dealer.NumberOfCards)
                                cardsLeft = false;
                        }
                    }
                }
                // otherwise
                else
                {
                    MessageBox.Show("There are no cards remaining", "No Cards");
                }

                // updates the cards remaining label
                lblCardsRemaining.Text = (dealer.NumberOfCards - dealer.CurrentCardIndex).ToString();
            }
            // otherwise the round is still in play
            else
            {
                MessageBox.Show("You cant draw as you are currently in the middle of a round!", "Invalid Operation");
            }
        }

        /// <summary>
        /// Event called when a CardPicture box is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardClick(object sender, EventArgs e)
        {
            // if its the player's turn to go
            if (currentPlayer == 1)
            {
                // convert the object to a card box
                CardPictureBox cpb = sender as CardPictureBox;

                // if the conversion was successful
                if (cpb != null)
                {
                    // set the size of the cardbox
                    cpb.Size = new Size(CardPictureBox.cardSize.Width / 2, CardPictureBox.cardSize.Height / 2);

                    // if the player is attacking
                    if (playerAttacking)
                    {
                        if (CheckAttackCard(cpb.PlayingCard))
                        {
                            MovePlayingCard(phcPlayer, pnlAttackCards, cpb);
                            AI_Logic();
                        }
                    }
                    // otherwise the player is defending
                    else
                    {
                        if (CheckDefendCard(cpb.PlayingCard))
                        {
                            MovePlayingCard(phcPlayer, pnlDefendCards, cpb);
                            AI_Logic();
                        }
                        else
                            MessageBox.Show("The card must be higher than the last played card");
                    }
                }
            }
            // other, the player cannot play
            else
            {
                MessageBox.Show("It is not your turn. Please wait until the other plays", "Unable to play");
            }
        }

        /// <summary>
        /// Attempts to move the given CardPictureBox to the given panel
        /// </summary>
        /// <param name="phc">the PlayerHand control that the card should be in</param>
        /// <param name="pnl">the panel the CardPictureBox will be moved to</param>
        /// <param name="cpb">the CardPictureBox that will be moved</param>
        private void MovePlayingCard(PlayerHand phc, Panel pnl, CardPictureBox cpb)
        {
            // try to move the card
            try
            {
                phc.RemovePlayingCard(cpb);
                pnl.Controls.Add(cpb);
                SetLocation(pnl);
            }
            // if the card does not exist
            catch (CardDoesNotExistException ex)
            {
                MessageBox.Show(ex.Message + ". Please select another card!", "Invalid Operation");
            }
            /*bool canPlayCard = true;    // determines if the given card can be played

            // determines if any cards are in the panel
            if (pnl.Controls.Count > 0)
            {
                // determines if the card is not the same rank 
                if (cpb.PlayingCard.Rank != ((CardPictureBox)pnl.Controls[0]).PlayingCard.Rank)
                {
                    canPlayCard = false;
                }
            }

            // if the card can be played
            if (canPlayCard)
            {
                // try to move the card
                try
                {
                    phc.RemovePlayingCard(cpb);
                    pnl.Controls.Add(cpb);
                    SetLocation(pnl);
                }
                // if the card does not exist
                catch (CardDoesNotExistException ex)
                {
                    MessageBox.Show(ex.Message + ". Please select another card!", "Invalid Operation");
                }
            }
            // otherwise, the card cannot be played
            else
            {
                MessageBox.Show("You cannot play that card. Must be a rank of " + ((CardPictureBox)pnl.Controls[0]).PlayingCard.Rank, "Invalid Move!");
            }*/
        }

        /// <summary>
        /// Set the location of the cards in the panel
        /// </summary>
        /// <param name="ph"></param>
        private void SetLocation(Panel ph)
        {
            int numberOfControls = ph.Controls.Count;   // saves the number of cards
            // run through each control
            for (int count = 0; count < numberOfControls; count++)
            {
                // attempt to convert it to a CardPictureBox
                CardPictureBox cpb = ph.Controls[count] as CardPictureBox;

                // if the control was converted, set the location
                if (cpb != null)
                {
                    cpb.Location = new Point(count * CardPictureBox.cardSize.Width / 2, 0);
                }
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

                // removes any cards from the panels
                pnlAttackCards.Controls.Clear();
                pnlDefendCards.Controls.Clear();

                btnFinishTurn.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the Reset button click event and resets the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


            /* currentPlayer = 0;

             int numberOfCards = phcComputer.PlayerInformation.CardsRemaining();
             int startingIndex = 0;

             if (!playerAttacking)
             {
                 // AI Attack Logic Will go here

             }
             else
             {// stores the list of cards the AI will play
                 List<CardPictureBox> boxes = new List<CardPictureBox>();

                 // run through each card in the attack hand
                 foreach (Control control in pnlAttackCards.Controls)
                 {
                     // save the current control as a cardpicturebox
                     CardPictureBox cpb = control as CardPictureBox;

                     // if it can be converted
                     if (cpb != null)
                     {
                         bool cardPlayed = false;    // determines if a card has been played

                         // run through each card in the ais hand
                         for (int count = startingIndex; count < numberOfCards && !cardPlayed; count++)
                         {
                             try
                             {
                                 // save the current cardPictureBox
                                 CardPictureBox currentCard = phcComputer.RetrieveCardBox(count);
                                 // if it is better than the current card in the attack panel, play it
                                 if (currentCard.PlayingCard > cpb.PlayingCard)
                                 {
                                     cardPlayed = true;
                                     boxes.Add(currentCard);
                                 }
                             }
                             catch (Exception ex)
                             {
                                 MessageBox.Show(ex.Message, "An Error Occured");
                             }
                             startingIndex++;
                         }
                     }
                 }

                 // if the same number of cards have been played
                 // display them on the panel and remove them from the computers hand
                 if (boxes.Count == pnlAttackCards.Controls.Count)
                 {
                     foreach (CardPictureBox card in boxes)
                     {
                         phcComputer.RemovePlayingCard(card);
                         pnlDefendCards.Controls.Add(card);
                     }
                     SetLocation(pnlDefendCards);
                 }
                 // else, state they have lost
                 else
                 {
                     MessageBox.Show("Unable to Defend. Player wins round!", pnlAttackCards.Controls.Count.ToString());
                     foreach (Control control in pnlAttackCards.Controls)
                     {
                         MessageBox.Show((control as CardPictureBox).PlayingCard.ToString());
                         phcComputer.AddPlayingCard(control as CardPictureBox);
                     }

                     pnlAttackCards.Controls.Clear();
                 }
             }*/

            if (playerAttacking)
            {
                btnFinishTurn.Text = "Next Turn";
                btnFinishTurn.Click -= btnFinishTurn_Click;
                btnFinishTurn.Click += NextTurn;
            }
        }


        /// <summary>
        /// Handles btnFinishTurn if the player has already played
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextTurn(object sender, EventArgs e)
        {

            // flips the attack boolean
            playerAttacking = !playerAttacking;

            currentPlayer = 1;

            pnlAttackCards.Controls.Clear();
            pnlDefendCards.Controls.Clear();

            DisperseCards();

            if (!playerAttacking)
                AI_Logic();

            btnFinishTurn.Text = "Finish Turn";
            btnFinishTurn.Click -= NextTurn;
            btnFinishTurn.Click += btnFinishTurn_Click;
        }

        private void AI_Logic()
        {
            int numberOfCards = phcComputer.PlayerInformation.CardsRemaining();
            int startingIndex = 0;

            if (playerAttacking)
            {
                // AI DEFEND LOGIC
                // stores the list of cards the AI will play
                List<CardPictureBox> boxes = new List<CardPictureBox>();

                // run through each card in the attack hand
                foreach (Control control in pnlAttackCards.Controls)
                {
                    // save the current control as a cardpicturebox
                    CardPictureBox cpb = control as CardPictureBox;

                    // if it can be converted
                    if (cpb != null)
                    {
                        bool cardPlayed = false;    // determines if a card has been played

                        // run through each card in the ais hand
                        for (int count = startingIndex; count < numberOfCards && !cardPlayed; count++)
                        {
                            try
                            {
                                // save the current cardPictureBox
                                CardPictureBox currentCard = phcComputer.RetrieveCardBox(count);
                                // if it is better than the current card in the attack panel, play it
                                if (CheckDefendCard(currentCard.PlayingCard))
                                {
                                    cardPlayed = true;
                                    boxes.Add(currentCard);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "An Error Occured");
                            }
                            startingIndex++;
                        }
                    }
                }

                // if the same number of cards have been played
                // display them on the panel and remove them from the computers hand
                if (boxes.Count == pnlAttackCards.Controls.Count)
                {
                    foreach (CardPictureBox card in boxes)
                    {
                        phcComputer.RemovePlayingCard(card);
                        pnlDefendCards.Controls.Add(card);
                    }
                    SetLocation(pnlDefendCards);
                }
                // else, state they have lost
                else
                {
                    MessageBox.Show("Unable to Defend. Player wins round!", pnlAttackCards.Controls.Count.ToString());
                    foreach (Control control in pnlAttackCards.Controls)
                    {
                        MessageBox.Show((control as CardPictureBox).PlayingCard.ToString());
                        phcComputer.AddPlayingCard(control as CardPictureBox);
                    }

                    pnlAttackCards.Controls.Clear();
                }
            }
            else
            {
                // AT ATTACK LOGIC
                CardPictureBox cpb = phcComputer.RetrieveCardBox(0);
                if (CheckAttackCard(cpb.PlayingCard))
                    MovePlayingCard(phcComputer, pnlAttackCards, phcComputer.RetrieveCardBox(0));
                else
                {
                    MessageBox.Show("Computer is finishing the round");
                    NextTurn(new object(), new EventArgs());
                }
            }
        }

        /// <summary>
        /// Checks the attacking card.
        /// </summary>
        /// <param name="card">The card to be checked</param>
        /// <return>True is the card can be played</return>
        /// <returns></returns>
        private bool CheckAttackCard(Card card)
        {
            bool returnValue = false;
            if (pnlAttackCards.Controls.Count > 0)
            {
                if (!CheckPanelCards(pnlAttackCards, card))
                    returnValue = CheckPanelCards(pnlDefendCards, card);
                else
                    returnValue = true;
            }
            else
                returnValue = true;

            return returnValue;
        }

        /// <summary>
        /// Checks if the defending card can be played
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private bool CheckDefendCard(Card card)
        {
            bool returnValue = false;
            int numberOfAttackCards = pnlAttackCards.Controls.Count;

            if (card > (pnlAttackCards.Controls[numberOfAttackCards - 1] as CardPictureBox).PlayingCard)
                returnValue = true;

            if (returnValue && numberOfAttackCards > 1)
            {
                if (!CheckPanelCards(pnlAttackCards, card))
                    returnValue = CheckPanelCards(pnlDefendCards, card);
                else
                    returnValue = true;
            }

            return returnValue;
        }

        private bool CheckPanelCards(Panel pnl, Card card)
        {
            bool returnValue = false;
            for (int cardCount = 0; cardCount < pnl.Controls.Count && !returnValue; cardCount++)
            {
                CardPictureBox currentCard = pnl.Controls[cardCount] as CardPictureBox;
                if (card.Rank == currentCard.PlayingCard.Rank)
                    returnValue = true;
            }

            return returnValue;
        }
    }
}
