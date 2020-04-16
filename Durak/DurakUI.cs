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
using System.IO;
using System.Collections.Generic;

namespace Durak
{
    public partial class DurakUI : Form
    {
        static string[] playerNames = { "Comptuer", "Player" };    // declares the winner options
        static int numberOfCards;
        const int MINIMUM_NUMBER_OF_CARDS = 6;  // the minimum number of cards in a players hand at the end of each round
        const string log_file_path = "/files/log.txt";
        const string stats_file_path = "/fies/stats.txt"; 
        const string START_GAME_STRING = "\n\n=====================================\nGame Started At: ";
        StreamWriter writer;

        CardDealer dealer;                      // the dealer object that will disperse the cards
        int currentPlayer;                      // the player whos currently up
        bool playerAttacking;                   // states if the player is supposed to be attacking (true) or defendng (false)
        bool noCardsRemainingNotification;      // states if the user has been notified of no cards remaining

        /// <summary>
        /// Loads the main form
        /// </summary>
        public DurakUI()
        {
            InitializeComponent();

            SettingForm settings = new SettingForm();
            settings.ShowDialog();

            dealer = new CardDealer(numberOfCards);  // set the number of cards for the dealer
            lblCardsRemaining.Text = (dealer.NumberOfCards).ToString(); // set the label test to the number of cards

            Card.trumpsExist = true;                // sets trump to true
            playerAttacking = true;                 // sets the player to attacking
            noCardsRemainingNotification = false;   // sets the no cards notication to false
            currentPlayer = 1;                      // sets the first player as playing

            WriteToFile(log_file_path, START_GAME_STRING + DateTime.Now.ToString());
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
            phcPlayer.PlayerName = playerNames[1];
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

                WriteToFile(log_file_path, "Trump Card: " + firstCard.ToString());

                // make the card's suit the trump
                Card.TrumpSuit = firstCard.Suit;
                // saves and rotates the image
                pbTrumpCard.Image = firstCard.GetImage();
                pbTrumpCard.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // resizes the picture box
                pbTrumpCard.Size = new Size(CardPictureBox.cardSize.Height, CardPictureBox.cardSize.Width);
                // updates the label
                lblCardsRemaining.Text = (dealer.NumberOfCards - 1).ToString();
            }
            else
            {
                NextTurn();
                /*// dispenses the cards into each players hand
                DisperseCards();*/
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
                    WriteToFile(log_file_path, "\nPlayers are drawing cards");
                    bool cardsLeft = true;  // determines if the player still has cards left in their hand

                    // counts how many PlayerHandControls there are
                    int numberOfPlayers = Controls.OfType<PlayerHand>().Count();

                    // saves each player hand control to an array
                    PlayerHand[] panels = new PlayerHand[numberOfPlayers];
                    panels[0] = phcComputer;
                    panels[1] = phcPlayer;

                    // runs through each hand
                    for (int playerCount = 0; playerCount < numberOfPlayers && cardsLeft; playerCount++)
                    {
                        PlayerHand currentPHC = panels[playerCount];    // gets the corresponding control

                        // runs until the player reachers the required number of cards
                        for (int count = currentPHC.PlayerInformation.CardsRemaining(); count < MINIMUM_NUMBER_OF_CARDS && cardsLeft; count++)
                        {
                            // draws the next card and adds it to the appropriate hand
                            CardPictureBox cardBox = new CardPictureBox(dealer.GetNextCard());
                            cardBox.FaceUp = currentPHC.FaceUp;   // sets the faceup orientation based on what the player has set

                            // if its the player who is recieving the card, add the click event
                            if (playerCount == 1)
                                cardBox.Click += CardClick;

                            // add the playing card to the correct control
                            currentPHC.AddPlayingCard(cardBox);

                            // if there are no cards left, set the bool to false
                            if (dealer.CurrentCardIndex >= dealer.NumberOfCards)
                                cardsLeft = false;

                            WriteToFile(log_file_path, "\tPlayer " + currentPHC.PlayerName.ToString() + " has drawn the card " + cardBox.PlayingCard.ToString() + " from the deck");
                        }
                    }


                    // updates the cards remaining label
                    lblCardsRemaining.Text = (dealer.NumberOfCards - dealer.CurrentCardIndex).ToString();
                }
                // else if there are no cards remaining and the notification hasnt been sent
                else if (!noCardsRemainingNotification)
                {
                    // display 0 cards and make the deck invisible
                    lblCardsRemaining.Text = "0";
                    cpbDeck.Visible = false;

                    // send the notification and set the boolean to true
                    MessageBox.Show("There are no cards remaining", "No Cards");
                    noCardsRemainingNotification = true;
                }
                // otherwise check if a player has won
                else
                {
                    // if the computer won
                    if (phcComputer.PlayerInformation.CardsRemaining() == 0)
                        GameOver(playerNames[0]);
                    // if the player won
                    else if (phcPlayer.PlayerInformation.CardsRemaining() == 0)
                        GameOver(playerNames[1]);
                }

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

