using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SetTheGame.Model
{
    class SetInspector : Inspector
    {
        public SetInspector() : base(3) { }

        private bool IsCorrect(Card card0, Card card1, Card card2)
        {
            if (!CheckShape(card0, card1, card2)) return false;
            if (!CheckFill(card0, card1, card2)) return false;
            if (!CheckColor(card0, card1, card2)) return false;
            if (!CheckNumber(card0, card1, card2)) return false;
            return true;
        }

        override public int NumberInDeck(Deck set)
        {
            if (set.Size() < NumberOfCardsInAnswer)
            {
                throw new ArgumentException("A deck must have at least " + NumberOfCardsInAnswer + " cards.");
            }
            int count = 0;
            int j;
            int k;
            int size = set.Size();
            for (int i = 0; i < size - 2; i++)
            {
                for (j = i + 1; j < size - 1; j++)
                {
                    for (k = j + 1; k < size; k++)
                    {
                        if (IsCorrect(set.Cards[i], set.Cards[j], set.Cards[k]))
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        protected override bool CheckShape(Deck set)
        {
            return CheckShape(set.Cards[0], set.Cards[1], set.Cards[2]);
        }

        private bool CheckShape(Card card0, Card card1, Card card2)
        {
            Shapes sh = card0.Shape;
            if (card1.Shape == sh)
            {
                return card2.Shape == sh;
            }
            else
            {
                Shapes sh2 = card1.Shape;
                Shapes sh3 = card2.Shape;
                return ((sh != sh3) && (sh2 != sh3));
            }
        }

        protected override bool CheckFill(Deck set)
        {
            return CheckFill(set.Cards[0], set.Cards[1], set.Cards[2]);
        }

        private bool CheckFill(Card card0, Card card1, Card card2)
        {
            Fills fi = card0.Fill;
            if (card1.Fill == fi)
            {
                return card2.Fill == fi;
            }
            else
            {
                Fills fi2 = card1.Fill;
                Fills fi3 = card2.Fill;
                return ((fi != fi3) && (fi2 != fi3));
            }
        }

        protected override bool CheckColor(Deck set)
        {
            return CheckColor(set.Cards[0], set.Cards[1], set.Cards[2]);
        }

        private bool CheckColor(Card card0, Card card1, Card card2)
        {
            Color co = card0.Color;
            if (card1.Color.Equals(co))
            {
                return card2.Color.Equals(co);
            }
            else
            {
                Color co2 = card1.Color;
                Color co3 = card2.Color;
                return ((!(co.Equals(co3))) && (!(co2.Equals(co3))));
            }
        }

        protected override bool CheckNumber(Deck set)
        {
            return CheckNumber(set.Cards[0], set.Cards[1], set.Cards[2]);
        }

        private bool CheckNumber(Card card0, Card card1, Card card2)
        {
            int nu = card0.Number;
            if (card1.Number == nu)
            {
                return card2.Number == nu;
            }
            else
            {
                int nu2 = card1.Number;
                int nu3 = card2.Number;
                return ((nu != nu3) && (nu2 != nu3));
            }
        }

        public override Deck GetAnswer(Deck set)
        {
            if (set.Size() < NumberOfCardsInAnswer)
            {
                throw new ArgumentException("A deck must have at least 3 cards.");
            }
            set.Shuffle();
            int size = set.Size();
            for (int i = 0; i < size - 2; i++)
            {
                for (int j = i + 1; j < size - 1; j++)
                {
                    for (int k = j + 1; k < size; k++)
                    {
                        if (IsCorrect(set.Cards[i], set.Cards[j], set.Cards[k]))
                        {
                            Deck toRet = new Deck();
                            toRet.AddCard(set.Cards[i]);
                            toRet.AddCard(set.Cards[j]);
                            toRet.AddCard(set.Cards[k]);
                            return toRet;
                        }
                    }
                }
            }
            return new Deck();
        }
    }
}
