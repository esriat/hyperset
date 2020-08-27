using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheGame.Model
{
    class SetMultiGameManager : AbstractMultiGameManager
    {
        public SetMultiGameManager(List<Player> players): base(players)
        {
            inspector = new SetInspector();
            NumberOfCardsInAnswer = 3;
        }

        public override bool GetOneCard()
        {
            if (remaining.Size() < 0)
            {
                throw new Exception("No more cards available");
            }
            if(NumberOfAnswers() == 0)
            {
                Card c = remaining.GetAndRemoveRange(0, 1).Cards[0];
                lastUpdated.AddCard(c);
                onBoard.AddCard(c);
                return false;
            }
            return true;
        }

        public override bool HasToEnd()
        {
            return ((remaining.Size() == 0) && (onBoard.Size() == DesiredNumberOfCards));
        }

        public override void StartGame()
        {
            onBoard = remaining.GetAndRemoveRange(0, DesiredNumberOfCards);
            while (inspector.NumberInDeck(onBoard) == 0)
            {
                foreach (Card c in onBoard.Cards)
                {
                    remaining.AddCard(c);
                }
                onBoard.Cards.Clear();
                onBoard = remaining.GetAndRemoveRange(0, DesiredNumberOfCards);
            }
        }

        public override List<Player> EndGame()
        {
            //if (!begginerModeEnabled)
            if (true)
            {
                LeaderboardsManager lb = new LeaderboardsManager();
                foreach (Player p in players)
                {
                    lb.AddScore(GameModes.Set, p);
                }
                lb.Save();
            }
            return players;
        }
    }
}
