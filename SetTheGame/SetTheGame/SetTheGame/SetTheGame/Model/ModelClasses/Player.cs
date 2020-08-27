using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheGame.Model
{
    public class Player : IComparable
    {
        public string Name { get; set; } = "";
        public int Points { get; set; } = 0;
        public int Time { get; set; } = 0;
        public float ScorePerMinute()
        {
            float nbMins = ((float)Time) / 60;
            return Points / nbMins;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Player toCompare = obj as Player;
            if (toCompare == null) throw new ArgumentException("Object is not a player");
            float i1 = ScorePerMinute();
            float i2 = toCompare.ScorePerMinute();
            if (i1 > i2)
            {
                return 1;
            }
            else if (i1 > i2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public void GainPoints()
        {
            Points++;
        }

        public void LosePoints()
        {
            if(Points > 0)
            {
                Points--;
            }
        }
    }
}
