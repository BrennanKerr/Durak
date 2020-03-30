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
using System.Drawing;
using System.Windows.Forms;
using CardLib;


namespace CardBox
{
    public partial class CardPictureBox: UserControl
    {
        static public Size cardSize = new Size(86, 132);
        /// <summary>
        /// The card to be saved
        /// </summary>
        private Card myCard;

        new public event EventHandler Click;

        /// <summary>
        /// Gets or sets the playing card
        /// </summary>
        public Card PlayingCard
        {
            get { return myCard; }
            set
            {
                myCard = value;
                UpdateCard();
            }
        }

        /// <summary>
        /// Gets or sets the cards suit
        /// </summary>
        public CardSuit Suit
        {
            set { PlayingCard.Suit = value; UpdateCard(); }
            get { return myCard.Suit; }
        }
        /// <summary>
        /// Gets ir sets the cards rank
        /// </summary>
        public CardRank Rank
        {
            set { PlayingCard.Rank = value; UpdateCard(); }
            get { return myCard.Rank; }
        }

        /// <summary>
        /// Gets or sets the face up value of the card
        /// </summary>
        public bool FaceUp
        {
            set
            {
                myCard.IsFaceUp = value;
                UpdateCard();
            }
            get { return myCard.IsFaceUp; }
        }

        /// <summary>
        /// Initializes the picture box
        /// </summary>
        public CardPictureBox()
        {
            InitializeComponent();
            myCard = new Card();
            myCard.IsFaceUp = false;
        }

        public CardPictureBox(Card card)
        {
            InitializeComponent();
            myCard = card.Clone() as Card;
            myCard.IsFaceUp = true;
        }

        /// <summary>
        /// Updates the picture boxes image
        /// </summary>
        public void UpdateCard()
        {
            pbCardBox.Image = myCard.GetImage();
        }

        /// <summary>
        /// Loads the card box object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardBox_Load(object sender, System.EventArgs e)
        {
            UpdateCard();
        }

        private void pbCardBox_Click(object sender, EventArgs e)
        {
            if (Click != null)
                Click((sender as Control).Parent, e);
        }
    }
}
