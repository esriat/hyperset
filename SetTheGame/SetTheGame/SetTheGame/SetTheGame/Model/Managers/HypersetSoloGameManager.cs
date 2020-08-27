using SetTheGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheGame.Model
{
    public class HypersetSoloGameManager : AbstractSoloGameManager
    {
        public HypersetSoloGameManager() : base()
        {
            inspector = new HypersetInspector();
            NumberOfCardsInAnswer = 4;
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
            List<Player> joueurs = new List<Player>();
            joueurs.Add(player);
            if (!begginerModeEnabled)
            {
                LeaderboardsManager lb = new LeaderboardsManager();
                lb.AddScore(GameModes.Hyperset, player);
                lb.Save();
            }
            return joueurs;
        }

        public override bool GetOneCard()
        {
            throw new Exception("Utilisation non autorisée");
        }
    }
}