                    // states if a player played successfully
                    bool playedSuccessfully = false;

                    // if the player is attacking
                    if (playerAttacking)
                    {
                        // if the card can be played as an attack card
                        if (CheckAttackCard(cpb.PlayingCard))
                        {
                            MovePlayingCard(phcPlayer, pnlAttackCards, cpb);
                            playedSuccessfully = true;
                        }
                        // otherwise advice the user the card is not a valid move
                        else
                        {
                            MessageBox.Show(cpb.PlayingCard.ToString() + " cannot be played" + Environment.NewLine + "Card must match a previously selected rank.",
                                "Invalid Move");
                        }
                    }
                    // otherwise the player is defending
                    else
                    {
                        // if the card is a valid defence card
                        if (CheckDefendCard(cpb.PlayingCard))
                        {
                            MovePlayingCard(phcPlayer, pnlDefendCards, cpb);
                            playedSuccessfully = true;
                        }
                        // otherwise, notify the user the card is not a valid move
                        else 
                            MessageBox.Show("The card cannot be played. Must be a higher card in the same suit or be within the trump suit.", "Invalid Move");
                    }

                    // if the player successfully played
                    if (playedSuccessfully)
                    {
                        // if there are no cards left to play
                        if (phcPlayer.PlayerInformation.CardsRemaining() == 0 && dealer.CurrentCardIndex < dealer.NumberOfCards)
                            GameOver(playerNames[1]);
                        // otherwise, let the ai play
                        else
                            AI_Logic();
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
            // try to move the card to the panel
            try
            {
                phc.RemovePlayingCard(cpb);
                pnl.Controls.Add(cpb);
                SetLocation(pnl);

                WriteToFile(log_file_path, "\t" + phc.PlayerName + (pnl == pnlAttackCards ? " attacked " : " defended " ) + "with " + cpb.PlayingCard.ToString());
            }
            // if the card does not exist
            catch (CardDoesNotExistException ex)
            {
                MessageBox.Show(ex.Message + ". Please select another card!", "Invalid Operation");
            }
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
            WriteToFile(log_file_path, START_GAME_STRING + DateTime.Now.ToString());

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

            cpbDeck.Visible = true;                 // makes the deck visible
            noCardsRemainingNotification = false;   // the notification has not been sent
            playerAttacking = true;                 // the player is attacking first
        }

        /// <summary>
        /// Handles the Reset button click event and resets the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            // message box appears prompting for the player to make a decision
            // if they press okay, board reset
            if (MessageBox.Show("Are you sure you want to reset the game?", "Reset Game", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                WriteToFile(log_file_path, "\nPlayer has decided that their best choice is to reset the game, if that is their best intentions, we cant stop them");
                ResetLayout();
            }
        }

