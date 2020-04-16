/*
 * CardList.cs
 * Defines a collection of cards
 * 
 * Author:  Group 1
 * Since:   8 March 2020
 * 
 * Reference:   Watson, K. et al. (2013). Beginning Visual C# 2022 Programming. 
 *                  Wrox Press.
 */

using System;
using System.Collections;

namespace CardLib
{
    /// <summary>
    /// Cards collection that stores Card objects
    /// </summary>
    public class CardList : CollectionBase, ICloneable
    {
        /// <summary>
        /// Add - inserts a new card to the list
        /// </summary>
        /// <param name="newCard">the card that will be added</param>
        public void Add(Card newCard)
        {
            List.Add(newCard);
        }

        /// <summary>
        /// Remove - deletes a card from the list
        /// </summary>
        /// <param name="oldCard">the card that is going to be deleted</param>
        public void Remove(Card oldCard)
        {
            if (!List.Contains(oldCard))
                throw new CardDoesNotExistException(oldCard.ToString()  + " does not exist in this players hand", oldCard);
            List.Remove(oldCard);
        }

        /// <summary>
        /// indexer - gets or sets a card at the provided index
        /// </summary>
        /// <param name="cardIndex">the index of the card</param>
        /// <returns></returns>
        public Card this[int cardIndex]
        {
            get
            {
                if (cardIndex >= List.Count)
                    throw new CardOutOfRangeException("There is no card at the index of " + cardIndex);

                return (Card)List[cardIndex];
            }
            set
            {
                List[cardIndex] = value;
            }
        }

        /// <summary>
        /// Utility method for copying card instances into another Cards instance-used in Deck.Shuffle().
        /// Ths implementation assumes that source and target collections are the same size.
        /// </summary>
        /// <param name="targetCards"></param>
        public void CopyTo(CardList targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }

        /// <summary>
        /// Checks to see if the Cards collection contains a particular card.
        /// This calls the Contains() method of the ArrayList for the collect which you access through the InnerList
        /// property
        /// </summary>
        /// <param name="card">the card that will be searched for</param>
        /// <returns></returns>
        public bool Contains(Card card)
        {
            return InnerList.Contains(card);
        }

        /// <summary>
        /// Clone - Creates a copy of the Cards collection
        /// </summary>
        /// <returns>the new instance of the collection</returns>
        public object Clone()
        {
            CardList newCards = new CardList();   // creates a cards collection

            // copies each card using the depp copy from Card
            foreach (Card sourceCard in List)
            {
                newCards.Add((Card)sourceCard.Clone());
            }

            // returns the new collection
            return newCards;
        }
    }
}
