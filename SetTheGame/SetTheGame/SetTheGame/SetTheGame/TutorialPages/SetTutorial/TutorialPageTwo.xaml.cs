using SetTheGame.Model;
using SetTheGame.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame.TutorialPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorialPageTwo : Grid
    {
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        private TutorialPage tutorialPage;
        public TutorialPageTwo(TutorialPage tutorialPage)
        {
            InitializeComponent();
            this.tutorialPage = tutorialPage;

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
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageTwoPartOne, MainGrid.BackgroundColor), 0, 0);
            IOColor colors = IOColor.Instance;
            CardsGrid.Children.Add(new UCCard(new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 3)), 0, 0);
            CardsGrid.Children.Add(new UCCard(new Card(Shapes.Wave, Fills.Filled, colors.Color2, 1)), 1, 0);
            CardsGrid.Children.Add(new UCCard(new Card(Shapes.Wave, Fills.Empty, colors.Color3, 2)), 2, 0);
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageTwoPartTwo, MainGrid.BackgroundColor), 0, 2);
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