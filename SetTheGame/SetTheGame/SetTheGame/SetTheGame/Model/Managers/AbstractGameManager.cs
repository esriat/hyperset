using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheGame.Model
{
    public abstract class AbstractGameManager
    {
        protected Deck remaining;
        protected Deck onBoard;
        protected Deck lastUpdated;
        protected Deck discarded;
        protected Inspector inspector;
        public int NumberOfCardsInAnswer { get; protected set; }
        public int DesiredNumberOfCards { get; protected set; }

        public AbstractGameManager()
        {
            remaining = Stub.Stub.GetFullDeck();
            onBoard = new Deck();
            discarded = new Deck();
            lastUpdated = new Deck();
            DesiredNumberOfCards = 12;
        }

        public abstract void StartGame();
        public abstract bool HasToEnd();
        public abstract List<Player> EndGame();
        public virtual int TotalNumberOfAnswers()
        {
            Deck all = new Deck();
            foreach (Card c in remaining.Cards)
            {
                all.AddCard(c);
            }
            foreach (Card c in onBoard.Cards)
            {
                all.AddCard(c);
            }
            return inspector.NumberInDeck(all);
        }
        public abstract bool GetOneCard();

        public int NumberOfAnswers()
        {
            return inspector.NumberInDeck(onBoard);
        }
        public Deck GetOnBoard()
        {
            return onBoard;
        }
        public virtual Deck GetAnswer()
        {
            return inspector.GetAnswer(onBoard);
        }
        public Deck GetUpdated()
        {
            Deck toReturn = new Deck();
            foreach (Card c in lastUpdated.Cards)
            {
                toReturn.AddCard(c);
            }
            lastUpdated.Cards.Clear();
            return toReturn;
        }

        public virtual void RemakeDeck()
        {
            remaining = discarded;
            remaining.Shuffle();
            discarded = new Deck();
        }
    }
}
