﻿/*
 * CardDealer.cs
 * Defines a card dealer that will store the cards being used
 * in the game
 * 
 * Author:  Group 1
 * Since:   8 March 2020
 */

using System;

namespace CardLib
{
    /// <summary>
    /// An object that will store the cards currently being used in the game
    /// </summary>
    public class CardDealer
    {
        /// <summary>
        /// The cards in play
        /// </summary>
        CardList dealerCards;
        /// <summary>
        /// The number of cards (52, 36, 20) in the game
        /// </summary>
        int numberOfCards;
        /// <summary>
        /// The next card in the dealers hand
        /// </summary>
        int nextCardIndex;

        /// <summary>
        /// Constructor: Initializes a CardDealer obkect
        /// </summary>
        /// <param name="cardCount">the number of cards the game is going to use</param>
        /// <throws>ArgumentOutOfRangeException if the number of cards is not 52, 36, or 20</throws>
        public CardDealer(int cardCount = 52)
        {
            // if the card range is not valid
            if (cardCount != 52 && cardCount != 36 && cardCount != 20)
                throw new CardOutOfRangeException("The number of cards must be either 20, 36, or 52", 0);
            
            // sets the number of cards
            numberOfCards = cardCount;
            // initalies the card list
            dealerCards = new CardList();
            // stores the cards
            ObtainCards();
        }

        /// <summary>
        /// Retrieve a card at a certain index
        /// </summary>
        /// <param name="index">the index of the desired card</param>
        /// <returns>the card at the given index</returns>
        public Card GetCard(int index)
        {
            return dealerCards[index];
        }

        /// <summary>
        /// Retrieves the next card and increases the counter by 1
        /// </summary>
        /// <returns></returns>
        public Card GetNextCard()
        {
            return (Card)dealerCards[nextCardIndex++].Clone();
        }

        /// <summary>
        /// Obtains the certain number of cards starting at the desired index
        /// </summary>
        public void ObtainCards()
        {
            nextCardIndex = 0;
            int startingRank;   // the index to start at

            // if cards exist, clear them
            if (dealerCards.Count > 0 || dealerCards != null)
                dealerCards.Clear();
            
            // determine the starting index
            if (numberOfCards == 20) startingRank = 10;
            else if (numberOfCards == 36) startingRank = 6;
            else startingRank = 2;

            // obtain the certain number of cards
            for (int suitCount = 0; suitCount < 4; suitCount++)
            {
                for (int rankCount = startingRank; rankCount < 15; rankCount++)
                {
                    dealerCards.Add(new Card((CardRank)rankCount, (CardSuit)suitCount));
                }
            }

            Shuffle();  // shuffles the cards
        }

        /// <summary>
        /// Shuffles the cards in the dealers hand
        /// </summary>
        public void Shuffle()
        {
            Random rng = new Random();

            for (int count = 0; count < numberOfCards; count++)
            {
                int index = rng.Next(0, numberOfCards - 1);
                Card temp = dealerCards[count].Clone() as Card;
                dealerCards[count] = dealerCards[index].Clone() as Card;
                dealerCards[index] = temp;
            }
        }

        /// <summary>
        /// Returns the number of cards the dealer starts with
        /// </summary>
        public int NumberOfCards
        {
            get { return numberOfCards; }
        }
    }
}