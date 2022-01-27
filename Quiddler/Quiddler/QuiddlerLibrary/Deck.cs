// Brittany Diesbourg & Dianne Corpuz - Section A

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuiddlerLibrary
{
    public class Deck : IDeck
    {
        // Private member variables
        private int cardsToBeDealt = 0;
        private const int NumberOfCards = 118;
        private static int Twelve = 12, Ten = 10, Eight = 8, Six = 6, Four = 4, Two = 2;

        //
        private List<IPlayer> players = null;
        private int undealtCards;

        //c'tor 
        /*public Deck()
        {

        }*/


        public string About => $"Test Client for: {GetType().Namespace}, Developers: Brittany Diesbourg and Dianne Corpuz";

        private Dictionary<string, int> CardCountsInDeck = new Dictionary<string, int>()
        {
                {"a",Ten}, {"b",Two},  {"c",Two},{"d",Four}, {"e",Twelve},{"f",Two},{"g",Four}, {"h",Two},{"i",Eight},  {"j",Two},  {"k",Two},  {"l",Four}, {"m",Two},{"n",Six}, {"o",Eight},
                 {"p",Two}, {"q",Two},{"r",Six},{"s",Four},{"t",Six},{"u",Six}, {"v",Two}, {"w",Two}, {"x",Two},  {"y",Four}, {"z",Two},  {"cl",Two}, {"er",Two}, {"in",Two},{"qu",Two}, {"th",Two},
        };


        public int CardCount
        {
            get
            {   //NOTE: should return undealtCards=NumberOfCards-(players.Length * cardsToBeDealt).. Then everytime the user gets a card from the deck, this should decrement
                return undealtCards;
            }

            init
            {
                CardCount = NumberOfCards;
            }
        }

        public int CardsPerPlayer
        {
            get
            {
                if (cardsToBeDealt < 3 && cardsToBeDealt > 10)
                {
                    throw new ArgumentOutOfRangeException("Invalid input" + cardsToBeDealt);
                }
                else
                    return cardsToBeDealt;
            }

            set
            {
                if (value != cardsToBeDealt)
                {
                    cardsToBeDealt = value;    //value is  for example: (in the client)    they assigned someVariable.CardsPerPlayer=3;     value is 3
                }
            }
        }

        //To be implemented
        public string TopDiscard => throw new NotImplementedException();


        IPlayer IDeck.NewPlayer()
        {
            //create new player, populates it with CardsPerPlayer cards

            IPlayer newPlayer = new Player(this);
            //players.Add(newPlayer);

            return newPlayer;
        }

        public override string ToString()
        {
            string deckInitialized = "";
            foreach (var cards in CardCountsInDeck)
            {
                deckInitialized += $"({cards.Key}{cards.Value}) ";
            }
            return deckInitialized;
        }
    }
}
