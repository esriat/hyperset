using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheGame.Model
{
    public class Deck
    {
        private List<Card> theCards = new List<Card>();
        public List<Card> Cards
        {
            get { return theCards; }
            set { theCards = value; }
        }

        public Deck GetAndRemoveRange(int beginning, int end)
        {
            if(beginning < 0 || end > Size())
            {
                throw new ArgumentException("Nombres invalides");
            }
            Deck toReturn = new Deck();
            toReturn.Cards = Cards.GetRange(beginning, end);
            Cards.RemoveRange(beginning, end);
            return toReturn;
        }

        public void AddCard(Card newCard)
        {
            theCards.Add(newCard);
        }

        public void AddCard(Card newCard, int index)
        {
            theCards.Insert(index, newCard);
        }

        public void RemoveCard(Card card)
        {
            theCards.Remove(card);
        }

        public int Size()
        {
            return theCards.Count;
        }

        public void Shuffle()
        {
            List<Card> newlist = new List<Card>();
            int count = theCards.Count;
            Random r = new Random();
            int randomIndex = 0;
            while (Size() > 0)
            {
                randomIndex = r.Next(0, count);
                newlist.Add(theCards[randomIndex]);
                theCards.RemoveAt(randomIndex);
                count--;
            }

            Cards = newlist;
        }
    }
}
