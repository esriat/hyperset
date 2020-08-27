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
    public partial class TutorialPageThree : Grid
    {
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        private TutorialPage tutorialPage;
        public TutorialPageThree(TutorialPage tutorialPage)
        {
            InitializeComponent();
            this.tutorialPage = tutorialPage;
            IOColor colors = IOColor.Instance;

            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            else
            {
                leavePageButton.TextColor = Xamarin.Forms.Color.Black;
                leavePagePreviousButton.TextColor = Xamarin.Forms.Color.Black;
            }
            leavePageButton.BackgroundColor = Xamarin.Forms.Color.Aqua;
            leavePageButton.Margin = 5;
            leavePageButton.CornerRadius = 10;
            leavePagePreviousButton.BackgroundColor = Xamarin.Forms.Color.Aqua;
            leavePagePreviousButton.Margin = 5;
            leavePagePreviousButton.CornerRadius = 10;
            leavePageButton.Text = Resources_fr.Next;
            leavePagePreviousButton.Text = Resources_fr.Previous;
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageThreePartOne, MainGrid.BackgroundColor), 0, 0);

            CardsGridOne.Children.Add(new UCCard(new Card(Shapes.Oval, Fills.Hatched, colors.Color2, 3)), 0, 0);
            CardsGridOne.Children.Add(new UCCard(new Card(Shapes.Oval, Fills.Empty, colors.Color2, 1)), 1, 0);
            CardsGridOne.Children.Add(new UCCard(new Card(Shapes.Oval, Fills.Filled, colors.Color2, 2)), 2, 0);
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageThreePartTwo, MainGrid.BackgroundColor), 0, 2);
            
            CardsGridTwo.Children.Add(new UCCard(new Card(Shapes.Diamond, Fills.Hatched, colors.Color1, 2)), 0, 0);
            CardsGridTwo.Children.Add(new UCCard(new Card(Shapes.Wave, Fills.Empty, colors.Color3, 2)), 1, 0);
            CardsGridTwo.Children.Add(new UCCard(new Card(Shapes.Diamond, Fills.Filled, colors.Color2, 2)), 2, 0);
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageThreePartThree, MainGrid.BackgroundColor), 0, 4);
        }

        private void leavePageButton_Clicked(object sender, EventArgs e)
        {
            tutorialPage.NextPage();
        }

        private void leavePagePreviousButton_Clicked(object sender, EventArgs e)
        {
            tutorialPage.PreviousPage();
        }
    }
}