        /// <summary>
        /// Fires when the player finishes their turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinishTurn_Click(object sender, EventArgs e)
        {
            // if the player is attacking
            if (playerAttacking)
            {
                // if there has already been a card used to attack
                if (pnlAttackCards.Controls.Count > 0)
                {
                    // prompt for the player to decide if they want to end their turn
                    if (MessageBox.Show("Are you sure you don't want to play any more cards?", "End Turn?",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        WriteToFile(log_file_path, "\n" + phcPlayer.PlayerName.ToString() + " decided to end the round without doing another attack");

                        // flips the attack boolean and goes to the next turn
                        playerAttacking = !playerAttacking;
                        NextTurn();
                    }
                }
                // otherwise, notify the player they must play a card
                else
                {
                    MessageBox.Show("You must play atleast 1 card", "Cannot skip turn");
                }
            }
            // if the player is defending
            else
            {
                // notify the player of the consequences of forfeiting
                if (MessageBox.Show("Do you want to forfeit the Round? Doing so will result in you taking all cards currently in Play", "Forfeit?",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    WriteToFile(log_file_path, "\nComputer has won the round as " + phcPlayer.PlayerName.ToString() + " did not defend");

                    // if yes, retrieve all the cards on the table and go to the next turn
                    RetrievePlayedCards(phcPlayer);
                    NextTurn();
                }
            }
        }


        /// <summary>
        /// Handles btnFinishTurn if the player has already played
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextTurn()
        {
            currentPlayer = 1;  // goes to the enxt turn

            // clears the controls
            pnlAttackCards.Controls.Clear();
            pnlDefendCards.Controls.Clear();

            // disperse the cards to the players
            DisperseCards();

            WriteToFile(log_file_path, "\nNew Round Has Started: " + (playerAttacking ? phcPlayer.PlayerName : phcComputer.PlayerName) + " is attacking");
            // if the player is defending, let the AI attack
            if (!playerAttacking)
                AI_Logic();
        }

        /// <summary>
        /// The AI (Computer) Logical thinking
        /// </summary>
        private void AI_Logic()
        {
            // the number of cards in teh computers hand
            int numberOfCards = phcComputer.PlayerInformation.CardsRemaining();
            bool cardPlayed = false;    // determines if the computer played a card. Defaulted to false
            CardPictureBox bestCard = null; // stores the best possible card to play

            // AI DEFEND LOGIC
            if (playerAttacking)
            {
                // run through each card in the hand
                for (int count = 0; count < numberOfCards; count++)
                {
                    // stores the current card
                    CardPictureBox currentCard = phcComputer.RetrieveCardBox(count);

                    // if the card can be played as a defence
                    if (CheckDefendCard(currentCard.PlayingCard))
                    {
                        // if the best card has not been set yet, store this card as the best
                        if (bestCard == null)
                            bestCard = currentCard;
                        // if the card is lower than the previously played card, store this card as the best
                        else if (currentCard.PlayingCard < bestCard.PlayingCard)
                        {
                            bestCard = currentCard;
                        }
                    }
                }

                // if there was no card found
                if (bestCard == null)
                {
                    // display the message to the log and messagebox
                    WriteToFile(log_file_path, "\n" + phcPlayer.PlayerName.ToString() + " has won the round as the computer was not able to defend");
                    MessageBox.Show("Unable to Defend. Player wins round!", "Round Over");
                    // the computer retrieves all the cards and the next turn occurs
                    RetrievePlayedCards(phcComputer);
                    NextTurn();
                }
                // otherwise, the card is played
                else
                {
                    bestCard.FaceUp = true;
                    MovePlayingCard(phcComputer, pnlDefendCards, bestCard);
                }
            }

            // AI ATTACK LOGIC
            else
            {
                // run through each card
                for(int count = 1; count < numberOfCards; count++)
                {
                    // save the card in the corresponding index
                    CardPictureBox currentCard = phcComputer.RetrieveCardBox(count);

                    // if the card can be used for an attack
                    if (CheckAttackCard(currentCard.PlayingCard))
                    {
                        // if the best card hasnt been set yet, make this card the best card
                        if (bestCard == null)
                            bestCard = currentCard;
                        // if this card is higher
                        else if (currentCard.PlayingCard > bestCard.PlayingCard)
                        {
                            // if this card is not trump, set it
                                // otherwise, keep the trump card
                            if (currentCard.PlayingCard.Suit != Card.TrumpSuit)
                                bestCard = currentCard;
                        }
                    }
                }

                // if no card was selected
                if (bestCard == null)
                {
                    // notify the player that the computer ended the round
                    WriteToFile(log_file_path, "\nComputer decided to end the round without doing another attack");
                    MessageBox.Show("Computer is finishing the round", "Round Over");

                    // make the player attack and move to the next turn
                    playerAttacking = true;
                    NextTurn();
                }
                // otherwise, play the card
                else
                {
                    bestCard.FaceUp = true;
                    MovePlayingCard(phcComputer, pnlAttackCards,bestCard);
                }
            }

            // if there are no cards left and the deck is empty, they have won
            if (cardPlayed && phcComputer.PlayerInformation.CardsRemaining() == 0 && dealer.CurrentCardIndex < dealer.NumberOfCards)
            {
                GameOver(playerNames[0]);
            }
        }

        /// <summary>
        /// Checks the attacking card.
        /// </summary>
        /// <param name="card">The card to be checked</param>
        /// <return>True is the card can be played</return>
        /// <returns>true if the card can be played</returns>
        private bool CheckAttackCard(Card card)
        {
            bool returnValue = false;   // determines if the card can be played. Defaulted to false

            // if attack cards have already been played
            if (pnlAttackCards.Controls.Count > 0)
            {
                // if the card does not match a previous attack card
                if (!CheckPanelCards(pnlAttackCards, card))
                    // return the result of the defend panel check
                    returnValue = CheckPanelCards(pnlDefendCards, card);

                else    // otherwise
                    returnValue = true;
            }
            else   // otherwise
                returnValue = true;

            return returnValue; // return the result
        }

        /// <summary>
        /// Checks if the defending card can be played
        /// </summary>
        /// <param name="card">the card to be checked</param>
        /// <returns>true if the card can be played</returns>
        private bool CheckDefendCard(Card card)
        {
            bool returnValue = false;   // determines if the card can be played. Defaulted to no.
            int numberOfAttackCards = pnlAttackCards.Controls.Count;    // gets the number of cards in the attack hand

            // gets the latest played card
            Card attackCard = (pnlAttackCards.Controls[numberOfAttackCards - 1] as CardPictureBox).PlayingCard;

            // if the attempted to play card is of greater value and the same suit
            if (card > attackCard && card.Suit == attackCard.Suit)
                returnValue = true;
            // if the attempted to play card's suit matches the trump suit and the attack card was not
            else if (card.Suit == Card.TrumpSuit && attackCard.Suit != Card.TrumpSuit)
                returnValue = true;

            return returnValue; // return the result
        }

        /// <summary>
        /// Checks if the card's rank matches a previous one played
        /// </summary>
        /// <param name="pnl">the panel to check</param>
        /// <param name="card">the card to check</param>
        /// <returns>true if the card can be played</returns>
        private bool CheckPanelCards(Panel pnl, Card card)
        {
            bool returnValue = false;   // determines if the card can be played. Defaulted to no

            // run through each card in the panel
            for (int cardCount = 0; cardCount < pnl.Controls.Count && !returnValue; cardCount++)
            {
                // save the current card as a picture box
                CardPictureBox currentCard = pnl.Controls[cardCount] as CardPictureBox;

                // if the ranks match, save the value to true
                if (card.Rank == currentCard.PlayingCard.Rank)
                    returnValue = true;
            }

            return returnValue; // return the result
        }

        /// <summary>
        /// Adds the cards currently on the table into the players hand
        /// </summary>
        /// <param name="phc">the player's hand that will be getting the cards</param>
        private void RetrievePlayedCards(PlayerHand phc)
        {
            // retrieve all the attack cards
            RetrievePanelCards(pnlAttackCards, phc);

            // retrieves all the defend cards
            RetrievePanelCards(pnlDefendCards, phc);
        }

        /// <summary>
        /// Gives the player all the cards in the panel
        /// </summary>
        /// <param name="pnl">the panel to remove the cards from</param>
        /// <param name="phc">the player hand control that will recieve the cards</param>
        private void RetrievePanelCards(Panel pnl, PlayerHand phc)
        {
            string playerInformation = phc.PlayerName.ToString();

            // run through each card and move them to the player
            for (int cardCount = 0; cardCount < pnl.Controls.Count;)
            {
                CardPictureBox cpb = pnl.Controls[cardCount] as CardPictureBox;
                WriteToFile(log_file_path, "\t" + playerInformation + " has taken the card " + cpb.PlayingCard.ToString() + " from the table");
                ChangeCardParameters(phc, ref cpb);
                phc.AddPlayingCard(cpb);
            }

            // clears the panel
            pnl.Controls.Clear();
        }

        /// <summary>
        /// Changes the parameters on the CardPictureBox
        /// </summary>
        /// <param name="phc"></param>
        /// <param name="cpb"></param>
        private void ChangeCardParameters(PlayerHand phc, ref CardPictureBox cpb)
        {
            // removes the card click event (if it has one set)
                // NOTE: Done to remove the possibility of duplicate firing
            cpb.Click -= CardClick;

            // if the player is retiving the cards, add the click event
            if (phc == phcPlayer)
            {
                cpb.Click += CardClick;
            }
            // otherwise, make the card face down
            else
            {
                cpb.FaceUp = false;
            }
        }

        /// <summary>
        /// States who won the game and prompts for a reset
        /// </summary>
        /// <param name="winner">the person whom won the game</param>
        private void GameOver(string winner)
        {
            WriteToFile(log_file_path, winner + " won the game");
            // ask if a new game is going to be started
            // if so, reset the game
            if (MessageBox.Show(winner + " has won the game." + Environment.NewLine + "Do you want to start a nwe game?", "Game Over",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetLayout();
            }
            // otherwise, exit
            else
            {
                MessageBox.Show("Thanks for playing!", "Exiting");  // Thanks the user for playing the game
                WriteToFile(log_file_path, "\nGame closed at: " + DateTime.Now.ToString() + "\n=====================================");
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Writes a given string to the provided path
        /// </summary>
        /// <param name="filePath">the location of the file</param>
        /// <param name="stringToWrite">the string to write</param>
        private void WriteToFile(string filePath, string stringToWrite)
        {
            try
            {
                // attempts to open the file
                writer = new StreamWriter(Application.StartupPath + log_file_path, true);
                // attempts to write the string to the file
                writer.WriteLine(stringToWrite);
                // attempts to close the writer
                writer.Close();
            }
            // catches any exceptions and displays an error message
            catch (IOException ex)
            {
                MessageBox.Show("An error arose when writing to the file.", "An Error Occured");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured: " + ex.Message + Environment.NewLine + ex.StackTrace, "An Error Occured");
            }
        }

        /// <summary>
        ///  Displays a message if the player forcefully closes the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DurakUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteToFile(log_file_path, "User Closed the game at: " + DateTime.Now.ToString() 
                                        + "\n\tHopefully the Computer wasn't beating them too badly");
        }

        internal static int SetNumberOfCards
        { 
            set
            {
                try
                {
                    CardDealer tempDealer = new CardDealer(value);
                    numberOfCards = value;
                }
                catch (CardOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message, "Invalid Selection");
                }
            }
        }

        internal static string PlayerName
        {
            set
            {
                try
                {
                    playerNames[1] = value;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Invalud Name");
                }
            }
        }
    }
}
