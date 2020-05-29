/*
 * Player.cs
 * Defnes a player that holds a name, player number, and a hand of cards
 * 
 * Author:  Group 1
 * Since:   8 March 2020
 */
using System;

using CardLib;

namespace PlayerLib
{
    /// <summary>
    /// Defines a player object
    /// </summary>
    public class Player
    {
        #region PROPERTIES_AND_FIELDS
        /// <summary>
        /// Counts the number of players in the game starting at 1
        /// </summary>
        private static int numberOfPlayers = 0;

        /// <summary>
        /// The name of the player
        /// </summary>
        private string myName;
        public string Name
        {
            get { return myName; }
            set { myName = value; }
        }
        /// <summary>
        /// The players number
        /// </summary>
        private int myNumber;
        /// <summary>
        /// The cards the player currently has
        /// </summary>
        private Hand myHand;
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Default constructor that initializes their hand and assigns their number
        /// </summary>
        public Player()
        {
            myHand = new Hand();
            myNumber = ++numberOfPlayers;
        }

        /// <summary>
        /// Constructor: adds a name to the player
        /// </summary>
        /// <param name="name"></param>
        public Player(string name):this()
        {
            myName = name; 
        }

        /// <summary>
        /// Constructor: Sets a player name and hand
        /// </summary>
        /// <param name="name">the name of the player</param>
        /// <param name="newHand">the hand of the player</param>
        public Player(string name, Hand newHand):this(name)
        {
            newHand.Cards.CopyTo(myHand.Cards); 
        }
        #endregion

        #region CARD_MANIPULATION_METHODS
        /// <summary>
        /// Adds a list of cards to the player
        /// </summary>
        /// <param name="cards">the list of cards</param>
        public void AddCards(CardList cards)
        {
            myHand.Cards = cards;
        }

        /// <summary>
        /// Adds a new card to the players hand
        /// </summary>
        /// <param name="newCard">the card that is added to their hand</param>
        public void AddCard(Card newCard)
        {
            myHand.Add(newCard);
        }

        /// <summary>
        /// Delete the card from the lsit
        /// </summary>
        /// <param name="oldCard">the card to be removed</param>
        public void Remove(Card oldCard)
        {
            try
            {
                myHand.Remove(oldCard);
            }
            catch (CardDoesNotExistException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Removes the cards from the hand
        /// </summary>
        public void RemoveCards()
        {
            myHand.RemoveCards();
        }

        /// <summary>
        /// Retrieves the players entire hand of cards
        /// </summary>
        /// <returns>the players hand as a CardList</returns>
        public CardList Cards()
        {
            return myHand.Cards;
        }

        /// <summary>
        /// Draws a card from the players hand. Will remove it from their hand.
        /// </summary>
        /// <param name="index">the index of the card</param>
        /// <returns>the list of cards</returns>
        public Card DrawCard(int index)
        {
            return myHand.DrawCard(index);
        }

        /// <summary>
        /// Replaces a card at a given index
        /// </summary>
        /// <param name="index">the card index to be overwritten</param>
        /// <param name="newCard">the card to place in the index</param>
        public void ReplaceCard(int index, Card newCard)
        {
            myHand.ReplaceCard(index, newCard);
        }
        #endregion

        #region OTHER_METHODS
        /// <summary>
        /// Retrieve the number of cards the player has left
        /// </summary>
        /// <returns>the number of cards</returns>
        public int CardsRemaining()
        {
            return myHand.CardsRemaining();
        }

        /// <summary>
        /// Returns the number of player objects in the game
        /// </summary>
        public static int NumberOfPlayers
        { 
            get { return numberOfPlayers; }
        }

        /// <summary>
        /// Returns the player as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return myNumber.ToString() + (myName == null ? "" : (": " + myName));
        }
        #endregion
    }
}
