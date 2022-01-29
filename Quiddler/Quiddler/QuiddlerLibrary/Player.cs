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
        private Deck PlayerDeck = null;

        public Player(Deck d)
        {
            PlayerDeck = d;
            TotalPoints = 0;
        }

        // implement the IPlayer interface

        public int CardCount => Cards.Count;

        public int TotalPoints { get; set; }        

        public bool Discard(string card)
        {
            throw new NotImplementedException();
        }

        public string DrawCard()
        {
            throw new NotImplementedException();
        }

        public string PickupTopDiscard()
        {
            Cards.Add(PlayerDeck.TopDiscard);
            return Cards[CardCount - 1];
        }

        public int PlayWord(string candidate)
        {
            int points = TestWord(candidate);

            if (points > 0)
            {
                //TODO discard the cards in the word from player cards

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

                if (wordArray.Length < CardCount) // makes sure there's at least 1 card left over to discard
                {
                    //TODO check if letters are in player's cards

                    string wordNoSpace = "";

                    foreach (var w in wordArray)
                        wordNoSpace += w;

                    Application App = new Application();
                    bool isWord = App.CheckSpelling(wordNoSpace);
                    App.Quit();

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
            string cardsDisplay = "Your cards are [";

            foreach (var c in Cards)
                cardsDisplay += c + " ";
            cardsDisplay += "].";

            return cardsDisplay;
        }
    }
}
