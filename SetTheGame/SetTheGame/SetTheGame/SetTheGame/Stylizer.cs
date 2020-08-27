using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SetTheGame
{
    public class Stylizer
    {
        public static Label GetStyledLabel(string text, Xamarin.Forms.Color backgroundColor)
        {
            Label lab = new Label();
            lab.Text = text;
            lab.HorizontalTextAlignment = TextAlignment.Center;
            lab.VerticalTextAlignment = TextAlignment.Center;
            if (backgroundColor == Xamarin.Forms.Color.Black)
            {
                lab.TextColor = Xamarin.Forms.Color.White;
            }
            return lab;
        }
    }
}
