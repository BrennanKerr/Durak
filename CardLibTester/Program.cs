using System;

using CardLib;
using PlayerLib;

namespace CardLibTester
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //TestCardDealer();
                TestCardDrawing(new CardDealer(20));
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\n" + e.GetType() + "\n" + e.Message);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Tests the CardDealer controls
        /// </summary>
        static void TestCardDealer()
        {
            CardDealer dealer;      // creates a new dealer
            bool isValid = false;   // sets the valid status to false

            do
            {
                try
                {
                    // attempts to create a new object with the entered number of cards
                    Console.Write("\nPlease enter a number of cards (Must be 20, 36, or 52): ");
                    dealer = new CardDealer(Convert.ToInt32(Console.ReadLine()));
                    isValid = true; // set to true if 20, 36, or 52 was entered

                    // shuffles the cards and displays the order
                        // colours each suit for easier observation
                    Console.WriteLine("\nThe Cards After Shuffling: ");
                    for (int count = 0; count < dealer.NumberOfCards; count++)
                    {
                        Card card = dealer.GetCard(count);
                        if (card.Suit == CardSuit.Clubs)
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        else if (card.Suit == CardSuit.Diamonds)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else if (card.Suit == CardSuit.Hearts)
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        else
                            Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine(card.ToString());
                    }
                    //sets the colour back to Gray
                    Console.ForegroundColor = ConsoleColor.Gray;
                    TestCardDrawing(dealer);    // tests the card draw controls
                    
                }
                // catch any and all exceptions that arise
                catch (Exception e)
                {
                    Console.WriteLine("\n" + e.Message);
                }
            } while (!isValid); // continue running until the input is valid
        }

        /// <summary>
        /// Tests drawing cards from a CardDealer object
        /// </summary>
        /// <param name="dealer"></param>
        static void TestCardDrawing(CardDealer dealer)
        {
            try
            {
                // initializes 2 players
                Player[] players = new Player[2];
                players[0] = new Player();
                players[1] = new Player();

                // writes their information onto the screen
                Console.WriteLine("\n\n" + players[0].ToString());
                Console.WriteLine(players[1].ToString());

                int cardsToDraw;        // stores the number of cards the player wants to draw
                bool numValid = false;  // if the input is a number, stores true

                do
                {
                    // takes the input as a string
                    String input;
                    Console.WriteLine("\nHow many cards should be drawn (Dealer has {0} cards)?: ", dealer.NumberOfCards.ToString());
                    input = Console.ReadLine();

                    // if the input is an integerr, save numValid as true
                    if (int.TryParse(input, out cardsToDraw))
                    {
                        // check if the number is greater than 0
                        if (cardsToDraw > 0)
                        {
                            // check if each player can get that amount
                            if (cardsToDraw <= dealer.NumberOfCards / Player.NumberOfPlayers)
                                numValid = true;
                            else
                                Console.WriteLine(cardsToDraw + " cards for " + Player.NumberOfPlayers + " would exceed " + dealer.NumberOfCards + ". Please enter another");
                        }
                        else
                            Console.WriteLine("Please enter a number higher than 1");
                    }
                } while (numValid == false);

                // draws the cards for each player
                for (int cardCount = 0; cardCount < cardsToDraw; cardCount++)
                {
                    for (int numOfPlayers = 0; numOfPlayers < Player.NumberOfPlayers; numOfPlayers++)
                    {
                        players[numOfPlayers].AddCard(dealer.GetNextCard());
                    }
                }

                // Displays all the cards for the players
                for (int count = 0; count < Player.NumberOfPlayers; count++)
                {
                    Console.WriteLine("\nPlayer " + (count + 1) + "'s hand:");
                    foreach (Card card in players[count].Cards())
                        Console.WriteLine(card.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\n" + e.GetType().ToString() + "\n" + e.Message);
            }
        }
    }
}
