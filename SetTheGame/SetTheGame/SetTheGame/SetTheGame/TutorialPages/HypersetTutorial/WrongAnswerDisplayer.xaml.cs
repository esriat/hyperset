using SetTheGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SetTheGame.Resources;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame.TutorialPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WrongAnswerDisplayer : Grid
    {
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        public WrongAnswerDisplayer(List<Card> cards, Label labelToShow)
        {
            InitializeComponent();
            MainGrid.Children.Add(new UCCard(cards[0]), 0, 1);
            MainGrid.Children.Add(new UCCard(cards[1]), 0, 2);
            MainGrid.Children.Add(new UCCard(cards[2]), 2, 1);
            MainGrid.Children.Add(new UCCard(cards[3]), 2, 2);

            MainGrid.Children.Add(new UCCard(cards[0]), 0, 4);
            MainGrid.Children.Add(new UCCard(cards[2]), 0, 5);
            MainGrid.Children.Add(new UCCard(cards[1]), 2, 4);
            MainGrid.Children.Add(new UCCard(cards[3]), 2, 5);

            MainGrid.Children.Add(new UCCard(cards[0]), 0, 7);
            MainGrid.Children.Add(new UCCard(cards[3]), 0, 8);
            MainGrid.Children.Add(new UCCard(cards[1]), 2, 7);
            MainGrid.Children.Add(new UCCard(cards[2]), 2, 8);

            MainGrid.Children.Add(labelToShow, 0, 3, 9, 10);

            Label lab = Stylizer.GetStyledLabel("✘", MainGrid.BackgroundColor);
            lab.FontSize = 60;
            lab.TextColor = Xamarin.Forms.Color.Red;
            
            Label lab1 = Stylizer.GetStyledLabel("✘", MainGrid.BackgroundColor);
            lab1.FontSize = 60;
            lab1.TextColor = Xamarin.Forms.Color.Red;

            Label lab2 = Stylizer.GetStyledLabel("✘", MainGrid.BackgroundColor);
            lab2.FontSize = 60;
            lab2.TextColor = Xamarin.Forms.Color.Red;

            MainGrid.Children.Add(lab, 1, 2, 1, 3);
            MainGrid.Children.Add(lab1, 1, 2, 4, 6);
            MainGrid.Children.Add(lab2, 1, 2, 7, 9);
        }
    }
}