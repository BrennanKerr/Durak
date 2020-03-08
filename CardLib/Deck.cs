/*
 * Deck.cs
 * Defines a deck of playing cards
 * 
 * Author:  Group 1
 * Since:   8 March 2020
 */

using System;

namespace CardLib
{
    /// <summary>
    /// Defines a Deck obkect that stores cards from Ace-King with the 4 ranks
    /// </summary>
    public class Deck
    {
        CardList myCards;   // the list of cards

        /// <summary>
        /// Default Constructor: Initializes a deck of 52 cards
        /// </summary>
        public Deck()
        {
            myCards = new CardList();   // initializes a new list

            // runs through each suit
            for (int suitCount = 0; suitCount < 4; suitCount++)
            {
                // runs through each rank
                for (int rankCount = 2; rankCount < 15; rankCount++)
                {
                    // adds the card with the corresponding rank and suit to the list
                    myCards.Add(new Card((CardRank)rankCount, (CardSuit)suitCount));
                }
            }
        }

        /// <summary>
        /// Returns the card at the given index
        /// </summary>
        /// <param name="index">the index</param>
        /// <returns>the corresponding card</returns>
        public Card AtIndex(int index)
        {
            return myCards[index];
        }

    }
}
