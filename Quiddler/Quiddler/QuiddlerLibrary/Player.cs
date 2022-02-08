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
        
        private List<string> Cards = new List<string>();
        private Deck GameDeck = null;

        // constructor - initializes deck so it can be call it can access it's members
        public Player(Deck d)
        {
            GameDeck = d;
            TotalPoints = 0;
        }

        // implement the IPlayer interface

        public int CardCount => Cards.Count;

        public int TotalPoints { get; set; }  // setter is not in IPlayer interface but is needed in class to increment the player's points


        // takes the string value of the card the player wants to discard, removes it from their hand and puts it in the discard pile, returns true if card is successfully discarded.
        public bool Discard(string card)
        {
            if (Cards.Contains(card))
            {
                Cards.Remove(card);
                GameDeck.DiscardedCards.Push(card);

                return true;
            }
            return false;
        }

        // draws a card from the deck and adds it to the player's hand, returns the string value of that card
        public string DrawCard()
        {
            if (GameDeck.CardCount == 0) // deck is empty
                throw new InvalidOperationException("The deck is out of cards!");

            Random random = new Random();
            int index;

            do
            {
                index = random.Next(GameDeck.CardsInDeck.Count - 1);  //index of random card picked

            } while (GameDeck.CardsInDeck.ElementAt(index).Value == 0);

            Cards.Add(GameDeck.CardsInDeck.ElementAt(index).Key); // add the card to player's hand
            GameDeck.CardsInDeck[GameDeck.CardsInDeck.ElementAt(index).Key] = GameDeck.CardsInDeck.ElementAt(index).Value - 1;  // decrease the number of that specific card when it's removed from deck

            return Cards[CardCount - 1];
        }

        public string PickupTopDiscard()
        {
            Cards.Add(GameDeck.TopDiscard);
            GameDeck.DiscardedCards.Pop();

            return Cards[CardCount - 1];
        }


        // tests the word and if it returns a point value over 0, removes the cards from player's hand, adds the point value to their total and returns the word's point value.
        public int PlayWord(string candidate)
        {
            int points = TestWord(candidate);

            if (points > 0)
            {
                string[] wordArray = candidate.Split(' ');

                foreach (var w in wordArray) // discard the cards used in word
                    Discard(w);

                TotalPoints += points;
            }
            return points;
        }

        // tests a string value to see if it is a valid word and returns the point values it's worth or 0 if it's not valid
        public int TestWord(string candidate)
        {
            if (candidate.Length > 0)
            {
                candidate = candidate.ToLower();

                string[] wordArray = candidate.Split(' ');

                if (wordArray.Length < CardCount) // makes sure there's at least 1 card left over in player's hand to discard
                {
                    string wordNoSpace = "";
                    int points = 0;

                    foreach (var w in wordArray)
                    {
                        if (!Cards.Contains(w)) // makes sure card is in player's hand
                            return 0;

                        wordNoSpace += w;
                        var cardPoints = GameDeck.CardPointValues.FirstOrDefault(c => c.Key == w); // look up the card's point value
                        points += cardPoints.Value;
                    }
                    
                    if (GameDeck.app.CheckSpelling(wordNoSpace)) // if word is valid 
                        return points;
                }                                
            }
            return 0;
        }

        // returns a string representation of the cards in the player's hand
        public override string ToString()
        {
            string cardsDisplay = "";

            foreach (var c in Cards)
                cardsDisplay += c + " ";
            
            cardsDisplay = cardsDisplay.Trim(); // removes last space

            return cardsDisplay;
        }

    }
}
