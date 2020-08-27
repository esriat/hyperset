using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheGame.Model.Managers
{
    public class HypersetMultiGameManager : AbstractMultiGameManager
    {
        public HypersetMultiGameManager(List<Player> players) : base(players)
        {
            inspector = new HypersetInspector();
            NumberOfCardsInAnswer = 4;
        }

        public override bool GetOneCard()
        {
            throw new Exception("Utilisation non autorisée");
        }

        public override bool HasToEnd()
        {
            return remaining.Size() < NumberOfCardsInAnswer;
        }

        public override void StartGame()
        {
            onBoard = remaining.GetAndRemoveRange(0, DesiredNumberOfCards);
        }

        public override List<Player> EndGame()
        {
            //if (!begginerModeEnabled)
            if (true)
            {
                LeaderboardsManager lb = new LeaderboardsManager();
                foreach (Player p in players)
                {
                    lb.AddScore(GameModes.Hyperset, p);
                }
                lb.Save();
            }
            return players;
        }
    }
}