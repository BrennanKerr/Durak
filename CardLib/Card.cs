/*
 * Card.cs
 * Defines the player card class
 * 
 * Author:  Group 1
 * Since:   28 March 2020
 * 
 * See: http://acbl.mybigcommerce.com/52-playing-cards/ for card images
 */

using System;
using System.Drawing;

namespace CardLib
{
    /// <summary>
    /// Defines a Playing CArd
    /// </summary>
    public class Card :ICloneable
    {
        #region FIELDS_AND_PROPERTIES
        /// <summary>
        /// The suit of the card
        /// </summary>
        private CardSuit mySuit;
        /// <summary>
        /// Gets or sets the suit
        /// </summary>
        public CardSuit Suit
        {
            get { return mySuit; }
            set { mySuit = value; }
        }
        /// <summary>
        /// The rank of the card
        /// </summary>
        private CardRank myRank;
        /// <summary>
        /// Gets or sets the rank of the card
        /// </summary>
        public CardRank Rank
        {
            get { return myRank; }
            set { myRank = value; }
        }

        /// <summary>
        /// States if the card is face up
        /// </summary>
        public bool IsFaceUp = false;

        /// <summary>
        /// States whether the trump modifier exists
        /// </summary>
        public static bool trumpsExist = false;
        /// <summary>
        /// Defines the suit that is the Trump Suit
        /// NOTE: Will only function is trumpsExist is true
        /// </summary>
        private static CardSuit trumpSuit = CardSuit.Clubs;
        public static CardSuit TrumpSuit
        { 
            get { return trumpSuit; }
            set { trumpSuit = value; }
        }

        /// <summary>
        /// Determines if ace is declared as high
        /// </summary>
        public static bool IsAceHigh = false;

        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Constructor: Initializes a Player Card
        /// </summary>
        /// <param name="rank">the rank of the card, Default of Ace</param>
        /// <param name="suit">the suit of the card, Default of Clubs</param>
        public Card(CardRank rank = CardRank.Ace, CardSuit suit = CardSuit.Clubs)
        {
            Rank = rank;
            Suit = suit;
        }

        /// <summary>
        /// Constructor: Initializes a playing card and declares the trump modifier settings
        /// </summary>
        /// <param name="rank">the cards rank</param>
        /// <param name="suit">the cards suit</param>
        /// <param name="isTrump">defines if trump is activated</param>
        /// <param name="trumpSuit">defines the trump suit</param>
        public Card(CardRank rank, CardSuit suit, bool isTrump, CardSuit trumpSuit):this(rank, suit)
        {
            trumpsExist = isTrump;
            Card.trumpSuit = trumpSuit;
        }
        #endregion
        #region OPERATORS
        /// <summary>
        /// Checks if the two cards match
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Card left, Card right)
        {
            return (left.GetHashCode() == right.GetHashCode());
        }
        /// <summary>
        /// Checks if the two cards dont match
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Card left, Card right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Checks if the card on the left is higher than the card on the right
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Card left, Card right)
        {
            bool returnValue;

            if (trumpsExist)
            {
                if (left.Suit == trumpSuit)
                {
                    returnValue = true;
                }
                else if (right.Suit == trumpSuit)
                {
                    returnValue = false;
                }
                else
                {
                    returnValue = (left.Rank > right.Rank);
                }
            }
            else
            {
                returnValue = (left.Rank > right.Rank);
            }
            return returnValue;
        }

        /// <summary>
        /// Checks if the card on the left is greater than or equal to the card on the right
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Card left, Card right)
        {
            bool returnValue = (left > right);
            if (!returnValue)
            {
                returnValue = (left == right);
            }

            return returnValue;
        }

        /// <summary>
        /// Checks if the card on the left is less than the card on the right
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Card left, Card right)
        {
            return right >= left;
        }
        /// <summary>
        /// Checks if the card on the left is less than or equal to the one on the right
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Card left, Card right)
        {
            return right > left;
        }

        /// <summary>
        /// Checks if the two cards are equal
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public override bool Equals(object card)
        {
            return this == (Card)card;
        }

        /// <summary>
        /// Retrieve a unique has for each card
        /// </summary>
        /// <returns>the hash</returns>
        public override int GetHashCode()
        {
            // sets the initial hash
            int hash = 13 * (int)mySuit;

            // if the rank is an ace
            if (myRank == CardRank.Ace)
            {
                // if ace is high, add the corresponding value
                if (IsAceHigh)
                    hash += (int)myRank;
                // otherwise, add 1
                else
                    hash += 1;
            }
            // otherwise, add the rank value
            else
                hash += (int)myRank;

            // if there are trumps and the suit matches the trump
            // add 100 to the hash code
            if (trumpsExist && (mySuit == trumpSuit))
                hash += 100;

            // return the code
            return hash;
        }
        #endregion

        #region OTHER_METHODS
        /// <summary>
        /// Returns the value of the rank.
        /// Used as Ace can either be 1 or the highest
        /// </summary>
        /// <param name="card">the card that needs to be checked</param>
        /// <returns></returns>
        static private int GetRankValue(Card card)
        {
            int rankValue;
            if (card.Rank == CardRank.Ace && IsAceHigh)
                rankValue = (int)CardRank.Ace;
            else
                rankValue = 1;

            return rankValue;
        }
        /// <summary>
        /// Overrides the ToString() operator
        /// </summary>
        /// <returns>the card as a string</returns>
        public override string ToString()
        {
            return Rank + " of " + Suit;
        }

        /// <summary>
        /// Returns a copy of the card
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Returns the corresponding Card Image
        /// </summary>
        /// <returns></returns>
        public Image GetImage()
        {
            string url; // the corresponding url for the card

            // if the card is face up, return it with the name
            // Rank_L (L being first letter of the suit)
            if (IsFaceUp)
            {
                url = myRank.ToString() + "_" + mySuit.ToString().Substring(0, 1).ToUpper().ToString();
            }
            // otherwise, save the face down card
            else
            {
                url = "gray_back";
            }

            // return the card as an image
            return Properties.Resources.ResourceManager.GetObject(url) as Image;
        }
        #endregion
    }
}
