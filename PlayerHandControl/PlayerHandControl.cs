/*
 * CardBox.cs
 * Defines the CardBox class which is used to display the image
 * 
 * Author:  Group 1
 * Since:   28 March 2020
 * 
 * See: http://acbl.mybigcommerce.com/52-playing-cards/ for card images
 */


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
    public partial class PlayerHandControl: UserControl
    {
        /// <summary>
        /// The player whose hand the panel controls
        /// </summary>
        private Player myPlayer;

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
        public PlayerHandControl()
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
        public PlayerHandControl(Player player)
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
            /*for (int i = 0; i < numberOfCards; i++)
            {
                Control card = pnlHand.Controls[i];
                card.Top = 0;
                card.Left = 100 * i;
            }*/
        }

        /// <summary>
        /// Sorts the cards
        /// CURRENTLY DOES NOT WORK
        /// </summary>
        public void OrderCards()
        {
            System.Diagnostics.Debug.WriteLine("\n\n==========New Run");
            CardList cards = myPlayer.Cards();

            for (int i = 0; i < cards.Count - 1; i++)
            {
                for (int j = 1; j < cards.Count; j++)
                {
                    Card firstCard = cards[i].Clone() as Card;
                    Card secondCard = cards[j].Clone() as Card;

                    if (firstCard > secondCard)
                    {
                        cards[i] = secondCard;
                        cards[j] = firstCard;

                        /*
                        myPlayer.ReplaceCard(i, secondCard);
                        myPlayer.ReplaceCard(j, firstCard);

                        (pnlHand.Controls[i] as CardPictureBox).PlayingCard = secondCard;
                        (pnlHand.Controls[j] as CardPictureBox).PlayingCard = firstCard;
                        */
                    }
                    System.Diagnostics.Debug.WriteLine(firstCard + " : " + secondCard + "\n\tTurns into " + cards[i] + " : " + cards[j]);
                }
            }

            myPlayer.RemoveCards();
            foreach (Card c in cards)
                myPlayer.AddCard(c);

            for (int i = 0; i < cards.Count; i++)
                (pnlHand.Controls[i] as CardPictureBox).PlayingCard = cards[i];
        }

    }
}
