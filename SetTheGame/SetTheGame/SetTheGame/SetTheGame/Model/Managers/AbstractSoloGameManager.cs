using SetTheGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheGame.Model
{
    public abstract class AbstractSoloGameManager : AbstractGameManager
    {
        public Player player = new Player();
        protected bool begginerModeEnabled = false;

        public AbstractSoloGameManager() : base()
        {
        }
        public void SetPlayerName(string username)
        {
            player.Name = username;
        }
        public bool TryAnswer(Deck answer)
        {
            lastUpdated.Cards.Clear();
            int j = 0;
            if (inspector.IsCorrect(answer))
            {
                player.GainPoints();
                foreach (Card card in answer.Cards)
                {
                    onBoard.RemoveCard(card);
                    discarded.AddCard(card);
                }
                int nb = DesiredNumberOfCards - onBoard.Size();
                if (nb > 0)
                {
                    Deck toPut = remaining.GetAndRemoveRange(0, nb);
                    foreach (Card card in toPut.Cards)
                    {
                        onBoard.AddCard(card, j);
                        lastUpdated.AddCard(card);
                        j++;
                    }
                }
                return true;
            }
            else
            {
                if (!begginerModeEnabled)
                {
                    player.LosePoints();
                }
                return false;
            }
        }
        public int GetPlayerScore()
        {
            return player.Points;
        }

        public void EnableBegginerMode()
        {
            begginerModeEnabled = true;
        }
    }
}