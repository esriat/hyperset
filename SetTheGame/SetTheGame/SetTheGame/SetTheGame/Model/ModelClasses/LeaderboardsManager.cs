using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SetTheGame.Model
{
    [XmlRoot] 
    public class LeaderboardsManager
    {
        private Leaderboard SetLeaderboard { get; set; }
        private Leaderboard HyperSetLeaderboard { get; set; }
        
        public LeaderboardsManager()
        {
            SetLeaderboard = IOLeaderboard.ChargeLeaderboard(GameModes.Set);
            HyperSetLeaderboard = IOLeaderboard.ChargeLeaderboard(GameModes.Hyperset);
        }
        public void AddScore(GameModes mode, Player score)
        {
            if(mode == GameModes.Set)
            {
                SetLeaderboard.AddScore(score);
            }
            else
            {
                HyperSetLeaderboard.AddScore(score);
            }
        }

        public Leaderboard GetLeaderboard(GameModes mode)
        {
            switch (mode)
            {
                case GameModes.Set: return SetLeaderboard;
                default: return HyperSetLeaderboard;
            }
        }

        public void Save()
        {
            IOLeaderboard.SaveLeaderboard(SetLeaderboard, GameModes.Set);
            IOLeaderboard.SaveLeaderboard(HyperSetLeaderboard, GameModes.Hyperset);
        }
    }
}
