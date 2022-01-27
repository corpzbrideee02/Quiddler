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
            if (TestWord(candidate) > 0)
            {
                //TotalPoints += TestWord(candidate);
            }

            throw new NotImplementedException();
        }

        public int TestWord(string candidate)
        {
            candidate = candidate.ToLower();

            
            bool isWord = App.CheckSpelling(candidate);
            App.Quit();
            
            throw new NotImplementedException();
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
