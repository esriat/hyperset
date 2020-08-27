using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheGame.Model
{
    public abstract class Inspector
    {
        public int NumberOfCardsInAnswer { get; private set; }
        public Inspector(int newNumber)
        {
            NumberOfCardsInAnswer = newNumber;
        }

        public virtual bool IsCorrect(Deck set)
        {
            if (set.Size() != NumberOfCardsInAnswer)
            {
                throw new ArgumentException("An answer must have exactly " + NumberOfCardsInAnswer + " cards.");
            }
            if (!CheckShape(set)) return false;
            if (!CheckFill(set)) return false;
            if (!CheckColor(set)) return false;
            if (!CheckNumber(set)) return false;
            return true;
        }
        public abstract int NumberInDeck(Deck set);
        public abstract Deck GetAnswer(Deck set);
        protected abstract bool CheckShape(Deck set);
        protected abstract bool CheckFill(Deck set);
        protected abstract bool CheckColor(Deck set);
        protected abstract bool CheckNumber(Deck set);
    }
}
