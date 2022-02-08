// Brittany Diesbourg & Dianne Corpuz - Section A

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
