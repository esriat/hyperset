using SetTheGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheGame.Stub
{
    class Stub
    {
        public static Deck GetTestSet()
        {
            Deck toReturn = new Deck();
            toReturn.AddCard(new Card(Shapes.Oval, Fills.Empty, GetGreenColor(), 1));
            toReturn.AddCard(new Card(Shapes.Oval, Fills.Empty, GetGreenColor(), 2));
            toReturn.AddCard(new Card(Shapes.Oval, Fills.Empty, GetGreenColor(), 3));
            toReturn.AddCard(new Card(Shapes.Wave, Fills.Empty, GetPurpleColor(), 3));
            toReturn.AddCard(new Card(Shapes.Diamond, Fills.Empty, GetRedColor(), 3));
            return toReturn;
        }

        public static Deck GetNotFullDeck()
        {
            IOColor io = IOColor.Instance;
            Deck toReturn = new Deck();
            foreach (Shapes sh in (Shapes[])Enum.GetValues(typeof(Shapes)))
            {
                foreach (Fills fi in (Fills[])Enum.GetValues(typeof(Fills)))
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        toReturn.AddCard(new Card(sh, fi, io.Color1, i));
                        toReturn.AddCard(new Card(sh, fi, io.Color2, i));
                        toReturn.AddCard(new Card(sh, fi, io.Color3, i));
                    }
                }
            }
            toReturn.Shuffle();
            for(int i = 0; i < 30; i++)
            {
                toReturn.RemoveCard(toReturn.Cards[i]);
            }
            return toReturn;
        }

        public static Deck GetTestHyperSet()
        {
            Deck all = GetFullDeck();
            all.Shuffle();
            Deck toReturn = new Deck();
            toReturn.AddCard(all.Cards[0]);
            toReturn.AddCard(all.Cards[1]);
            toReturn.AddCard(all.Cards[2]);
            toReturn.AddCard(all.Cards[3]);
            System.Diagnostics.Debug.WriteLine("Card : " + toReturn.Cards[0]);
            System.Diagnostics.Debug.WriteLine("Card : " + toReturn.Cards[1]);
            System.Diagnostics.Debug.WriteLine("Card : " + toReturn.Cards[2]);
            System.Diagnostics.Debug.WriteLine("Card : " + toReturn.Cards[3]);
            return toReturn;
        }

        public static Deck GetFullDeck()
        {
            IOColor io = IOColor.Instance;
            Deck toReturn = new Deck();
            foreach (Shapes sh in (Shapes[])Enum.GetValues(typeof(Shapes)))
            {
                foreach (Fills fi in (Fills[])Enum.GetValues(typeof(Fills)))
                {
                    for(int i = 1; i <= 3; i++)
                    {
                        toReturn.AddCard(new Card(sh, fi, io.Color1, i));
                        toReturn.AddCard(new Card(sh, fi, io.Color2, i));
                        toReturn.AddCard(new Card(sh, fi, io.Color3, i));
                    }
                }
            }
            toReturn.Shuffle();
            return toReturn;
        }

        public static Deck GetEmptyDeck()
        {
            return new Deck();
        }

        public static Color GetGreenColor()
        {
            Color green = new Color();
            green.SetGreen();
            return green;
        }

        public static Color GetPurpleColor()
        {
            Color purple = new Color();
            purple.SetBlue();
            return purple;
        }

        public static Color GetRedColor()
        {
            Color red = new Color();
            red.SetRed();
            return red;
        }

        public static List<Player> GetResults()
        {
            List<Player> toRet = new List<Player>();
            Player toAdd = new Player();
            Random rnd = new Random();
            int score = rnd.Next(5, 20);
            for(int i = 0; i<score; i++)
            {
                toAdd.GainPoints();
            }
            toRet.Add(toAdd);
            return toRet;
        }

        public static Leaderboard GetLeaderboard()
        {
            Leaderboard lb = new Leaderboard();
            lb.AddScore(new Player()
            {
                Name = "Paul",
                Points = 10,
                Time = 120
            });
            lb.AddScore(new Player()
            {
                Name = "Titouan",
                Points = 101,
                Time = 180
            });
            lb.AddScore(new Player()
            {
                Name = "Trofor",
                Points = 3,
                Time = 60
            });
            return lb;
        }
    }
}
