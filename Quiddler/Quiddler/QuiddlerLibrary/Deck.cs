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

        private int undealtCards=118;

        //c'tor 
        public Deck()
        {
            ShuffleCardsInDeck();
        }


        public string About => $"Test Client for: {GetType().Namespace}, Developers: Brittany Diesbourg and Dianne Corpuz";

        private Dictionary<string, int> CardsInDeck = new Dictionary<string, int>()
         {
                 {"a",Ten}, {"b",Two},  {"c",Two},{"d",Four}, {"e",Twelve},{"f",Two},{"g",Four}, {"h",Two},{"i",Eight},  {"j",Two},  {"k",Two},  {"l",Four}, {"m",Two},{"n",Six}, {"o",Eight},
                  {"p",Two}, {"q",Two},{"r",Six},{"s",Four},{"t",Six},{"u",Six}, {"v",Two}, {"w",Two}, {"x",Two},  {"y",Four}, {"z",Two},  {"cl",Two}, {"er",Two}, {"in",Two},{"qu",Two}, {"th",Two},
         };


        //stack discarded Cards
        private Stack<string> DiscardedCards = new Stack<string>();

        
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

        //if user wants the top discarded card, it will just gets it from the myStack(stack of discarded card)
        //if not, it will randomly gets the card from the CardsInDeck(Dictionary)
        public string TopDiscard
        {
            get
            {
                if(TopDiscard==null)
                {
                    var random_ = new Random();
                    int index = random_.Next(CardsInDeck.Count());  //index of random picked items

                    var itemsPicked = "";
                    if (CardsInDeck.ElementAt(index).Value > 0)
                    {

                        itemsPicked = CardsInDeck.ElementAt(index).Key;
                        CardsInDeck[CardsInDeck.ElementAt(index).Key] = CardsInDeck.ElementAt(index).Value - 1;
                        DiscardedCards.Push(itemsPicked);
                    }

                    --undealtCards;
                    return itemsPicked;
                }

                
                --undealtCards;
                return DiscardedCards.Pop();
                
            }
        }

        IPlayer IDeck.NewPlayer()
        {
            //create new player, populates it with CardsPerPlayer cards
            IPlayer newPlayer = new Player(this);

            for (int i=0; i<CardsPerPlayer;++i)
            {
                newPlayer.DrawCard();
                --undealtCards;
            }

            return newPlayer;
        }

        public override string ToString()
        {
            string deckInitialized = "";
            foreach (var cards in CardsInDeck)
            {
                deckInitialized += $"{cards.Key}({cards.Value}) ";
            }
            return deckInitialized;
        }



        //*************************************NoTE: just added these methods... Please disregard   *************************************

        public Dictionary<string, int> GetCardsInDeck()
        {
            return CardsInDeck;
        }


        private void ShuffleCardsInDeck()
        {
            List<string> ShuffledCardsList = new List<string>();
            foreach (var cards in CardsInDeck)
            {
                for (int i = 0; i < cards.Value; ++i)
                {
                    ShuffledCardsList.Add(cards.Key);
                }
            }

            ShuffledCardsList = ShuffledCardsList.OrderBy(item => Guid.NewGuid()).ToList();
        }

        //draw pile
        private Stack<string> DrawPile = new Stack<string>();

        //Pick a random card from the deck
        private string GetRandomCard()
        {
            var random_ = new Random();
            int index = random_.Next(CardsInDeck.Count());  //index of random picked items

            var itemsPicked = "";
            if (CardsInDeck.ElementAt(index).Value != 0)
            {
                itemsPicked = CardsInDeck.ElementAt(index).Key;
                CardsInDeck[CardsInDeck.ElementAt(index).Key] = CardsInDeck.ElementAt(index).Value - 1;
            }

            return itemsPicked;
        }



    }
}
