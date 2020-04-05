/*
 * CardBox.cs
 * Defines the CardBox class which is used to display the image
 * 
 * Author:  Group 1
 * Since:   28 March 2020
 * 
 * See: http://acbl.mybigcommerce.com/52-playing-cards/ for card images
 */


using System;
using System.Windows.Forms;
using CardBox;
using PlayerLib;
using CardLib;
using System.Collections.Generic;

namespace PlayerHandControl
{
    /// <summary>
    /// Controls allows the displaying of a players cards in hand
    /// </summary>
    public partial class PlayerHand: UserControl
    {
        /// <summary>
        /// The player whose hand the panel controls
        /// </summary>
        private Player myPlayer;

        /// <summary>
        /// Stores the face up value of the players hand
        /// </summary>
        private bool faceUpValue;

        public bool FaceUp
        { 
            get { return faceUpValue; }
            set { faceUpValue = value; }
        }

        new public EventHandler Click;

        /// <summary>
        /// Gets or sets the players information
        /// </summary>
        public Player PlayerInformation
        {
            get { return myPlayer; }
            set { myPlayer = value; }
        }

        /// <summary>
        /// Gets or sets the players name
        /// </summary>
        public string PlayerName
        {
            get { return myPlayer.Name; }
            set 
            { 
                myPlayer.Name = value;
                lblName.Text = myPlayer.Name;
            }
        }

        /// <summary>
        /// Initializes the PlayerHand Control
        /// </summary>
        public PlayerHand()
        {
            InitializeComponent();
            myPlayer = new Player();
            lblName.Text = "NAME GOES HERE";
            lblNumberOfCards.Text = "0";
        }

        /// <summary>
        /// Initializes the PlayerHandControl with a predefined player
        /// </summary>
        /// <param name="player"></param>
        public PlayerHand(Player player)
        {
            InitializeComponent();
            myPlayer = player;
            lblName.Text = myPlayer.Name;
            lblNumberOfCards.Text = myPlayer.CardsRemaining().ToString();
        }

        /// <summary>
        /// Adds a bew card to the panel
        /// </summary>
        /// <param name="cardBox">the card as a picture box</param>
        public void AddPlayingCard(CardPictureBox cardBox)
        {
            pnlHand.Controls.Add(cardBox);
            myPlayer.AddCard(cardBox.PlayingCard);
            lblNumberOfCards.Text = myPlayer.CardsRemaining().ToString();
            SetLocation();
        }

        /// <summary>
        /// Adds a new card to the panel
        /// </summary>
        /// <param name="card">the playing card to add</param>
        public void AddPlayingCard(Card card)
        {
            CardPictureBox cardBox = new CardPictureBox(card);
            AddPlayingCard(cardBox);
        }

        /// <summary>
        /// Removes the corresponding card from the panel and players hand
        /// </summary>
        /// <param name="card"></param>
        public void RemovePlayingCard(CardPictureBox card)
        {
            myPlayer.Remove(card.PlayingCard);
            lblNumberOfCards.Text = myPlayer.CardsRemaining().ToString();
            pnlHand.Controls.Remove(card);
            SetLocation();

        }

        /// <summary>
        /// Sets the location of the new Card
        /// </summary>
        /// <param name="card"></param>
        public void SetLocation()
        {
            // the number of cards in the panel
            int numberOfCards = pnlHand.Controls.Count;

            // cards exist in the hand
            if (numberOfCards > 0)
            {
                int cardWidth = CardPictureBox.cardSize.Width;          // the width of the cards
                int startingLocation = (pnlHand.Width - cardWidth) / 2; // the starting location of the card (initially half way in the panel)
                int seperation = cardWidth;                             // the seperation of the cards (initially the width of the cards

                // more than 1 card exists in the hand
                if (numberOfCards > 1)
                {                  
                    // if the cards would exceed the panel width
                        // set a new seperation
                    if (cardWidth * numberOfCards > pnlHand.Width)
                    {
                        seperation = ((pnlHand.Width - cardWidth)) / numberOfCards;
                    }

                    // make a new starting point
                    startingLocation -= (cardWidth * (numberOfCards - 1))/2;

                    // if the starting location is off the screen
                        // set the new starting location
                    if (startingLocation < 0)
                        startingLocation = cardWidth / 4;
                }

                // set each card to their corresponding locations
                for (int count = 0; count < numberOfCards; count++)
                {
                    pnlHand.Controls[count].Top = 0;
                    pnlHand.Controls[count].Left = startingLocation + (seperation * count);
                }
            }
        }

