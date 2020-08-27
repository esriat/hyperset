using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SetTheGame.Resources;
using SetTheGame.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame.TutorialPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HypersetTutorialPageTwo : Grid
    {
        private Card ghostCard;
        private TutorialPage tutorialPage;
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        public HypersetTutorialPageTwo(TutorialPage tutorialPage)
        {
            InitializeComponent();
            this.tutorialPage = tutorialPage;

            IOColor colors = IOColor.Instance;
            Card c0 = new Card(Shapes.Oval, Fills.Empty, colors.Color1, 1);
            Card c1 = new Card(Shapes.Diamond, Fills.Hatched, colors.Color3, 2);
            Card c2 = new Card(Shapes.Diamond, Fills.Filled, colors.Color2, 3);
            Card c3 = new Card(Shapes.Oval, Fills.Hatched, colors.Color3, 2);
            ghostCard = new Card(Shapes.Wave, Fills.Hatched, colors.Color3, 2);

            leavePagePreviousButton.Text = Resources_fr.Previous;
            NextPageButton.Text = Resources_fr.Next;
            ShowCardButton.Text = Resources_fr.ShowCard;

            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageTwoPartOne, MainGrid.BackgroundColor));
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageTwoPartTwo, MainGrid.BackgroundColor), 0, 2);
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageTwoPartThree, MainGrid.BackgroundColor), 0, 4);

            CardsGridOne.Children.Add(new UCCard(c0), 0, 0);
            CardsGridOne.Children.Add(new UCCard(c1), 1, 0);
            CardsGridOne.Children.Add(new UCCard(c2), 2, 0);
            CardsGridOne.Children.Add(new UCCard(c3), 3, 0);

            CardsGridLeft.Children.Add(new UCCard(c0), 0, 0);
            CardsGridLeft.Children.Add(new UCCard(c2), 0, 1);
                
            CardsGridRight.Children.Add(new UCCard(c1), 0, 0);
            CardsGridRight.Children.Add(new UCCard(c3), 0, 1);
        }

        private void leavePageButton_Clicked(object sender, EventArgs e)
        {
            tutorialPage.NextPage();
        }

        private void leavePagePreviousButton_Clicked(object sender, EventArgs e)
        {
            tutorialPage.PreviousPage();
        }

        private void ShowCardButton_Clicked(object sender, EventArgs e)
        {
            CardsGridTwo.Children.Add(new UCCard(ghostCard), 1, 0);
        }
    }
}