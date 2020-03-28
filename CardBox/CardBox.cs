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
using CardLib;


namespace CardBox
{
    public partial class CardBox: UserControl
    {
        /// <summary>
        /// The card to be saved
        /// </summary>
        private Card myCard;

        /// <summary>
        /// Gets or sets the playing card
        /// </summary>
        public Card PlayingCard
        {
            get { return myCard; }
            set
            {
                myCard = value;
                UpdateImage();
            }
        }

        /// <summary>
        /// Gets or sets the cards suit
        /// </summary>
        public CardSuit Suit
        {
            set { PlayingCard.Suit = value; UpdateImage(); }
            get { return myCard.Suit; }
        }
        /// <summary>
        /// Gets ir sets the cards rank
        /// </summary>
        public CardRank Rank
        {
            set { PlayingCard.Rank = value; UpdateImage(); }
            get { return myCard.Rank; }
        }

        /// <summary>
        /// Initializes the picture box
        /// </summary>
        public CardBox()
        {
            InitializeComponent();
            myCard = new Card(CardRank.Deuce, CardSuit.Clubs);
            myCard.IsFaceUp = false;
        }

        /// <summary>
        /// Updates the picture boxes image
        /// </summary>
        public void UpdateImage()
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
            UpdateImage();
        }
    }
}
