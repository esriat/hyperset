using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SetTheGame.Model
{
    public class Leaderboard
    {
        private const int MaximumNumberOfScores = 10;
        public List<Player> Players { get; set; } = new List<Player>();
        public void AddScore(Player player)
        {
            int i = GetPlaceInLeaderboard(player);
            if (i == -2)
            {
                Players.Add(player);
            }
            else
            {
                Players.Insert(i, player);
                if(Players.Count > MaximumNumberOfScores)
                {
                    Players.RemoveAt(MaximumNumberOfScores);
                }
            }
        }

        private int GetPlaceInLeaderboard(Player player)
        {
            if (Players.Count == 0) return -2;
            foreach(Player p in Players)
            {
                if(p.ScorePerMinute() < player.ScorePerMinute())
                {
                    return Players.IndexOf(p);
                }
            }
            return Players.Count;
        }
    }
}
