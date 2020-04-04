using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    class CardDoesNotExistException : Exception
    {
        /// <summary>
        /// the card as a string
        /// </summary>
        private readonly string cardString;

        /// <summary>
        /// Parameterized Constructor: Sets the message and card that was selected
        /// </summary>
        /// <param name="message">the error message to display</param>
        /// <param name="card">the card as a string</param>
        public CardDoesNotExistException(string message = "The selected card does not exist", string card= "No card Selected")
        {
            cardString = card;  // saves the card string
        }

        /// <summary>
        /// Parameterized Constructor: Sets the message and converts the card to a string to pass to the
        ///     CardDoesNotExistException(string, string) constructor)
        /// </summary>
        /// <param name="message">the error message</param>
        /// <param name="card">the card</param>
        public CardDoesNotExistException(string message, Card card) : base(card.ToString())
        {  }

        /// <summary>
        /// Retrieve the card string
        /// </summary>
        public string CardSelected
        {
            get { return cardString; }
        }
    }
}
