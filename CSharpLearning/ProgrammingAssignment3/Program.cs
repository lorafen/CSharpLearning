using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCards;

namespace ProgrammingAssignment3
{
    /// <summary>
    /// Blackjack
    /// </summary>
    class Program
    {
        /// <summary>
        /// Blackjack
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // Declare variables for and create a deck of cards and blackjack hands for the dealer nad the player
            string dealer = "Dealer";
            string player = "Player";
            Card dealerCard;
            Card playerCard;

            Deck deckOfCards = new Deck();

            BlackjackHand dealerBlackJackHand = new BlackjackHand(dealer);
            BlackjackHand playerBlackJackHand = new BlackjackHand(player);

            // Print a “welcome” message to the user telling them that the program will play a single hand of Blackjack
            Console.WriteLine("This is the single hand of Blackjack programm");

            // Shuffle the deck of cards
            deckOfCards.Shuffle();

            // Deal 2 cards to the player and dealer
            dealerCard = deckOfCards.TakeTopCard();
            dealerBlackJackHand.AddCard(dealerCard);
            
            playerCard = deckOfCards.TakeTopCard();
            playerBlackJackHand.AddCard(playerCard);

            //  Make all the player’s cards face up (you need to see what you have!); there's a method for this in the BlackjackHand class
            playerBlackJackHand.ShowFirstCard();

            // Make the dealer’s first card face up (the second card is the dealer’s “hole” card); there's a method for this in the BlackjackHand class
            dealerBlackJackHand.ShowFirstCard();

            // Print both the player’s hand and the dealer’s hand
            playerBlackJackHand.Print();
            dealerBlackJackHand.Print();

            // Let the player hit if they want to
            playerBlackJackHand.HitOrNot(deckOfCards);

            // Dealer hit the card if his is under 10
            int dealerScore = dealerBlackJackHand.Score;

            if (dealerScore < 10)
            {
                dealerCard = deckOfCards.TakeTopCard();
                dealerBlackJackHand.AddCard(dealerCard);
            }
            else
            {
                Console.WriteLine("Dealer didn't hit a card");
                Console.WriteLine();
            }

            // Make all the dealer’s cards face up; there's a method for this in the BlackjackHand class
            dealerBlackJackHand.ShowAllCards();

            // Print both the player’s hand and the dealer’s hand
            playerBlackJackHand.Print();
            dealerBlackJackHand.Print();

            // Print the scores for both hands
            Console.WriteLine("Player's score: " + playerBlackJackHand.Score);
            Console.WriteLine("Dealer's score: " + dealerBlackJackHand.Score);

            Console.WriteLine();
        }
    }
}
