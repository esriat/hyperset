using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheGame.Model
{
    public class Card
    {
        public Shapes Shape { get; set; }
        public Fills Fill { get; set; }
        public Color Color { get; set; }
        public int Number { get; set; }
        
        public Card(Shapes newShape, Fills newFill, Color newColor, int newNumber)
        {
            Shape = newShape;
            Fill = newFill;
            Color = newColor;
            Number = newNumber;
        }

        public override bool Equals(object obj)
        {
            Card toCheck = obj as Card;
            if (toCheck == null) return false;
            if (toCheck.Shape != this.Shape) return false;
            if (toCheck.Fill != this.Fill) return false;
            if (toCheck.Color != this.Color) return false;
            if (toCheck.Number != this.Number) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string message = "Shape : ";
            message += Shape;
            message += "; Fill : ";
            message += Fill;
            message += "; Color : ";
            message += Color.ToString();
            message += "; Number : ";
            message += Number;
            return message;
        }
    }
}
