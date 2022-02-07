// Brittany Diesbourg & Dianne Corpuz - Section A

using System;

namespace QuiddlerLibrary
{
    public interface IDeck:IDisposable
    {
        public string About { get; }
        public int CardCount { get; }
        public int CardsPerPlayer { get; set; }
        public string TopDiscard { get; }

        IPlayer NewPlayer();
        public string ToString();
    }
}
