using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SetTheGame.Model
{
    public class Color
    {
        private const int MIN_BORDER = 0;
        private const int MAX_BORDER = 255;

        private int red;
        public int Red { 
            get 
            {
                return red;
            }
            set
            {
                if (value < MIN_BORDER || value > MAX_BORDER)
                {
                    throw new ArgumentException("Out of border");
                }
                red = value;
            }
        }
        
        private int green;
        public int Green
        {
            get
            {
                return green;
            }
            set
            {
                if(value < MIN_BORDER || value > MAX_BORDER)
                {
                    throw new ArgumentException("Out of border");
                }
                green = value;
            }
        }
        
        private int blue;
        public int Blue
        {
            get
            {
                return blue;
            }
            set
            {
                if (value < MIN_BORDER || value > MAX_BORDER)
                {
                    throw new ArgumentException("Out of border");
                }
                blue = value;
            }
        }

        public Color()
        {

        }

        public Color(int newRed, int newGreen, int newBlue)
        {
            Red = newRed;
            Green = newGreen;
            Blue = newBlue;
        }

        public void SetBlue()
        {
            Red = 0;
            Green = 147;
            Blue = 255;
        }

        public void SetGreen()
        {
            Red = 66;
            Green = 232;
            Blue = 25;
        }

        public void SetRed()
        {
            Red = 255;
            Green = 35;
            Blue = 0;
        }

        public override bool Equals(object obj)
        {
            Color toCheck = obj as Color;
            if (toCheck == null) return false;
            if (toCheck.Red != this.Red) return false;
            if (toCheck.Green != this.Green) return false;
            if (toCheck.Blue != this.Blue) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string toRet = Red.ToString();
            toRet += "/";
            toRet += Green.ToString();
            toRet += "/";
            toRet += Blue.ToString();
            return toRet;
        }
    }
}