        /// <summary>
        /// Sorts the cards
        /// CURRENTLY DOES NOT WORK
        /// </summary>
        public void OrderCards()
        {
            MessageBox.Show("Currently Not Working as Intended");
            string cardListString = "";
            System.Diagnostics.Debug.WriteLine("\n\n==========New Run");
            // saves the player's list of cards to a new CardList object
            CardList cards = myPlayer.Cards();

            // run through each card in the array
            for (int i = 0; i < cards.Count - 1; i++)
            {
                /*Card firstCard = cards[i].Clone() as Card;*/
                for (int j = 1; j < cards.Count; j++)
                {
                    Card firstCard = cards[i].Clone() as Card;
                    Card secondCard = cards[j].Clone() as Card;

                    if (firstCard > secondCard)
                    {
                        cards[i] = secondCard;
                        cards[j] = firstCard;
                        //break;
                    }
                    System.Diagnostics.Debug.WriteLine(firstCard + " : " + secondCard + "\t\n" + ((firstCard > secondCard) ? ">" : "<"));

                    foreach (Card c in cards)
                        cardListString += c.ToString() + "\n";
                    System.Diagnostics.Debug.WriteLine("\n\nCARD LIST\n" + cardListString);
                    cardListString = "";
                }
            }

            myPlayer.RemoveCards();
            foreach (Card c in cards)
            {
                myPlayer.AddCard(c);
                cardListString += c.ToString() + "\n";
            }

            for (int i = 0; i < cards.Count; i++)
                (pnlHand.Controls[i] as CardPictureBox).PlayingCard = cards[i];

            System.Diagnostics.Debug.WriteLine("\n\nCARD LIST\n" + cardListString);
        }

        /// <summary>
        /// Flips the control so the labels are underneath the panel
        /// NOTE: Cannot be reversed
        /// </summary>
        public void FlipControl()
        {
            pnlHand.Top = this.Top;
            lblName.Top = 132;
            lblNumberOfCards.Top = 149;
        }

        /// <summary>
        /// Gets called when anywhere in the control gets clicked.
        /// Determines if a card was clicked and if so, calls the corresponding click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerHandControl_Click(object sender, EventArgs e)
        {
            bool isClickedControl = false;  // determines if the card was found

            // runs through each control in the panel
            for (int controlCount = 0; controlCount < pnlHand.Controls.Count && !isClickedControl; controlCount++)
            {
                // attemps to convert the control to a CardPictureBox
                CardPictureBox cbp = pnlHand.Controls[controlCount] as CardPictureBox;

                // if the control was converted
                if (cbp != null)
                {
                    // if the mouse is within the card box location,
                        // fire the given cards event and set isClickecControl to true
                    if (MousePosition.X >= cbp.Location.X && MousePosition.X <= (cbp.Location.X + cbp.Width))
                    {
                        if (MousePosition.Y >= cbp.Location.Y && MousePosition.Y <= (cbp.Location.Y + cbp.Height))
                        {
                            Click(cbp, e);
                            isClickedControl = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Removes all cards from the players hand
        /// </summary>
        public void ResetHand()
        {
            myPlayer.RemoveCards();
            pnlHand.Controls.Clear();
            lblNumberOfCards.Text = "0";
        }

        public CardPictureBox RetrieveCardBox(int index)
        {
            CardPictureBox cpb;

            if (index < pnlHand.Controls.Count)
            {
                cpb = pnlHand.Controls[index] as CardPictureBox;;
                if (cpb == null)
                    throw new InvalidCastException("The control at {0} cannot be fully converted to a CardPictureBox", index);
            }
            else
            {
                throw new IndexOutOfRangeException("There is no Control at the index of " + index);
            }

            return cpb;
        }
    }
}
