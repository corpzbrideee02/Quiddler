// Brittany Diesbourg & Dianne Corpuz - Section A

using System;
using System.Collections.Generic;
using QuiddlerLibrary;

namespace QuiddlerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // SET UP FOR GAME

            IDeck deck = new Deck();
            List<IPlayer> players = new List<IPlayer>();

            Console.WriteLine(deck.About);

            string input;
            int playerNum;

            Console.WriteLine($"\nDeck initialized with the following {deck.CardCount} cards...");
            Console.WriteLine(deck);

            do
            {
                Console.Write("\nHow many players are there? (1‐8): ");
                input = Console.ReadLine();

                playerNum = int.Parse(input);

            } while (playerNum < 1 || playerNum > 8);

            input = "";

            int cardNum;
            do
            {
                Console.Write("\nHow many cards will be dealt to each player? (3‐10): ");
                input = Console.ReadLine();

                cardNum = int.Parse(input);

            } while (cardNum < 3 || cardNum > 10);

            deck.CardsPerPlayer = cardNum;

            for (int i = 0; i < playerNum; ++i)
            {
                players.Add(deck.NewPlayer());
            }
                

            Console.WriteLine($"Cards were dealt to {playerNum} player(s).");


            Console.WriteLine($"The top card which was '{deck.TopDiscard}' was moved to the discard pile.");

            // PLAY THE GAME

            bool quitGame = false;
            char yOrN;

            do
            {
                for (int i = 0; i < players.Count; ++i) // do this for each player in a round
                {
                    Console.WriteLine("\n‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐");
                    Console.WriteLine($"Player {i+1} ({players[i].TotalPoints} points)");
                    Console.WriteLine("‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐");

                    Console.WriteLine($"\nThe deck now contains the following {deck.CardCount} cards...");
                    Console.WriteLine(deck);

                    Console.WriteLine($"\nYour cards are [{players[i]}]");

                    // ask for top discard
                    do
                    {
                        //string discard2 = deck.TopDiscard;
                        Console.Write($"\nDo you want the top card in the discard pile which is '{deck.TopDiscard}'? (y/n): ");
                        yOrN = char.ToLower(Console.ReadKey().KeyChar);

                    } while ((yOrN != 'y') && (yOrN != 'n'));

                    if (yOrN == 'n')
                    {
                        string drawnCard = players[i].DrawCard();
                        Console.WriteLine($"\nThe dealer dealt '{drawnCard}' to you from the deck.");
                        Console.WriteLine($"The deck contains {deck.CardCount} cards.");
                    }
                    else if (yOrN == 'y')
                    {
                        string topDC = players[i].PickupTopDiscard(); // may change this later once I know what to do with the returned string
                    }

                    Console.WriteLine($"\nYour cards are [{players[i]}]");


                    // test and play word

                    bool testWord = true;

                    do
                    {
                        Console.Write($"Test a word for its points value? (y/n): ");
                        yOrN = char.ToLower(Console.ReadKey().KeyChar);

                        if (yOrN == 'y')
                        {
                            int points = 0;
                            string enteredWord;

                            do
                            {
                                Console.Write($"\nEnter a word using [{players[i]}] leaving a space between cards: ");

                                enteredWord = Console.ReadLine();

                                points = players[i].TestWord(enteredWord);

                                Console.WriteLine($"\nThe word [{enteredWord}] is worth {points} points.");

                            } while (points == 0);

                            do
                            {
                                Console.Write($"Do you want to play the word [{enteredWord}]? (y/n): ");
                                yOrN = char.ToLower(Console.ReadKey().KeyChar);

                            } while (yOrN != 'y' && yOrN != 'n') ;
                        
                            if (yOrN == 'y')
                            {
                                points = players[i].PlayWord(enteredWord); // may change this later once I know what to do with the returned int

                                Console.WriteLine($"\nYour cards are [{players[i]}] and you have {players[i].TotalPoints} points.");
                                testWord = false; // playing the word so no need to test another one
                            }
                        }

                    } while ((yOrN != 'y') && (yOrN != 'n' && testWord)); // if player chooses not to play a word they will be asked if they want to test another one instead

                    do
                    {
                        Console.Write("\nEnter a card from your hand to drop on the discard pile: ");
                        input = Console.ReadLine().ToLower();
                        input = input.Trim(); // trims any leading/trailing spaces if needed

                    } while (!players[i].ToString().Contains(input)); // check to see if entered card is in player's hand

                    bool discarded = players[i].Discard(input); // may change this later once I know what to do with the returned bool

                    Console.WriteLine($"\nYour cards are [{players[i]}]");
                }

                do
                {
                    Console.Write("Would you like each player to take another turn? (y/n): ");
                    yOrN = char.ToLower(Console.ReadKey().KeyChar);

                } while (yOrN != 'y' && yOrN != 'n');

                if (yOrN == 'n')
                {
                    quitGame = true;

                    Console.WriteLine("\nRetiring the game.\n");

                    Console.WriteLine("The final scores are...");
                    Console.WriteLine("‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐");

                    for (int i = 0; i < players.Count; ++i)
                    {
                        Console.WriteLine($"Player {i + 1}: {players[i].TotalPoints} points");
                    }
                }

            } while (!quitGame);
        }
    }
}
