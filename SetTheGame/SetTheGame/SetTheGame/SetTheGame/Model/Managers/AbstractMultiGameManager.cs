using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SetTheGame.Model
{
    public abstract class AbstractMultiGameManager : AbstractGameManager
    {
        protected List<Player> players = new List<Player>();

        public AbstractMultiGameManager(List<Player> players) : base()
        {
            this.players = players;
        }

        public bool TryAnswer(Deck answer, Player player)
        {
            lastUpdated.Cards.Clear();
            int j = 0;
            if (inspector.IsCorrect(answer))
            {
                player.GainPoints();
                foreach (Card card in answer.Cards)
                {
                    onBoard.RemoveCard(card);
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
                return false;
            }
        }

        public void SetPlayerTimes(int counter)
        {
            foreach(Player p in players)
            {
                p.Time = counter;
            }
        }
    }
}