// Brittany Diesbourg & Dianne Corpuz - Section A

namespace QuiddlerLibrary
{
    public interface IDeck
    {
        public string About { get; }
        public int CardCount { get; }
        public int CardsPerPlayer { get; set; }
        public string TopDiscard { get; }

        IPlayer NewPlayer();
        public string ToString();
    }
}
