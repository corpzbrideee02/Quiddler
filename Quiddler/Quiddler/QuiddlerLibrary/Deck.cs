// Brittany Diesbourg & Dianne Corpuz - Section A

using System;
using System.Collections.Generic;
using System.Linq;

namespace QuiddlerLibrary
{
    public class Deck : IDeck
    {
        // Private member variables
        private int cardsToBeDealt = 0;
        public int undealtCards = 118;
        //private const int NumberOfCards = 118;
        //private string topDiscard = "";

        //c'tor 
        /*public Deck()
        {
            ShuffleCardsInDeck();
        }*/


        public string About => $"Test Client for: {GetType().Namespace}, Developers: Brittany Diesbourg and Dianne Corpuz";

        public Dictionary<string, int> CardsInDeck = new Dictionary<string, int>()
         {
                 {"a",10}, {"b",2},  {"c",2},{"d",4}, {"e",12},{"f",2},{"g",4}, {"h",2},{"i",8},  {"j",2},  {"k",2},  {"l",4}, {"m",2},{"n",6}, {"o",8},
                  {"p",2}, {"q",2},{"r",6},{"s",4},{"t",6},{"u",6}, {"v",2}, {"w",2}, {"x",2},  {"y",4}, {"z",2},  {"cl",2}, {"er",2}, {"in",2},{"qu",2}, {"th",2},
         };

        public Dictionary<string, int> CardPointValues = new Dictionary<string, int>()
         {
                 {"a",2}, {"b",8},  {"c",8},{"d",5}, {"e",2},{"f",6},{"g",6}, {"h",7},{"i",2},  {"j",13},  {"k",8},  {"l",3}, {"m",5},{"n",5}, {"o",2},
                  {"p",6}, {"q",15},{"r",5},{"s",3},{"t",3},{"u",4}, {"v",11}, {"w",10}, {"x",12},  {"y",4}, {"z",14},  {"cl",10}, {"er",7}, {"in",7},{"qu",9}, {"th",9},
         };


        //stack of discarded Cards
        public Stack<string> DiscardedCards = new Stack<string>();

        
        //implementation of IDeck Interface
        public int CardCount
        {
            get
            {   
                return undealtCards;
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
                    cardsToBeDealt = value; 
                }
            }
        }

        public string TopDiscard
        {
            get
            {
                if(DiscardedCards.Count==0)
                {
                    var random_ = new Random();
                    int index = random_.Next(CardsInDeck.Count());  //index of random picked items

                    string selectedTopDiscard = "";
                    if (CardsInDeck.ElementAt(index).Value > 0)
                    {
                        selectedTopDiscard = CardsInDeck.ElementAt(index).Key;
                        CardsInDeck[CardsInDeck.ElementAt(index).Key] = CardsInDeck.ElementAt(index).Value - 1;
                        DiscardedCards.Push(selectedTopDiscard);
                        --undealtCards;
                    }

                    return selectedTopDiscard;
                }

                --undealtCards;
               return DiscardedCards.Peek();
            }
        }

        IPlayer IDeck.NewPlayer()
        {
            //create new player, populates it with CardsPerPlayer cards
            IPlayer newPlayer = new Player(this);

            for (int i=0; i<CardsPerPlayer;++i)
            {
                newPlayer.DrawCard();
               // --undealtCards;
            }

            return newPlayer;
        }

        public override string ToString()
        {
            string deckDisplay = "";
            foreach (var cards in CardsInDeck)
            {
                //just to have a clear format
                deckDisplay += $"{cards.Key,2:G}({cards.Value,2:G}) ";
                if(cards.Key.Equals("l")|| cards.Key.Equals("x"))
                    deckDisplay += "\n";
            }
            return deckDisplay;
        }

        //*************************************NoTE: just added these methods...   *************************************

        public List<string> ShuffleCardsInDeck()
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
            return ShuffledCardsList;
        }

    }
}
