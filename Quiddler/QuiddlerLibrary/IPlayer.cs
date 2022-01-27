// Brittany Diesbourg & Dianne Corpuz - Section A

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuiddlerLibrary
{
    public interface IPlayer
    {
        int CardCount { get; }
        int TotalPoints { get; }

        public string DrawCard();
        public bool Discard(string card);
        public string PickupTopDiscard();
        public int PlayWord(string candidate);
        public int TestWord(string candidate);
        public string ToString();
    }
}
