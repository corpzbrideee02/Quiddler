// Brittany Diesbourg & Dianne Corpuz - Section A

using QuiddlerLibrary;
using System;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuiddlerPlayer
{
    public class Player : IPlayer
    {
        public int CardCount { get; }

        public int TotalPoints { get; }

        public Player( Deck d)
        {
            CardCount = 0;
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

            Application app = new Application();
            bool isWord = app.CheckSpelling(candidate);
            app.Quit();
            
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
