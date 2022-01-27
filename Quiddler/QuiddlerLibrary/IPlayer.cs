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

        string DrawCard();
        bool Discard(string card);
        string PickupTopDiscard();
        int PlayWord(string candidate);
        int TestWord(string candidate);
        string ToString();
    }
}
