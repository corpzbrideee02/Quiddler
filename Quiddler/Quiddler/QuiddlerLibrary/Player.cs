// Brittany Diesbourg & Dianne Corpuz - Section A

using QuiddlerLibrary;
using System;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuiddlerLibrary
{
    internal class Player : IPlayer
    {
        // private members
        
        private List<string> Cards = new List<string>();
        private Deck GameDeck = null;

        public Player(Deck d)
        {
            GameDeck = d;
            TotalPoints = 0;
        }

        // implement the IPlayer interface

        public int CardCount => Cards.Count;

        public int TotalPoints { get; set; }  // setter is not in IPlayer interface but is needed in class to increment the player's points

        public bool Discard(string card)
        {
            if (Cards.Contains(card))
            {
                Cards.Remove(card);
                // TODO: put card in discard pile
            }
            return false;
        }

        public string DrawCard()
        {
            if (GameDeck.CardCount == 0)
                throw new InvalidOperationException();

            Random random;
            int index;

            //do
            //{
            //    random = new Random();
            //    index = random.Next(PlayerDeck.CardCount - 1);  //index of random card picked

            //} while (PlayerDeck.CardCountsInDeck.ElementAt(index).Value != 0);
                
            //Cards.Add(PlayerDeck.CardCountsInDeck.ElementAt(index).Key);

            //--CardCountsInDeck.ElementAt(index).Value;

            return Cards[CardCount - 1];
        }

        public string PickupTopDiscard()
        {
            Cards.Add(GameDeck.TopDiscard);
            // TODO: TopDiscard gets next card's value
            return Cards[CardCount - 1];
        }

        public int PlayWord(string candidate)
        {
            int points = TestWord(candidate);

            if (points > 0)
            {
                string[] wordArray = candidate.Split(' ');

                bool discarded = false; // may change this later once I know what to do with the returned bool

                foreach (var w in wordArray)
                    discarded = Discard(w);

                TotalPoints += points;
            }
            return points;
        }

        public int TestWord(string candidate)
        {
            if (candidate.Length > 0)
            {
                candidate = candidate.ToLower();

                string[] wordArray = candidate.Split(' ');

                if (wordArray.Length < CardCount) // makes sure there's at least 1 card left over in player's hand to discard
                {
                    string wordNoSpace = "";

                    foreach (var w in wordArray)
                    {
                        if (!Cards.Contains(w))
                            return 0;
                        wordNoSpace += w;
                    }

                    Application App = new Application(); // should be moved to Deck class
                    bool isWord = App.CheckSpelling(wordNoSpace);
                    App.Quit(); // call in Dispose?

                    if (isWord)
                    {
                        // TODO: add up points
                    }
                }                                
            }
            return 0;
        }

        public override string ToString()
        {
            string cardsDisplay = "";

            foreach (var c in Cards)
                cardsDisplay += c + " ";
            
            cardsDisplay = cardsDisplay.Trim(); // removes last space

            return cardsDisplay;
        }
    }
}
