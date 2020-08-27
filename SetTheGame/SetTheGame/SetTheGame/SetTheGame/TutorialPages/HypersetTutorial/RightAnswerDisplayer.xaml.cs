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
    public partial class RightAnswerDisplayer : Grid
    {
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        public RightAnswerDisplayer(Label firstLabel, List<Card> cards, Label secondLabel)
        {
            InitializeComponent();
            MainGrid.Children.Add(firstLabel);
            MainGrid.Children.Add(secondLabel, 0, 2);

            CardsGrid.Children.Add(new UCCard(cards[0]));
            CardsGrid.Children.Add(new UCCard(cards[1]), 0, 1);
            CardsGrid.Children.Add(new UCCard(cards[2]), 2, 0);
            CardsGrid.Children.Add(new UCCard(cards[3]), 2, 1);
            CardsGrid.Children.Add(new UCCard(cards[4]), 1, 2, 0, 2);
        }
    }
}