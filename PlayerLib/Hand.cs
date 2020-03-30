/*
 * Hand.cs
 * Defines a hand of cards
 * 
 * Author:  Group 1
 * Since:   8 March 2020
 */

using System;

using CardLib;

namespace PlayerLib
{
    /// <summary>
    /// A list of cards that is currently in a players hand
    /// </summary>
    public class Hand
    {
        /// <summary>
        /// The list of cards
        /// </summary>
        private CardList myCards;

        #region CONSTRUCTORS
        /// <summary>
        /// Default Constructor: defines an empty list
        /// </summary>
        public Hand()
        {
            myCards = new CardList();
        }

        /// <summary>
        /// Creates a copy of a card list to use in the given hand
        /// </summary>
        /// <param name="newCards"></param>
        public Hand(CardList newCards)
        {
            newCards.CopyTo(myCards);
        }
        #endregion

        #region LIST_METHODS
        /// <summary>
        /// Adds a new card to the hand
        /// </summary>
        /// <param name="newCard">the card to be added</param>
        public void Add(Card newCard) { myCards.Add(newCard); }
        /// <summary>
        /// Removes a certain card from the hand
        /// </summary>
        /// <param name="oldCard">the specic card to be removed</param>
        public void Remove(Card oldCard) { myCards.Remove(oldCard); }
        /// <summary>
        /// Checks if a certain card is in the hand
        /// </summary>
        /// <param name="card">the card to look for</param>
        /// <returns>true if the card exists in the hand</returns>
        public bool Contains(Card card) { return myCards.Contains(card); }
        /// <summary>
        /// Removes all cards in the hand
        /// </summary>
        public void RemoveCards() { myCards.Clear(); }
        #endregion

        #region OTHER_METHODS
        /// <summary>
        /// Retrieves the card at the certain index and removes it from the hand
        /// </summary>
        /// <param name="index">the location of the card</param>
        /// <returns>the card drawn from the hand</returns>
        public Card DrawCard(int index)
        {
            Card drawnCard = myCards[index];
            myCards.Remove(drawnCard);
            return drawnCard;
        }

        /// <summary>
        /// Gets or Sets the cards in the hand
        /// </summary>
        public CardList Cards
        { 
            get { return myCards.Clone() as CardList; }
            set { value.CopyTo(myCards); }
        }

        /// <summary>
        /// Returns the number of cards remaining 
        /// </summary>
        /// <returns>the number of cards left in the hand</returns>
        public int CardsRemaining()
        {
            return myCards.Count;
        }

        /// <summary>
        /// Replaces the card at the given index
        /// </summary>
        /// <param name="index">the index of the card that will be replced</param>
        /// <param name="newCard">the card that will replace it</param>
        public void ReplaceCard(int index, Card newCard) { this.myCards[index] = newCard.Clone() as Card; }
        /// <summary>
        /// Returns the hand as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string obj = "";

            foreach (Card c in myCards)
                obj += c.ToString() + "\n";

            return obj;
        }
        #endregion
    }
}
