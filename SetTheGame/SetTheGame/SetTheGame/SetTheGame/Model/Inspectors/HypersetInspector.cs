using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheGame.Model
{
    //Reverse algorithm : try reverse (for 81 cards, check if 2 sets on board)

    public class HypersetInspector : Inspector
    {
        private bool twoWithOne = false;
        private bool threeWithOne = false;
        private bool fourWithOne = false;
        public HypersetInspector() : base(4) { }

        public override bool IsCorrect(Deck set)
        {
            twoWithOne = true;
            threeWithOne = true;
            fourWithOne = true;
            return base.IsCorrect(set);
        }

        private bool IsCorrect(Card card0, Card card1, Card card2, Card card3)
        {
            twoWithOne = true;
            threeWithOne = true;
            fourWithOne = true;
            if (!CheckShape(card0, card1, card2, card3)) return false;
            if (!CheckFill(card0, card1, card2, card3)) return false;
            if (!CheckColor(card0, card1, card2, card3)) return false;
            if (!CheckNumber(card0, card1, card2, card3)) return false;
            return true;
        }

        public override Deck GetAnswer(Deck set)
        {
            if (set.Size() < NumberOfCardsInAnswer)
            {
                throw new ArgumentException("A deck must have at least " + NumberOfCardsInAnswer + " cards.");
            }
            set.Shuffle();
            int size = set.Size();
            for (int i = 0; i < size - 3; i++)
            {
                for (int j = i + 1; j < size - 2; j++)
                {
                    for (int k = j + 1; k < size - 1; k++)
                    {
                        for (int l = k + 1; l < size; l++)
                        {
                            if (IsCorrect(set.Cards[i], set.Cards[j], set.Cards[k], set.Cards[l]))
                            {
                                Deck toRet = new Deck();
                                toRet.AddCard(set.Cards[i]);
                                toRet.AddCard(set.Cards[j]);
                                toRet.AddCard(set.Cards[k]);
                                toRet.AddCard(set.Cards[l]);
                                return toRet;
                            }
                        }
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine(" CA A ECHOUE ALED ALED ALED ALED ALED ALED ALED ");
            return new Deck();
        }

        public override int NumberInDeck(Deck set)
        {
            if (set.Size() < NumberOfCardsInAnswer)
            {
                throw new ArgumentException("A deck must have at least " + NumberOfCardsInAnswer + " cards.");
            }
            int count = 0;
            int j;
            int k;
            int l;
            int size = set.Size();
            for (int i = 0; i < size - 3; i++)
            {
                for (j = i + 1; j < size - 2; j++)
                {
                    for (k = j + 1; k < size - 1; k++)
                    {
                        for (l = k + 1; l < size; l++)
                        {
                            if (IsCorrect(set.Cards[i], set.Cards[j], set.Cards[k], set.Cards[l]))
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }

        protected override bool CheckShape(Deck set)
        {
            return CheckShape(set.Cards[0], set.Cards[1], set.Cards[2], set.Cards[3]);
        }

        private bool CheckShape(Card card0, Card card1, Card card2, Card card3)
        {
            Shapes sh0 = card0.Shape, sh1 = card1.Shape, sh2 = card2.Shape, sh3 = card3.Shape;
            if (twoWithOne)
            {
                if (!CanCompleteShape(GetThirdShape(card0.Shape, card1.Shape), card2.Shape, card3.Shape))
                {
                    twoWithOne = false;
                }
            }
            if (threeWithOne)
            {
                if (!CanCompleteShape(GetThirdShape(card0.Shape, card2.Shape), card1.Shape, card3.Shape))
                {
                    threeWithOne = false;
                }
            }
            if (fourWithOne)
            {
                if (!CanCompleteShape(GetThirdShape(card0.Shape, card3.Shape), card1.Shape, card2.Shape))
                {
                    fourWithOne = false;
                }
            }
            bool check = GeneralCheck();
            System.Diagnostics.Debug.WriteLine("General check shape : " + check);
            return check;
        }

        private Shapes GetThirdShape(Shapes sh0, Shapes sh1)
        {
            if (sh0 == sh1)
            {
                System.Diagnostics.Debug.WriteLine("Shape : " + sh0);
                return sh0;
            }
            List<Shapes> shapes = new List<Shapes>();
            shapes.Add(Shapes.Diamond);
            shapes.Add(Shapes.Oval);
            shapes.Add(Shapes.Wave);
            shapes.Remove(sh0);
            shapes.Remove(sh1);
            return shapes[0];
        }

        private bool CanCompleteShape(Shapes toCheck, Shapes card0, Shapes card1)
        {
            if (card0 == card1)
            {
                return card0 == toCheck;
            }
            return ((card0 != toCheck) && (card1 != toCheck));
        }

        protected override bool CheckFill(Deck set)
        {
            return CheckFill(set.Cards[0], set.Cards[1], set.Cards[2], set.Cards[3]);
        }

        private bool CheckFill(Card card0, Card card1, Card card2, Card card3)
        {
            if (twoWithOne)
            {
                if (!CanCompleteFill(GetThirdFill(card0.Fill, card1.Fill), card2.Fill, card3.Fill))
                {
                    twoWithOne = false;
                }
            }
            if (threeWithOne)
            {
                if (!CanCompleteFill(GetThirdFill(card0.Fill, card2.Fill), card1.Fill, card3.Fill))
                {
                    threeWithOne = false;
                }
            }
            if (fourWithOne)
            {
                if (!CanCompleteFill(GetThirdFill(card0.Fill, card3.Fill), card1.Fill, card2.Fill))
                {
                    fourWithOne = false;
                }
            }
            bool check = GeneralCheck();
            System.Diagnostics.Debug.WriteLine("General check fill : " + check);
            return check;
        }

        private Fills GetThirdFill(Fills fi0, Fills fi1)
        {
            if (fi0 == fi1) return fi0;
            List<Fills> fills = new List<Fills>();
            fills.Add(Fills.Empty);
            fills.Add(Fills.Filled);
            fills.Add(Fills.Hatched);
            fills.Remove(fi0);
            fills.Remove(fi1);
            return fills[0];
        }

        private bool CanCompleteFill(Fills toCheck, Fills card0, Fills card1)
        {
            if (card0 == card1)
            {
                return card0 == toCheck;
            }
            return ((card0 != toCheck) && (card1 != toCheck));
        }

        protected override bool CheckColor(Deck set)
        {
            return CheckColor(set.Cards[0], set.Cards[1], set.Cards[2], set.Cards[3]);
        }

        private bool CheckColor(Card card0, Card card1, Card card2, Card card3)
        {
            if (twoWithOne)
            {
                if (!CanCompleteColor(GetThirdColor(card0.Color, card1.Color), card2.Color, card3.Color))
                {
                    twoWithOne = false;
                }
            }
            if (threeWithOne)
            {
                if (!CanCompleteColor(GetThirdColor(card0.Color, card2.Color), card1.Color, card3.Color))
                {
                    threeWithOne = false;
                }
            }
            if (fourWithOne)
            {
                if (!CanCompleteColor(GetThirdColor(card0.Color, card3.Color), card1.Color, card2.Color))
                {
                    fourWithOne = false;
                }
            }
            bool check = GeneralCheck();
            System.Diagnostics.Debug.WriteLine("General check color : " + check);
            return check;
        }

        private Color GetThirdColor(Color co0, Color co1)
        {
            if (co0 == co1) return co0;
            List<Color> colors = new List<Color>();
            IOColor ioColor = IOColor.Instance;
            colors.Add(ioColor.Color1);
            colors.Add(ioColor.Color2);
            colors.Add(ioColor.Color3);
            colors.Remove(co0);
            colors.Remove(co1);
            return colors[0];
        }

        private bool CanCompleteColor(Color toCheck, Color card0, Color card1)
        {
            if (card0.Equals(card1))
            {
                return card0.Equals(toCheck);
            }
            return ((card0 != toCheck) && (card1 != toCheck));
        }

        protected override bool CheckNumber(Deck set)
        {
            return CheckNumber(set.Cards[0], set.Cards[1], set.Cards[2], set.Cards[3]);
        }

        private bool CheckNumber(Card card0, Card card1, Card card2, Card card3)
        {
            if (twoWithOne)
            {
                if (!CanCompleteNumber(GetThirdNumber(card0.Number, card1.Number), card2.Number, card3.Number))
                {
                    twoWithOne = false;
                }
            }
            if (threeWithOne)
            {
                if (!CanCompleteNumber(GetThirdNumber(card0.Number, card2.Number), card1.Number, card3.Number))
                {
                    threeWithOne = false;
                }
            }
            if (fourWithOne)
            {
                if (!CanCompleteNumber(GetThirdNumber(card0.Number, card3.Number), card1.Number, card2.Number))
                {
                    fourWithOne = false;
                }
            }
            bool check = GeneralCheck();
            System.Diagnostics.Debug.WriteLine("General check number : " + check);
            return check;
        }

        private int GetThirdNumber(int i0, int i1)
        {
            if (i0 == i1) return i0;
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Remove(i0);
            numbers.Remove(i1);
            return numbers[0];
        }

        private bool CanCompleteNumber(int toCheck, int card0, int card1)
        {
            if (card0 == card1)
            {
                return card0 == toCheck;
            }
            return ((card0 != toCheck) && (card1 != toCheck));
        }

        private bool GeneralCheck()
        {
            return twoWithOne || threeWithOne || fourWithOne;
        }
    }
}