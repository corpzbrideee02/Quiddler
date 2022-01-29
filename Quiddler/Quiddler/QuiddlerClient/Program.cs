// Brittany Diesbourg & Dianne Corpuz - Section A

using System;
using QuiddlerLibrary;

namespace QuiddlerClient
{
    class Program
    {
        static void Main(string[] args)
        {

            IDeck deck = new Deck();

            Console.WriteLine(deck.About);

            string input;
            int playerNum;

            Console.WriteLine("\nDeck initialized with the following " + deck.CardCount + " cards...");
            Console.WriteLine(deck);

            do
            {
                Console.WriteLine("\nHow many players are there? (1‐8): ");
                input = Console.ReadLine();

                playerNum = int.Parse(input);

            } while (playerNum < 1 || playerNum > 8);

           

            input = "";

            int cardNum;
            do
            {
                Console.WriteLine("\nHow many cards will be dealt to each player? (3‐10):");
                input = Console.ReadLine();

                cardNum = int.Parse(input);

            } while (cardNum < 3 || cardNum > 10);

            deck.CardsPerPlayer = cardNum;

            for (int i = 0; i < playerNum; ++i)
                deck.NewPlayer();

            Console.WriteLine("Cards were dealt to " + playerNum + " player(s).");

            string discard = deck.TopDiscard;

            Console.WriteLine("The top card which was '" + discard + "' was moved to the discard pile.");

            // TO DO loop for the game
        }
    }
}
