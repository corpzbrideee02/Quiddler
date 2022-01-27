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
        private Application App = new Application();
        private List<string> Cards = new List<string>();
        private Deck PlayerDeck = null;


        // implement the IPlayer interface

        public int CardCount => Cards.Count;

        public int TotalPoints { get; }

        public Player(Deck d)
        {
            PlayerDeck = d;
            TotalPoints = 0;
        }

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
            throw new NotImplementedException();
        }

        public int PlayWord(string candidate)
        {
            int points = TestWord(candidate);

            if (points > 0)
            {
                //TotalPoints += points;
            }

            throw new NotImplementedException();
        }

        public int TestWord(string candidate)
        {
            if (candidate.Length > 0)
            {
                candidate = candidate.ToLower();

                string[] wordArray = candidate.Split(' ');

                string wordNoSpace = "";

                foreach (var w in wordArray)
                    wordNoSpace += w;

                bool isWord = App.CheckSpelling(wordNoSpace);
                App.Quit();

                if (isWord)
                {
                    // TODO: add up points
                }
                else
                    return 0;

                
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
