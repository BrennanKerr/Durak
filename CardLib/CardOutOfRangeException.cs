/*
 * CardOutOfRangeException.cs
 * Defiens an exception used when a card is trying to be retrieved that does not correspond with a list
 * 
 * Author:  Group 8
 * Since:   8 March 2020
 * 
 * Reference:   Watson, K. et al. (2013). Beginning Visual C# 2022 Programming. 
 *                  Wrox Press.
 */

using System;

namespace CardLib
{
    public class CardOutOfRangeException : Exception
    {
        // stores the number of cards that are remaining in the list
        private readonly int cardsRemaining;

        /// <summary>
        /// Constructor: Saves the message and number of cards remaining in a list
        /// </summary>
        /// <param name="message">the message that will be stored and can be displayed</param>
        /// <param name="remaining">the number of cards remaining in a list (if within a list)</param>
        public CardOutOfRangeException(string message = "Card does not exist", int remaining = 0) :base(message)
        {
            cardsRemaining = remaining;
        }

        /// <summary>
        /// Gets the number of cards remaining
        /// </summary>
        public int CardsRemaining
        {
            get { return cardsRemaining; }
        }
    }
}
